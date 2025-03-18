using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data.Repositories;

public class CarRepository : SaveChangesDb, IRepository<Car>, IDisposable
{
    private readonly CarRentalContext _context;
    private bool disposed = false;

    public CarRepository(CarRentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Create(Car item)
    {
        await _context.Cars.AddAsync(item);
        await Save(_context);
    }

    public async Task Delete(int id)
    {
        await _context.Cars.Where(c => c.Id == id).ExecuteDeleteAsync();
        await Save(_context);
    }

    public async Task<Car?> Get(int id)
    {
        return await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Car>> GetAll()
    {
        return await _context.Cars.AsNoTracking().ToListAsync();
    }

    public async Task Update(int id, Car item)
    {
        var existingCar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

        if (existingCar != null)
        {
            _context.Entry(existingCar).CurrentValues.SetValues(item);
            await Save(_context);
        }
        else
        {
            throw new KeyNotFoundException("Car not found.");
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

    ~CarRepository()
    {
        Dispose(false);
    }

    public bool StatusDispose()
    {
        return disposed;
    }
}