using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReloadWS.DTO;
using MongoDB.Driver;

namespace ReloadWS.DAL
{
	public static class CaptchaDB
	{
		public static List<DTO.Captcha> getAll()
		{
			var client = new MongoClient(Conexion.getSettings());
			var db = client.GetDatabase(Conexion.db);
			IMongoCollection<DTO.Captcha> colCaptchas = db.GetCollection<DTO.Captcha>("Captchas");

			List<DTO.Captcha> result = (from d in colCaptchas.AsQueryable<DTO.Captcha>()
										select d).ToList();

			return result;
		}
	}
}
