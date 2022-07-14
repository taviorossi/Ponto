using ProjetoPontoBase.Models.Base;
using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjetoPontoBase.Models
{
    [SQLite.Table("PONTO")]
    public class Ponto : CoreEntity, INotifyPropertyChanged
    {
        /// <summary>
        /// Id do Ponto
        /// </summary>
        [SQLite.Column("ID_POINT")]
        public Guid? PontoId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Horário do ponto inicial
        /// </summary>
        [SQLite.Column("FIRST_POINT")]
        public string PontoInicial { get; set; }
        /// <summary>
        /// Horário do ponto final
        /// </summary>
        [SQLite.Column("LAST_POINT")]
        public string PontoFinal { get; set; }
        /// <summary>
        /// Calculo do tempo total
        /// </summary>
        [SQLite.Column("CALC_POINT")]
        public string PontoCalculo { get; set; }
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

        #region -> Ignore
        [Ignore]
        public string InclusaoFormatada
        {
            get
            {
                return Inclusao.ToString("dd/MM/yyyy HH:mm");
            }
        }
        #endregion

        #region -> Virtuals
        [Ignore]
        public virtual Ponto ponto { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
