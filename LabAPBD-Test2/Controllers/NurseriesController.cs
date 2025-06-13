using LabAPBD_Test2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabAPBD_Test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NurseriesController(INurseriesService nurseriesService) : ControllerBase
{
    
    [HttpGet("{nurseryId:int}/batches")]
    public async Task<ActionResult> GetNurseryBatches(int nurseryId)
    {
        var res = await nurseriesService.GetBatchesForNurseryById(nurseryId);

        if (!res.Success)
        {
            return res.ErrorCode switch
            {
                "NURSERY_NOT_FOUND" => NotFound(res.Message),
                _ => BadRequest(res.ErrorCode + ": " + res.Message)
            };
        }
        
        return Ok(res.Data);
    }
    
}