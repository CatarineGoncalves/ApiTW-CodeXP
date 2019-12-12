using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;
using Microsoft.EntityFrameworkCore;
using WebApiTw.Interfaces;

namespace WebApiTw.Repositories
{
    public class EventoRepositore : EventoInterface
    {
        BancoDeDadosEventsContext  context = new  BancoDeDadosEventsContext  ();
        
        public async Task<List<Evento>> Get(){
            
            return await context.Evento.ToListAsync();

        }

        public async Task <Evento> Put (int id,Evento evento){
            context.Entry(evento).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return evento;
        }

        public async Task <Evento> Post(Evento evento){
             await context.SaveChangesAsync();
            return evento;
        }

        //  public List<Evento> Filtro(string NomeEvento, Evento evento)
        // {
        //     List<Evento> evento = context.Evento.Where(c => c.NomeEvento.Contains(filtro)).ToList();

        //     return evento;
        // }

        
    }
}