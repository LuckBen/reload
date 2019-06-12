using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DAL
{
    public static class Conexion
    {

        private static string cadenaConexion { get;  set; }
        public static string db { get; private set; }
        public static string user { get; private set; }
        public static string password { get; private set; }
        public static string ip { get; private set; }

		static Conexion()
		{
			establecerConexionDB();
		}
        private static void establecerConexionDB()
        {
            user = System.Configuration.ConfigurationSettings.AppSettings["mongodb_user"].ToString();
            password = System.Configuration.ConfigurationSettings.AppSettings["mongodb_password"].ToString();
			ip = System.Configuration.ConfigurationSettings.AppSettings["mongodb_address"].ToString();
            db = System.Configuration.ConfigurationSettings.AppSettings["mongodb_db"].ToString();

            cadenaConexion = "mongodb://username:password@address/_db"
							.Replace("username", user).Replace("password", password)
                            .Replace("address", ip).Replace("_db", db);
        }

		public static MongoClientSettings getSettings()
		{
			string mongoDbAuthMechanism = "SCRAM-SHA-1";
			MongoInternalIdentity internalIdentity =
					  new MongoInternalIdentity("admin", user);
			PasswordEvidence passwordEvidence = new PasswordEvidence(password);
			MongoCredential mongoCredential =
				 new MongoCredential(mongoDbAuthMechanism,
						 internalIdentity, passwordEvidence);
			List<MongoCredential> credentials =
					   new List<MongoCredential>() { mongoCredential };


			MongoClientSettings settings = new MongoClientSettings();
			// comment this line below if your mongo doesn't run on secured mode
			settings.Credentials = credentials;
			String mongoHost = ip;
            MongoServerAddress address = new MongoServerAddress(mongoHost);
			settings.Server = address;

			return settings;
		}

    }
}
