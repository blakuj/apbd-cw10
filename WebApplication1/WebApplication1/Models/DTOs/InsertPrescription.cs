namespace WebApplication1.Models.DTOs;

public class InsertPrescription
{
    public PatientDTO PatientDto { get; set; }
    public List<MedicamentDTO> MedicamentDto { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
}

public class MedicamentDTO
{
    public int IdMedicament { get; set; }
    public string Description { get; set; }
    public int Dose { get; set; }
}

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}