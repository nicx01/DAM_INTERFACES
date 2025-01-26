using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonBackRules.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using PokemonBackRules.Utils;

namespace PokemonBackRules.ViewModel
{
    public partial class ImportViewModel : ViewModelBase
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private const string ApiUrl = Constantes.POKE_HISTORIC_URL;

        [ObservableProperty]
        private string _statusIcon;

        [RelayCommand]
        public async Task ImportJson()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    Title = "Selecciona un archivo JSON"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    string json = File.ReadAllText(filePath);

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var records = JsonSerializer.Deserialize<List<BattleRecord>>(json, options);

                    if (records != null)
                    {
                        await DeleteAllRecordsAsync();

                        foreach (var record in records)
                        {
                            HttpContent content = new StringContent(JsonSerializer.Serialize(record), System.Text.Encoding.UTF8, "application/json");
                            HttpResponseMessage response = await HttpClient.PostAsync(ApiUrl, content);

                            if (!response.IsSuccessStatusCode)
                            {
                                SetStatus("Error al importar el archivo.", Constantes.ERROR_IMAGE_PATH);
                                return;
                            }
                        }

                        SetStatus("¡Importación exitosa!", Constantes.CHECK_IMAGE_PATH);
                    }
                    else
                    {
                        SetStatus("El archivo no tiene el formato correcto.", Constantes.ERROR_IMAGE_PATH);
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatus($"Error al cargar el archivo: {ex.Message}", Constantes.ERROR_IMAGE_PATH);
            }
        }

        private async Task DeleteAllRecordsAsync()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"{ApiUrl}/DeleteAll");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al borrar los registros existentes en la API.", "Error");
                    SetStatus("Error al borrar los registros existentes.", Constantes.ERROR_IMAGE_PATH);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al borrar registros: {ex.Message}", "Error");
                SetStatus("Error al borrar los registros existentes.", Constantes.ERROR_IMAGE_PATH);
            }
        }

        private void SetStatus(string message, string iconFilePath)
        {
            StatusIcon = iconFilePath;  
        }

    }
}
