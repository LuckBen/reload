using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

using ReloadWS.DTO;
namespace ReloadWS.DAL
{
    public static class PaisesDB
    {
        public static void insertarPaises(DTO.Pais[] paises)
        {
            var client = new MongoClient(Conexion.getSettings());
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Pais> colPaises = db.GetCollection<Pais>("paises");
            colPaises.InsertMany(paises);
        }
    }
}
