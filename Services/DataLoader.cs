using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using YoYo_Web_App.Models;


namespace YoYo_Web_App.Services
{
    public class DataLoader
    {
        public YoYoViewModel GetPlayersData()
        {
            var pleayersList = new List<PlayersModel>
                {
               new PlayersModel() {  _id = 1, firstName = "Ashton", lastName = "Eaton" },
               new PlayersModel() {  _id = 2, firstName = "Brayan", lastName = "Clay" },
               new PlayersModel() {  _id = 3, firstName = "Dean", lastName = "Karnazes" },
               new PlayersModel() {  _id = 4, firstName = "Usain", lastName = "Bolt" },
               new PlayersModel() {  _id = 5, firstName = "Dep", lastName = "Johny" },
               new PlayersModel() {  _id = 6, firstName = "Abhilash", lastName = "Virat" },
               new PlayersModel() {  _id = 7, firstName = "Sachin", lastName = "Tendulkar" },
               new PlayersModel() {  _id = 8, firstName = "James", lastName = "Bond" },
               new PlayersModel() {  _id = 9, firstName = "Steve", lastName = "Rogers" },
               new PlayersModel() {  _id = 10, firstName = "Scarlet", lastName = "Johnson" },
               new PlayersModel() {  _id = 11, firstName = "Emilie", lastName = "Clark" },
               new PlayersModel() {  _id = 12, firstName = "Diana", lastName = "Hayden" },
               new PlayersModel() {  _id = 13, firstName = "Salina", lastName = "Kayele" },
               new PlayersModel() {  _id = 14, firstName = "Ronaldo", lastName = "Christiano" },
               new PlayersModel() {  _id = 15, firstName = "Stephinie", lastName = "Mcmohan" }
                };


            IList<FintessRatingModel> fintessRatinngMetaData;
            using (StreamReader r = new StreamReader(@"wwwroot/mockdata/fitnessrating_beeptest.json"))
            {
                string jsonString = r.ReadToEnd();
                fintessRatinngMetaData = JArray.Parse(jsonString).Select(ratingObj => new FintessRatingModel
                {
                    AccumulatedShuttleDistance = (int)ratingObj["AccumulatedShuttleDistance"],
                    SpeedLevel = (int)ratingObj["SpeedLevel"],
                    ShuttleNo = (int)ratingObj["ShuttleNo"],
                    Speed = (float)ratingObj["Speed"],
                    LevelTime = (float)ratingObj["LevelTime"],
                    CommulativeTime = (string)ratingObj["ApproxVo2Max"],
                    StartTime = (string)ratingObj["StartTime"],
                    ApproxVo2Max = (string)ratingObj["ApproxVo2Max"]
                }).ToList();
            }

            var jsonData = JsonConvert.SerializeObject(new { pleayersList = pleayersList, fintessRatinngMetaData = fintessRatinngMetaData });
            return new YoYoViewModel { pleayersList = pleayersList, fintessRatinngMetaData = fintessRatinngMetaData, JSONContent = jsonData };

        }


    }
}
