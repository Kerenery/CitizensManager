using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TELE2Test.DAL.Context;
using TELE2Test.DAL.Entities;
using TELE2Test.DAL.Interfaces;
using TELE2Test.DAL.Tools;

namespace TELE2Test.DAL.Repositories;

public class CitizenRepository : ICitizenRepository
{
    private readonly TELE2TestContext _context;

    public CitizenRepository(TELE2TestContext context)
        => _context = context;

    public void Dispose()
        => _context.Dispose();

    public async Task<Citizen> GetByIdAsync(string id)
        => await _context.Citizens.FindAsync(id);

    public async Task InsertAsync(Citizen? citizen)
    {
        await _context.Citizens.AddAsync(citizen);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Citizen entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var citizen = await _context.Citizens.FindAsync(id);
        _context.Citizens.Remove(citizen);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Citizen?>> GetAllAsync()
        => await _context.Citizens.ToListAsync();

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();

    public async Task InsertManyAsync(IEnumerable<Citizen> entities)
    {
        await _context.Citizens.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateManyAsync(IEnumerable<Citizen> citizens)
    {
        var citizensToUpdateIds = citizens.Select(c => c.Id);
        var citizensToUpdate = await _context.Citizens
            .Where(c => citizensToUpdateIds.Contains(c.Id))
            .ToListAsync();
        
        _context.Citizens.RemoveRange(citizensToUpdate);
        await _context.Citizens.AddRangeAsync(citizens);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Citizen>> GetAllBySex(SexType? sex)
        => await _context.Citizens
            .Where(c => c.Sex == sex)
            .ToListAsync();

    public async Task<IEnumerable<Citizen>> GetAllByAge()
        => await _context.Citizens
            .OrderBy(c => c.Age)
            .ToListAsync();
}