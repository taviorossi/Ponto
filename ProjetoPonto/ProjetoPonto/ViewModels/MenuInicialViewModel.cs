using ProjetoPonto.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoPonto.ViewModels
{
    internal class MenuInicialViewModel
    {
        private Command _detalhe;
        public Command Detalhe => _detalhe ?? (_detalhe = new Command(async () => await EntrarDetalhe()));

        public async Task EntrarDetalhe()
        {
            Application.Current.MainPage = new NavigationPage(new Detalhe());
        }
    }
}
