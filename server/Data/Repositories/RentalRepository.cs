using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data.Repositories;

public class RentalRepository : SaveChangesDb, IRepository<Rental>, IDisposable
{
    private readonly CarRentalContext _context;
    private bool disposed = false;

    public RentalRepository(CarRentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Create(Rental item)
    {
        await _context.Rentals.AddAsync(item);
        await Save(_context);
    }

    public async Task Delete(int id)
    {
        await _context.Rentals.Where(r => r.Id == id).ExecuteDeleteAsync();
        await Save(_context);
    }

    public async Task<Rental?> Get(int id)
    {
        return await _context.Rentals.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Rental>> GetAll()
    {
        return await _context.Rentals.AsNoTracking().ToListAsync();
    }

    public async Task Update(int id, Rental item)
    {
        var existingRental = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);

        if (existingRental != null)
        {
            _context.Entry(existingRental).CurrentValues.SetValues(item);
            await Save(_context);
        }
        else
        {
            throw new KeyNotFoundException("Rental not found.");
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~RentalRepository()
    {
        Dispose(false);
    }

    public bool StatusDispose()
    {
        return disposed;
    }
}