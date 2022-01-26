using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class GameDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string StudioName { get; set; }
        public string ReleaseDate { get; set; }

        public List<string>? Genres { get; set; }
        public List<string>? Languages { get; set; }
        public List<string>? Tags { get; set; }
        public string Status { get; set; }
        public string? SystemRequirements { get; set; }
    }
}
