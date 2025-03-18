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
public class ReviewsController : ControllerBase
{
    private readonly CarRentalContext _context;
    private readonly IMapper _mapper;

    public ReviewsController(CarRentalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Reviews
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews()
    {
        var reviews = await _context.Reviews
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .ToListAsync();
        return _mapper.Map<IEnumerable<ReviewDto>>(reviews).ToList();
    }

    // GET: api/Reviews/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> GetReview(int id)
    {
        var review = await _context.Reviews
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (review == null)
        {
            throw new ReviewNotFoundException($"Review with ID {id} was not found.");
        }

        return _mapper.Map<ReviewDto>(review);
    }

    // POST: api/Reviews
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> CreateReview(CreateReviewDto createReviewDto)
    {
        var review = _mapper.Map<Review>(createReviewDto);
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        var reviewDto = _mapper.Map<ReviewDto>(review);
        return CreatedAtAction(nameof(GetReview), new { id = review.Id }, reviewDto);
    }

    // PUT: api/Reviews/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(int id, CreateReviewDto updateReviewDto)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null)
        {
            throw new ReviewNotFoundException($"Review with ID {id} was not found.");
        }

        _mapper.Map(updateReviewDto, review);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Reviews/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null)
        {
            throw new ReviewNotFoundException($"Review with ID {id} was not found.");
        }

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}