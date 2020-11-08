using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea2NoSqlApi.Models;

namespace Tarea2NoSqlApi.Services
{
    public class ComentarioService
    {
        private IMongoCollection<Comentario> _comentarios; 

        public ComentarioService(ITarea2NoSqlSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _comentarios = database.GetCollection<Comentario>(settings.CollectionComentarios);
        }

        public List<Comentario> Get()
        {
            return _comentarios.Find(d => true).ToList();
        }
        public Comentario GetById(string id)
        {
            return _comentarios.Find(d => d.Id == id).First();
        }

        public Comentario Create(Comentario comentario)
        {
            _comentarios.InsertOne(comentario);
            return comentario;
        }

        public void AgregarEmocion(string idComentario, string emocion)
        {
            Comentario com = GetById(idComentario);

            if (emocion.Equals("1"))
            {
                com.CantMg += 1;

            }
            else
            {
                com.CantNoMg += 1;
            }
            
            _comentarios.ReplaceOne(comentario => comentario.Id == idComentario, com);

        }
        public List<Comentario> ObtenerComentariosDeUsuario(string correoUsuario)
        {
            return _comentarios.Find(c => c.CorreoUsuario == correoUsuario).ToList();
        }
    }
}
