using ProjetoPontoBase.Data.Common;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPontoBase.Data.Interface
{
    public interface IUsuarioRepository : ICoreRepository<Usuario>
    {
        bool GetUser(string Nome, string Senha);
        void InsertUser(string Nome, string Senha, string Email);
    }
}
