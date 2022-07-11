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
    public class PopupInsercaoViewModel : INotifyPropertyChanged
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
                if (_hora != value)
                {
                    _hora = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Hora"));
                    }
                }
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

        #region -> Commands
        public Command ButtonOk => _buttonOk ?? (_buttonOk = new Command( async () => await CriarPonto()));
        #endregion

        #region -> Métodos
        private async Task CriarPonto()
        {
            try
            {
                _hora = new DateTime();
                _hora = DateTime.Now;
                PontoRepository pontoRepository = new PontoRepository();
                await pontoRepository.StartPonto(_hora.Date, _txtTitulo, _txtDescricao, _local);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }
        #endregion
    }
}
