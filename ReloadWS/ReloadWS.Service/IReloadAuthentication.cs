using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using ReloadWS.DTO.Response;
using ReloadWS.DTO.Request;

namespace ReloadWS.Service
{
    [ServiceContract]
    public interface IReloadAuthentication
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
		DTO.Response.Response<DTO.Usuario> logeo(LoginRequest loginRquest);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json)]
		DTO.Response.Response<DTO.Usuario> registro(RegistroRequest registroRequest);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "verificar-mail/{mail}")]
        string verificarMail(string mail);


        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json)]
        DTO.Request.RegistroRequest obtenerInfoRequest();

		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
					BodyStyle = WebMessageBodyStyle.Bare,
					RequestFormat = WebMessageFormat.Json)]
		DTO.Response.Response<DTO.Captcha> obtenerCaptcha();


	}
}
