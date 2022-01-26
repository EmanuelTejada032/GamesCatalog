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
        public float Price { get; set; }
        //public int? User { get; set; }
        public int? Studio { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<int>? Genres { get; set; }
        public List<int>? Languages { get; set; }
        public List<int>? Tags { get; set; }
        public int Status { get; set; }
        public string? SystemRequirements { get; set; }

    }
}
