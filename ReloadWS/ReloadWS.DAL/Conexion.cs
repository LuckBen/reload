using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DAL
{
    public static class Conexion
    {

        public static string cadenaConexion { get; private set; }
        public static string db { get; private set; }
        public static string user { get; private set; }
        public static string password { get; private set; }
        public static string address { get; private set; }
        private static void establecerConexionDB()
        {
            user = System.Configuration.ConfigurationSettings.AppSettings["mongodb_user"].ToString();
            password = System.Configuration.ConfigurationSettings.AppSettings["mongodb_password"].ToString();
            address = System.Configuration.ConfigurationSettings.AppSettings["mongodb_address"].ToString();
            db = System.Configuration.ConfigurationSettings.AppSettings["mongodb_db"].ToString();

            cadenaConexion = "mongodb://username:password@address/db"
                            .Replace("username", user).Replace("password", password)
                            .Replace("address", address).Replace("db", db);
        }
    }
}
