using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ReloadWS.DTO;
using ReloadWS.DTO.Request;

namespace ReloadWS.DAL
{
	public static class PostDB
	{
		public static void addPost(DTO.Post post)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<DTO.Post> colPaises = db.GetCollection<DTO.Post>("posts");
			colPaises.InsertOne(post);
		}

		public static void deletePost(Post post)
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<Post> colPost = db.GetCollection<Post>("posts");

			var result = colPost.FindOneAndUpdate(
				Builders<Post>.Filter.Eq("_id", post._id),
				Builders<Post>.Update.Set("activo", false)
				);
		}

		public static List<PostDestacado> obtenerPostPorPuntos(int cuantos)
		{
			var client = new MongoClient(Conexion.getSettings());
			var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");
            return (from p in colPost.AsQueryable<Post>().Where(x => x.activo).OrderByDescending(x => x.puntos).Take(cuantos).ToList()
                    select new PostDestacado { destaque = PostDestacado.TIPO_DESTAQUE.PUNTOS, post = p }).ToList();
                    
		}

		public static List<PostDestacado> obtenerPostPorComentarios(int cuantos)
		{
			var client = new MongoClient(Conexion.getSettings());
			var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");
            return (from p in colPost.AsQueryable<Post>().Where(x => x.activo).OrderByDescending(x => x.contComentarios).Take(cuantos).ToList()
                    select new PostDestacado { post = p, destaque = PostDestacado.TIPO_DESTAQUE.COMENTARIO }).ToList();
		}

		public static List<PostDestacado> obtenerPostRecientes(int cuantos)
		{
			var client = new MongoClient(Conexion.getSettings());
			var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");
            return (from p in colPost.AsQueryable<Post>().Where(x => x.activo).OrderByDescending(x => x.fechaAlta).Take(cuantos).ToList()
                    select new PostDestacado { destaque = PostDestacado.TIPO_DESTAQUE.RECIENTE, post = p }).ToList();
		}

		public static Post editPost(Post post)
		{
			var client = new MongoClient(Conexion.getSettings());
			var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");

			Post ePost = new Post();
				
			ePost =  colPost.FindOneAndUpdate(
				Builders<Post>.Filter.Eq("_id", post._id),
				Builders<Post>.Update.Set("titulo", post.titulo)
										.Set("contenido",post.contenido)
										.Set("imagen", post.imagen)
										.Set("categoria",post.categoria)
				);
         
			return ePost;
		}

		public static void comment(Comentario commentary)
		{
			var client = new MongoClient(Conexion.getSettings());
			var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");

			colPost.FindOneAndUpdate(
				Builders<Post>.Filter.Eq("_id", commentary.postid),
				Builders<Post>.Update.Push("comentarios",commentary)
			);

		}

        public static DTO.Post getPost(string idPost)
        {
            var client = new MongoClient(Conexion.getSettings());
            var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");
            return colPost.AsQueryable<Post>().Single(x => x._id == idPost);
        }
    }
}
