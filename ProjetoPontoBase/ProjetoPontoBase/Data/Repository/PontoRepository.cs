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

        public void StartPonto(string pontoInicial, string titulo, string descricao)
        {
            try
            {
                    Ponto ponto = new Ponto { PontoInicial = pontoInicial, Titulo = titulo, Descricao = descricao };
                    var startPonto = _dbContext.Conexao.Insert(ponto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Ponto> GetAllPontos()
        {
            try
            {
                return _dbContext.Conexao.Table<Ponto>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizaPonto(Ponto ponto)
        {
            try
            {
                var atualizaPonto = _dbContext.Conexao.Query<Ponto>("INSERT INTO PONTO LAST_POINT VALUE ? WHERE ID_POINT = ?; ", ponto.PontoFinal, ponto.PontoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
