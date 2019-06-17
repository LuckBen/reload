using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReloadWS.DTO;
using ReloadWS.DTO.Request;
using ReloadWS.DTO.Response;
using ReloadWS.BI;

namespace ReloadWS.Service
{
	public class PostService : IPostService
	{
		public Response<Post> addPost(Request<Post> requestPost)
		{
			Response<Post> respuesta = new Response<Post>();
			BI.PostModule.addPost(requestPost.contenido);
			respuesta.estado = BI.PostModule.estado;

			return respuesta;
		}

		public Response<string> comment(Request<Comentario> commentary)
		{
			Response<string> respuesta = new Response<string>();
            BI.PostModule.comment(commentary.contenido);
			respuesta.estado = BI.PostModule.estado;
			return respuesta;
		}

		public void deletePost(Request<DTO.Post> post)
		{
			BI.PostModule.deletePost(post.contenido);
		}

		public Response<Post> editPost(Request<Post> post)
		{
			Response<Post> respuesta = new Response<Post>();
			respuesta.contenido = BI.PostModule.editPost(post.contenido);
			respuesta.estado = BI.PostModule.estado;

			return respuesta;
		}

		public Request<Post> getPost()
		{
			Request<Post> req = new Request<Post>();
			Post post = new Post();
			post.contenido = "dldd";
			post.categoria = new Categoria
			{
				descripcion = "descrp",
				logo = "logo",
				nombre = "nombre"
			};
			post.favoritos = 2;
			post.fechaAlta = DateTime.Now;
			post.fechaModificacion = DateTime.Now;
			post.imagen = "eso.png";
			post.titulo = "titulo";
			post.contenido = "contenido";
			post.tags.Add("tag1");
			post.tags.Add("tag2");
			 			
			post.propietario = new Sujeto
			{
				alias = "Lucho",
				imagen = "lucho.png",
				codigo = "lucho",
				pais = new Pais
				{
					codigo = "AR",
					nombre = "Argentina"
				},
				rango = new Rango
				{
					nombre = "Administrador",
					imagen = "admin.png",
					descripcion = "Administrador del sitio"
				}
			};

			req.contenido = post;
			req.token = "asdads";
			req.usuario = "Lucho";

			return req;
		}
	}
}
