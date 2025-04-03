using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Task1.BLL.Dto;
using Task1.BLL.Interfaces;

namespace Task1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly IDataService _dataService;

    public DataController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<IActionResult> GetData([FromQuery] GetDataRequest request,
        CancellationToken cancellationToken = default)
    {
        var filteredData = await _dataService.GetDataWithFiltersAsync(request, cancellationToken);
        return Ok(filteredData);
    }

    [HttpPost]
    public async Task<IActionResult> SaveData([FromBody] JsonElement jsonRequest,
        CancellationToken cancellationToken = default)
    {
        await _dataService.RemoveAllAsync(cancellationToken);
        await _dataService.OrderByCodeAndSaveDataAsync(jsonRequest, cancellationToken);
        return NoContent();
    }
}