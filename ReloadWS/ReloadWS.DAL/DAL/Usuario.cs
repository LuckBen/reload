using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReloadWS.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReloadWS.DAL.DAL
{
    public class UsuarioMongo:Usuario
    {
        [BsonElement("id")]
        public ObjectId Id { get; set; }
    }
}
