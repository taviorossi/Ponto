using ProjetoPontoBase.Data.Common;
using ProjetoPontoBase.Data.Interface;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ProjetoPontoBase.Data.Repository
{
    public class PontoRepository : CoreRepository<Ponto>, IPontoRepository
    {
        public void EndPonto(DateTime pontoFim, DateTime calcPonto)
        {
            Ponto ponto = new Ponto { PontoFinal = pontoFim, PontoCalculo = calcPonto };
            var IniciaPonto = _dbContext.Conexao.Insert(ponto);
        }

        public string GetPonto(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void StartPonto(DateTime pontoInicial, string titulo, string descricao, string local)
        {
            try
            {
                Ponto ponto = new Ponto { PontoInicial = pontoInicial, Titulo = titulo, Descricao = descricao, Posicao = local };
                var IniciaPonto = _dbContext.Conexao.Insert(ponto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
