using System.ComponentModel.DataAnnotations;

namespace LabAPBD_Test2.DTOs;

public class NewBatchDto
{
    [Required]
    public int? Quantity { get; set; }
    
    [Required]
    public string Species { get; set; }
    
    [Required]
    public string Nursery { get; set; }
    
    [Required]
    public List<NewBatchResponsibleDto> Responsible { get; set; }
}

public class NewBatchResponsibleDto
{
    [Required]
    public int? EmployeeId { get; set; }
    
    [Required]
    public string Role { get; set; }
}