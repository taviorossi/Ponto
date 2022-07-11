using ProjetoPontoBase.Models.Base;
using System;

namespace ProjetoPontoBase.Models
{
    [SQLite.Table("PONTO")]
    public class Ponto : CoreEntity
    {
        /// <summary>
        /// Id do Ponto
        /// </summary>
        [SQLite.Column("ID_POINT")]
        public Guid? PontoId { get; set; }
        /// <summary>
        /// Horário do ponto inicial
        /// </summary>
        [SQLite.Column("FIRST_POINT")]
        public DateTime PontoInicial { get; set; }
        /// <summary>
        /// Horário do ponto final
        /// </summary>
        [SQLite.Column("LAST_POINT")]
        public DateTime PontoFinal { get; set; }
        /// <summary>
        /// Calculo do tempo total
        /// </summary>
        [SQLite.Column("CALC_POINT")]
        public DateTime PontoCalculo { get; set; }
        /// <summary>
        /// Titulo do ponto
        /// </summary>
        [SQLite.Column("TITLE_POINT")]
        public string Titulo { get; set; }
        /// <summary>
        /// Descrição do ponto
        /// </summary>
        [SQLite.Column("DESC_POINT")]
        public string Descricao { get; set; }
        /// <summary>
        /// Posição aonde o ponto foi iniciado
        /// </summary>
        [SQLite.Column("LOCATION_POINT")]
        public string Posicao { get; set; }
    }
}
