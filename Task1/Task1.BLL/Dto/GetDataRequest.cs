namespace Task1.BLL.Dto;

public class GetDataRequest
{
    public int? Id { get; init; }
    public int? MinId { get; init; }
    public int? MaxId { get; init; }
    public int? Code { get; init; }
    public int? MinCode { get; init; }
    public int? MaxCode { get; init; }
    public string? Value { get; init; }
}