using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class PaginationListConfig
    {
        public int StartLine { get; set; }
        public int LastLine { get; set; }
        public int TotalItems { get; set; }
    }
}
