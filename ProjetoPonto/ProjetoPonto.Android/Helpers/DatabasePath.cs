using ProjetoPontoBase.Data.Interface;
using System.IO;

namespace ProjetoPonto.Droid.Helpers
{
    public class DatabasePath : IDBPath
    {
        public DatabasePath()
        {

        }

        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Ponto.db3");
        }
    }
}