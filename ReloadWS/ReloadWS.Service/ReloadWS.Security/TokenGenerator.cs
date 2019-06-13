//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Claims;
//using Microsoft.IdentityModel.Tokens;
//using System.Net;
//using System.Security.Cryptography;
//using System.IO;
//using System.ServiceModel.Channels;
//using System.ServiceModel;

//namespace ReloadWS.Security
//{
//	public static class TokenGenerator
//	{
//        public enum INTEGRIDAD_TOKEN { CORRUPTO, OK, EXPIRADO, NO_ENCONTRADO, NO_CORRESPONDE_USUARIO, USUARIO_NO_ENCONTRADO};
//		private static byte[] Clave;
//		private static byte[] IV ;
//        private static int tiempoLimiteTokenMinutos;
//		private const int TOKEN_IP = 0;
//		private const int TOKEN_USER = 1;
//		private const int TOKEN_TIME = 2;
//        static TokenGenerator()
//        {
//            tiempoLimiteTokenMinutos = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["tiempo_limite_token_minutos"]);
//            Clave = Encoding.ASCII.GetBytes(System.Configuration.ConfigurationSettings.AppSettings["JWT_SECRET_KEY"]);
//            IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
//        }

//		/// <summary>
//		/// TOKEN: username_ip_datetime
//		/// </summary>
//		/// <returns>token encrypted</returns>
//		public static string GenerateToken(string username)
//		{

//            string Cadena = getIpAddress() + "_" + username.ToUpper() + "_" + DateTime.Now.ToString();
//			return Encriptar(Cadena);
//		}

//		public static string getIpAddress()
//		{
//			OperationContext context = OperationContext.Current;
//            MessageProperties properties = context.IncomingMessageProperties;
//			RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
//			string address = string.Empty;
//			if (properties.Keys.Contains(HttpRequestMessageProperty.Name))
//			{
//				HttpRequestMessageProperty endpointLoadBalancer = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
//				if (endpointLoadBalancer != null && endpointLoadBalancer.Headers["X-Forwarded-For"] != null)
//					address = endpointLoadBalancer.Headers["X-Forwarded-For"];
//			}
//			if (string.IsNullOrEmpty(address))
//			{
//				address = endpoint.Address;
//			}
//			return address;
//		}

//		private static string Encriptar(string Cadena)
//		{
//			byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
//			byte[] encripted;
//			RijndaelManaged cripto = new RijndaelManaged();
//			using (MemoryStream ms = new MemoryStream(inputBytes.Length))
//			{
//				using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
//				{
//					objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
//					objCryptoStream.FlushFinalBlock();
//					objCryptoStream.Close();
//				}
//				encripted = ms.ToArray();
//			}
//			return Convert.ToBase64String(encripted);
//		}
//        public static INTEGRIDAD_TOKEN validarIntegridadToken(string token, string ipCliente)
//		{
//			try
//			{
//				string[] arrayToken = desencriptar(token).Split('_');
//				string ip = arrayToken[TOKEN_IP];
//				string usuarioToken = arrayToken[TOKEN_USER];
//				string fechaToken = arrayToken[TOKEN_TIME];

//				if (!UserSecurity.usersConnect.ContainsKey(usuarioToken))
//				{
//					return INTEGRIDAD_TOKEN.USUARIO_NO_ENCONTRADO;
//				}

//				string tokenLista = UserSecurity.usersConnect[usuarioToken].tokens.SingleOrDefault(x => x.Equals(token));

//				if (string.IsNullOrEmpty(tokenLista))
//				{
//					return INTEGRIDAD_TOKEN.NO_CORRESPONDE_USUARIO;
//				}

//				double diferencia = Math.Abs(DateTime.Now.TimeOfDay.TotalMinutes - DateTime.Parse(fechaToken).TimeOfDay.TotalMinutes);

//				if (diferencia > tiempoLimiteTokenMinutos)
//				{
//					return INTEGRIDAD_TOKEN.EXPIRADO;
//				}

//				return INTEGRIDAD_TOKEN.OK;

//			} catch (Exception)
//			{
//				return INTEGRIDAD_TOKEN.CORRUPTO;
//			}

//		}

//		public static string desencriptar(string token)
//		{
//			byte[] inputBytes = Convert.FromBase64String(token);
//			byte[] resultBytes = new byte[inputBytes.Length];
//			string textoLimpio = String.Empty;
//			RijndaelManaged cripto = new RijndaelManaged();
//			using (MemoryStream ms = new MemoryStream(inputBytes))
//			{
//				using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
//				{
//					using (StreamReader sr = new StreamReader(objCryptoStream, true))
//					{
//						textoLimpio = sr.ReadToEnd();
//					}
//				}
//			}
//			return textoLimpio;
//		}
//	}
//}
