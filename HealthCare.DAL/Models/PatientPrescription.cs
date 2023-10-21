using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DAL.Models
{
    public class PatientPrescription
    {
        public Guid PrescriptionId { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;

        public int PatientAge { get; set; }

        public string PatientGender { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public string Symptoms { get; set; } = null!;

        public string Medicine { get; set; } = null!;

    }
}
