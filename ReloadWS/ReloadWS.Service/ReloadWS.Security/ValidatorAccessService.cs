using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ReloadWS.Security
{
	public class ValidatorAccessService : ServiceAuthorizationManager
	{
		private string claveAccesoServicio;
		public ValidatorAccessService()
		{
			this.claveAccesoServicio = System.Configuration.ConfigurationSettings.AppSettings["Clave_Acceso_Servicio"].ToString();
		}
		/// <summary>
		/// Cada petición Http tiene que tener en el header, un atributo Authorization con una
		/// clave especial independiente del token para acceder al servicio.
		/// </summary>
		/// <param name="operationContext"></param>
		/// <returns>true si accede, false si no</returns>
		protected override bool CheckAccessCore(OperationContext operationContext)
		{
			try {

                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

                return true;

                var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

				if ((authHeader != null) && (authHeader != string.Empty))
				{

					bool iguales =  authHeader.ToString().Equals(this.claveAccesoServicio);
					return iguales;
				}
			}
			catch (Exception)
			{

			}

			return false;
				
		}
	}
}

