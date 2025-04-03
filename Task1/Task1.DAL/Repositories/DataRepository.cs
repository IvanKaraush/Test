using Microsoft.EntityFrameworkCore;
using Task1.DAL.Entities;
using Task1.DAL.Interfaces;

namespace Task1.DAL.Repositories;

public class DataRepository : IDataRepository
{
    private readonly DataContext _context;

    public DataRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Data>> GetDataAsync(int? exactCode, int? minCode, int? maxCode, int? exactId,
        int? minId, int? maxId, string? value, CancellationToken cancellationToken = default)
    {
        return await _context.Data
            .Where(d => !exactCode.HasValue || d.Code == exactCode.Value)
            .Where(d => !minCode.HasValue || d.Code >= minCode.Value)
            .Where(d => !maxCode.HasValue || d.Code <= maxCode.Value)
            .Where(d => !exactId.HasValue || d.Id == exactId.Value)
            .Where(d => !minId.HasValue || d.Id >= minId.Value)
            .Where(d => !maxId.HasValue || d.Id <= maxId.Value)
            .Where(d => string.IsNullOrWhiteSpace(value) || EF.Functions.ILike(d.Value, $"%{value}%"))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Data>> GetAllDataAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Data.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Data data, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(data, cancellationToken);
    }

    public void Remove(Data data)
    {
        _context.Remove(data);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}