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
        //public List<string> GamesList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            WebClient webClient = new WebClient();
            string json = webClient.DownloadString("http://api.steampowered.com/ISteamApps/GetAppList/v0002/?key=STEAMKEY2&format=json");


            JObject jsonObject = JObject.Parse(json);
            JArray jsonArray = (JArray)jsonObject["applist"]["apps"];

            string[] gameNames = jsonArray.Select(app => app["name"]).Values<string>().ToArray<string>();
            int[] gameIDs = jsonArray.Select(app => app["appid"]).Values<int>().ToArray();



            Dictionary<int, string> GamesList = new Dictionary<int, string>();

            for (int i = 0; i < gameIDs.Count(); i++)
            {
                GamesList.Add(gameIDs[i], gameNames[i]);
            }

            //TextField.Text = String.Join("\n", strLst.ToArray<string>());
        }
    }
}
