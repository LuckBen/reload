using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.ServiceModel;
using ReloadWS.DTO.Response;
using ReloadWS.DTO.Request;
using ReloadWS.BI;
using ReloadWS.DTO;

namespace ReloadWS.Service
{
    
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ReloadService : IPostService, IUsuarioService, IHelperService
    {
        #region USUARIO
        Response<string> IUsuarioService.cambiarClave(Request<RequestCambioClave> requestCambioClave)
        {
            Response<string> respuesta = new Response<string>();
            BI.UsersModule.cambiarClave(requestCambioClave);
            respuesta.estado = BI.UsersModule.estado;
            return respuesta;
        }

        public Response<UsuarioInfo> saveInfo(Request<UsuarioInfoRequest> info)
        {
            Response<UsuarioInfo> respuesta = new Response<UsuarioInfo>();
            if (info == null)
            {
                return respuesta;
            }
            BI.UsersModule.grabarInfo(info.usuario, info.contenido.usuarioInfo);
            BI.UsersModule.grabarMail(info.usuario, info.contenido.mail);

            respuesta.estado = BI.UsersModule.estado;

            return respuesta;
        }

        public Request<UsuarioInfo> obtenerInfo()
        {
            UsuarioInfo userinfo = new UsuarioInfo();
            userinfo.apellido = "benedict";
            userinfo.datosProfes = "Programador";
            userinfo.fechaNac = DateTime.Now.ToShortDateString();
            userinfo.habitos = "gym";
            userinfo.idiomas = "ingles";
            userinfo.nombre = "Luciano";
            userinfo.pais = new Pais
            {
                nombre = "Argentina",
                codigo = "AR"
            };
            userinfo.propiasPalabras = "blablabla";
            userinfo.sexo = "M";

            return new Request<UsuarioInfo>()
            {
                contenido = userinfo,
                token = "asdda",
                usuario = "Lucho"
            };
        }
        public Response<DTO.Pais[]> getPaises()
        {
            Response<DTO.Pais[]> respuesta = new Response<DTO.Pais[]>();
            respuesta.contenido = BI.PaisesModule.getPaises();
            respuesta.estado = BI.PaisesModule.estado;
            return respuesta;
        }
        void IUsuarioService.exit(string username)
        {
            BI.UsersModule.usuariosConectados.quitarToken(username, BI.TokenModule.obtenerTokenCliente());
        }
        #endregion

        public Response<Post> addPost(Request<Post> requestPost)
        {
            Response<Post> respuesta = new Response<Post>();
            BI.PostModule.addPost(requestPost?.contenido);
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

        public Response<Categoria[]> getCategorias()
        {
            DTO.Response.Response<DTO.Categoria[]> respuesta = new Response<Categoria[]>();
            respuesta.contenido =  BI.Helper.getCategorias();
            respuesta.estado = new Estado();
            return respuesta;

        }

        public Response<Post[]> getRecientes()
        {
            Response<Post[]> respuesta = new Response<Post[]>();
            respuesta.contenido = BI.PostModule.getRecientes();
            respuesta.estado = BI.PostModule.estado;
            return respuesta;
        }
    }
}
