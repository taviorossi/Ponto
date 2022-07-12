using ProjetoPontoBase.Context;
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
        public PontoRepository()
        {
            DbContext = PontoContext.Current;
        }
        public string GetPonto(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void StartPonto(string pontoInicial, string titulo, string descricao)
        {
            try
            {
                    Ponto ponto = new Ponto { PontoInicial = pontoInicial, Titulo = titulo, Descricao = descricao };
                    var startPonto = _dbContext.Conexao.Insert(ponto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ponto> GetAllPontos()
        {
            try
            {
                return _dbContext.Conexao.Table<Ponto>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
