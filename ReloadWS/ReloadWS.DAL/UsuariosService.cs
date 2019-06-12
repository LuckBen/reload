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
    public static class UsuariosService 
    {
        public static Estado estado { get; set; }
        static UsuariosService()
        {
            estado = new ReloadWS.DAL.Estado();
        }
        public static Usuario getUsuario(string codigo)
        {
            
            estado.iniciar();
            var client = new MongoClient(Conexion.cadenaConexion);
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");
            //BsonDocument bsondoc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>("{ { _id: ObjectId(1) } }");
            //var result = colUsuarios.Find(bsondoc);

            Usuario result = (from d in colUsuarios.AsQueryable<Usuario>()
                          where d.codigo.Equals(codigo)
                          select new Usuario
                          {
                              codigo = d.codigo

                          }).FirstOrDefault();
            return result;
        }

        public static void grabar(Usuario usuario)
        {
            var client = new MongoClient(Conexion.cadenaConexion);
            var db = client.GetDatabase(Conexion.db);
            IMongoCollection<Usuario> colUsuarios = db.GetCollection<Usuario>("usuarios");
            colUsuarios.InsertOne(usuario);
        }

    }
}
