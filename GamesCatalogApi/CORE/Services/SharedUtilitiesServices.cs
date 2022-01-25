using CORE.Interfaces;
using CORE.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class SharedUtilitiesServices: ISharedUtilitiesServices
    {
        IConfiguration _configuration;

        public SharedUtilitiesServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CatalogItem> GetGameGenresCatalog()
        {
            return GetCatalogList("Proc_Games_Genres_Cata_Get", new CatalogItem() { Name= "Genre_Name", Description = "Genre_Description" });
             
        }
        
        public List<CatalogItem> GetGameTagsCatalog()
        {
            return GetCatalogList("Proc_Games_Tags_Cata_Get", new CatalogItem() { Name= "Tag_Name", Description = "Tag_Description" });
             
        }

        public List<CatalogItem> GetLanguagesCatalog()
        {
            return GetCatalogList("Proc_Languages_Cata_Get", new CatalogItem() { Name = "Language_Name", Description = "Language_Description" });

        }
        public List<CatalogItem> GetReviewsRatingsCatalog()
        {
            return GetCatalogList("Proc_Review_Ratings_Cata_Get", new CatalogItem() { Name = "Rating_Value", Description = "Rating_Description" });

        }
        public List<CatalogItem> GetUsersRolesCatalog()
        {
            return GetCatalogList("Proc_Users_Role_Cata_Get", new CatalogItem() { Name = "Role_Name", Description = "Role_Description" });

        }


        public List<CatalogItem> GetCatalogList(string storedProcedure, CatalogItem catalogItem)
        { 
            
            List<CatalogItem> catalogList = new List<CatalogItem>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand cmd = new SqlCommand($"{storedProcedure}", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    CatalogItem catalog = new CatalogItem
                    {
                        Id = Convert.ToInt32(datareader["Id"]),
                        Name = datareader[$"{catalogItem.Name}"].ToString(),
                        Description = datareader[$"{catalogItem.Description}"].ToString()
                    };
                    catalogList.Add(catalog);
                }
                con.Close();

            }
            return catalogList;

        }
        


    }
}
