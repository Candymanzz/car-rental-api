using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using server.Data;
using server.DTOs;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PaymentsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Payments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentDto>>> GetPayments()
    {
        var payments = await _context.Payments
            .Include(p => p.Rental)
            .ToListAsync();
        return _mapper.Map<IEnumerable<PaymentDto>>(payments).ToList();
    }

    // GET: api/Payments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentDto>> GetPayment(int id)
    {
        var payment = await _context.Payments
            .Include(p => p.Rental)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
        {
            return NotFound();
        }

        return _mapper.Map<PaymentDto>(payment);
    }

    // POST: api/Payments
    [HttpPost]
    public async Task<ActionResult<PaymentDto>> CreatePayment(CreatePaymentDto createPaymentDto)
    {
        var payment = _mapper.Map<Payment>(createPaymentDto);
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        var paymentDto = _mapper.Map<PaymentDto>(payment);
        return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, paymentDto);
    }

    // PUT: api/Payments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, CreatePaymentDto updatePaymentDto)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
        {
            return NotFound();
        }

        _mapper.Map(updatePaymentDto, payment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Payments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
        {
            return NotFound();
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}