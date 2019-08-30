using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ReloadWS.Service
{
    [ServiceContract]
    public interface IRangoService
    {
        [OperationContract]
        [WebInvoke(Method = "*", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "rangos")]
        DTO.Rango[] getRangos();
        
    }
}
