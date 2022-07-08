using ProjetoPonto.Droid.Helpers;
using ProjetoPontoBase.Data.Interface;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace ProjetoPonto.Droid.Helpers
{
    public class DatabasePath : IDBPath
    {
        public DatabasePath()
        {
        }

        public string GetDbPath()
        {
            try
            {
                return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Ponto.db3");
            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
            }
            //Path.Combine(, "Ponto.db3") ;
           // return 
        }
    }
}