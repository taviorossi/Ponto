using ProjetoPonto.Views;
using ProjetoPonto.Views.Popup;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace ProjetoPonto.ViewModels
{
    public class MenuInicialViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sender)
        {
        }

        public INavigation Navigation { get; set; }
       
        private Command _detalhe;
        private Command _adicionar;

        public Command Detalhe => _detalhe ?? (_detalhe = new Command(async () => await EntrarDetalhe()));
        public Command Adicionar => _adicionar ?? (_adicionar = new Command(() => AdicionarPonto()));

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

        private async void AdicionarPonto()
        {
            try
            {
                App.Current.MainPage.Navigation.ShowPopup(PopupInsercao);

                //string titulo;
                //string descricao;
                //DateTimeOffset horario;

                //var action = await App.Current.MainPage.DisplayActionSheet("Insira um novo ponto:", "Cancelar", "OK", "Titluo:", "Descrição:", "Horário:" );
                //switch(action)
                //{
                //    case "Cancelar":
                //        break;

                //    case "OK":
                //        break;

                //    case "Titluo:":

                //        break;

                //    case "Descrição:":
                //        break;

                //    case "Horário:":
                //        break;
                //}
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }
        }
    }
}
