using CommunityToolkit.Mvvm.ComponentModel;
using PokemonBackRules.Model;
using PokemonBackRules.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace PokemonBackRules.ViewModel
{
    public partial class TeamViewModel : ViewModelBase
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string ApiUrl = Constantes.POKE_TEAM_URL;

        private Random random = new Random();

        [ObservableProperty]
        private ObservableCollection<PokemonSummary> pokemonSummaries = new ObservableCollection<PokemonSummary>();

        public TeamViewModel()
        {
            // Cargar los Pokémon capturados al inicializar
            // LoadCapturedPokemons();
        }

        public override async Task LoadAsync()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    List<BattleRecord> pokemonList = JsonSerializer.Deserialize<List<BattleRecord>>(json);

                    if (pokemonList != null)
                    {
                        var pokemonSummariesList = pokemonList
                            .Where(p => !string.IsNullOrEmpty(p.PokeName)) // Filtrar por Pokémon con nombre
                            .GroupBy(p => p.PokeName)
                            .Select(g => new PokemonSummary
                            {
                                PokeName = g.Key,
                                Image = g.FirstOrDefault(p => p.Shiny)?.Image ?? g.First().Image, 
                                Shiny = g.Any(p => p.Shiny), // Si hay al menos un Pokémon Shiny en el grupo, se pone Shiny=true
                                Count = g.Count() // Número de veces que aparece ese Pokémon
                            })
                            .ToList();

                        PokemonSummaries.Clear();
                        foreach (var summary in pokemonSummariesList)
                        {
                            PokemonSummaries.Add(summary);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Pokémon: {ex.Message}");
            }
        }

        // Clase de resumen de Pokémon
        public class PokemonSummary
        {
            public string PokeName { get; set; }
            public string Image { get; set; }
            public int Count { get; set; }
            public bool Shiny { get; set; }
        }
    }
}
