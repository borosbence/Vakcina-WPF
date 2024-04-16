using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Vakcina.WPF.Views;

namespace Vakcina.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            UpdateViewCommand = new RelayCommand<string>(Execute);
            LogoutCommand = new RelayCommand<Window>(Close);
            SelectedViewModel = App.Current.Services.GetRequiredService<OltasViewModel>();
            // TODO: 10 Bejelentkezett felhasználónév megjelenítése
            LoggedUser = "username";
        }

        private ObservableObject _selectedViewModel = default!;
        public ObservableObject SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }
        public RelayCommand<string> UpdateViewCommand { get; }
        public RelayCommand<Window> LogoutCommand { get; }

        public string? LoggedUser { get; }

        public void Execute(string parameter)
        {
            if (parameter.ToString() == "oltas")
            {
                SelectedViewModel = App.Current.Services.GetRequiredService<OltasViewModel>();
            }
        }
        private void Close(Window window)
        {
            var loginView = new LoginWindow();
            loginView.Show();
            window.Close();
        }
    }
}
