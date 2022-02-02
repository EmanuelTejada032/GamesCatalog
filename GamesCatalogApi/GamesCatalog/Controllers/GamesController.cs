using CORE.Interfaces;
using CORE.Models;
using GamesCatalog.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly Impersonation _impersonation;

        public GamesController(IGameServices gameServices, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _configuration = configuration;
            _impersonation = new Impersonation(_configuration);
            _hostEnvironment = hostEnvironment;
            _gameService = gameServices;
        }

        [HttpPost("GamePost")]
        public async Task<ActionResult> GamePost([FromForm] Game game)
        {
            try
            {
                var gameId = _gameService.RegisterGame(game);
                string serverPath = await _gameService.UploadFrontPageImage(new PostGameImage {gameId= gameId, Image = game.Image }, _hostEnvironment.ContentRootPath);
                await _impersonation.SaveFiles(game.Image,serverPath);
                return Ok(gameId);

            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
            
        }

        [HttpGet("GameList")]
        public ActionResult GetGameList([FromQuery]Pagination paginationData)
        {
            try
            {
                return Ok(_gameService.GetGameList(paginationData));
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }

        }


        [HttpGet]
        [Route("{id}")]
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
        public ActionResult<List<GameCard>> GetTopGames()
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
