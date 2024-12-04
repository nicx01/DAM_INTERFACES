using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonBackRules.Model;
using PokemonBackRules.Models;
using PokemonBackRules.Utils;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace PokemonBackRules.ViewModel
{
    public partial class FightViewModel : ViewModelBase
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string PokeApiUrl = "https://pokeapi.co/api/v2/pokemon/";
        private Random random = new Random();

        [ObservableProperty]
        private string _pokemonImage;
        [ObservableProperty]
        private int _opponentHealth;
        [ObservableProperty]
        private int _maxOpponentHealth = 100; //default
        [ObservableProperty]
        private int _playerHealth = 1000; 
        [ObservableProperty]
        private int _maxPlayerHealth = 1000; 
        [ObservableProperty]
        private int _pokemonAttack = 0;

        public FightViewModel()
        {
            LoadRandomPokemon();
        }

        [RelayCommand]
        public void Scape()
        {
            LoadRandomPokemon();
        }
        [RelayCommand]

        public void ApplyDamage()
        {
            Random random = new Random();
            int damage = random.Next(0, 41); OpponentHealth -= damage;
            if (OpponentHealth <= 0) LoadRandomPokemon();
            else PlayerHealth -= PokemonAttack;
        }
        private async Task LoadRandomPokemon()
        {
            try
            {
                int randomId = random.Next(1, 101);
                string apiUrl = $"{PokeApiUrl}{randomId}";

                HttpResponseMessage response = await HttpClient.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    SetDefaultPokemonImage();
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var pokemonData = JsonSerializer.Deserialize<PokemonResponseModel>(json, options);

                if (pokemonData == null)
                {
                    SetDefaultPokemonImage();
                    return;
                }

                var hpStat = pokemonData.Stats.FirstOrDefault(s => s.StatInfo.Name == "hp");
                var attackStat = pokemonData.Stats.FirstOrDefault(s => s.StatInfo.Name == "attack");
                MaxOpponentHealth = hpStat?.BaseStat ?? 100;
                OpponentHealth = MaxOpponentHealth;
                PokemonAttack = attackStat?.BaseStat ?? 10;

                bool useShinySprite = random.Next(0, 100) < 5;
                PokemonImage = useShinySprite
                    ? pokemonData.FightSprites.FrontShiny ?? Constantes.MISSINGNO_IMAGE_PATH
                    : pokemonData.FightSprites.FrontDefault ?? Constantes.MISSINGNO_IMAGE_PATH;
            }
            catch (Exception ex)
            {
                SetDefaultPokemonImage();
                Console.WriteLine($"Error loading Pokémon: {ex.Message}");
            }
        }

        private void SetDefaultPokemonImage()
        {
            PokemonImage = Constantes.MISSINGNO_IMAGE_PATH;
            MaxOpponentHealth = 100;
            OpponentHealth = MaxOpponentHealth;
        }
    }
}