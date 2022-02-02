using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IGameServices
    {
        public int RegisterGame(Game newGameData);
        public List<GameCard> GetGameList(Pagination paginationData);
        public GameDetail GetGameDetailById(int id);
        public List<GameCard> GetTopGames();
        public Task<string> UploadFrontPageImage(PostGameImage postImageData , string localPath);

    }
}
