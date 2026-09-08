/*
Q3. Composite Primary Key Junction Table
Create an enrollments table to model the many-to-many relationship between students and courses. It must have student_id and course_id as Foreign Keys, and together they should form a Composite Primary Key so a student cannot enroll in the same course twice. Also include enroll_date (DEFAULT to today) and grade (CHAR(2), nullable).
*/
CREATE TABLE enrollments (
    student_id INTEGER,
    course_id INTEGER,
    enroll_date DATE DEFAULT CURRENT_DATE,
    grade CHAR(2),
    
    PRIMARY KEY (student_id, course_id),
    
    CONSTRAINT fk_enroll_student 
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    
    CONSTRAINT fk_enroll_course 
    FOREIGN KEY (course_id) REFERENCES courses(course_id)
);

/*
Q4. Enforce a Valid Grade Range
Add a CHECK constraint on enrollments.grade so that only these values are allowed: 'A+', 'A', 'B+', 'B', 'C', 'F', or NULL (ungraded). Name the constraint explicitly.
*/
ALTER TABLE enrollments 
ADD CONSTRAINT chk_grade_range 
CHECK (grade IN ('A+', 'A', 'B+', 'B', 'C', 'F') OR grade IS NULL);

/*
Q7. UNIQUE Constraint with a Real-World Twist
Two students can legitimately share the same name, but no two students should share the same email address. Add a UNIQUE constraint on students.email. Then attempt to insert a student with an email that already exists, and note what PostgreSQL does.
*/
ALTER TABLE students 
ADD CONSTRAINT uk_student_email 
UNIQUE (email);

-- Test duplicate email insertion
-- INSERT INTO students (full_name, dob, email, cgpa, is_active, skills, profile, enrolled_at, dept_id) 
-- VALUES ('John Doe', '2000-01-01', 'ravi.singh@example.com', 8.0, TRUE, '{}', '{}', NOW(), 2);

/*
Q8. SET NULL on Optional Relationship
Suppose faculty advisors are tracked in a new advisors table (advisor_id PRIMARY KEY, advisor_name), and students.advisor_id is a Foreign Key to it — but a student without an assigned advisor is still valid. If an advisor leaves the college and their row is deleted, existing students should NOT be deleted, but their advisor_id should become NULL.
(a) Create the advisors table.
(b) Add advisor_id to students with the correct ON DELETE behavior.
(c) Test it: assign an advisor to a student, delete that advisor, and verify the student still exists with advisor_id now NULL.
*/
-- (a), (b), (c) — write all statements here:
CREATE TABLE advisors (
    advisor_id SERIAL PRIMARY KEY,
    advisor_name VARCHAR(100) NOT NULL
);

ALTER TABLE students 
ADD COLUMN advisor_id INTEGER;

ALTER TABLE students 
ADD CONSTRAINT fk_student_advisor 
FOREIGN KEY (advisor_id) REFERENCES advisors(advisor_id) ON DELETE SET NULL;

-- Test the functionality
INSERT INTO advisors (advisor_name) VALUES ('Dr. Smith');

UPDATE students 
SET advisor_id = 1 
WHERE full_name = 'Ravi Singh';  -- Will fail if student doesn't exist

-- Delete advisor and check if student keeps existing with NULL advisor_id
DELETE FROM advisors WHERE advisor_id = 1;
SELECT * FROM students WHERE advisor_id IS NULL;

/*
Q9. Composite Unique Constraint
The college wants to ensure that within courses, no two courses in the same department can share the exact same course_name (duplicate course names ARE allowed across different departments). Add a constraint on courses that enforces uniqueness on the combination of (dept_id, course_name), not on course_name alone.
*/
ALTER TABLE courses 
ADD CONSTRAINT uk_dept_course_name 
UNIQUE (dept_id, course_name);

/*
Q10. Debugging a Broken Insert
A junior developer ran the following statement and it failed. Diagnose why it failed based on the constraints you have built in this assignment, fix the underlying data or statement, and re-run it successfully. Document what was wrong.
INSERT INTO enrollments (student_id, course_id, grade)
VALUES (9999, 1, 'A+');
*/
-- This fails because student_id 9999 doesn't exist in students table
-- Fix: ensure student exists first
INSERT INTO students (full_name, dob, email, cgpa, is_active, skills, profile, enrolled_at, dept_id) 
VALUES ('Test Student', '2000-01-01', 'test@student.edu', 8.0, TRUE, '{}', '{}', NOW(), 1);

-- Now correctly insert into enrollments 
INSERT INTO enrollments (student_id, course_id, grade)
VALUES ((SELECT student_id FROM students WHERE full_name = 'Test Student'), 1, 'A+');

/*
Q11. CHECK Constraint with Multiple Conditions
Add a CHECK constraint to students that enforces: cgpa must be between 0 and 10 AND age (add this column if it doesn't exist, SMALLINT) must be at least 16. Use a single CHECK expression combining both conditions with AND.
*/
ALTER TABLE students 
ADD COLUMN age SMALLINT;

ALTER TABLE students 
ADD CONSTRAINT chk_student_age_cgpa 
CHECK (cgpa >= 0 AND cgpa <= 10 AND age >= 16);

/*
Q12. Self-Referencing Foreign Key
The college wants to track reporting structure among staff. Using (or creating) an employees table with columns emp_id (PRIMARY KEY) and manager_id, add a Foreign Key on manager_id that references emp_id in the SAME table (a self-referencing relationship), allowing manager_id to be NULL for the top-level employee (e.g., the Principal). Insert at least 3 employees forming a two-level reporting chain and prove the relationship with a SELECT that shows each employee next to their manager's name (a self-join).
*/
CREATE TABLE employees (
    emp_id SERIAL PRIMARY KEY,
    emp_name VARCHAR(100) NOT NULL,
    manager_id INTEGER,
    
    CONSTRAINT fk_employee_manager 
    FOREIGN KEY (manager_id) REFERENCES employees(emp_id)
);

-- Insert test employees
INSERT INTO employees (emp_name, manager_id) VALUES 
('Principal', NULL),
('Dean', 1),
('Manager', 2);

-- Self-join to show reporting structure
SELECT 
    e.emp_name AS Employee,
    m.emp_name AS Manager
FROM employees e
LEFT JOIN employees m ON e.manager_id = m.emp_id;