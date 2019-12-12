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
    public class SalaController : ControllerBase
    {
         SalaRepositorie repositorio = new SalaRepositorie();
         [HttpGet]
        public async Task<ActionResult<List<Sala>>> Get()
        {
            List <Sala> salas = await repositorio.Get();

            if (salas == null)
            {
                return NotFound(new { mensagem = "Nenhuma sala encontrada" });
            }
            return salas;
        }

         [HttpPost]
        public async Task<ActionResult<Sala>> Post(Sala sala)
        {
            try
            {
                
                await repositorio.Post(sala);
            }
           
            catch (System.Exception)
            {
                throw;
            }
            return sala;
        }

        [HttpPut("Id")]
          public async Task<ActionResult> Put(int id, Sala sala)
        {
            if (id != sala.IdSala)
            {
                return BadRequest(new { mensagem = "Id da sala nao encontrado" });
            }
           
            else
            {
                await repositorio.Put(id,sala);
            }

            return NoContent();
        
         }

    }
}