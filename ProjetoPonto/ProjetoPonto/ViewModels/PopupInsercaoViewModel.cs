using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ProjetoPontoBase.Data.Repository;
using Xamarin.Forms;
using ProjetoPontoBase.Models;
using System.Globalization;
using System.Linq;

namespace ProjetoPonto.ViewModels
{
    public class PopupInsercaoViewModel : BaseViewModel
    {
        #region -> Propiedades
        private string _txtTitulo;
        private string _txtDescricao;
        private DateTime _hora;
        private DateTime _horaFinal;
        private TimeSpan _calculoDaHora;
        private Command _buttonOk;
        private Command _buttonEnd;
        private Ponto _ponto;
        #endregion

        #region -> Construtor
        public PopupInsercaoViewModel()
        {
            Hora = DateTime.Now;
            HoraFinal = DateTime.Now;
        }
        #endregion

        #region -> Encapsulamentos
        public DateTime Hora
        {
            get { return _hora; }
            set { _hora = value; OnPropertyChanged("Hora"); }
        }

        public DateTime HoraFinal
        {
            get { return _horaFinal; }
            set { _horaFinal = value; OnPropertyChanged("HoraFinal"); }
        }

        public TimeSpan CalculoDaHora
        {
            get { return _calculoDaHora; }
            set { _calculoDaHora = value; OnPropertyChanged("HoraFinal"); }
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
                //Converte a string para datetime
                DateTimeOffset dtOffset;
           
                if (DateTimeOffset.TryParse(PontoFinal.PontoInicial, null, DateTimeStyles.None, out dtOffset))
                {
                    Hora = dtOffset.DateTime;
                    Hora.ToString("T");
                }


                //Calculo da hora total
                PontoFinal.PontoFinal = HoraFinal.ToString("T");
                PontoFinal.PontoCalculo = HoraFinal.Subtract(Hora).ToString("T");

                PontoRepository pontoRepository = new PontoRepository();
                pontoRepository.AtualizaPonto(PontoFinal);

                await App.Current.MainPage.DisplayAlert("Tudo Certo!", "Ponto encerrado com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
