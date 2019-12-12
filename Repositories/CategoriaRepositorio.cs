

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;
using Microsoft.EntityFrameworkCore;
using WebApiTw.Interfaces;

namespace WebApiTw.Repositories
{
    public class CategoriaRepositorio : CategoriaInterface
    {
        BancoDeDadosEventsContext  context = new  BancoDeDadosEventsContext  ();

        public async Task<List<Categoria>> Filtro(string nome){
            return await context.Categoria.ToListAsync();

        }

        public async Task <Categoria> Put (int id, Categoria categoria){
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return categoria;
        }

        public async Task <Categoria> Post(Categoria categoria){
             await context.SaveChangesAsync();
            return categoria;
        }

        public async Task<List<Categoria>> Get(){
            return await context.Categoria.ToListAsync();

        }


        public Task<List<Categoria>> Filto(string Filtro)
        {
            throw new System.NotImplementedException();
        }
    }
}