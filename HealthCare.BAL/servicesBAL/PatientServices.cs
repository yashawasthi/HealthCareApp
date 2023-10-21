using HealthCare.BAL.servicesBAL.Interface;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using HealthCare.DAL.servicesDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BAL.servicesBAL
{
    public class PatientServices : IPatientServices
    {
        private readonly HealthCareContext _context;
        DAL.servicesDAL.PatientServices serviceDAL;

        public PatientServices(HealthCareContext context)
        {
            _context = context;
            serviceDAL = new DAL.servicesDAL.PatientServices(_context);
        }

        public List<Patient> GetAllPatients()
        {
            return serviceDAL.GetPatients();
        }

    public List<PatientPrescription> GetPatientPrescriptionDetails()
        {
            return serviceDAL.Details();
        }

        public void AddNewPatient(Patient newPatient)
        {
            serviceDAL.AddNewPatient(newPatient);
        }

        public Prescription EditPrescription(Guid id)
        {
            return serviceDAL.EditPrescription(id);
        }

        public void Edit(Prescription model)
        {
            serviceDAL.UpdatePrescription(model);
        }

        public void DeletePrescription(Prescription model)
        {
            serviceDAL.DeletePrescription(model);
        }

        public void AddPrescription(Prescription newPrescription)
        {
            serviceDAL.AddPrescription(newPrescription);
        }

        public Patient EditPatient(int id)
        {
            return serviceDAL.EditPatient(id);
        }

        public void updatePatient(Patient model)
        {
            serviceDAL.updatePatient(model);
        }

        public void DeletePatient(Patient model)
        {
            serviceDAL.deletePatient(model);
        }

        public Patient ViewPatient(int id)
        {
            return serviceDAL.ViewPatient(id);
        }
    }
}
