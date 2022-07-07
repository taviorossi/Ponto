using ProjetoPontoBase.Data.Common;
using ProjetoPontoBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPontoBase.Data.Interface
{
    public interface IUsuarioRepository : ICoreRepository<Usuario>
    {
        string GetUser(string Id);
        string InsertUser(string Nome, string Senha);
    }
}
