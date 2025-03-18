using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data.Repositories;

public class PaymentRepository : SaveChangesDb, IRepository<Payment>, IDisposable
{
    private readonly CarRentalContext _context;
    private bool disposed = false;

    public PaymentRepository(CarRentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Create(Payment item)
    {
        await _context.Payments.AddAsync(item);
        await Save(_context);
    }

    public async Task Delete(int id)
    {
        await _context.Payments.Where(p => p.Id == id).ExecuteDeleteAsync();
        await Save(_context);
    }

    public async Task<Payment?> Get(int id)
    {
        return await _context.Payments.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Payment>> GetAll()
    {
        return await _context.Payments.AsNoTracking().ToListAsync();
    }

    public async Task Update(int id, Payment item)
    {
        var existingPayment = await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);

        if (existingPayment != null)
        {
            _context.Entry(existingPayment).CurrentValues.SetValues(item);
            await Save(_context);
        }
        else
        {
            throw new KeyNotFoundException("Payment not found.");
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

    ~PaymentRepository()
    {
        Dispose(false);
    }

    public bool StatusDispose()
    {
        return disposed;
    }
}