using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ILogger<PlayersController> _ILogger;
        private readonly INotificationService _NotificationService;

        public PlayersController(ILogger<PlayersController> logger, 
                                 INotificationService notificationService)
        {
            _ILogger = logger;
            _NotificationService = notificationService;
        }

        [HttpGet("api/sneakers/{sneakerId}/players")]
        public async Task<IActionResult> GetPlayersForSneaker(int sneakerId)
        {
            try
            {
                var sneakers = SneakerDataStore.Instance
                                              .GetSneakers()
                                              .FirstOrDefault(s => s.Id == sneakerId);

                if (sneakers == default(SneakerDto))
                {
                    _ILogger.LogInformation($"No Players Found for Sneakerid: {sneakerId}");
                    return NotFound();
                }
                return Ok(sneakers.WornByPlayers);
            }
            catch (Exception ex)
            {
                _ILogger.LogCritical("An exception occured in GetPlayersForSneaker() EndPoint for sneakerId: {sneakerId}");
                return StatusCode(500, "An problem occured handling your request");
            }
        }

        [HttpGet("api/sneakers/{sneakerId}/players/{playerId}")]
        public async Task<IActionResult> GetPlayerForSneaker(int sneakerId, int playerId)
        {
            var sneakers = SneakerDataStore.Instance
                                       .GetSneakers()
                                       .FirstOrDefault(s => s.Id == sneakerId);
            if (sneakers == default(SneakerDto))
                return NotFound();

            var player = sneakers.WornByPlayers.FirstOrDefault(i => i.Id == playerId);
            if (player == default(PlayerDto))
                return NotFound();

            return Ok(player);
        }


        [Route(ApiRoutes.PlayersApiControllerRoute)]
        public async Task<IActionResult> GetPlayers()
        {
            var players = PlayersDataStore.Instance.GetPlayers();
            return Ok(players);
        }

        [HttpGet("api/players/{playerId}", Name = ApiRoutes.GetPlayerByIdRouteName)]
        public async Task<IActionResult> GetPlayer(int playerId)
        {
            var player = PlayersDataStore.Instance
                    .GetPlayers()
                    .FirstOrDefault(i => i.Id == playerId);
            return Ok(player);
        }

        [HttpPost(ApiRoutes.PlayersApiControllerRoute)]
        public async Task<IActionResult> Post([FromBody]CreatePlayerDto newPlayer)
        {
            if (newPlayer == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = PlayersDataStore.Instance.AddNewPlayer(newPlayer);
            return CreatedAtRoute(ApiRoutes.GetPlayerByIdRouteName, new { playerId = player.Id}, player);
        }
        
        [HttpPut("api/players/{playerId}")]
        public async Task<IActionResult> Put(int playerId, [FromBody]UpdatePlayerDto updatePlayer)
        {
            if (updatePlayer == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //TODO::implement PUT update logic to validate all fields being updated 
            //and logic to update all fields

            return NoContent();
        }

        [HttpDelete("api/players/{playerId}")]
        public async Task<IActionResult> Delete(int playerId)
        {
            var player = PlayersDataStore.Instance
                .GetPlayers()
                .FirstOrDefault(i => i.Id == playerId);

            if (player == default(PlayerDto))
                return NotFound();

            //TODO::add delete logic here

            return NoContent();
        }
    }
}
