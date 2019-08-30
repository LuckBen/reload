using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReloadWS.DTO;
using ReloadWS.DAL.Persistencia;

namespace ReloadWS.DAL.Api
{
    public static class RangoDB
    {
   
        public static Rango[] GetAll()
        {
            using(ReloadEntities db = new ReloadEntities())
            {
                return (from a in db.TBL_RANGOS
                        select new Rango
                        {
                            descripcion = a.RANGO_DESCRP,
                            id = a.RANGOid,
                            imagen = a.RANGO_IMAGEN,
                            nombre = a.RANGO_NOMBRE,
                            puntosDar = a.RANGO_PUNTOS_DAR,
                            puntosRequeridos = a.RANGO_PUNTOS_REQ

                        }).ToArray();
            }
        }
    }
}
