using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using ReloadWS.DTO.Response;

namespace ReloadWS.Service
{


	[ServiceContract]
	public interface IReloadService
    {
		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		string logeo(LoginResponse loginResponse);
	}
}
