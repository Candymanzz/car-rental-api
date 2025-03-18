using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using server.Data;
using server.DTOs;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CustomersController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers).ToList();
    }

    // GET: api/Customers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        return _mapper.Map<CustomerDto>(customer);
    }

    // POST: api/Customers
    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
    {
        var customer = _mapper.Map<Customer>(createCustomerDto);
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var customerDto = _mapper.Map<CustomerDto>(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customerDto);
    }

    // PUT: api/Customers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CreateCustomerDto updateCustomerDto)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        _mapper.Map(updateCustomerDto, customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}