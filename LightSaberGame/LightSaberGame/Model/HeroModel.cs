using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.Model
{
    [JsonObject]
    public class HeroModel
    {
        public HeroModel()
            : this(string.Empty, string.Empty)
        {

        }

        public HeroModel(string name, string score)
        {
            this.Name = name;
            this.Score = score;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }
    }
}
