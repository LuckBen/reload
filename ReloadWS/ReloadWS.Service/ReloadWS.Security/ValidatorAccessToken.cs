using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace ReloadWS.Security
{
	public class ValidatorAccessToken : ServiceAuthorizationManager
	{
		private string claveAccesoServicio;
		
		public ValidatorAccessToken()
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
				
				ValidatorAccessService validatorService = new ValidatorAccessService();
				if (!validatorService.CheckAccess(operationContext))
				{
					return false;
				}

                return true;


                string tokenHeader = BI.TokenModule.obtenerTokenCliente();
				string ip = ReloadWS.BI.Helper.getIPAddress();
				
                return (ReloadWS.BI.TokenModule.validarIntegridadToken(tokenHeader, ip) == ReloadWS.BI.TokenModule.INTEGRIDAD_TOKEN.OK);
			
			}
			catch (Exception)
			{

			}

			return false;
				
		}


	}
}

