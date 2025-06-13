using LabAPBD_Test2.DTOs;
using LabAPBD_Test2.Services.Utils;

namespace LabAPBD_Test2.Services;

public class NurseriesService : INurseriesService
{
    public Task<ServiceResult<NurseryBatchesDto>> GetBatchesForNurseryById(int nurseryId)
    {
        throw new NotImplementedException();
    }
}