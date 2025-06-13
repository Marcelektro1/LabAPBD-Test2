// using Microsoft.AspNetCore.Mvc;
//
// namespace LabAPBD_Test2.Controllers;
//
// [ApiController]
// [Route("api/[controller]")]
// public class SomethingController(ISomeService someService) : ControllerBase
// {
//     
//     [HttpGet("{patientId:int}")]
//     public async Task<ActionResult> GetPatientDetails(int patientId)
//     {
//         var res = await patientsService.GetPatientDetails(patientId);
//
//         if (!res.Success)
//         {
//             return res.ErrorCode switch
//             {
//                 "PATIENT_NOT_FOUND" => NotFound(res.Message),
//                 _ => BadRequest(res.ErrorCode + ": " + res.Message)
//             };
//         }
//         
//         return Ok(res);
//     }
//     
// }