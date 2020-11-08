using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea2NoSqlApi.Models
{
    public class Tarea2NoSqlSettings:ITarea2NoSqlSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string CollectionComentarios { get; set; }

        public string CollectionUsuarios { get; set; }
    }

    public interface ITarea2NoSqlSettings
    {
         string Server { get; set; }
         string Database { get; set; }
         string CollectionComentarios { get; set; }
         string CollectionUsuarios { get; set; }
    }
}
