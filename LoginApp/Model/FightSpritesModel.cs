using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonBackRules.Model
{
    public class FightSpritesModel
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }
}
