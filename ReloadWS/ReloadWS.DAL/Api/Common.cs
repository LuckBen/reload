using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReloadWS.DTO;
using ReloadWS.DAL.Persistencia;

namespace ReloadWS.DAL.Api
{
    public static class Common
    {
        public static Categoria[] getCategorias()
        {
            using(ReloadEntities db = new ReloadEntities())
            {
                return (from a in db.TBL_CATEGORIAS select new Categoria
                {
                    id = a.CATEGORIAid,
                    nombre = a.CATEGORIA_NOMBRE,
                    logo = a.CATEGORIA_LOGO
                }).ToArray();
            }

        }
    }
}
