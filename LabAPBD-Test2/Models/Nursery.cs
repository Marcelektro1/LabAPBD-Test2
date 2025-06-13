using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAPBD_Test2.Models;

[Table("Nursery")]
public class Nursery
{
    [Key]
    public int NurseryId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    
    public DateTime EstablishedDate { get; set; }
}