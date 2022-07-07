using ProjetoPonto.Models;
using ProjetoPonto.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoPonto.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sender)
        {
        }

        public INavigation Navigation { get; set; }

        private string _nome;
        private string _senha;

        #region -> Encapsulamentos
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged("Nome"); }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; OnPropertyChanged("Senha"); }
        }
        #endregion

        #region -> Commands
        private Command _buttonLogin;
        private Command _buttonCadastro;
        public Command ButtonLogin => _buttonLogin ?? (_buttonLogin = new Command( async () => await ExecutaLogin()));
        public Command ButtonCadastro => _buttonCadastro ?? (_buttonCadastro = new Command(async () => await AbrirCadastro()));
        #endregion

        #region -> Métodos
        private async Task ExecutaLogin()
        {
            Usuario usuario = new Usuario();

            try
            {
                if( _nome == usuario.Nome && _senha == usuario.Senha)
                    Application.Current.MainPage = new NavigationPage(new MenuInicial());
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }

        private async Task AbrirCadastro()
        {
            try
            {
                await Navigation.PushAsync(new Cadastro(), false);

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Atencao", ex.Message, "OK");
            }
        }
        #endregion

    }
}
