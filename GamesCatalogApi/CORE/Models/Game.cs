using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class Game
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        //public List<IFormFile> Images { get; set; }
        public float Price { get; set; }
        //public int? User { get; set; }
        public int? Studio { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<int>? Genres { get; set; }
        public ICollection<int>? Languages { get; set; }
        public ICollection<int>? Tags { get; set; }
        public int Status { get; set; }
        public string? SystemRequirements { get; set; }

    }
}
