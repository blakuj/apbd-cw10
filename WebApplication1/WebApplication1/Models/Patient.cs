using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

[Table(nameof(Patient))]
public class Patient
{
    [Key]
    public int IdDoctor { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set;}
    
    public ICollection<Prescription> Prescription { get; set; } 
        = new HashSet<Prescription>();
}