using CORE.Interfaces;
using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        IGameServices _gameService;

        public GamesController(IGameServices gameServices)
        {
            _gameService = gameServices;
        }
        

        [HttpPost("GamePost")]
        public ActionResult GamePost([FromBody] Game game)
        {
            try
            {
                return Ok(_gameService.RegisterGame(game));
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
            
        }
    }
}
