using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;
using Microsoft.EntityFrameworkCore;
using WebApiTw.Interfaces;

namespace WebApiTw.Repositories
{
    public class SalaRepositorie : SalaInterface
    {
        BancoDeDadosEventsContext  context = new  BancoDeDadosEventsContext  ();
        

           public async Task<List<Sala>> Get(){
            return await context.Sala.ToListAsync();

        }

        public async Task <Sala> Put (int id,Sala sala){
            context.Entry(sala).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return sala;
        }

        public async Task <Sala> Post(Sala sala){
             await context.SaveChangesAsync();
            return sala;
        }

       
    }
}