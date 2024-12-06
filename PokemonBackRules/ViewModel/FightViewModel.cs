using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonBackRules.Model;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PokemonBackRules.Utils;

namespace PokemonBackRules.ViewModel
{
    public partial class FightViewModel : ViewModelBase
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:7119/Pokemon";

        private Random random = new Random();

        [ObservableProperty]
        private string _pokemonImage;
        [ObservableProperty]
        private int _opponentHealth;
        [ObservableProperty]
        private int _maxOpponentHealth = 100;
        [ObservableProperty]
        private int _playerHealth = 1000;
        [ObservableProperty]
        private int _maxPlayerHealth = 1000;
        [ObservableProperty]
        private int _pokemonAttack = 0;
        [ObservableProperty]
        private string _pokemonName;

        private bool isShiny = false;
        private DateTime start;
        private int damageDone = 0;
        private int damageReceived = 0;
        private int healthFightStarted = 0;
        private int currentId = 0;

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
        public async Task ApplyDamage()
        {
            int damage = random.Next(0, 41);
            OpponentHealth -= damage;
            damageDone += damage;
            if (OpponentHealth <= 0)
            {
                await FinalizeBattleRecordAsync(false);
                LoadRandomPokemon();
            }
            else
            {
                GetDamage();
            }
        }

        private void GetDamage()
        {
            PlayerHealth -= PokemonAttack;
            damageReceived += PokemonAttack;
        }

        [RelayCommand]
        public async void Capture()
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

                await FinalizeBattleRecordAsync(true);
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
                string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{randomId}";

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
                GenerateTimestampId();
                await CreateBattleRecordAsync();
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

        private async Task FinalizeBattleRecordAsync(bool isCaptured)
        {
            try
            {
                var record = new BattleRecord
                {
                    Id=currentId,
                    DataStart = start,
                    DateEnd = DateTime.Now,
                    PokeName = PokemonName,
                    Image = PokemonImage,
                    Shiny = isShiny,
                    DamageDoneTrainer = damageDone,
                    DamageReceivedTrainer = damageReceived,
                    DamageDonePokemon = Math.Max(0, healthFightStarted - PlayerHealth),
                    Catch = isCaptured
                };

                string json = JsonSerializer.Serialize(record);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClient.PutAsync($"{ApiUrl}/{record.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error updating record: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finalizing record: {ex.Message}");
            }
        }

        private async Task CreateBattleRecordAsync()
        {
            try
            {
                var record = new BattleRecord
                {
                    Id = currentId,
                    DataStart = start,
                    DateEnd = start,
                    PokeName = PokemonName,
                    Image = PokemonImage,
                    Shiny = isShiny,
                    DamageDoneTrainer = damageDone,
                    DamageReceivedTrainer = damageReceived,
                    DamageDonePokemon = Math.Max(0, healthFightStarted - PlayerHealth),
                    Catch = false
                };

                string json = JsonSerializer.Serialize(record);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClient.PostAsync(ApiUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error creating record: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating record: {ex.Message}");
            }
        }
        private void GenerateTimestampId()
        {
            Random random = new Random();
            currentId = random.Next(1, 10001);

        }
    }
}
