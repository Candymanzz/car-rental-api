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
public class CarsController : ControllerBase
{
    private readonly CarRentalContext _context;
    private readonly IMapper _mapper;

    public CarsController(CarRentalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Cars
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
    {
        var cars = await _context.Cars.ToListAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars).ToList();
    }

    // GET: api/Cars/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CarDto>> GetCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            throw new CarNotFoundException($"Car with ID {id} was not found.");
        }

        return _mapper.Map<CarDto>(car);
    }

    // POST: api/Cars
    [HttpPost]
    public async Task<ActionResult<CarDto>> CreateCar(CreateCarDto createCarDto)
    {
        var car = _mapper.Map<Car>(createCarDto);
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        var carDto = _mapper.Map<CarDto>(car);
        return CreatedAtAction(nameof(GetCar), new { id = car.Id }, carDto);
    }

    // PUT: api/Cars/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar(int id, CreateCarDto updateCarDto)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            throw new CarNotFoundException($"Car with ID {id} was not found.");
        }

        _mapper.Map(updateCarDto, car);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Cars/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            throw new CarNotFoundException($"Car with ID {id} was not found.");
        }

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}