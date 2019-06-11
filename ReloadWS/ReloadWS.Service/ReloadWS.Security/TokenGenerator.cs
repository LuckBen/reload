using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Cryptography;
using System.IO;

namespace ReloadWS.Security
{
	public static class TokenGenerator
	{
		private static byte[] Clave = Encoding.ASCII.GetBytes("xddxxiiiiiiPPd");
		private static byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
		public static string GenerateToken(string Cadena)
		{
			// appsetting for Token JWT
			var secretKey = System.Configuration.ConfigurationSettings.AppSettings["JWT_SECRET_KEY"];

			byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
			byte[] encripted;
			RijndaelManaged cripto = new RijndaelManaged();
			using (MemoryStream ms = new MemoryStream(inputBytes.Length))
			{
				using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
				{
					objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
					objCryptoStream.FlushFinalBlock();
					objCryptoStream.Close();
				}
				encripted = ms.ToArray();
			}
			string eso = Convert.ToBase64String(encripted);

			string original = ValidarToken(eso);
			 return null;
		}

		public static string ValidarToken(string token)
		{
			byte[] inputBytes = Convert.FromBase64String(token);
			byte[] resultBytes = new byte[inputBytes.Length];
			string textoLimpio = String.Empty;
			RijndaelManaged cripto = new RijndaelManaged();
			using (MemoryStream ms = new MemoryStream(inputBytes))
			{
				using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
				{
					using (StreamReader sr = new StreamReader(objCryptoStream, true))
					{
						textoLimpio = sr.ReadToEnd();
					}
				}
			}
			return textoLimpio;
		}
	}
}
