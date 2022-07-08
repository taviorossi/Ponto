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
            DbContext = PontoContext.Current;
        }

        public bool GetUser(string Nome, string Senha)
        {
            try
            {
                var getUser = _dbContext.Conexao.FindWithQuery<Usuario>(
                    "SELECT NM_USER AND PS_USER FROM USUARIO WHERE NM_USER = ? AND PS_USER = ?", Nome, Senha);

                if (getUser != null)
                    return true;

                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertUser(string nome, string senha, string email)
        {
            try
            {
                Usuario user = new Usuario { Nome = nome, Senha = senha, Email = email };
                var insertUser = _dbContext.Conexao.Insert(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
