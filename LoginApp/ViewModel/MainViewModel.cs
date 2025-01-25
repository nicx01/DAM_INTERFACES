using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokemonBackRules.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(PokeSukaViewModel pokeSukaViewModel, MainMenuViewModel mainMenuViewModel, FightViewModel fightViewModel, TeamViewModel teamViewModel, HistoricViewModel historicViewModel, ImportViewModel importViewModel, RegisterViewModel registerViewModel)
        {
            _selectedViewModel = mainMenuViewModel;
            PokeSukaViewModel = pokeSukaViewModel;
            MainMenuViewModel = mainMenuViewModel;
            FightViewModel = fightViewModel;
            TeamViewModel = teamViewModel;
            HistoricViewModel = historicViewModel;
            ImportViewModel = importViewModel;
            RegisterViewModel = registerViewModel;
        }
        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public PokeSukaViewModel PokeSukaViewModel { get; }
        public MainMenuViewModel MainMenuViewModel { get; }
        public FightViewModel FightViewModel { get; }
        public TeamViewModel TeamViewModel { get; }
        public HistoricViewModel HistoricViewModel { get; }
        public ImportViewModel ImportViewModel { get; }
        public RegisterViewModel RegisterViewModel { get; }

        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
