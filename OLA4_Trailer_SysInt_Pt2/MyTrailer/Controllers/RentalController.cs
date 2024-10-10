using Microsoft.AspNetCore.Mvc;
using MyTrailer.Application.DTOs;
using MyTrailer.Application.Services;
using MyTrailer.Infrastructure;


namespace MyTrailer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalController : ControllerBase
{
    private readonly RentalService _rentalService;
    private readonly ICustomerRepository _customerRepository;

    public RentalController(RentalService rentalService, ICustomerRepository customerRepository, PaymentService paymentService)
    {
        _rentalService = rentalService;
        _customerRepository = customerRepository;
    }

    [HttpPost] 
    public async Task<IActionResult> CreateRental([FromBody] RentalRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }

        try
        {
            var rental = await _rentalService.CreateRental(request.CustomerId, request.TrailerId, request.StartDate,
                request.EndDate, request.IsInsured);

            if (rental == null)
            {
                return StatusCode(500, "An error occurred while creating the rental.");
            }
            
            var response = new RentalResponse(
                rental?.Id ?? 0,
                rental?.Customer?.Id ?? 0,
                rental?.Trailer?.Id ?? 0,
                rental?.StartDate ?? DateTime.MinValue,
                rental?.EndDate ?? DateTime.MinValue,
                rental?.Price?.Amount ?? 0,
                rental?.IsInsured ?? false
            );
            

            return CreatedAtAction(nameof(GetRentalById), new { id = response.Id }, response);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "An error occurred while creating the rental.");
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetRentalById(int id)
    {
        var rental = _rentalService.GetRentalById(id);
        if (rental == null)
        {
            return NotFound($"Rental with ID {id} not found.");
        }

        var response = new RentalResponse(
            rental?.Id ?? 0,
            rental?.Customer?.Id ?? 0,
            rental?.Trailer?.Id ?? 0,
            rental?.StartDate ?? DateTime.MinValue,
            rental?.EndDate ?? DateTime.MinValue,
            rental?.Price?.Amount ?? 0,
            rental?.IsInsured ?? false
        );
        return Ok(response);
    }

    // get all rentals by customerid
    [HttpGet("customer/{customerId:int}")]
    public IActionResult GetRentalsByCustomerId(int customerId)
    {
        var customer = _customerRepository.GetById(customerId);
        if (customer == null)
        {
            return NotFound($"Customer with ID {customerId} not found.");
        }

        var rentals = _rentalService.GetRentalsByCustomerId(customerId);
        var response = rentals.Select(rental => new RentalResponse(
            rental?.Id ?? 0,
            rental?.Customer?.Id ?? 0,
            rental?.Trailer?.Id ?? 0,
            rental?.StartDate ?? DateTime.MinValue,
            rental?.EndDate ?? DateTime.MinValue,
            rental?.Price?.Amount ?? 0,
            rental?.IsInsured ?? false
        )).ToList();
        return Ok(response);
    }
}