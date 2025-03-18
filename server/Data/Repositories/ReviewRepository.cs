using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data.Repositories;

public class ReviewRepository : SaveChangesDb, IRepository<Review>, IDisposable
{
    private readonly CarRentalContext _context;
    private bool disposed = false;

    public ReviewRepository(CarRentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Create(Review item)
    {
        await _context.Reviews.AddAsync(item);
        await Save(_context);
    }

    public async Task Delete(int id)
    {
        await _context.Reviews.Where(r => r.Id == id).ExecuteDeleteAsync();
        await Save(_context);
    }

    public async Task<Review?> Get(int id)
    {
        return await _context.Reviews.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Review>> GetAll()
    {
        return await _context.Reviews.AsNoTracking().ToListAsync();
    }

    public async Task Update(int id, Review item)
    {
        var existingReview = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);

        if (existingReview != null)
        {
            _context.Entry(existingReview).CurrentValues.SetValues(item);
            await Save(_context);
        }
        else
        {
            throw new KeyNotFoundException("Review not found.");
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

    ~ReviewRepository()
    {
        Dispose(false);
    }

    public bool StatusDispose()
    {
        return disposed;
    }
}