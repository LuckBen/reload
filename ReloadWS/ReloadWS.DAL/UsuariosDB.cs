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
    public static class UsuariosDB 
    {
        static UsuariosDB()
        {
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
								where d.codigo.ToLower() == codigo.ToLower()
								select d).FirstOrDefault();
			
            return result;
        }

		public static void addPost(Post post)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

			var result = colUsuarios.FindOneAndUpdate(
				Builders<Usuario>.Filter.Eq("_id", post.propietario._id),
				Builders<Usuario>.Update.Push("posts", post)
			);
		}

		public static void grabar(Usuario usuario)
        {
            var client = new MongoClient(Conexion.getSettings());
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");
            colUsuarios.InsertOne(usuario);
        }

        public static void grabarMail(string mail)
        {
            throw new NotImplementedException();
        }

        public static void grabarMail(string usuarioCodigo,string mail )
        {
            var client = new MongoClient(Conexion.getSettings());
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

            var result = colUsuarios.FindOneAndUpdate(
                Builders<Usuario>.Filter.Eq("codigo", usuarioCodigo),
                Builders<Usuario>.Update.Set("mail", mail )
            );
        }

        public static void grabarClave(string codigo, string claveNueva)
        {
            var client = new MongoClient(Conexion.getSettings());
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

            var result = colUsuarios.FindOneAndUpdate(
                Builders<Usuario>.Filter.Where(x => x.codigo == codigo),
                Builders<Usuario>.Update.Set("password", claveNueva)
            );
        }

        public static void deletePost(Post post)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

			var result = colUsuarios.FindOneAndUpdate(
				Builders<Usuario>.Filter.Where(x => x._id.Equals(post.propietario._id) && x.posts.Any(y => y._id.Equals(post._id))),
				Builders<Usuario>.Update.Set("posts.$.activo", false)
			);
		}

		public static void grabarInfo(string username, UsuarioInfo info)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");
			
			var result = colUsuarios.FindOneAndUpdate(
				Builders<Usuario>.Filter.Eq("codigo", username),
				Builders<Usuario>.Update.Set("info",info)
			);
		}

		public static void editPost(Post post)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");

			var result = colUsuarios.FindOneAndUpdate(
				Builders<Usuario>.Filter.Where(x => x._id.Equals(post.propietario._id) && x.posts.Any(y => y._id.Equals(post._id))),
				Builders<Usuario>.Update.Set("posts.$.contenido", post.contenido)
			);
		}
	}
}
