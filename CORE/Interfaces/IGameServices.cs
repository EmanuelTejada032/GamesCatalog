using CORE.Models;
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
    }
}
