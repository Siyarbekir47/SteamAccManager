using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamAccManager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.Win32;
using SteamAccManager.Models;

namespace SteamAccManager.DataAccess
{

    public class GameDataAccess
    {
        private readonly string _appFolder;

        public GameDataAccess(string appFolder)
        {
            _appFolder = appFolder;
        }

        public List<GameInfo> GetUserGames(string steamID64)
        {
            string gamesFilePath = Path.Combine(_appFolder, steamID64 + "Gi.json");
            if (File.Exists(gamesFilePath))
            {
                string json = File.ReadAllText(gamesFilePath);
                return JsonConvert.DeserializeObject<List<GameInfo>>(json);
            }
            return new List<GameInfo>();
        }


        public static String GetCurrentSteamID64()
        {
            string SteamID3 = null;
            string SteamID64 = null;
            string SteamID64_BASE = "76561197960265728";


            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam\ActiveProcess"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("ActiveUser");
                        if (o != null)
                        {
                            SteamID3 = o.ToString();
                            if (SteamID3 == "0")
                            {
                                MessageBox.Show("Login to Steam first.");
                                return null;
                            }

                            Int64 SteamID3Int = 0;
                            Int64 SteamID64Int = 0;

                            Int64.TryParse(SteamID3, out SteamID3Int);
                            Int64.TryParse(SteamID64_BASE, out SteamID64Int);


                            return (SteamID3Int + SteamID64Int).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public List<GameInfo> LoadUserGames(string steamID64)
        {
            List<GameInfo> loadedGames = new List<GameInfo>();
            string gamesFilePath = Path.Combine(_appFolder, steamID64 + "Gi.json");
            if (File.Exists(gamesFilePath))
            {

                // Logic to load and deserialize the games
                string json = File.ReadAllText(gamesFilePath);
                loadedGames = JsonConvert.DeserializeObject<List<GameInfo>>(json);
                return loadedGames;
            }
            return loadedGames;
        }


        public string GetIconPath(string appID)
        {
            string myResourcesFolder = Path.Combine(_appFolder, "Resources");
            string iconPath = Path.Combine(myResourcesFolder, appID + ".jpg");
            if (!File.Exists(iconPath))
            {
                iconPath = Path.Combine(myResourcesFolder, "0.jpg"); // Default icon
            }
            return iconPath;
        }


    }
}
