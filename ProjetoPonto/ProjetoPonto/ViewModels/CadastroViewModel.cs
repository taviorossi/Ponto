using ProjetoPonto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjetoPontoBase.Data.Repository;

namespace ProjetoPonto.ViewModels
{
    public class CadastroViewModel : BaseViewModel
    {
        #region -> Propriedades
        private Command _buttonRealizarCadastro;
        private Usuario _usuario;
        private string _nome;
        private string _senha;
        private string _email;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region -> Encapsulamentos
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

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
        
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }
        #endregion

        #region -> Commands
        public Command BtnAvancarCommand => _buttonRealizarCadastro ?? (_buttonRealizarCadastro = new Command(() => RealizarCadastro()));
        #endregion

        #region -> Métodos
        private void RealizarCadastro()
        {
            try
            {
                //VALIDAÇÕES

                if (_nome != null && _senha != null && _email != null && _email.Contains("@"))
                { 
                    UsuarioRepository usuarioRepository = new UsuarioRepository();
                    usuarioRepository.InsertUser(_nome, _senha, _email);
                    App.Current.MainPage.DisplayAlert("Tudo certo!", "Usuário criado com sucesso", "OK");
                }
                if(_nome == null)
                {
                    App.Current.MainPage.DisplayAlert("Ops", "Preencha o campo do nome", "OK");
                }
                if(_senha == null)
                {
                    App.Current.MainPage.DisplayAlert("Ops", "Preencha o campo do senha", "OK");
                }
                if(_email == null || _email.Contains("@") == false)
                {
                    App.Current.MainPage.DisplayAlert("Ops", "Insira o email corretamente", "OK");
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }
        #endregion
    }
}
