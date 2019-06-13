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
	public interface IReloadService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare)]
        void salir(string username);

		[OperationContract]
		[WebInvoke(Method = "POST",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		Response<DTO.UsuarioInfo> grabarInfo(Request<DTO.UsuarioInfo> info);

		[OperationContract]
		[WebInvoke(Method = "POST",
		ResponseFormat = WebMessageFormat.Json,
		BodyStyle = WebMessageBodyStyle.Bare)]
		Request<DTO.UsuarioInfo> obtenerInfo();
	}
}
