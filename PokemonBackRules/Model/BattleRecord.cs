using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBackRules.Model
{
    public class BattleRecord
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("DataStart")]
        public string DataStart { get; set; }
        [JsonPropertyName("DateEnd")]
        public string DateEnd { get; set; }
        [JsonPropertyName("PokeName")]
        public string PokeName { get; set; }
        [JsonPropertyName("DamageDoneTrainer")]
        public int DamageDoneTrainer { get; set; }
        [JsonPropertyName("DamageReceivedTrainer")]
        public int DamageReceivedTrainer { get; set; }
        [JsonPropertyName("DamageDonePokemon")]
        public int DamageDonePokemon { get; set; }
        [JsonPropertyName("Image")]
        public string Image { get; set; }
        [JsonPropertyName("Catch")]
        public bool Catch { get; set; }
        [JsonPropertyName("Shiny")]
        public bool Shiny { get; set; }
    }

}
