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
    public interface IHelperService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "*",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate ="categorias")]
        DTO.Response.Response<DTO.Categoria[]> getCategorias();
    }
}
