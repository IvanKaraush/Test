using Task1.DAL.Entities;

namespace Task1.DAL.Interfaces;

public interface IDataRepository
{
    public Task<List<Data>> GetDataAsync(int? exactCode, int? minCode, int? maxCode, int? exactId, int? minId,
        int? maxId, string? value, CancellationToken cancellationToken = default);

    Task<List<Data>> GetAllDataAsync(CancellationToken cancellationToken = default);

    Task AddAsync(Data data, CancellationToken cancellationToken = default);

    void Remove(Data data);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}