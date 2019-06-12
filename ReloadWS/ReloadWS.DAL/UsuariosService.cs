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
    public class UsuariosService : Servicio
    {

        public Usuario getUsuario(string codigo)
        {
            
            estado.iniciar();
            var client = new MongoClient(Conexion.cadenaConexion);
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");
            //BsonDocument bsondoc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>("{ { _id: ObjectId(1) } }");
            //var result = colUsuarios.Find(bsondoc);

            var result = (from d in colUsuarios.AsQueryable<Usuario>()
                          where d.codigo.Equals(codigo)
                          select new Usuario
                          {
                              codigo = d.codigo

                          }).FirstOrDefault();
                            
            return result.tob

        }
    }
}
