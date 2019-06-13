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
        public enum INTEGRIDAD_TOKEN { CORRUPTO, OK, EXPIRADO};
		private static byte[] Clave;
		private static byte[] IV ;
        private static int tiempoLimiteTokenMinutos;
        static TokenGenerator()
        {
            tiempoLimiteTokenMinutos = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["tiempo_limite_token_minutos"]);
            Clave = Encoding.ASCII.GetBytes(System.Configuration.ConfigurationSettings.AppSettings["JWT_SECRET_KEY"]);
            IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
        }

		public static string GenerateToken(string Cadena)
		{
            // appsetting for Token JWT

            Cadena = Cadena + "_" + DateTime.Now.ToString();
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
			return Convert.ToBase64String(encripted);
		}

        public static INTEGRIDAD_TOKEN validarIntegridadToken(string usuario,DateTime emision, string token)
        {
            try {
                string[] arrayToken = desencriptarToken(token).Split('_');
                string usuarioToken = arrayToken[0];
                string fechaToken = arrayToken[1];

                if (!usuario.ToUpper().Equals(usuarioToken.ToUpper()))
                {
                    return INTEGRIDAD_TOKEN.CORRUPTO;
                }

                if (!emision.Equals(DateTime.Parse(fechaToken))) {
                    return INTEGRIDAD_TOKEN.CORRUPTO;
                }
                double diferencia = Math.Abs(DateTime.Now.TimeOfDay.TotalMinutes - emision.TimeOfDay.TotalMinutes);
                if (diferencia > tiempoLimiteTokenMinutos)
                {
                    return INTEGRIDAD_TOKEN.EXPIRADO;
                }

                return INTEGRIDAD_TOKEN.OK;

            } catch (Exception)
            {
                return INTEGRIDAD_TOKEN.CORRUPTO;
            }


        }



		public static string desencriptarToken(string token)
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
