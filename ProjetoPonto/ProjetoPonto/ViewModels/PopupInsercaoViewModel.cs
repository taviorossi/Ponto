using ProjetoPonto.Views.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using ProjetoPontoBase.Data.Repository;
using Xamarin.Forms;
using ProjetoPontoBase.Models;

namespace ProjetoPonto.ViewModels
{
    public class PopupInsercaoViewModel : BaseViewModel
    {
        #region -> Propiedades
        private string _txtTitulo;
        private string _txtDescricao;
        private DateTime _hora;
        private DateTime _horaFinal;
        private string _local;
        private Command _buttonOk;
        private Command _buttonEnd;
        private Ponto _ponto;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region -> Construtor
        public PopupInsercaoViewModel()
        {
            Hora = DateTime.Now;
            HoraFinal = DateTime.Now;
        }
        #endregion

        #region -> Encapsulamentos
        public string Local
        {
            get { return _local; }
            set { _local = value; }
        }

        public DateTime Hora
        {
            set { _hora = value;OnPropertyChanged("Hora"); }
            get { return _hora; }
        }

        public DateTime HoraFinal
        {
            get { return _horaFinal; }
            set { _horaFinal = value; }
        }

        public string TxtDescricao
        {
            get { return _txtDescricao; }
            set { _txtDescricao = value; }
        }

        public string TxtTitulo
        {
            get { return _txtTitulo; }
            set { _txtTitulo = value; }
        }

        public Ponto PontoFinal
        {
            get { return _ponto; }
            set { _ponto = value; }
        }

        #endregion

        #region -> Commands
        public Command ButtonOk => _buttonOk ?? (_buttonOk = new Command( async () => await CriarPonto()));
        public Command ButtonEnd => _buttonEnd ?? (_buttonEnd = new Command( async () => await EncerrarPonto()));
        #endregion

        #region -> Métodos
        private async Task CriarPonto()
        {
            try
            {
                PontoRepository pontoRepository = new PontoRepository();
                MenuInicialViewModel menuInicialViewModel = new MenuInicialViewModel();
                pontoRepository.StartPonto(_hora.ToString("T"), _txtTitulo, _txtDescricao);

                await App.Current.MainPage.DisplayAlert("Tudo Certo!", "Ponto criado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }

        private async Task EncerrarPonto()
        {
            try
            {
                PontoFinal.PontoFinal = HoraFinal.ToString("T");
                PontoRepository pontoRepository = new PontoRepository();
                pontoRepository.AtualizaPonto(PontoFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
