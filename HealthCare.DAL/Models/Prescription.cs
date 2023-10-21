using System;
using System.Collections.Generic;

namespace HealthCare.DAL.Models;

public partial class Prescription
{
    public Guid PrescriptionId { get; set; }

    public int PatientId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string Symptoms { get; set; } = null!;

    public string Medicine { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
