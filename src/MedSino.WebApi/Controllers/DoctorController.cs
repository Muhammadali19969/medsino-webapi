using MedSino.Service.Interfaces.Doctors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedSino.WebApi.Controllers
{

    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategoryIdAsync(long categoryId)
            =>Ok(await _doctorService.GetByCategoryIdAsync(categoryId));
        
    }
}
