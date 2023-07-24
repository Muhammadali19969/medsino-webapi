using MedSino.Service.Dtos.Ratings;
using MedSino.Service.Interfaces.Raitings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers
{
    [Route("api/raiting")]
    [ApiController]
    public class RaitingController : ControllerBase
    {
        private readonly IRaitingService _raitingService;

        public RaitingController(IRaitingService raiting)
        {
            this._raitingService = raiting;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] RaitingDto dto)
            => Ok(await _raitingService.CreateAsync(dto));

    }
}
