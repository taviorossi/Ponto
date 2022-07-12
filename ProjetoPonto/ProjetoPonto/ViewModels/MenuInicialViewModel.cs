using ProjetoPonto.Views;
using ProjetoPonto.Views.Popup;
using ProjetoPontoBase.Data.Interface;
using ProjetoPontoBase.Data.Repository;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace ProjetoPonto.ViewModels
{
    public class MenuInicialViewModel : BaseViewModel
    {
        #region -> Propriedades
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sender)
        {
        }

        public INavigation Navigation { get; set; }
        private Command _detalhe;
        private Command _adicionar;
        private List<Usuario> _usuarios;
        private ObservableCollection<Ponto> _pontos;
        private PontoRepository _pontoRepository;
        #endregion

        #region -> Encapsulamentos
        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }

        public ObservableCollection<Ponto> Pontos
        {
            get { return _pontos; }
            set { _pontos = value; OnPropertyChanged("Pontos"); }
        }
        #endregion

        #region -> Commands
        public Command Detalhe => _detalhe ?? (_detalhe = new Command(async () => await EntrarDetalhe()));
        public Command Adicionar => _adicionar ?? (_adicionar = new Command(() => AdicionarPonto()));
        #endregion

        #region -> Métodos
        private async Task EntrarDetalhe()
        {
            try
            {
                await Navigation.PushAsync(new Detalhe(),false);

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }

        private void AdicionarPonto()
        {
            try
            {
                var popup = new PopupInsercao();
                App.Current.MainPage.Navigation.ShowPopup(popup);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }

        public void BuscaDados()
        {
            try
            {
                _pontoRepository = new PontoRepository();

                var listPonto = _pontoRepository.GetAllPontos();
                Pontos = new ObservableCollection<Ponto>(listPonto);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }
        #endregion
    }
}
