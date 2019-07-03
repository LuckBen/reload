using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using ReloadWS.DTO.Response;
using ReloadWS.DTO.Request;

namespace ReloadWS.Service
{
	[ServiceContract]
	public interface IPostService
	{

		[OperationContract]
		[WebInvoke(Method = "*",
					ResponseFormat = WebMessageFormat.Json,
					BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate ="publicar")]
		Response<DTO.Post> addPost(Request<DTO.Post> post);

        [OperationContract]
        [WebInvoke(Method = "*",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "recientes")]
        Response<DTO.Post[]> getRecientes();


		[OperationContract]
		[WebInvoke(Method = "*",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		Request<DTO.Post> getPost();

		[OperationContract]
		[WebInvoke(Method = "*",
					ResponseFormat = WebMessageFormat.Json,
					BodyStyle = WebMessageBodyStyle.Bare)]
		Response<DTO.Post> editPost(Request<DTO.Post> post);

		[OperationContract]
		[WebInvoke(	Method = "*",
					ResponseFormat = WebMessageFormat.Json,
					BodyStyle = WebMessageBodyStyle.Bare)]
		void deletePost(Request<DTO.Post> post);

		[OperationContract]
		[WebInvoke(Method = "*",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		Response<string> comment(Request<DTO.Comentario> commentary);

	}
}
