using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;
using Microsoft.EntityFrameworkCore;
using WebApiTw.Interfaces;

namespace WebApiTw.Repositories
{
    public class ComunidadeRepositorie : ComunidadeInterface
    {
         BancoDeDadosEventsContext  context = new  BancoDeDadosEventsContext  ();

        public async Task<List<Comunidade>> Get(){
            return await context.Comunidade.ToListAsync();

        }

        public async Task <Comunidade> Put ( int id,Comunidade comunidade){
            context.Entry(comunidade).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return comunidade;
        }

        public async Task <Comunidade> Post(Comunidade comunidade){
            context.Comunidade.Add(comunidade);
             await context.SaveChangesAsync();
            return comunidade;
        }

      
    }
}