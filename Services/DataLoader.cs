﻿using System;
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
        public IList<PlayersModel> LoadPlayersData()
        {
            using(StreamReader r = new StreamReader(@"wwwroot/mockdata/fitnessrating_beeptest.json"))
            {
                string json = r.ReadToEnd();
                var jsonStr = JsonSerializer.Deserialize<FintessRatingModel>(json);
            }

            PlayersModel[] listOfPlayers = new PlayersModel[15]
                {
               new PlayersModel() { firstName = "Ashton", lastName = "Eaton" },
               new PlayersModel() { firstName = "Brayan", lastName = "Clay" },
               new PlayersModel() { firstName = "Dean", lastName = "Karnazes" },
               new PlayersModel() { firstName = "Usain", lastName = "Bolt" },
               new PlayersModel() { firstName = "Dep", lastName = "Johny" },
               new PlayersModel() { firstName = "Abhilash", lastName = "Virat" },
               new PlayersModel() { firstName = "Sachin", lastName = "Tendulkar" },
               new PlayersModel() { firstName = "James", lastName = "Bond" },
               new PlayersModel() { firstName = "Steve", lastName = "Rogers" },
               new PlayersModel() { firstName = "Scarlet", lastName = "Johnson" },
               new PlayersModel() { firstName = "Emilie", lastName = "Clark" },
               new PlayersModel() { firstName = "Diana", lastName = "Hayden" },
               new PlayersModel() { firstName = "Salina", lastName = "Kayele" },
               new PlayersModel() { firstName = "Ronaldo", lastName = "Christiano" },
               new PlayersModel() { firstName = "Stephinie", lastName = "Mcmohan" }
                };

            return listOfPlayers.ToList<PlayersModel>();
        }
    }
}
