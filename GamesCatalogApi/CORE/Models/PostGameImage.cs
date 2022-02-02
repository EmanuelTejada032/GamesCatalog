using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class PostGameImage
    {
        public int gameId { get; set; }
        public IFormFile Image { get; set; }
    }
}
