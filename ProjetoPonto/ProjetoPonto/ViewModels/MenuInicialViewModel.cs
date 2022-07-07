using ProjetoPonto.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
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

        public Command Detalhe => _detalhe ?? (_detalhe = new Command(async () => await EntrarDetalhe()));

        private async Task EntrarDetalhe()
        {
            try
            {
                await Navigation.PushAsync(new Detalhe(),false);

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Atencao", ex.Message, "OK");
            }
        }
    }
}
