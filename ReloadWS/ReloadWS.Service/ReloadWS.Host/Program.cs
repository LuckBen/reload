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
			System.ServiceModel.ServiceHost hostUserService = new System.ServiceModel.ServiceHost(typeof(ReloadWS.Service.UsuarioService));
            System.ServiceModel.ServiceHost hostAuthenticationService = new System.ServiceModel.ServiceHost(typeof(ReloadWS.Service.AuthenticationService));
			System.ServiceModel.ServiceHost hostPostService = new System.ServiceModel.ServiceHost(typeof(ReloadWS.Service.PostService));

            try {

				hostUserService.Open();
				hostAuthenticationService.Open();
				hostPostService.Open();
                Console.Read();

            } catch(Exception ex)
            {
                Security.Logs.grabar(ex);
            }
            finally
            {
				hostUserService.Close();
				hostAuthenticationService.Close();
				hostPostService.Close();
            }

        }

    }
}
