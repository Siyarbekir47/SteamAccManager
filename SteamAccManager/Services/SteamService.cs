using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccManager.Services
{
    public class SteamService
    {
        private readonly string _apkiKey;
        private readonly string _appFolder;
        private readonly string _resourcesFolder;

        public SteamService(string apiKey, string appFolder, string resourcesFolder)
        {
            _apkiKey = apiKey;
            _appFolder = appFolder;
            _resourcesFolder = resourcesFolder;
        }

        public async Task<string> GetSteamBib(string steamid64)
        {
            string urlGames = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={_apkiKey}&steamid={steamid64}&format=json&include_appinfo=1";
            string urlAccount = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={_apkiKey}&format=json&steamids={steamid64}";
            string urlProfile = $"https://steamcommunity.com/profiles/{steamid64}";
            if (steamid64 == null)
            {
                MessageBox.Show("Keine SteamID64 gefunden.");
                return null;
            }


            using (HttpClient client = new HttpClient())
            {
                var firstResponse = await client.GetStringAsync(urlGames);
                var gamesJsonData = JObject.Parse(firstResponse);
                string gamesFilePath = Path.Combine(_appFolder, steamid64 + "Gi.json");
                var gamesArray = gamesJsonData["response"]["games"] as JArray; // Cast to JArray to access the array methods



                if (gamesArray != null && gamesArray.Count > 0)
                {
                    // There are games in the JSON data, so you can proceed with processing
                    var games = gamesJsonData["response"]["games"].Select(game => new
                    {
                        Name = game["name"].ToString(),
                        AppID = game["appid"].ToString(),
                        Playtime = game["playtime_forever"].ToString(),
                        IconURL = game["img_icon_url"].ToString()
                    }).ToList();


                    if (File.Exists(gamesFilePath))
                    {
                        File.Delete(gamesFilePath);
                    }


                    MessageBox.Show("Spiele gefunden.");
                    // Serialize the list of games to JSON as an array



                    // download the image of the game icons for every appid found in the gameArray
                    foreach (var img in games)
                    {
                        string tempFilePath = Path.Combine(_resourcesFolder, img.AppID + ".jpg");
                        if (!File.Exists(tempFilePath))
                        {
                            string urlGameIcon = $"https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/{img.AppID}/{img.IconURL}.jpg";
                            using (var client2 = new HttpClient())
                            {

                                var response = await client2.GetAsync(urlGameIcon);
                                if (response.IsSuccessStatusCode)
                                {
                                    using (var stream = await response.Content.ReadAsStreamAsync())
                                    using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                                    {
                                        await stream.CopyToAsync(fileStream);
                                    }
                                }



                            }
                        }
                    }


                    string json = JsonConvert.SerializeObject(games, Formatting.Indented);


                    // Write the JSON to the file
                    File.WriteAllText(gamesFilePath, json);
                }
                else
                {
                    //lstvGames.Items.Clear();
                    MessageBox.Show(@"  -Keine Spiele gefunden.-
1. Stelle sicher das dein Profil Öffentlich ist.
2. Stelle sicher das die Spieldetails auf Öffentlich ist.
            (Diese einstellung findest du unter:)
(->Profil bearbeiten->Datenschutzeinstellungen-> Spieldetails)");

                }


                var secondResponse = await client.GetStringAsync(urlAccount);
                var accountJsonData = JObject.Parse(secondResponse);
                string accountFilePath = Path.Combine(_appFolder, steamid64 + "Ai.json");

                var account = accountJsonData["response"]["players"].Select(account => new
                {
                    SteamID64 = account["steamid"].ToString(),
                    Nickname = account["personaname"].ToString(),
                    ProfileLink = account["profileurl"].ToString(),
                    ProfileIcon = account["avatarfull"].ToString()
                }).ToList();


                // Delete the file if it exists

                if (File.Exists(accountFilePath))
                {
                    File.Delete(accountFilePath);
                }



                if (account.Count == 0)
                {
                    MessageBox.Show("Kein Account gefunden.");
                }
                else
                {
                    string json = JsonConvert.SerializeObject(account, Formatting.Indented);
                    File.WriteAllText(accountFilePath, json);
                }
                return null;
            }
        }

    }
}
