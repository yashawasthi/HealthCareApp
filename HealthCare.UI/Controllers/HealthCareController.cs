using HealthCare.BAL.servicesBAL;
using HealthCare.DAL.Data;
using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HealthCare.UI.Controllers
{
    public class HealthCareController : Controller
    {
        private readonly HealthCareContext _context;
        PatientServices patientService;

        public HealthCareController(HealthCareContext context)
        {
            
            _context = context;
            patientService = new PatientServices(_context);

        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            return View(patientService.GetAllPatients());
        }

        [HttpGet]
        public IActionResult PatientDetails()
        {
            return View(patientService.GetPatientPrescriptionDetails());
        }


        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(Patient newPatient)
        {


            patientService.AddNewPatient(newPatient);

            return RedirectToAction("PatientDetails");
        }


        [HttpGet]
        public IActionResult EditPrescription(Guid id)
        {

            return View(patientService.EditPrescription(id));

        }

        [HttpPost]
        public IActionResult EditPrescription(Prescription model)
        {
            patientService.Edit(model);

            return RedirectToAction("PatientDetails");
        }

        [HttpPost]
        public IActionResult Delete(Prescription model)
        {
            patientService.DeletePrescription(model);
            return RedirectToAction("PatientDetails");
        }

        [HttpGet]
        public IActionResult AddPrescription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPrescription(Prescription newPrescription)
        {

            patientService.AddPrescription(newPrescription);
            return RedirectToAction("PatientDetails");
        }

        [HttpGet]
        public IActionResult EditPatient(int id)
        {
           
            return View(patientService.EditPatient(id));

        }

        [HttpPost]
        public IActionResult EditPatient(Patient model)
        {
            patientService.updatePatient(model);
            return RedirectToAction("GetAllPatients");
        }

        [HttpPost]
        public IActionResult DeletePatient(Patient model)
        {

            patientService.DeletePatient(model);
            return RedirectToAction("PatientDetails");
        }

        [HttpGet]
        public IActionResult ViewPatient(int id)
        {

            return View(patientService.ViewPatient(id));

        }

    }
}
