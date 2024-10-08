using Microsoft.AspNetCore.Mvc;
using MyTrailer.API.DTOs;
using MyTrailer.Application.Services;


namespace MyTrailer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalController : ControllerBase
{
    private readonly RentalService _rentalService;

    public RentalController(RentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpPost]
    public IActionResult CreateBooking([FromBody] RentalRequest request)
    {
        _rentalService.CreateBooking(request.TrailerId, request.StartDate, request.EndDate);
        return Ok();
    }
}
