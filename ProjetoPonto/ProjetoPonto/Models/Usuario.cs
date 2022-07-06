using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPonto.Models
{
    public class Usuario
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Usuario (){ Id = 1; Nome = "Octavio"; Senha = "123456"; }
    }
}
