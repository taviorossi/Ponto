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
        void StartPonto(DateTime pontoInicial, string titulo, string descricao, string local);
        void EndPonto(DateTime pontoFim, DateTime calcPonto);
        string GetPonto(Guid Id);
    }
}
