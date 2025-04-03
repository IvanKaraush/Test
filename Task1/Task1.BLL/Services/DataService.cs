using System.Text.Json;
using AutoMapper;
using Task1.BLL.Dto;
using Task1.BLL.Interfaces;
using Task1.DAL.Entities;
using Task1.DAL.Interfaces;

namespace Task1.BLL.Services;

public class DataService : IDataService
{
    private readonly IDataRepository _dataRepository;
    private readonly IMapper _mapper;

    public DataService(IDataRepository dataRepository, IMapper mapper)
    {
        _dataRepository = dataRepository;
        _mapper = mapper;
    }

    public async Task<GetDataResponse[]> GetDataWithFiltersAsync(GetDataRequest request,
        CancellationToken cancellationToken = default)
    {
        var filteredData =
            await _dataRepository.GetDataAsync(request.Code, request.MinCode, request.MaxCode, request.Id,
                request.MinId, request.MaxId, request.Value, cancellationToken);
        return _mapper.Map<GetDataResponse[]>(filteredData);
    }

    public async Task OrderByCodeAndSaveDataAsync(JsonElement request, CancellationToken cancellationToken = default)
    {
        var parsedDataRequest = request.Deserialize<Dictionary<int, string>[]>();
        var collectionOfData = _mapper.Map<Data[]>(parsedDataRequest);
        foreach (var data in collectionOfData.OrderBy(c => c.Code))
        {
            await _dataRepository.AddAsync(data, cancellationToken);
        }

        await _dataRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAllAsync(CancellationToken cancellationToken = default)
    {
        var collectionOfData = await _dataRepository.GetAllDataAsync(cancellationToken);
        foreach (var data in collectionOfData)
        {
            _dataRepository.Remove(data);
        }

        await _dataRepository.SaveChangesAsync(cancellationToken);
    }
}