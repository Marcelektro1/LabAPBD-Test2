using LabAPBD_Test2.DTOs;
using LabAPBD_Test2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabAPBD_Test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchesController(IBatchesService batchesService) : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> CreateNewBatch([FromBody] NewBatchDto newBatch)
    {
        var res = await batchesService.CreateNewBatch(newBatch);

        if (!res.Success)
        {
            return res.ErrorCode switch
            {
                "SPECIES_NOT_FOUND" => NotFound(res.Message),
                "BATCH_NOT_FOUND" => NotFound(res.Message),
                "EMPLOYEE_NOT_FOUND" => NotFound(res.Message),
                _ => BadRequest(res.ErrorCode + ": " + res.Message)
            };
        }

        return Created();

    }
    
}