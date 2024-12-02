using System;
using System.Text.Json.Serialization;

namespace PokemonBackRules.Model
{
    public class PokemonResponseModel
    {
        [JsonPropertyName("sprites")]
        public FightSprites FightSprites { get; set; }
    }

    public class FightSprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }
}
