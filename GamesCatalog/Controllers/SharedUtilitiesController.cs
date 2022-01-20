using CORE.Interfaces;
using CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedUtilitiesController: ControllerBase
    {
        ISharedUtilitiesServices _sharedUtilitiesServices;

        public SharedUtilitiesController(ISharedUtilitiesServices sharedUtilitiesServices)
        {
            _sharedUtilitiesServices = sharedUtilitiesServices;
        }

        [HttpGet("GetGenresCata")]
        public ActionResult<List<CatalogItem>> GetGameGenresCatalog()
        {
            return Ok(_sharedUtilitiesServices.GetGameGenresCatalog());
        }

        [HttpGet("GetTagsCata")]
        public ActionResult<List<CatalogItem>> GetGameTags()
        {
            return Ok(_sharedUtilitiesServices.GetGameTagsCatalog());
        }
        
        [HttpGet("GetLanguagesCata")]
        public ActionResult<List<CatalogItem>> GetLanguages()
        {
            return Ok(_sharedUtilitiesServices.GetLanguagesCatalog());
        }

        [HttpGet("GetRatingsCata")]
        public ActionResult<List<CatalogItem>> GetRatingsCata()
        {
            return Ok(_sharedUtilitiesServices.GetReviewsRatingsCatalog());
        }

        [HttpGet("GetRolesCata")]
        public ActionResult<List<CatalogItem>> GetRoles()
        {
            return Ok(_sharedUtilitiesServices.GetUsersRolesCatalog());
        }

    }
}
