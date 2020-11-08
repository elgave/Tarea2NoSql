using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea2NoSqlApi.Models;

namespace Tarea2NoSqlApi.Services
{
    public class UsuarioService
    {
        private IMongoCollection<Usuario> _usuarios;

        public UsuarioService(ITarea2NoSqlSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _usuarios = database.GetCollection<Usuario>(settings.CollectionUsuarios);
        }
        public bool ExisteUsuario(string correo)
        {
            if (_usuarios.Find(u => u.Correo == correo).CountDocuments() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

    }
}
