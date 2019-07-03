using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DAL
{
    public static class Common
    {
        public static void insertarCategoria()
        {
            DTO.Categoria cat = new DTO.Categoria();
            cat._id = "32";
            cat.nombre = "Videos On-line";
            cat.logo = "film.png";
            var client = new MongoClient(Conexion.getSettings());
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<DTO.Categoria> colPaises = db.GetCollection<DTO.Categoria>("categorias");
            colPaises.InsertOne(cat);
        }

        public static DTO.Categoria[] getCategorias()
        {
            var client = new MongoClient(Conexion.getSettings());
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<DTO.Categoria> colCategorias = db.GetCollection<DTO.Categoria>("categorias");
            return (from dbcat in colCategorias.AsQueryable<DTO.Categoria>() select dbcat).ToArray();
        }
    }
}
