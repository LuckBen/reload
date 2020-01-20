using System;
using System.Collections.Generic;
using System.Linq;
using ReloadWS.DTO;
using ReloadWS.DAL.Persistencia;

namespace ReloadWS.DAL.Api
{
    public static class UsuariosDB 
    {
        static UsuariosDB()
        {
        }

		public static Usuario obtenerUsuarioPorMail(string mail)
		{

            using (ReloadEntities db = new ReloadEntities()) {
                return (from a in db.TBL_USUARIOS
                        where a.USUARIO_MAIL == mail
                        select new Usuario
                        {
                            codigo = a.USUARIO_CODIGO

                        }).FirstOrDefault();
            }

            
		}

		/// <summary>
		/// busca un usuario por su mail, y lo pone como activo.
		/// </summary>
		public static void actualizarActivoPorMail(string mail)
		{
			using(ReloadEntities db = new ReloadEntities())
            {
                db.TBL_USUARIOS.Single(x => x.USUARIO_MAIL == mail).USUARIO_ACTIVO = true;
                db.SaveChanges();
            }
		}

        public static Usuario obtenerUsuario(string codigo)
        {

            using (ReloadEntities db = new ReloadEntities())
            {
                TBL_USUARIOS UsuarioDB = (from a in db.TBL_USUARIOS
                                          where a.USUARIO_CODIGO == codigo
                                          select a).FirstOrDefault();

                if(UsuarioDB == null)
                {
                    return null;
                }

                Usuario Usuario = new Usuario
                {
                    codigo = UsuarioDB.USUARIO_CODIGO,
                    activo = UsuarioDB.USUARIO_ACTIVO,
                    password = UsuarioDB.USUARIO_PASSWORD,
                    info = new UsuarioInfo
                    {
                        apellido = UsuarioDB.USUARIO_APELLIDO,
                        datosProfes = UsuarioDB.USUARIO_DATOS_PROF,
                        fechaNac = ((DateTime)(UsuarioDB.USUARIO_FECHANAC == null ? DateTime.Now : UsuarioDB.USUARIO_FECHANAC)).ToShortDateString(),
                        habitos = UsuarioDB.USUARIO_HABITOS,
                        fechaAlta = UsuarioDB.USUARIO_FECALT.ToShortDateString(),
                        idiomas = UsuarioDB.USUARIO_IDIOMAS,
                        imagen = UsuarioDB.USUARIO_IMAGEN,
                        nombre = UsuarioDB.USUARIO_NOMBRE,
                        sexo = UsuarioDB.USUARIO_SEXO
                    },
                    mail = UsuarioDB.USUARIO_MAIL,
                    puntos = UsuarioDB.USUARIO_PUNTOS,
                    id = UsuarioDB.USUARIO_ID

                };

                if(UsuarioDB.TBL_PAISES != null)
                {
                    Usuario.info.pais = new Pais
                    {
                        nombre = UsuarioDB.TBL_PAISES.PAIS_NOMBRE,
                        codigo = UsuarioDB.TBL_PAISES.PAIS_CODIGO,
                        id = UsuarioDB.TBL_PAISES.PAIS_ID
                    };
                }

                if (UsuarioDB.TBL_RANGOS != null)
                {
                    Usuario.rango = new Rango
                    {
                        descripcion = UsuarioDB.TBL_RANGOS.RANGO_DESCRP,
                        id = UsuarioDB.TBL_RANGOS.RANGO_ID,
                        imagen = UsuarioDB.TBL_RANGOS.RANGO_IMAGEN,
                        nombre = UsuarioDB.TBL_RANGOS.RANGO_NOMBRE,
                        puntosDar = UsuarioDB.TBL_RANGOS.RANGO_PUNTOS_DAR,
                        puntosRequeridos = UsuarioDB.TBL_RANGOS.RANGO_PUNTOS_REQ
                    };
                }

                foreach(var post in UsuarioDB.TBL_POSTS)
                {
                    Post postTemp = new Post();
                    postTemp.activo = post.POST_DEBAJA;

                    postTemp.categoria = new Categoria
                    {
                        nombre = post.TBL_CATEGORIAS.CATEGORIA_NOMBRE,
                        id = post.TBL_CATEGORIAS.CATEGORIA_ID,
                        logo = post.TBL_CATEGORIAS.CATEGORIA_LOGO
                    };

                    postTemp.imagen = post.POST_IMAGEN;

                    postTemp.puntos = post.POST_PUNTOS;
                    postTemp.seComenta = post.POST_SE_COMENTA;
                    postTemp.seguidores = post.POST_SEGUIDORES;
                    postTemp.sticky = post.POST_STICKY;
                    postTemp.tags = post.POST_TAGS.Split(',').ToList();
                    postTemp.titulo = post.POST_TITULO;
                    postTemp.visitas = post.POST_VISITAS;
                    postTemp.fechaAlta = post.POST_FECALT.ToShortDateString();
                    postTemp.id = post.POST_ID;
                    postTemp.contenido = post.POST_COTENIDO;
                    postTemp.contenidoEditor = post.POST_CONTENIDO_EDIT;
                    postTemp.favoritos = post.POST_FAVORITOS;

                    Usuario.posts.Add(postTemp);
                }

                return Usuario;
            }
            
        }

		public static void grabar(Usuario usuario)
        {
            using(ReloadEntities db = new ReloadEntities())
            {
                db.TBL_USUARIOS.Add(new TBL_USUARIOS
                {
                    USUARIO_CODIGO = usuario.codigo,
                    USUARIO_PASSWORD = usuario.password,
                    USUARIO_MAIL = usuario.mail,
                    USUARIO_FECALT = DateTime.Now,
                    USUARIO_RANGO = usuario.rango.id
                });
                db.SaveChanges();
            }
        }

        public static void grabarMail(string mail)
        {
            throw new NotImplementedException();
        }

        public static void grabarMail(string usuarioCodigo,string mail )
        {
            using(ReloadEntities db = new ReloadEntities())
            {
                db.TBL_USUARIOS.Single(x => x.USUARIO_CODIGO == usuarioCodigo).USUARIO_MAIL = mail;
                db.SaveChanges();
            }

        }

        public static void grabarClave(string codigo, string claveNueva)
        {
            using(ReloadEntities db = new ReloadEntities())
            {
                db.TBL_USUARIOS.Single(x => x.USUARIO_CODIGO == codigo).USUARIO_PASSWORD = claveNueva;
                db.SaveChanges();
            }
        }


		public static void grabarInfo(string username, UsuarioInfo info)
		{
            using (ReloadEntities db = new ReloadEntities())
            {
                TBL_USUARIOS UsuarioDB = db.TBL_USUARIOS.Single(x => x.USUARIO_CODIGO == username);
                UsuarioDB.USUARIO_NOMBRE = info.nombre;
                UsuarioDB.USUARIO_APELLIDO = info.apellido;
                UsuarioDB.USUARIO_IMAGEN = info.imagen;
               // UsuarioDB.USUARIO_FECHANAC =  DateTime.Parse(info.fechaNac);
                UsuarioDB.USUARIO_DATOS_PROF = info.datosProfes;
                UsuarioDB.USUARIO_HABITOS = info.habitos;
                UsuarioDB.USUARIO_SEXO = info.sexo;
                UsuarioDB.USUARIO_PAIS_ID = info.pais.id;
                db.SaveChanges();
            }
		}

	}
}
