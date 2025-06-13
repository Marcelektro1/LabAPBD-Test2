using LabAPBD_Test2.DTOs;
using LabAPBD_Test2.Services.Utils;

namespace LabAPBD_Test2.Services;

public interface IBatchesService
{
    public Task<ServiceResult<object>> CreateNewBatch(NewBatchDto newBatchDto);
}