using HospitalER.exception;
using HospitalER.repository;

namespace HospitalER.service;

public class TriageService
{
    private readonly IRepository<int, Patient> patientRepo;
    private readonly PriorityQueue<Patient,int> triageQueue = new PriorityQueue<Patient,int>();

    public TriageService(IRepository<int, Patient> patientRepo)
    {
        this.patientRepo = patientRepo;
    }

    public void AdmitPatient(Patient p)
    {
        var v = patientRepo.GetById(p.Id);
        if (v == null) throw new EntityDontExist("no patient record");
        triageQueue.Enqueue(p,int.Parse(p.Severity));
    }

    public Patient CallNextPatient()
    {
        if (triageQueue.Count == 0)
        {
            throw new NoPatientInQueue("currently no patient in the queue");
        }
         return triageQueue.Dequeue();
    }
    
}