namespace WebApplication1.Models.DTOs;

public class GetPrescritpion
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public IEnumerable<PrescriptionDTO> PrescriptionDto { get; set; }
}

public class PrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<MedicamentsDTO> MedicamentsList { get; set; }
    public DoctorDTO Doctor { get; set; }

}

public class MedicamentsDTO
{
    public int IdMedicament { get; set; }
    public string Name{ get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
}

public class DoctorDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
}
