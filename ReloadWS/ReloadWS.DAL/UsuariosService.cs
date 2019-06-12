using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

using ReloadWS.DTO;

namespace ReloadWS.DAL
{
    public static class UsuariosService 
    {
        public static Estado estado { get; set; }
        static UsuariosService()
        {
            estado = new ReloadWS.DAL.Estado();
        }

		public static Usuario obtenerUsuarioPorMail(string mail)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

			Usuario result = (from d in colUsuarios.AsQueryable<Usuario>()
							  where d.mail == mail
							  select d).FirstOrDefault();
			return result;
		}

		/// <summary>
		/// busca un usuario por su mail, y lo pone como activo.
		/// </summary>
		public static void actualizarActivoPorMail(string mail)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

			var result = colUsuarios.FindOneAndUpdate(
				Builders<Usuario>.Filter.Eq("mail",mail),
				Builders<Usuario>.Update.Set("activo", true)
				);
		}

        public static Usuario obtenerUsuario(string codigo)
        {
            
            var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

            Usuario result = (from d in colUsuarios.AsQueryable<Usuario>()
								where d.codigo.Equals(codigo)
								select d).FirstOrDefault();
			

            return result;
        }

        public static void grabar(Usuario usuario)
        {
            var client = new MongoClient(Conexion.getSettings());
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");
            colUsuarios.InsertOne(usuario);
        }

    }
}
