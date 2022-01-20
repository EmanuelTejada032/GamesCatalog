using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface ISharedUtilitiesServices
    {
        public List<CatalogItem> GetGameGenresCatalog();
        public List<CatalogItem> GetGameTagsCatalog();
        public List<CatalogItem> GetLanguagesCatalog();
        public List<CatalogItem> GetReviewsRatingsCatalog();
        public List<CatalogItem> GetUsersRolesCatalog();
    }
}
