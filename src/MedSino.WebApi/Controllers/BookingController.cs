using MedSino.Service.Dtos.Bookings;
using MedSino.Service.Interfaces.Bookings;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers;

[Route("api/booking")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        this._bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] BookingCreateDto dto)
        =>Ok(await _bookingService.CreateAsync(dto));

    [HttpGet("{doctorId}/{bookingDate}")]
    public async Task<IActionResult> GetByIdDateAsync(long doctorId, string bookingDate)
        => Ok(await _bookingService.GetByIdDateAsync(doctorId, bookingDate));

}
