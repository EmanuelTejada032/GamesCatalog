using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class CatalogPostData
    {
        public int ResourceParentId { get; set; }
        public List<int> ItemsIdList { get; set; }
    }
}
