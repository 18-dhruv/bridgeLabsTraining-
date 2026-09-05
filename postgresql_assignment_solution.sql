/*
============================================================
PostgreSQL Assignment
Introduction to PostgreSQL, pgAdmin, Schema & Datatypes
============================================================

Source: Assignment "Introduction to PostgreSQL, pgAdmin, Schema & Datatypes"

IMPORTANT:
1. Run the CREATE DATABASE statements while connected to the default
   database (usually "postgres").
2. In pgAdmin, connect the Query Tool to college_db before running
   the college_db section.
3. Then connect the Query Tool to library_db before running the
   library_db section.
*/

-- ============================================================
-- SECTION A — CONCEPTUAL QUESTIONS
-- ============================================================

/*
Q1. What is PostgreSQL? List any four key features.

PostgreSQL is an open-source object-relational database management
system (ORDBMS) used to store, manage, and query structured data.

Four key features:
1. Open-source and highly extensible.
2. Supports advanced SQL and complex queries.
3. Supports rich data types such as JSONB, arrays, UUID, and ranges.
4. Provides strong ACID compliance, transactions, and concurrency control.


Q2. What are the five broad categories of SQL commands?

1. DDL (Data Definition Language)  -> CREATE
2. DML (Data Manipulation Language) -> INSERT
3. DQL (Data Query Language)        -> SELECT
4. DCL (Data Control Language)      -> GRANT
5. TCL (Transaction Control Language) -> COMMIT


Q3. What is pgAdmin used for?

pgAdmin is a graphical administration and development tool for
PostgreSQL.

Query Tool:
- Used to write and execute SQL queries.
- Used to create and modify database objects.
- Displays query results and execution messages.

Dashboard:
- Provides an overview of database/server activity.
- Can display information such as sessions, transactions,
  server activity, and resource usage.


Q4. What is a Schema in PostgreSQL? Why is the default schema called
'public'?

A schema is a logical namespace inside a database that contains
objects such as tables, views, functions, and sequences.

'public' is the default schema created in a PostgreSQL database and
is commonly available for objects unless another schema is selected.


Q5. CHAR(n) vs VARCHAR(n) vs TEXT

CHAR(n):
- Fixed-length character type.
- Values shorter than n are padded with spaces.

VARCHAR(n):
- Variable-length character type.
- Has a maximum length of n characters.

TEXT:
- Variable-length text with no declared maximum length.
- Useful when an application does not need a specific character limit.


Q6. TIMESTAMP vs TIMESTAMPTZ

TIMESTAMP:
- Stores a date and time without time-zone information.

TIMESTAMPTZ:
- PostgreSQL's timestamp-with-time-zone type.
- Represents an instant in time and converts its display according
  to the session time zone.


Q7. What is SERIAL? What does it internally create?

SERIAL is PostgreSQL shorthand for an integer column whose value is
automatically generated from a sequence.

It effectively creates:
- An integer column
- A sequence
- A DEFAULT expression that obtains the next value from that sequence

SERIAL is not a true standalone data type.
*/


-- ============================================================
-- SECTION B — HANDS-ON pgAdmin PRACTICE
-- TASK 1 — SERVER & DATABASE SETUP
-- ============================================================

-- Run these while connected to the default "postgres" database.

CREATE DATABASE college_db;

CREATE DATABASE library_db;


-- ============================================================
-- COLLEGE DATABASE
-- ============================================================
-- After creating college_db, connect pgAdmin Query Tool to
-- college_db and run the following statements.
-- ============================================================


-- TASK 2 — SCHEMA CREATION

CREATE SCHEMA academics;

CREATE SCHEMA admin;


-- List all schemas in college_db using information_schema.schemata

SELECT
    schema_name
FROM information_schema.schemata
ORDER BY schema_name;


-- TASK 3 — CREATE academics.students

CREATE TABLE academics.students
(
    student_id  SERIAL PRIMARY KEY,
    full_name   VARCHAR(100) NOT NULL,
    dob         DATE,
    email       TEXT,
    cgpa        NUMERIC(3,2),
    is_active   BOOLEAN DEFAULT TRUE,
    skills      TEXT[],
    profile     JSONB,
    enrolled_at TIMESTAMPTZ DEFAULT NOW()
);


-- TASK 4 — VERIFY students TABLE COLUMNS AND DATA TYPES

SELECT
    column_name,
    data_type
FROM information_schema.columns
WHERE table_schema = 'academics'
  AND table_name = 'students'
ORDER BY ordinal_position;


-- Optional: display additional column details for verification.

SELECT
    column_name,
    data_type,
    udt_name,
    is_nullable,
    column_default
FROM information_schema.columns
WHERE table_schema = 'academics'
  AND table_name = 'students'
ORDER BY ordinal_position;


-- ============================================================
-- SECTION C — CHALLENGE EXERCISE
-- LIBRARY DATABASE
-- ============================================================
-- Connect pgAdmin Query Tool to library_db before running this
-- section.
-- ============================================================

-- Create schema

CREATE SCHEMA catalog;


-- Create catalog.books
--
-- Sensible data types selected according to the assignment:
-- book_id       -> SERIAL
-- title         -> VARCHAR(255)
-- author        -> VARCHAR(150)
-- isbn          -> VARCHAR(20)
-- price         -> NUMERIC(10,2)
-- published_date-> DATE
-- is_available  -> BOOLEAN
-- extra_info    -> JSONB

CREATE TABLE catalog.books
(
    book_id        SERIAL PRIMARY KEY,
    title          VARCHAR(255) NOT NULL,
    author         VARCHAR(150) NOT NULL,
    isbn           VARCHAR(20) UNIQUE,
    price          NUMERIC(10,2),
    published_date DATE,
    is_available   BOOLEAN DEFAULT TRUE,
    extra_info     JSONB
);


-- Verify the books table

SELECT
    column_name,
    data_type,
    is_nullable,
    column_default
FROM information_schema.columns
WHERE table_schema = 'catalog'
  AND table_name = 'books'
ORDER BY ordinal_position;


-- ============================================================
-- END OF ASSIGNMENT
-- ============================================================
