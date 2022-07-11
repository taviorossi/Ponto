using ProjetoPontoBase.Models.Base;
using SQLite;
using System;

namespace ProjetoPontoBase.Models
{
    [SQLite.Table("USUARIO")]
    public class Usuario : CoreEntity
    {
        /// <summary>
        /// ID do Usuário
        /// </summary>
        [SQLite.Column("ID_USER")]
        public Guid? UsuarioId { get; set; }
        /// <summary>
        /// Nome do usuário
        /// </summary>
        [SQLite.Column("NM_USER")]
        public string Nome { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>
        [SQLite.Column("PS_USER")]
        public string Senha { get; set; }
        [SQLite.Column("EMAIL_USER")]
        public string Email { get; set; }

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
        public virtual Usuario usuario { get; set; }
        #endregion
    }
}
