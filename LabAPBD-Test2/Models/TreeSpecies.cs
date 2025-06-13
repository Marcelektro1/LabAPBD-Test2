using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAPBD_Test2.Models;

[Table("Tree_Species")]
public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    
    [MaxLength(100)]
    public string LatinName { get; set; }
    
    public int GrowthTimeInYears { get; set; }
}