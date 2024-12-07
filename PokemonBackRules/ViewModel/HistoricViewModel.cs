using CommunityToolkit.Mvvm.ComponentModel;
using PokemonBackRules.Model;
using PokemonBackRules.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace PokemonBackRules.ViewModel
{
    public partial class HistoricViewModel : ViewModelBase
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:7119/Pokemon"; // URL de tu API

        [ObservableProperty]
        private ObservableCollection<BattleRecord> battleRecords = new ObservableCollection<BattleRecord>();

        public HistoricViewModel()
        {
            // LoadAsync();
        }

        public override async Task LoadAsync()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var records = JsonSerializer.Deserialize<List<BattleRecord>>(json, options); 

                    if (records != null)
                    {
                        BattleRecords.Clear();

                        foreach (var record in records)
                        {
                            BattleRecords.Add(record);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Failed to load historic data: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading historic data: {ex.Message}");
            }
        }
    }
}
