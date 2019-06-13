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
        Security.Response<DTO.Usuario> IReloadService.logeo(LoginRequest loginRquest)
        {
            Security.Response<DTO.Usuario> respuesta = new Security.Response<DTO.Usuario>();
            return respuesta;
        }
    }
}
