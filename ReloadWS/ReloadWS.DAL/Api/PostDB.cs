using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReloadWS.DTO;
using ReloadWS.DTO.Request;
using ReloadWS.DAL.Persistencia;

namespace ReloadWS.DAL.Api
{
    public static class PostDB
	{
		public static void addPost(DTO.Post post)
		{
            
            using (ReloadEntities db = new ReloadEntities())
            {
                db.TBL_POSTS.Add(new TBL_POSTS
                {
                    POST_TITULO = post.titulo,
                    POST_CATEGORIA = post.categoria.id,
                    POST_CANT_COMENTARIOS = 0,
                    POST_CONTENIDO_EDIT = post.contenidoEditor,
                    POST_COTENIDO = post.contenido,
                    POST_DEBAJA = false,
                    POST_FAVORITOS = 0,
                    POST_FECALT = DateTime.Now,
                    POST_FECMOD = DateTime.Now,
                    POST_PROPIETARIO = post.propietario.id,
                    POST_PUNTOS = 0,
                    POST_SEGUIDORES = 0,
                    POST_SE_COMENTA = post.seComenta,
                    POST_STICKY = post.sticky,
                    POST_TAGS = post.etiquetas,
                    POST_VISITAS = 0
                });
                db.SaveChanges();
            }

		}

		public static void deletePost(Post post)
		{
            using (ReloadEntities db = new ReloadEntities())
            {
                db.TBL_POSTS.Single(x => x.POSTid == post.id).POST_DEBAJA = true;
                db.SaveChanges();
            }
		}

		public static List<PostDestacado> obtenerPostPorPuntos(int cuantos)
		{

            using(ReloadEntities db = new ReloadEntities())
            {
               return (from a in (from post in db.TBL_POSTS
                            where !post.POST_DEBAJA
                            select new Post
                            {
                                activo = post.POST_DEBAJA,
                                categoria = new Categoria
                                {
                                    id = post.TBL_CATEGORIAS.CATEGORIAid,
                                    logo = post.TBL_CATEGORIAS.CATEGORIA_LOGO,
                                    nombre = post.TBL_CATEGORIAS.CATEGORIA_NOMBRE
                                },
                                id = post.POSTid,
                                contenido = post.POST_COTENIDO,
                                contenidoEditor = post.POST_CONTENIDO_EDIT,
                                etiquetas = post.POST_TAGS,
                                favoritos = post.POST_FAVORITOS,
                                fechaAlta = post.POST_FECALT.ToShortDateString(),
                                fechaModificacion = post.POST_FECMOD.ToShortDateString(),
                                propietario = new Sujeto
                                {
                                    alias = post.TBL_USUARIOS.USUARIO_CODIGO,
                                    codigo = post.TBL_USUARIOS.USUARIO_CODIGO,
                                    id = post.TBL_USUARIOS.USUARIOid,
                                    rango = new Rango
                                    {
                                        id = post.TBL_USUARIOS.TBL_RANGOS.RANGOid,
                                        descripcion = post.TBL_USUARIOS.TBL_RANGOS.RANGO_DESCRP,
                                        nombre = post.TBL_USUARIOS.TBL_RANGOS.RANGO_NOMBRE,
                                        imagen = post.TBL_USUARIOS.TBL_RANGOS.RANGO_IMAGEN,
                                        puntosDar = post.TBL_USUARIOS.TBL_RANGOS.RANGO_PUNTOS_DAR,
                                        puntosRequeridos = post.TBL_USUARIOS.TBL_RANGOS.RANGO_PUNTOS_REQ
                                    }
                                },
                                puntos = post.POST_PUNTOS,
                                seComenta = post.POST_SE_COMENTA,
                                seguidores = post.POST_SEGUIDORES,
                                sticky = post.POST_STICKY,
                                titulo = post.POST_TITULO,
                                visitas = post.POST_VISITAS

                            }).OrderByDescending(x => x.puntos).Take(cuantos).ToList()
                 select new PostDestacado
                 {
                     destaque = PostDestacado.TIPO_DESTAQUE.PUNTOS,
                     post = a

                 }).ToList();
            }

            //return (from p in colPost.AsQueryable<Post>().Where(x => x.activo).OrderByDescending(x => x.puntos).Take(cuantos).ToList()
            //        select new PostDestacado { destaque = PostDestacado.TIPO_DESTAQUE.PUNTOS, post = p }).ToList();
                    
		}

		//public static List<PostDestacado> obtenerPostPorComentarios(int cuantos)
		//{
		//	var client = new MongoClient(Conexion.getSettings());
		//	var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");
  //          return (from p in colPost.AsQueryable<Post>().Where(x => x.activo).OrderByDescending(x => x.contComentarios).Take(cuantos).ToList()
  //                  select new PostDestacado { post = p, destaque = PostDestacado.TIPO_DESTAQUE.COMENTARIO }).ToList();
		//}

		//public static List<PostDestacado> obtenerPostRecientes(int cuantos)
		//{
		//	var client = new MongoClient(Conexion.getSettings());
		//	var colPost = client.GetDatabase(Conexion.db).GetCollection<Post>("posts");
  //          return (from p in colPost.AsQueryable<Post>().Where(x => x.activo).OrderByDescending(x => x.fechaAlta).Take(cuantos).ToList()
  //                  select new PostDestacado { destaque = PostDestacado.TIPO_DESTAQUE.RECIENTE, post = p }).ToList();
		//}

		public static Post editPost(Post post)
		{
			using(ReloadEntities db = new ReloadEntities())
            {
                TBL_POSTS postDB = db.TBL_POSTS.Single(x => x.POSTid == post.id);

                postDB.POST_TITULO = post.titulo;
                postDB.POST_CONTENIDO_EDIT = post.contenidoEditor;
                postDB.POST_COTENIDO = post.contenido;
                postDB.POST_CATEGORIA = post.categoria.id;
                db.SaveChanges();
            }

            return post;
				
		}

		public static void comment(Comentario commentary)
		{
            using(ReloadEntities db = new ReloadEntities())
            {
                db.TBL_POST_COMENTARIOS.Add(new TBL_POST_COMENTARIOS
                {
                    POST_COMENTARIO_CONTENIDO = commentary.contenido,
                    POST_COMENTARIO_DEBAJA = false,
                    POST_COMENTARIO_FECALT = DateTime.Now,
                    POST_COMENTARIO_NEG = 0,
                    POST_COMENTARIO_POS = 0,
                    POST_COMENTARIO_POSTid = commentary.postid,
                    POST_COMENTARIO_USUARIOid = commentary.emisor.id
                });
                db.SaveChanges();
            }
		}

        public static DTO.Post getPost(int idPost)
        {
            using (ReloadEntities db = new ReloadEntities())
            {
                return (from post in db.TBL_POSTS
                        where !post.POST_DEBAJA && post.POSTid == idPost
                        select new Post
                        {
                            activo = post.POST_DEBAJA,
                            categoria = new Categoria
                            {
                                id = post.TBL_CATEGORIAS.CATEGORIAid,
                                logo = post.TBL_CATEGORIAS.CATEGORIA_LOGO,
                                nombre = post.TBL_CATEGORIAS.CATEGORIA_NOMBRE
                            },
                            id = post.POSTid,
                            contenido = post.POST_COTENIDO,
                            contenidoEditor = post.POST_CONTENIDO_EDIT,
                            etiquetas = post.POST_TAGS,
                            favoritos = post.POST_FAVORITOS,
                            fechaAlta = post.POST_FECALT.ToShortDateString(),
                            fechaModificacion = post.POST_FECMOD.ToShortDateString(),
                            propietario = new Sujeto
                            {
                                alias = post.TBL_USUARIOS.USUARIO_CODIGO,
                                codigo = post.TBL_USUARIOS.USUARIO_CODIGO,
                                id = post.TBL_USUARIOS.USUARIOid,
                                rango = new Rango
                                {
                                    id = post.TBL_USUARIOS.TBL_RANGOS.RANGOid,
                                    descripcion = post.TBL_USUARIOS.TBL_RANGOS.RANGO_DESCRP,
                                    nombre = post.TBL_USUARIOS.TBL_RANGOS.RANGO_NOMBRE,
                                    imagen = post.TBL_USUARIOS.TBL_RANGOS.RANGO_IMAGEN,
                                    puntosDar = post.TBL_USUARIOS.TBL_RANGOS.RANGO_PUNTOS_DAR,
                                    puntosRequeridos = post.TBL_USUARIOS.TBL_RANGOS.RANGO_PUNTOS_REQ
                                }
                            },
                            puntos = post.POST_PUNTOS,
                            seComenta = post.POST_SE_COMENTA,
                            seguidores = post.POST_SEGUIDORES,
                            sticky = post.POST_STICKY,
                            titulo = post.POST_TITULO,
                            visitas = post.POST_VISITAS

                        }).FirstOrDefault();
            }
        }
    }
}
