using ProjetoPontoBase.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ProjetoPontoBase.Models
{
    public class Ponto : CoreEntity
    {
        public DateTimeOffset PontoInicial { get; set; }
        public DateTimeOffset PontoFinal { get; set; }
        public DateTimeOffset PontoCalculo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Location Posicao { get; set; }
    }
}
