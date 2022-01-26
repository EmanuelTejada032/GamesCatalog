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

        [HttpGet("GameList")]
        public ActionResult GetGameList()
        {
            try
            {
                return Ok(_gameService.GetGameList());
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }

        }


        [HttpGet]
        [Route("GameList/{id}")]
        public ActionResult<GameDetail> GetGameDetailById(int id)
        {
            GameDetail gameDetail = _gameService.GetGameDetailById(id);
            if (gameDetail.Id == 0)
            {
                return NotFound();
            }

            return Ok(gameDetail);

        }

        [HttpGet("GetTopGames")]
        public ActionResult GetTopGames()
        {
            try
            {
                return Ok(_gameService.GetTopGames());
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }

        }

    }
}
