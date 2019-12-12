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
    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio repositorio = new CategoriaRepositorio();
/// <summary>
/// Exibe todas as categorias
/// </summary>
/// <returns>retorna todas as categorias registradas</returns>
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            List<Categoria> categorias = await repositorio.Get();

            if (categorias == null)
            {
                return NotFound(new { mensagem = "Categoria nao encontrada" });
            }
            return categorias;
        }
/// <summary>
/// 
/// </summary>
/// <param name="categoria"></param>
/// <returns></returns>
         [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try
            {
                
                await repositorio.Post(categoria);
            }
           
            catch (System.Exception)
            {
                throw;
            }
            return categoria;
        }

            [HttpPut("id")]
          public async Task<ActionResult> Put(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest(new { mensagem = "Id Nao encontrado" });
            }
           
            else
            {
                await repositorio.Put(id,categoria);
            }

            return NoContent();
        
         }

        //  [HttpGet("FiltroPorNome")]
        // public ActionResult<List<Categoria>> Filtro([FromBody]string filtro)
        // {
        //     List<Categoria> categoriaFiltrada = repositorio.Filtro(filtro);

        //     return categoriaFiltrada;
        // }




    }
}