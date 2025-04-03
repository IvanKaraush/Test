using System.Text.Json;
using Task1.BLL.Dto;

namespace Task1.BLL.Interfaces;

public interface IDataService
{
    Task<GetDataResponse[]> GetDataWithFiltersAsync(GetDataRequest request, CancellationToken cancellationToken = default);
    Task OrderByCodeAndSaveDataAsync(JsonElement request, CancellationToken cancellationToken = default);
    Task RemoveAllAsync(CancellationToken cancellationToken = default);
}