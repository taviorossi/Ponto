using ProjetoPontoBase.Data.Interface;
using ProjetoPontoBase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetoPontoBase.Context
{
    public class PontoContext
    {
        private static SQLiteConnection _sqliteConnection;

        public static PontoContext _lazy;

        public static PontoContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new PontoContext();

                return _lazy;
            }
        }

        private PontoContext()
        {
            _sqliteConnection = new SQLiteConnection(DependencyService.Get<IDBPath>().GetDbPath());
            _sqliteConnection.CreateTable<Usuario>();
        }

        public SQLiteConnection Conexao
        {
            get { return _sqliteConnection; }
            set { _sqliteConnection = value; }
        }
    }
}
