using CORE.Interfaces;
using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class GameServices: IGameServices
    {

        IConfiguration _configuration;

        Random random = new Random();

        public GameServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<GameCard> GetGameList(Pagination paginationData)
        {
            List<GameCard> gamesList = new List<GameCard>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand command = new SqlCommand("Proc_Games_Trans_GetList", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Page_Index", paginationData.PageIndex);
                command.Parameters.AddWithValue("@Page_Size", paginationData.PageSize);
                command.Parameters.AddWithValue("@Search_Term", paginationData.SearchTerm);

                connection.Open();
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    GameCard game = new GameCard
                    {
                        Id = Convert.ToInt32(datareader["Id"]),
                        Title = datareader["Title"].ToString(),
                        //Image = datareader["Image"].ToString(),
                        Image = "https://assets.nintendo.com/image/upload/c_pad,f_auto,h_613,q_auto,w_1089/ncom/es_LA/games/switch/e/enter-the-gungeon-switch/hero?v=2021120608",
                        Price = Convert.ToInt32(datareader["Price"]),
                        ReleaseDate = datareader["Release_Date"].ToString(),
                        Studio = datareader["Studio_Name"].ToString(),
                        StartLine = Convert.ToInt32(datareader["Start_Line"]),
                        LastLine = Convert.ToInt32(datareader["Last_Line"]),
                        TotalItems = Convert.ToInt32(datareader["Total_Rows"]),
                    };

                    

                    gamesList.Add(game);
                }
                connection.Close();


            }

            return gamesList;
        }

        public GameDetail GetGameDetailById(int gameId)
        {

            GameDetail gameDetail = new GameDetail();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand command = new SqlCommand("Proc_Games_Trans_GetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Game_Id",gameId);


                connection.Open();
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    gameDetail = new GameDetail
                    {
                        Id = gameId,
                        Title = datareader["Title"].ToString(),
                        Image = "https://assets.nintendo.com/image/upload/c_pad,f_auto,h_613,q_auto,w_1089/ncom/es_LA/games/switch/e/enter-the-gungeon-switch/hero?v=2021120608",
                        ////Image = datareader["Image"].ToString(),
                        Description = datareader["Description"].ToString(),
                        Price = Convert.ToInt32(datareader["Price"]),
                        StudioName = datareader["Studio_Name"].ToString(),
                        ReleaseDate = datareader["Release_Date"].ToString(),
                        Genres = GetGameGenres(gameId),
                        Languages = GetGameLanguages(gameId),
                        Tags = GetGameTags(gameId),
                        Status = datareader["Status_Name"].ToString(),
                        SystemRequirements = datareader["System_Requirements"].ToString()
                    };

                }
                connection.Close();


            }
            return gameDetail;
        }

        private List<string> GetGameTags(int id)
        {
            return GetPropertiesList("Proc_Games_Tags_Trans_GetByGameId", (id, "Tag_Name"));
        }

        private List<string> GetGameLanguages(int id)
        {
            return GetPropertiesList("Proc_Games_Languages_Trans_GetByGameId", (id, "Language_Name"));

        }

        private List<string> GetGameGenres(int id)
        {
            return GetPropertiesList("Proc_Games_Genres_Trans_GetByGameId", (id, "Genre_Name"));
        }


        private List<string> GetPropertiesList(string storedProcedure, (int gameId, string propertyName) procedureConfig)
        {
            List<string> propertyList = new List<string>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand command = new SqlCommand($"{storedProcedure}", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue($"@Game_Id", procedureConfig.gameId);

                connection.Open();
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string property = datareader[$"{procedureConfig.propertyName}"].ToString();
                    propertyList.Add(property);
                }
                connection.Close();


            }

            return propertyList;
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
                command.Parameters.AddWithValue("@Studio_Id", newGameData.Studio);
                command.Parameters.AddWithValue("@Release_Date", newGameData.ReleaseDate);
                command.Parameters.AddWithValue("@System_Requirements", newGameData.SystemRequirements);

                connection.Open();
                gameId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                //this.AddGameGenres(gameId, newGameData.Genres);
                //this.AddGameTags(gameId, newGameData.Tags);
                //this.AddGameLanguages( gameId,newGameData.Languages );

            }

            return gameId;
        }


        public List<GameCard> GetTopGames()
        {
            List<GameCard> topGamesList = new List<GameCard>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand command = new SqlCommand("Proc_Games_Trans_GetTopGames", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    GameCard game = new GameCard
                    {
                        Id = Convert.ToInt32(datareader["Game_Id"]),
                        Title = datareader["Title"].ToString(),
                        Image = datareader["Image"].ToString(),
                        Price = Convert.ToInt32(datareader["Price"]),
                        ReleaseDate = datareader["Release_Date"].ToString(),
                        Studio = datareader["Studio_Name"].ToString()
                    };
                    topGamesList.Add(game);
                }
                connection.Close();


            }
            return topGamesList;
        }

        private void AddGameGenres(int gameId, List<int> gameGenresIdList)
        {
            this.AddCatlogList("Proc_Games_Genres_Trans_Insert",new CatalogPostData {ResourceParentId = gameId, ItemsIdList =  gameGenresIdList });
        }

        private void AddGameTags(int gameId, List<int> gameTagsIdList)
        {
            this.AddCatlogList("Proc_Games_Tags_Trans_Insert", new CatalogPostData { ResourceParentId = gameId, ItemsIdList = gameTagsIdList });

        }

        private void AddGameLanguages(int gameId, List<int> gameLanguagesIdList)
        {
            this.AddCatlogList("Proc_Games_Languages_Trans_Insert", new CatalogPostData { ResourceParentId = gameId, ItemsIdList = gameLanguagesIdList });
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

        public async Task<string> UploadFrontPageImage(PostGameImage postImageData, string localPath)
        {
            
                string fileName = postImageData.Image.FileName.Split('.')[0];
                string fileExtension = postImageData.Image.FileName.Split('.')[postImageData.Image.FileName.Split('.').Length -1];
                string uniqueName = fileName + "-" + random.Next(1000000,10000000)+ $".{fileExtension}";
                string fileSize = (postImageData.Image.Length / 1000000).ToString() + "mb";

                var folderPathServer = Path.Combine(GetFilePath("Game_Images"), uniqueName);
                string localFolderPath = Path.Combine(Path.Combine(localPath, "Files/GameImages"), uniqueName);

                using (var fileStream = new FileStream(localFolderPath, mode: FileMode.Create))
                {
                    if (localFolderPath != null)
                    {
                        await postImageData.Image.CopyToAsync(fileStream);
                    }
                }

                GameImage gameImage = new GameImage()
                {
                    FileName = fileName,
                    FileExtension = fileExtension,
                    FilePath = folderPathServer,
                    FileSize = fileSize
                };

                this.SaveImageData(postImageData.gameId, gameImage);

                return folderPathServer;            
        
        }

        private void SaveImageData(int gameId, GameImage gameImage)
        {
             
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand command = new SqlCommand("Proc_Games_Images_Trans_Insert", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Game_Id", gameId);
                command.Parameters.AddWithValue("@File_Name", gameImage.FileName);
                command.Parameters.AddWithValue("@File_Extension", gameImage.FileExtension);
                command.Parameters.AddWithValue("@File_Path", gameImage.FilePath);
                command.Parameters.AddWithValue("@File_Size", gameImage.FileSize);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        private string GetFilePath(string parameterCode)
        {
            string serverPath = "";
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("gamesCatalogConection")))
            {
                SqlCommand command = new SqlCommand("Proc_System_Parameter_Config_GetPaths", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Parameter_Code", parameterCode);

                connection.Open();
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    serverPath = datareader["Parameter_Value"].ToString();
                }
                connection.Close();

            }

            return serverPath;
        }
    }
}
