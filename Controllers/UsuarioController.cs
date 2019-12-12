using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiTw.Repositories;

namespace WebApiTw.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorie repositorio = new UsuarioRepositorie();

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            List<Usuario> usuarios = await repositorio.Get();

            if (usuarios == null)
            {
                return NotFound(new { mensagem = "Usuario nao encontrada" });
            }
            return usuarios;
        }

         [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
                
                await repositorio.Post(usuario);
            }
           
            catch (System.Exception)
            {
                throw;
            }
            return usuario;
        }

            [HttpPut("id")]
          public async Task<ActionResult> Put(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest(new { mensagem = "Id Nao encontrado" });
            }
           
            else
            {
                await repositorio.Put(id,usuario);
            }

            return NoContent();
        
         }

        //  [HttpGet("FiltroPorNome")]
        // public ActionResult<List<Usuario>> Filtro([FromBody]string filtro)
        // {
        //     List<Usuario> usuarioFiltrado = repositorio.Filtro(filtro);

        //     return usuarioFiltrado;
        // }
    }
}