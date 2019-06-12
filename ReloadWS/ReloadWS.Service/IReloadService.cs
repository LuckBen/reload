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
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		string logeo(LoginRequest loginRquest);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        string registro(RegistroRequest registroRequest);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Bare,  RequestFormat = WebMessageFormat.Json)]
        RegistroRequest saludo();

    }
}
