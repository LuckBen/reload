using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Host
{
    public class Program
    {

		public static void Main(string[] args)
		{
            //Security.TokenGenerator.validarIntegridadToken("lucho", DateTime.Now, "0X7pDS51y2BDPCGuUMzU55s+11F/G7CYfFPRMpqzWT4=");
			System.ServiceModel.ServiceHost hostServicioReload = new System.ServiceModel.ServiceHost(typeof(ReloadWS.Service.ReloadService));
            System.ServiceModel.ServiceHost hostServicioReloadAuthentication = new System.ServiceModel.ServiceHost(typeof(ReloadWS.Service.ReloadServiceAuthentication));
            try { 
                hostServicioReload.Open();
                hostServicioReloadAuthentication.Open();
                Console.Read();
            } catch(Exception ex)
            {
                Security.Logs.grabar(ex);
            }
            finally
            {
                hostServicioReload.Close();
                hostServicioReloadAuthentication.Close();
            }

        }

    }
}
