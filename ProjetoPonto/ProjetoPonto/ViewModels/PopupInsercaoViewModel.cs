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

namespace ProjetoPonto.ViewModels
{
    public class PopupInsercaoViewModel : BaseViewModel
    {
        #region -> Propiedades
        private string _txtTitulo;
        private string _txtDescricao;
        private DateTime _hora;
        private string _local;
        private Command _buttonOk;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region -> Encapsulamentos
        public string Local
        {
            get { return _local; }
            set { _local = value; }
        }

        public DateTime Hora
        {
            set 
            {
                _hora = value;OnPropertyChanged("Hora");
            }
            get { return _hora; }
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
        #endregion

        public PopupInsercaoViewModel()
        {
            Hora = DateTime.Now;
        }

        #region -> Commands
        public Command ButtonOk => _buttonOk ?? (_buttonOk = new Command( async () => await CriarPonto()));
        #endregion

        #region -> Métodos
        private async Task CriarPonto()
        {
            try
            {
                
                PontoRepository pontoRepository = new PontoRepository();
                pontoRepository.StartPonto(_hora.ToString("T"), _txtTitulo, _txtDescricao);

                await App.Current.MainPage.DisplayAlert("Tudo Certo!", "Ponto criado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }
        #endregion
    }
}
