using ProjetoPontoBase.Context;
using ProjetoPontoBase.Data.Common;
using ProjetoPontoBase.Data.Interface;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPontoBase.Data.Repository
{
    public class UsuarioRepository : CoreRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository()
        {
            DbContext = Context.AppContext.Current;
        }

        public string GetUser(string Id)
        {
            try
            {
                var getUser = _dbContext.Conexao.FindWithQuery<Usuario>(
                    "SELECT NM_USER FROM USUARIO WHERE ID_USER = ?", Id);
                return getUser.Nome;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string InsertUser(string Nome, string Senha)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUsuarioRepository<T>
    {
    }
}
