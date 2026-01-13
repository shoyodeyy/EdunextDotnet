using Edunext.Application.Abstractions.Persistence;
using Edunext.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edunext.Infrastructure.Persistence.Repositories;

public class TableRepository : ITableRepository
{
    private readonly AppDbContext _context;

    public TableRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Table?> GetByIdAsync(Guid tableId)
    {
        return await _context.Tables.FirstOrDefaultAsync(t => t.Id == tableId); 
    }

    public async Task<Table?> GetByCodeAsync(string code)
    {
        return await _context.Tables.FirstOrDefaultAsync(t => t.Code == code); 
    }

    public async Task AddAsync(Table table)
    {
        await _context.Tables.AddAsync(table);
    }

    public void Update(Table table)
    {
        _context.Tables.Update(table);
    }
}