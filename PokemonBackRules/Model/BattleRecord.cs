﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBackRules.Model
{
    public class BattleRecord
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("dataStart")]
        public string DataStart { get; set; }
        [JsonPropertyName("dateEnd")]
        public string DateEnd { get; set; }
        [JsonPropertyName("pokeName")]
        public string PokeName { get; set; }
        [JsonPropertyName("damageDoneTrainer")]
        public int DamageDoneTrainer { get; set; }
        [JsonPropertyName("damageReceivedTrainer")]
        public int DamageReceivedTrainer { get; set; }
        [JsonPropertyName("damageDonePokemon")]
        public int DamageDonePokemon { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("catch")]
        public bool Catch { get; set; }
        [JsonPropertyName("shiny")]
        public bool Shiny { get; set; }
    }

}
