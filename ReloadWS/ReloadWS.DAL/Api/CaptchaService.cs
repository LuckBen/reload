using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReloadWS.DTO;

namespace ReloadWS.DAL.Api
{
	public static class CaptchaDB
	{
        public static List<DTO.Captcha> getAll()
        {
            List<Captcha> captchas = new List<Captcha>();

            using (ReloadWS.DAL.Persistencia.ReloadEntities db = new Persistencia.ReloadEntities())
            {
                captchas = (from c in db.TBL_CAPTCHAS
                            select new Captcha
                            {
                                id = c.CAPTCHA_ID,
                                captcha = c.CAPTCHA_DATO,
                                respuesta = c.CAPTCHA_RESPUESTA
                            }).ToList();
            }


			return captchas;
		}
	}
}
