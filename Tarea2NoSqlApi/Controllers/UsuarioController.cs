using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea2NoSqlApi.Models;
using Tarea2NoSqlApi.Services;

namespace Tarea2NoSqlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        public ActionResult<Usuario> Create(Usuario usuario)
        {
            if (_usuarioService.ExisteUsuario(usuario.Correo))
            {
                return BadRequest("Ya existe un usuario con el correo: " + usuario.Correo.ToString());
            }
            else
            {
                _usuarioService.Create(usuario);
                return Ok(usuario);
            }
        }
    }
}
