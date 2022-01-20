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
    public class GameServices: IGameServices
    {
        IConfiguration _configuration;

        public GameServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int RegisterGame(Game newGameData)
        {

            int gameId = 0;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand command = new SqlCommand("Proc_Games_Trans_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Title", newGameData.Title);
                command.Parameters.AddWithValue("@Description", newGameData.Description);
                command.Parameters.AddWithValue("@Price", newGameData.Price);
                command.Parameters.AddWithValue("@Release_Date", newGameData.ReleaseDate);
                command.Parameters.AddWithValue("@System_Requirements", newGameData.SystemRequirements);

                connection.Open();
                gameId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                this.AddGameGenres("Proc_Games_Genres_Trans_Insert", new CatalogPostData() { ResourceParentId = gameId, ItemsIdList = newGameData.Genres });
                this.AddGameTags("Proc_Games_Tags_Trans_Insert", new CatalogPostData() { ResourceParentId = gameId, ItemsIdList = newGameData.Tags });
                this.AddGameLanguages("Proc_Games_Languages_Trans_Insert", new CatalogPostData() { ResourceParentId = gameId, ItemsIdList = newGameData.Languages });
               

            }
            return gameId;
        }


        private void AddGameGenres(string storedProcedure, CatalogPostData gameGenresIdList)
        {
            this.AddCatlogList(storedProcedure, gameGenresIdList);
        }

        private void AddGameTags(string storedProcedure, CatalogPostData gameTagsIdList)
        {
            this.AddCatlogList(storedProcedure, gameTagsIdList);

        }

        private void AddGameLanguages(string storedProcedure, CatalogPostData gameLanguagesIdList)
        {
            this.AddCatlogList( storedProcedure, gameLanguagesIdList);
        }



        private void AddCatlogList(string storedProcedure,  CatalogPostData catalogPostData)
        {


            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                DataTable itemIdList = new DataTable();
                itemIdList.Columns.Add("Resource_Id");

                foreach (int item in catalogPostData.ItemsIdList)
                {
                    itemIdList.Rows.Add(item);
                }

                SqlCommand command = new SqlCommand($"{storedProcedure}", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Resource_Parent_Id", catalogPostData.ResourceParentId);
                command.Parameters.AddWithValue("@Resource_Id_List", itemIdList);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

       
    }
}
