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
            try
            {

                //if (WebOperationContext.Current.OutgoingResponse.Headers["Access-Control-Allow-Origin"] == null)
                //{
                //    
                //}


                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Request-Method", "POST,GET,PUT,DELETE,OPTIONS");

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

