using System;
using System.Collections.Generic;

namespace HealthCare.DAL.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string PatientName { get; set; } = null!;

    public int PatientAge { get; set; }

    public string PatientGender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();
}
