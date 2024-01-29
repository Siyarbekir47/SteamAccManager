using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccManager.Models
{
    public class GameInfo
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AppID")]
        public string AppID { get; set; }

        [JsonProperty("playtime_forever")]
        public string Playtime { get; set; }

        [JsonProperty("img_icon_url")]
        public string IconURL { get; set; }

    }
}
