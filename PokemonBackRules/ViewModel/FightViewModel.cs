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

        private string _pokemonImage;
        public string PokemonImage
        {
            get => _pokemonImage;
            set
            {
                _pokemonImage = value;
                OnPropertyChanged(nameof(PokemonImage));
            }
        }

        public FightViewModel()
        {
            LoadRandomPokemon();
        }

        [RelayCommand]
        private void Scape()
        {
            LoadRandomPokemon();
        }

        private async void LoadRandomPokemon()
        {
            try
            {
                int randomId = random.Next(1, 101); 
                string apiUrl = $"{PokeApiUrl}{randomId}";

                HttpResponseMessage response = await HttpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var pokemonData = JsonSerializer.Deserialize<PokemonResponseModel>(json);

                    bool useShinySprite = random.Next(0, 100) < 5;
                    PokemonImage = useShinySprite ?
                        pokemonData.FightSprites.FrontShiny ?? Constantes.MISSINGNO_IMAGE_PATH :
                        pokemonData.FightSprites.FrontDefault ?? Constantes.MISSINGNO_IMAGE_PATH;

                    }
                    else
                {
                    PokemonImage = "..Resources\\missingNo.jpg";
                }
            }
            catch (Exception ex)
            {
                PokemonImage = "..Resources\\missingNo.jpg";
            }
        }


        private void PerformScape()
        {
        }
    }
}