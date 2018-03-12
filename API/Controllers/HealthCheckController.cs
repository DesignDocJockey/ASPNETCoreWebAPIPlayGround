using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Contexts;

namespace API.Controllers
{
    [Route("api/healthcheck")]
    public class HealthCheckController : Controller
    {
        private readonly SneakersDbContext _SneakersDbContext;
        public HealthCheckController(SneakersDbContext ctx)
        {
            _SneakersDbContext = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}