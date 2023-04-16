using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using Vakcina.WPF.Repositories;

namespace Vakcina.WPF.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        public LoginViewModel(FelhasznaloRepository repository)
        {
            _repository = repository;
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        private readonly FelhasznaloRepository _repository;
        public RelayCommand LoginCommand { get; set; }

        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set 
            {
                SetProperty(ref _username, value);
                LoginCommand.NotifyCanExecuteChanged(); 
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set 
            {
                SetProperty(ref _password, value);
                LoginCommand.NotifyCanExecuteChanged(); 
            }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password);
        }

        private void Login()
        {
            ErrorMessage = _repository.Authenticate(_username, _password);
            if (ErrorMessage == "Sikeres bejelentkezés.")
            {
                var mw = new MainWindow();
                Application.Current.Windows[0].Close();
                mw.Show();
            }
        }
    }
}
