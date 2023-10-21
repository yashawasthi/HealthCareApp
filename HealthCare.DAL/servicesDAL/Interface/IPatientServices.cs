using HealthCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.servicesDAL.Interface
{
    internal interface IPatientServices
    {
        public List<Patient> GetPatients();

        public List<PatientPrescription> Details();

        public void AddNewPatient(Patient newPatient);

        public Prescription EditPrescription(Guid id);

        public void UpdatePrescription(Prescription model);

        public void DeletePrescription(Prescription model);

        public void AddPrescription(Prescription newPrescription);

        public Patient EditPatient(int id);

        public void updatePatient(Patient model);

        public void deletePatient(Patient model);

        public Patient ViewPatient(int id);

    }
}
