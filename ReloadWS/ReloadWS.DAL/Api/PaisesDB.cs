using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReloadWS.DAL.Persistencia;
using ReloadWS.DTO;

namespace ReloadWS.DAL.Api
{
    public static class PaisesDB
    {
        public static void insertarPaises()
        {

            var paises = getPaises();
            using (ReloadEntities db = new Persistencia.ReloadEntities())
            {
                foreach(var pais in paises)
                {
                    db.TBL_PAISES.Add(new Persistencia.TBL_PAISES
                    {
                        PAIS_CODIGO = pais.codigo,
                        PAIS_NOMBRE = pais.nombre
                    });
                    db.SaveChanges();
                }
            }


        }

        public static Pais[] getPaises()
        {

            using(ReloadEntities db = new ReloadEntities())
            {
                return (from a in db.TBL_PAISES select new Pais { codigo = a.PAIS_CODIGO, nombre = a.PAIS_NOMBRE, id = a.PAIS_ID }).ToArray();
            }

        }
    }
}
