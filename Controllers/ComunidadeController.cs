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
    public class ComunidadeController : ControllerBase
    {
          ComunidadeRepositorie repositorio = new ComunidadeRepositorie();

        [HttpGet]
        public async Task<ActionResult<List<Comunidade>>> Get()
        {
            List<Comunidade> comunidade = await repositorio.Get();

            if (comunidade == null)
            {
                return NotFound(new { mensagem = "Nenhuma categoria encontrada" });
            }
            return comunidade;
        }

         [HttpPost]
        public async Task<ActionResult<Comunidade>> Post(Comunidade comunidade)
        {
            try
            {
                
                await repositorio.Post(comunidade);
            }
           
            catch (System.Exception)
            {
                throw;
            }
            return comunidade;
        }

          public async Task<ActionResult> Put(int id, Comunidade comunidade)
        {
            if (id != comunidade.IdComunidade)
            {
                return BadRequest(new { mensagem = "Inconsistência nos IDs informados" });
            }
           
            else
            {
                await repositorio.Put(id,comunidade);
            }

            return NoContent();
        
         }
    }
}