using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ReloadWS.Security
{
    public class DistributorValidator: ServiceAuthorizationManager
	{
		protected override bool CheckAccessCore(OperationContext operationContext)
		{
			//Extract the Authorization header, and parse out the credentials converting the Base64 string:  
			var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
			var accion = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

			TokenGenerator.GenerateToken("hola");
	
			if ((authHeader != null) && (authHeader != string.Empty))
			{
				var svcCredentials = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authHeader)).Split(':');

				var user = new { Name = svcCredentials[1].Split(',')[0].Replace('"',' ').Trim(), Password = svcCredentials[2].Replace('"',' ').Replace('}',' ').Trim() };

				if ((user.Name.Equals("Lucho") && user.Password.Equals("123")))
				{
					//User is authrized and originating call will proceed  
					return true;
				}
				else
				{
					//not authorized  
					return false;
				}
			}
			else
			{
				if(accion.ToString().ToUpper().Equals("REGISTRO") || accion.ToString().ToUpper().Equals("LOGEO"))
				{
					return true;
				}
				//No authorization header was provided, so challenge the client to provide before proceeding:  
				WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"MyWCFService\"");
				//Throw an exception with the associated HTTP status code equivalent to HTTP status 401  
				throw new WebFaultException(HttpStatusCode.Unauthorized);
			}
		}
	}
}

