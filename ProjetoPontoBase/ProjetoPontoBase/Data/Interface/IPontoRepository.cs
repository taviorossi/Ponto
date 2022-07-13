using ProjetoPontoBase.Data.Common;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ProjetoPontoBase.Data.Interface
{
    public interface IPontoRepository : ICoreRepository<Ponto>
    {
        void StartPonto(string pontoInicial, string titulo, string descricao);
        void AtualizaPonto(Ponto ponto);
        List<Ponto> GetAllPontos();
    }
}
