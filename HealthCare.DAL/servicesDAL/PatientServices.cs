using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using HealthCare.DAL.servicesDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.servicesDAL
{
    public class PatientServices : IPatientServices
    {
        private readonly HealthCareContext _context;
        public PatientServices(HealthCareContext context)
        {
            _context= context;
        }


        public List<Patient> GetPatients()
        {
            var patients = _context.Patients.ToList();

            return patients;
        }


        public List<PatientPrescription> Details()
        {
            var patients = (from patient in _context.Patients
                            from prescriptions in _context.Prescriptions
                            where patient.Id == prescriptions.PatientId
                            select new PatientPrescription
                            {
                                PatientId = patient.Id,
                                PrescriptionId = prescriptions.PrescriptionId,
                                PatientName = patient.PatientName,
                                PatientAge = patient.PatientAge,
                                PatientGender = patient.PatientGender,

                                Address = patient.Address,

                                DoctorName = prescriptions.DoctorName,

                                Symptoms = prescriptions.Symptoms,

                                Medicine = prescriptions.Medicine,

                            }).ToList();

            return patients;
        }


        public void AddNewPatient(Patient newPatient)
        {
            var patient = new Patient()
            {
                Id = newPatient.Id,
                PatientAge = newPatient.PatientAge,
                PatientName = newPatient.PatientName,
                PatientGender = newPatient.PatientGender,
                Address = newPatient.Address,
            };

            _context.Patients.Add(patient);
            _context.SaveChanges();
        }


        public Prescription EditPrescription(Guid id) {

            var patient = _context.Prescriptions.FirstOrDefault(x => x.PrescriptionId == id);


                var viewModel = new Prescription()
                {
                    PrescriptionId = id,
                    PatientId = patient.PatientId,
                    DoctorName = patient.DoctorName,
                    Symptoms = patient.Symptoms,
                    Medicine = patient.Medicine,
                };
                return viewModel;

        }


        public void UpdatePrescription(Prescription model)
        {

            var patient = _context.Prescriptions.Find(model.PrescriptionId);

                patient.DoctorName = model.DoctorName;
                patient.Symptoms = model.Symptoms;
                patient.Medicine = model.Medicine;


                _context.SaveChanges();

        }


        public void DeletePrescription(Prescription model)
        {

            var patient = _context.Prescriptions.Find(model.PrescriptionId);

                _context.Prescriptions.Remove(patient);
                _context.SaveChanges();
        }


        public void AddPrescription(Prescription newPrescription)
        {
            var prescription = new Prescription()
            {
                PrescriptionId = new Guid(),
                PatientId = newPrescription.PatientId,
                DoctorName = newPrescription.DoctorName,
                Symptoms = newPrescription.Symptoms,
                Medicine = newPrescription.Medicine
            };

            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
        }


        public Patient EditPatient(int id)
        {
            var patient = _context.Patients.FirstOrDefault(x => x.Id == id);


                var viewModel = new Patient()
                {
                    PatientName = patient.PatientName,
                    PatientAge = patient.PatientAge,
                    PatientGender = patient.PatientGender,
                    Address = patient.Address,
                };

                return viewModel;
          
        }


        public void updatePatient(Patient model)
        {
            var patient = _context.Patients.Find(model.Id);

                patient.PatientName = model.PatientName;
                patient.PatientGender = model.PatientGender;
                patient.Address = model.Address;
                patient.PatientAge = model.PatientAge;


                _context.SaveChanges();
        }


        public void deletePatient(Patient model) {

            var patientPrescription = _context.Prescriptions.FirstOrDefault(x => x.PatientId == model.Id);

            var patient = _context.Patients.FirstOrDefault(x => x.Id == model.Id);

            if (patientPrescription != null)
            {
                _context.Prescriptions.Remove(patientPrescription);
                _context.SaveChanges();
            }

            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }


        public Patient ViewPatient(int id)
        {
            var patient = _context.Patients.FirstOrDefault(x => x.Id == id);


            var viewModel = new Patient()
            {
                Id=patient.Id,
                PatientName = patient.PatientName,
                PatientAge = patient.PatientAge,
                PatientGender = patient.PatientGender,
                Address = patient.Address,
            };

            return viewModel;

        }
    }
}
