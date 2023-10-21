using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BAL.servicesBAL.Interface
{
    internal interface IPatientServices
    {
        public List<Patient> GetAllPatients();

        public List<PatientPrescription> GetPatientPrescriptionDetails();

        public void AddNewPatient(Patient newPatient);

        public Prescription EditPrescription(Guid id);

        public void Edit(Prescription model);

        public void DeletePrescription(Prescription model);

        public void AddPrescription(Prescription newPrescription);

        public Patient EditPatient(int id);

        public void updatePatient(Patient model);

        public void DeletePatient(Patient model);

        public Patient ViewPatient(int id);
    }
}
