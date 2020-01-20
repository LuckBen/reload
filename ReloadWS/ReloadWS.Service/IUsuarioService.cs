using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using ReloadWS.DTO.Response;
using ReloadWS.DTO.Request;

namespace ReloadWS.Service
{
	[ServiceContract]
	public interface IUsuarioService
    {
        [OperationContract]
        [WebInvoke(Method = "*",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        void exit(string username);

        [OperationContract]
        [WebInvoke(Method = "*",
    ResponseFormat = WebMessageFormat.Json,
    RequestFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Bare)]
        Response<string> cambiarClave(Request<DTO.Request.RequestCambioClave> requestCambioClave);

        [OperationContract]
		[WebInvoke(Method = "*",
			ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		Response<DTO.Usuario> saveInfo(Request<DTO.Request.UsuarioInfoRequest> info);

        [OperationContract]
        [WebInvoke(Method = "*",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        Request<DTO.UsuarioInfo> obtenerInfo();

        [OperationContract]
        [WebInvoke(Method = "*",
        BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "paises")]
        Response<DTO.Pais[]> getPaises();
    }
}
