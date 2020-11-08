 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea2NoSqlApi.Models;
using Tarea2NoSqlApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea2NoSqlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        public ComentarioService _comentarioService;
        public UsuarioService _usuarioService;
        public ComentarioController(ComentarioService comentarioService, UsuarioService usuarioService )
        {
            _comentarioService = comentarioService;
            _usuarioService = usuarioService;
        }
        // GET: api/<ComentarioController>
        [HttpGet]
        public  ActionResult<List<Comentario>> Get()
        {
            return _comentarioService.Get();
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Comentario> GetId(string id)
        {
            return _comentarioService.GetById(id);
        }

        [HttpPost]
        public ActionResult<Comentario> Create(Comentario comentario)
        {
            if (_usuarioService.ExisteUsuario(comentario.CorreoUsuario))
            {
                if (comentario.Contenido.Length > 256)
                {
                    return BadRequest("El texto no puede superar los 256 caracteres");
                }
                else
                {
                    _comentarioService.Create(comentario);
                    return Ok(comentario);
                }
            }
            else
                return BadRequest("No existe un usuario con el correo: " + comentario.CorreoUsuario.ToString());
            
        }
        
        [HttpPut("{idComentario}/{emocion}")]
        public ActionResult AgregarEmocion(string idComentario, string emocion)
        {
            _comentarioService.AgregarEmocion(idComentario, emocion);
            return Ok();
        }

        [HttpGet("GetComenariosUsu/{correoUsuario}")]
        public ActionResult<List<Comentario>> GetComentariosUsu(string correoUsuario)
        {
            return _comentarioService.ObtenerComentariosDeUsuario(correoUsuario);
        }

    }
}
