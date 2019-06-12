using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.ServiceModel;
using ReloadWS.DTO.Response;
using ReloadWS.DTO.Request;
using ReloadWS.BI;
namespace ReloadWS.Service
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ReloadService : IReloadService
	{
        public string registro(RegistroRequest registroRequest)
        {
            BI.UsersModule.Registro(registroRequest);
            return "Ok";
        }

        string IReloadService.logeo(LoginRequest loginRquest)
		{
			return "OK";
		}

        RegistroRequest IReloadService.saludo()
        {
            return new RegistroRequest
            {
                mail = "benedict.luciano@gmail.com",
                password = "xddxxd",
                usuario = "Lucho"
            };
        }


	}
}
