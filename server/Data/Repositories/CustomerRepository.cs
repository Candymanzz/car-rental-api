using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data.Repositories;

public class CustomerRepository : SaveChangesDb, IRepository<Customer>, IDisposable
{
    private readonly CarRentalContext _context;
    private bool disposed = false;

    public CustomerRepository(CarRentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Create(Customer item)
    {
        await _context.Customers.AddAsync(item);
        await Save(_context);
    }

    public async Task Delete(int id)
    {
        await _context.Customers.Where(c => c.Id == id).ExecuteDeleteAsync();
        await Save(_context);
    }

    public async Task<Customer?> Get(int id)
    {
        return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _context.Customers.AsNoTracking().ToListAsync();
    }

    public async Task Update(int id, Customer item)
    {
        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

        if (existingCustomer != null)
        {
            _context.Entry(existingCustomer).CurrentValues.SetValues(item);
            await Save(_context);
        }
        else
        {
            throw new KeyNotFoundException("Customer not found.");
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

    ~CustomerRepository()
    {
        Dispose(false);
    }

    public bool StatusDispose()
    {
        return disposed;
    }
}