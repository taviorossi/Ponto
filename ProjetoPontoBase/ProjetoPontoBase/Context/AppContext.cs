using ProjetoPontoBase.Data.Interface;
using ProjetoPontoBase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetoPontoBase.Context
{
    public class AppContext
    {
        private static SQLiteConnection _sqliteConnection;

        public static AppContext _lazy;

        public static AppContext Current
        {
            get
            {
                if (_lazy == null)
                    _lazy = new AppContext();

                return _lazy;
            }
        }

        private AppContext()
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
