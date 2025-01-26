using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonBackRules.Model
{
    public class PokemonResponseModel
    {
        [JsonPropertyName("sprites")]
        public FightSprites FightSprites { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class FightSprites
    {
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string FrontShiny { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("stat")]
        public StatInfo StatInfo { get; set; }
    }

    public class StatInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("attack")]
        public string Attack { get; set; }
    }
}
