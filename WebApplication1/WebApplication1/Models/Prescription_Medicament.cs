using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;


[Table(nameof(Prescription_Medicament))]
[PrimaryKey(nameof(IdPrescription),nameof(IdMedicament))]
public class Prescription_Medicament
{
   
    public int IdPrescription { get; set; }
    public int IdMedicament { get; set; }

    public int? Dose { get; set; }

    [MaxLength(100)]
    public string Details { get; set; }


    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; } = null!;
    
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; } = null!;
    
    
}