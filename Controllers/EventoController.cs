
using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WebApiTw.Repositories;

namespace WebApiTw.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class EventoController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
         EventoRepositore repositorio = new EventoRepositore();
        [HttpGet]
        public async Task<ActionResult<List<Evento>>> Get()
        {
            List<Evento> eventos = await repositorio.Get();

            if (eventos == null)
            {
                return NotFound(new { mensagem = "Nenhum evento encontrada" });
            }
            System.Console.WriteLine(eventos);
            return eventos;
        }

         [HttpPost]
        public async Task<ActionResult<Evento>> Post(Evento evento)
        {
            try
            {
                
                await repositorio.Post(evento);
            }
           
            catch (System.Exception)
            {
                throw;
            }
            return evento;
        }

        [HttpPut("Id")]
          public async Task<ActionResult> Put(int id, Evento evento)
        {
            if (id != evento.IdEvento)
            {
                return BadRequest(new { mensagem = "Id nao encontrado" });
            }
           
            else
            {
                await repositorio.Put(id,evento);
            }

            return NoContent();
        
         }

        // [HttpGet("FiltroPorNome")]
        //  public ActionResult<List<Evento>> Filtro([FromBody]string filtro)
        // {
        //     List<Categoria> eventoFiltrado = repositorio.FiltroPorNome(filtro);
        //     return eventoFiltrado;
        // }

    }
}