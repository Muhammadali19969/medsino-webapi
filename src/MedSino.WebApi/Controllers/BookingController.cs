using MedSino.Service.Dtos.Bookings;
using MedSino.Service.Interfaces.Bookings;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] BookingCreateDto dto)
        => Ok(await _bookingService.CreateAsync(dto));

    [HttpGet("{doctorId}/{bookingDate}")]
    [Authorize(Roles = "Doctor,User")]
    public async Task<IActionResult> GetByIdDateAsync(long doctorId, string bookingDate)
        => Ok(await _bookingService.GetByIdDateAsync(doctorId, bookingDate));

    [HttpGet("{doctorId}/{time}/{date}")]
    [Authorize(Roles = "Doctor,Admin")]
    public async Task<IActionResult> GetUserViewByDoctorIdDateTime(long doctorId, string time, string date)
        => Ok(await _bookingService.GetUserViewByDoctorIdDateTime(doctorId, time, date));

}
