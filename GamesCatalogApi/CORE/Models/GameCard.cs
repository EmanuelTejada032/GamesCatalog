using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class GameCard: PaginationListConfig
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public string ReleaseDate { get; set; }

        public string Studio { get; set; }

    }
}
