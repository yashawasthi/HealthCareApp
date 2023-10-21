using HealthCare.BAL.servicesBAL;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCareController : ControllerBase
    {
        private readonly HealthCareContext _context;
        PatientServices patientService;


        public HealthCareController(HealthCareContext context)
        {
            _context = context;
            patientService = new PatientServices(_context);
        }


        [HttpGet("getAllPatients")]
        public IActionResult GetAllPatients()
        {
            return Ok(patientService.GetAllPatients());
        }



        [HttpPost("addPatient")]
        public IActionResult AddPatient(Patient newPatient)
        {


            patientService.AddNewPatient(newPatient);
            return Ok(patientService.GetAllPatients());
        }


        [HttpPut("editPrescription")]
        public IActionResult EditPrescription(Prescription model)
        {
            patientService.Edit(model);
            return Ok();
        }



        [HttpPost("addPrescription")]
        public IActionResult AddPrescription(Prescription newPrescription)
        {

            patientService.AddPrescription(newPrescription);
            return Ok();
        }


        [HttpPost("editPatient")]
        public IActionResult EditPatient(Patient model)
        {
            patientService.updatePatient(model);
            return Ok();
        }


        [HttpDelete("deletePatient")]
        public IActionResult DeletePatient(Patient model)
        {

            patientService.DeletePatient(model);
            return Ok();
        }


        [HttpDelete("deletePrescription")]
        public IActionResult Delete(Prescription model)
        {
            patientService.DeletePrescription(model);
            return Ok();
        }


        [HttpGet("getPatientPrescriptionDetails")]
        public IActionResult PatientDetails()
        {
            return Ok(patientService.GetPatientPrescriptionDetails());
        }


        [HttpGet("getPatient")]
        public IActionResult getPatient(int id)
        {
            return Ok(patientService.ViewPatient(id));
        }


        [HttpGet("getPatientPrescription")]
        public IActionResult getPatientPrescription(int id)
        {
            var patientPrescriptionDetails = patientService.GetPatientPrescriptionDetails();

                 var patient_detail= (from detail in patientPrescriptionDetails
                                 where detail.PatientId == id
                                 select new PatientPrescription
                                 {
                                     PatientId = detail.PatientId,
                                     PrescriptionId = detail.PrescriptionId,
                                     PatientName = detail.PatientName,
                                     PatientAge = detail.PatientAge,
                                     PatientGender = detail.PatientGender,

                                     Address = detail.Address,

                                     DoctorName = detail.DoctorName,

                                     Symptoms = detail.Symptoms,

                                     Medicine = detail.Medicine,

                                 }).ToList();

            return Ok(patient_detail);
        }
    }
}
