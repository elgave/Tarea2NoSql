using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea2NoSqlApi.Models
{
    public class Comentario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("correoUsuario")]
        public string CorreoUsuario { get; set; }

        [BsonElement("contenido")]
        public string Contenido { get; set; }

        [BsonElement("cantMg")]
        public int CantMg { get; set; }

        [BsonElement("cantNoMg")]
        public int CantNoMg { get; set; }
    }
}
