using webapp_travel_agency.Data;
using webapp_travel_agency.Models;
using webapp_travel_agency.Utils;
using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViaggisController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Viaggio> viaggi = new List<Viaggio>();

            using (BlogContext db = new BlogContext())
            {
                viaggi = db.Viaggi.ToList<Viaggio>();
            }

            return Ok(viaggi);
        }


    }
}