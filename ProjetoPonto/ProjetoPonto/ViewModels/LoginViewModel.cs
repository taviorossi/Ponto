using ProjetoPonto.Views;
using ProjetoPontoBase.Data.Repository;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoPonto.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region -> Propriedades
        private string _nome;
        private string _senha;
        public INavigation Navigation { get; set; }
        private List<Usuario> _usuarios;
        private UsuarioRepository _usuarioRepository;
        #endregion

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

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; OnPropertyChanged("Usuarios"); }
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
                /* 
                 * var id = usuarioRepository.GetUser(_nome, _senha)
                 * if(id != null)
                 * Application.Current.MainPage = new NavigationPage(new MenuInicial(id));
                 */


                UsuarioRepository usuarioRepository = new UsuarioRepository();
                if (usuarioRepository.GetUser(_nome, _senha) == true)
                    Application.Current.MainPage = new NavigationPage(new MenuInicial(_nome));
                else
                    await App.Current.MainPage.DisplayAlert("Ops", "Login incorreto", "OK");
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

        //public void BuscaDadosUsuario()
        //{
        //    try
        //    {   
        //        _usuarioRepository = new UsuarioRepository();

        //        var listUsuario = _usuarioRepository.GetAllUsers();
        //        Usuarios = new List<Usuario>(listUsuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
        //    }
        //}
        #endregion

    }
}
