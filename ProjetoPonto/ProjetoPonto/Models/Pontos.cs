using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPonto.Models
{
    internal class Pontos
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTimeOffset PontoInicio { get; set; }
        public DateTimeOffset PontoFim { get; set; }
        public DateTimeOffset PontoTotal { get; set; }

    }
}
