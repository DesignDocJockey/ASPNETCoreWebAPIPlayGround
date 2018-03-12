using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(ApiRoutes.SneakersApiControllerRoute)]
    public class SneakersController : Controller
    {
        // GET api/sneakers
        [HttpGet]
        public async Task<IActionResult> GetSneakers()
        {
            var sneaks = SneakerDataStore.Instance.GetSneakers();
            return Ok(sneaks);
        }

        // GET api/sneakers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSneaker(int id)
        {
            var sneaks = SneakerDataStore.Instance
                         .GetSneakers()
                         .FirstOrDefault(i => i.Id == id);

            if (sneaks == default(SneakerDto))
                return NotFound();

            return Ok(sneaks);
        } 
    }
}
