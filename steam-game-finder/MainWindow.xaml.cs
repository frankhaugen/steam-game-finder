using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;


//using System.Net.Http;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

namespace steam_game_finder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataGrid GamesDetails = new DataGrid();
        public Dictionary<int, string> GamesList = new Dictionary<int, string>();
        public WebClient webClient = new WebClient();

        //public List<string> GamesList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            

            //TextField.Text = String.Join("\n", strLst.ToArray<string>());
        }

        private void ButtonFetchList_Click(object sender, RoutedEventArgs e)
        {
            string json = webClient.DownloadString("http://api.steampowered.com/ISteamApps/GetAppList/v0002/?key=STEAMKEY2&format=json");
            
            JObject jsonObject = JObject.Parse(json);
            JArray jsonArray = (JArray)jsonObject["applist"]["apps"];

            string[] gameNames = jsonArray.Select(app => app["name"]).Values<string>().ToArray<string>();
            int[] gameIDs = jsonArray.Select(app => app["appid"]).Values<int>().ToArray();

            for (int i = 0; i < gameIDs.Count(); i++)
            {
                GamesList.Add(gameIDs[i], gameNames[i]);
            }
        }

        private void ButtonCollectDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        /*
         * 
         * {
           "421170": {
              "success": true,
              "data": {
                 "type": "game",
                 "name": "Indivisible",
                 "steam_appid": 421170,
                 "required_age": 0,
                 "is_free": false,
                 "controller_support": "full",
                 "short_description": "Indivisible is a new, action-packed RPG from Lab Zero, creators of the critically acclaimed Skullgirls! Set in a huge fantasy world, Indivisible tells the story of Ajna, a good-natured tomboy with a rebellious streak who sets out on a quest to save everything she knows from being destroyed.",
                 "header_image": "https://steamcdn-a.akamaihd.net/steam/apps/421170/header.jpg?t=1531794027",
                 "website": "http://indivisiblegame.com/",
                 "developers": [
                    "Lab Zero Games"
                 ],
                 "publishers": [
                    "505 Games"
                 ],
                 "platforms": {
                    "windows": true,
                    "mac": true,
                    "linux": true
                 },
                 "categories": [
                    {
                       "id": 2,
                       "description": "Single-player"
                    },
                    {
                       "id": 28,
                       "description": "Full controller support"
                    }
                 ],
                 "genres": [
                    {
                       "id": "1",
                       "description": "Action"
                    },
                    {
                       "id": "23",
                       "description": "Indie"
                    },
                    {
                       "id": "3",
                       "description": "RPG"
                    }
                 ],
                 "release_date": {
                    "coming_soon": true,
                    "date": "Early 2019"
                 },
                 "support_info": {
                    "url": "http://support.505games.com/support/home",
                    "email": ""
                 }
              }
           }
}
         * 
         */
    }
}
