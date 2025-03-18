using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using server.Data;
using server.DTOs;
using server.Models;
using server.Exceptions;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly CarRentalContext _context;
    private readonly IMapper _mapper;

    public RentalsController(CarRentalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Rentals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentalDto>>> GetRentals()
    {
        var rentals = await _context.Rentals
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .ToListAsync();
        return _mapper.Map<IEnumerable<RentalDto>>(rentals).ToList();
    }

    // GET: api/Rentals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RentalDto>> GetRental(int id)
    {
        var rental = await _context.Rentals
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (rental == null)
        {
            throw new RentalNotFoundException($"Rental with ID {id} was not found.");
        }

        return _mapper.Map<RentalDto>(rental);
    }

    // POST: api/Rentals
    [HttpPost]
    public async Task<ActionResult<RentalDto>> CreateRental(CreateRentalDto createRentalDto)
    {
        var rental = _mapper.Map<Rental>(createRentalDto);
        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();

        var rentalDto = _mapper.Map<RentalDto>(rental);
        return CreatedAtAction(nameof(GetRental), new { id = rental.Id }, rentalDto);
    }

    // PUT: api/Rentals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRental(int id, CreateRentalDto updateRentalDto)
    {
        var rental = await _context.Rentals.FindAsync(id);
        if (rental == null)
        {
            throw new RentalNotFoundException($"Rental with ID {id} was not found.");
        }

        _mapper.Map(updateRentalDto, rental);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Rentals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRental(int id)
    {
        var rental = await _context.Rentals.FindAsync(id);
        if (rental == null)
        {
            throw new RentalNotFoundException($"Rental with ID {id} was not found.");
        }

        _context.Rentals.Remove(rental);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}