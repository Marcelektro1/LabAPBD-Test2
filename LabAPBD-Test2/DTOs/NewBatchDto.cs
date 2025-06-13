namespace LabAPBD_Test2.DTOs;

public class NewBatchDto
{
    public int Quantity { get; set; }
    public string Species { get; set; }
    public string Nursery { get; set; }
    public List<NewBatchResponsibleDto> Responsible { get; set; }
}

public class NewBatchResponsibleDto
{
    public int EmployeeId { get; set; }
    public string Role { get; set; }
}