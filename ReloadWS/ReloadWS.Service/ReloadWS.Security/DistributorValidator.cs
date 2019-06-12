using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ReloadWS.Security
{
	public class DistributorValidator : ServiceAuthorizationManager
	{
		private string claveAccesoServicio;
		public DistributorValidator()
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
				var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
				var accion = WebOperationContext.Current.IncomingRequest.Headers["Action"];

				if ((authHeader != null) && (authHeader != string.Empty))
				{
					var token = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authHeader)).ToString();

					return token.ToString().Equals(this.claveAccesoServicio);
				}
			}
			catch (Exception)
			{

			}

			return false;
				
		}
	}
}

