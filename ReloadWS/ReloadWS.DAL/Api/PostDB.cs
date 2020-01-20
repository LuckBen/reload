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
                    POST_CONTENIDO_EDIT = post.contenido,
                    POST_COTENIDO = post.contenido,
                    POST_DEBAJA = false,
                    POST_FAVORITOS = 0,
                    POST_FECALT = DateTime.Now,
                    POST_FECMOD = DateTime.Now,
                    POST_PROPIETARIO = post.propietario.id,
                    POST_IMAGEN = post.imagen,
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
                db.TBL_POSTS.Single(x => x.POST_ID == post.id).POST_DEBAJA = true;
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
                                    id = post.TBL_CATEGORIAS.CATEGORIA_ID,
                                    logo = post.TBL_CATEGORIAS.CATEGORIA_LOGO,
                                    nombre = post.TBL_CATEGORIAS.CATEGORIA_NOMBRE
                                },
                                id = post.POST_ID,
                                contenido = post.POST_COTENIDO,
                                contenidoEditor = post.POST_CONTENIDO_EDIT,
                                etiquetas = post.POST_TAGS,
                                favoritos = post.POST_FAVORITOS,
                                propietario = new Sujeto
                                {
                                    alias = post.TBL_USUARIOS.USUARIO_CODIGO,
                                    codigo = post.TBL_USUARIOS.USUARIO_CODIGO,
                                    id = post.TBL_USUARIOS.USUARIO_ID,
                                    rango = new Rango
                                    {
                                        id = post.TBL_USUARIOS.TBL_RANGOS.RANGO_ID,
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

        public static List<PostDestacado> obtenerPostPorComentarios(int cuantos)
        {

            using (ReloadEntities db = new ReloadEntities())
            {
                return (from a in (from post in db.TBL_POSTS
                                   where !post.POST_DEBAJA
                                   select new Post
                                   {
                                       activo = post.POST_DEBAJA,
                                       categoria = new Categoria
                                       {
                                           id = post.TBL_CATEGORIAS.CATEGORIA_ID,
                                           logo = post.TBL_CATEGORIAS.CATEGORIA_LOGO,
                                           nombre = post.TBL_CATEGORIAS.CATEGORIA_NOMBRE
                                       },
                                       id = post.POST_ID,
                                       contenido = post.POST_COTENIDO,
                                       contenidoEditor = post.POST_CONTENIDO_EDIT,
                                       etiquetas = post.POST_TAGS,
                                       favoritos = post.POST_FAVORITOS,
                                       propietario = new Sujeto
                                       {
                                           alias = post.TBL_USUARIOS.USUARIO_CODIGO,
                                           codigo = post.TBL_USUARIOS.USUARIO_CODIGO,
                                           id = post.TBL_USUARIOS.USUARIO_ID,
                                           rango = new Rango
                                           {
                                               id = post.TBL_USUARIOS.TBL_RANGOS.RANGO_ID,
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

                                   }).OrderByDescending(x => x.contComentarios).Take(cuantos).ToList()
                        select new PostDestacado
                        {
                            destaque = PostDestacado.TIPO_DESTAQUE.COMENTARIO,
                            post = a

                        }).ToList();
            }
        }

        public static void addPoints(Punto contenido)
        {
            using(ReloadEntities db = new ReloadEntities())
            {
                db.TBL_POSTS.Single(x => x.POST_ID == contenido.idPost).POST_PUNTOS += contenido.cuantos;
                db.SaveChanges();
            }
        }

        public static void visit(int idPost)
        {
            using(ReloadEntities db = new ReloadEntities())
            {
                db.TBL_POSTS.Single(x => x.POST_ID == idPost).POST_VISITAS++;
                db.SaveChanges();
            }
        }

        public static List<PostDestacado> obtenerPostRecientes(int cuantos)
        {

            using (ReloadEntities db = new ReloadEntities())
            {
                return (from a in (from post in db.TBL_POSTS
                                   orderby post.POST_CANT_COMENTARIOS
                                   where !post.POST_DEBAJA
                                   select new Post
                                   {
                                       activo = post.POST_DEBAJA,
                                       categoria = new Categoria
                                       {
                                           id = post.TBL_CATEGORIAS.CATEGORIA_ID,
                                           logo = post.TBL_CATEGORIAS.CATEGORIA_LOGO,
                                           nombre = post.TBL_CATEGORIAS.CATEGORIA_NOMBRE
                                       },
                                       id = post.POST_ID,
                                       contenido = post.POST_COTENIDO,
                                       contenidoEditor = post.POST_CONTENIDO_EDIT,
                                       etiquetas = post.POST_TAGS,
                                       favoritos = post.POST_FAVORITOS,
                                       propietario = new Sujeto
                                       {
                                           alias = post.TBL_USUARIOS.USUARIO_CODIGO,
                                           codigo = post.TBL_USUARIOS.USUARIO_CODIGO,
                                           id = post.TBL_USUARIOS.USUARIO_ID,
                                           rango = new Rango
                                           {
                                               id = post.TBL_USUARIOS.TBL_RANGOS.RANGO_ID,
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
                                       visitas = post.POST_VISITAS,
                                       imagen = post.POST_IMAGEN

                                   }).Take(cuantos).ToList()
                        select new PostDestacado
                        {
                            destaque = PostDestacado.TIPO_DESTAQUE.RECIENTE,
                            post = a

                        }).ToList();
            }


        }

        public static Post editPost(Post post)
		{
			using(ReloadEntities db = new ReloadEntities())
            {
                TBL_POSTS postDB = db.TBL_POSTS.Single(x => x.POST_ID == post.id);

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
                    POST_COMENTARIO_POST_ID = commentary.postid,
                    POST_COMENTARIO_USUARIO_ID = commentary.emisor.id
                });
                db.SaveChanges();
            }
		}

        public static DTO.Post getPost(int idPost)
        {
            using (ReloadEntities db = new ReloadEntities())
            {
                var post = (from p in db.TBL_POSTS
                            where !p.POST_DEBAJA && p.POST_ID == idPost select p).FirstOrDefault();

                Post po =new Post
                        {
                            activo = post.POST_DEBAJA,
                            categoria = new Categoria
                            {
                                id = post.TBL_CATEGORIAS.CATEGORIA_ID,
                                logo = post.TBL_CATEGORIAS.CATEGORIA_LOGO,
                                nombre = post.TBL_CATEGORIAS.CATEGORIA_NOMBRE
                            },
                            id = post.POST_ID,
                            contenido = post.POST_COTENIDO,
                            contenidoEditor = post.POST_CONTENIDO_EDIT,
                            etiquetas = post.POST_TAGS,
                            favoritos = post.POST_FAVORITOS,
                            propietario = new Sujeto
                            {
                                alias = post.TBL_USUARIOS.USUARIO_CODIGO,
                                codigo = post.TBL_USUARIOS.USUARIO_CODIGO,
                                id = post.TBL_USUARIOS.USUARIO_ID,
                                rango = new Rango
                                {
                                    id = post.TBL_USUARIOS.TBL_RANGOS.RANGO_ID,
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
                            visitas = post.POST_VISITAS,
                            imagen = post.POST_IMAGEN

                        };
                po.fechaAlta = post.POST_FECALT.ToShortDateString();
                po.fechaModificacion = post.POST_FECMOD.ToShortDateString();

                foreach(var comentarioDB in post.TBL_POST_COMENTARIOS)
                {
                    po.comentarios.Add(new Comentario
                    {
                        contenido = comentarioDB.POST_COMENTARIO_CONTENIDO,
                        debaja = comentarioDB.POST_COMENTARIO_DEBAJA,
                        dislikes = comentarioDB.POST_COMENTARIO_NEG,
                        emisor = new Sujeto
                        {
                            alias = comentarioDB.TBL_USUARIOS.USUARIO_CODIGO,
                            imagen = comentarioDB.TBL_USUARIOS.USUARIO_IMAGEN,
                            //pais = new Pais
                            //{
                            //    codigo = comentarioDB.TBL_USUARIOS.TBL_PAISES.PAIS_CODIGO,
                            //    id = comentarioDB.TBL_USUARIOS.TBL_PAISES.PAIS_ID,
                            //    nombre = comentarioDB.TBL_USUARIOS.TBL_PAISES.PAIS_NOMBRE
                            //},
                            codigo = comentarioDB.TBL_USUARIOS.USUARIO_CODIGO,
                            id = comentarioDB.TBL_USUARIOS.USUARIO_ID,
                            rango = new Rango
                            {
                                id = comentarioDB.TBL_USUARIOS.TBL_RANGOS.RANGO_ID,
                                descripcion = comentarioDB.TBL_USUARIOS.TBL_RANGOS.RANGO_DESCRP,
                                imagen = comentarioDB.TBL_USUARIOS.TBL_RANGOS.RANGO_IMAGEN,
                                nombre = comentarioDB.TBL_USUARIOS.TBL_RANGOS.RANGO_NOMBRE

                            }
                        },
                        esMensajePrivado = false,
                        likes = comentarioDB.POST_COMENTARIO_POS,
                        postid = comentarioDB.POST_COMENTARIO_POST_ID,
                        id = comentarioDB.POST_COMENTARIO_ID
                    });
                }

                return po;
            }
        }
    }
}
