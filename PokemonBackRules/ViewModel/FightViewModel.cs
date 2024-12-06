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
        [ObservableProperty]
        public ObservableCollection<BattleRecord> _battleRecords = new ObservableCollection<BattleRecord>();
        [ObservableProperty]
        private string _pokemonName;



        private bool isShiny = false;
        private DateTime start;
        private int damageDone=0;
        private int damageReceived=0;
        private int healthFightStarted = 0;

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
            int damage = random.Next(0, 41); 
            OpponentHealth -= damage;
            damageDone += damage;
            if (OpponentHealth <= 0)
            {
                LoadRandomPokemon();
                FinalizeBattleRecord(false);
            }
            else GetDamage();
        }

        private void GetDamage()
        {
            PlayerHealth -= PokemonAttack;
            damageReceived += PokemonAttack;
        }

        [RelayCommand]
        public void Capture()
        {
            if (OpponentHealth <= 0)
            {
                return;
            }
            double captureProbability = 1.0 - (OpponentHealth / (double)MaxOpponentHealth);
            double roll = random.NextDouble();
            if (roll <= captureProbability)
            {

                if (isShiny)
                {
                    PlayerHealth = MaxPlayerHealth; 
                }
                else
                {
                    PlayerHealth = Math.Min(PlayerHealth + (int)(MaxPlayerHealth * 0.05), MaxPlayerHealth);
                }
                FinalizeBattleRecord(true);
                LoadRandomPokemon();
            }
            else
            {
                GetDamage();           
            }
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
                PokemonName = pokemonData.Name;

                var hpStat = pokemonData.Stats.FirstOrDefault(s => s.StatInfo.Name == "hp");
                var attackStat = pokemonData.Stats.FirstOrDefault(s => s.StatInfo.Name == "attack");
                MaxOpponentHealth = hpStat?.BaseStat ?? 100;
                OpponentHealth = MaxOpponentHealth;
                PokemonAttack = attackStat?.BaseStat ?? 10;

                bool useShinySprite = random.Next(0, 100) < 5;
                isShiny = useShinySprite;
                PokemonImage = useShinySprite
                    ? pokemonData.FightSprites.FrontShiny ?? Constantes.MISSINGNO_IMAGE_PATH
                    : pokemonData.FightSprites.FrontDefault ?? Constantes.MISSINGNO_IMAGE_PATH;
                start = DateTime.Now;
                damageDone = 0;
                damageReceived = 0;
                healthFightStarted = PlayerHealth;
                CreateBattleRecord();
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
        private void FinalizeBattleRecord(bool isCaptured)
        {
            var record = BattleRecords.LastOrDefault();

            if (record != null)
            {
                record.DateEnd = DateTime.Now; 
                record.DamageDoneTrainer = damageDone; 
                record.DamageReceivedTrainer = damageReceived; 
                record.DamageDonePokemon = Math.Max(0, healthFightStarted - PlayerHealth); 
                record.Catch = isCaptured; 
            }
        }

        private void CreateBattleRecord()
        {
            var record = new BattleRecord
            {
                DataStart = start,
                PokeName = PokemonName,
                Image = PokemonImage,
                Shiny = isShiny
            };

            BattleRecords.Add(record);
        }

    }
}