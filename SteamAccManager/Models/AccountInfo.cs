using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAccManager.Models
{
    public class AccountInfo
    {
        [JsonProperty("Nickname")]
        public string Nickname { get; set; }

        [JsonProperty("ProfileLink")]
        public string ProfileLink { get; set; }

        [JsonProperty("ProfileIcon")]
        public string ProfileIcon { get; set; }

        [JsonProperty("SteamID64")]
        public string SteamID64 { get; set; }
    }

}
