using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;

namespace WebApiTw.Interfaces
{
    public interface EventoInterface
    {
         Task<List<Evento>> Get ();

        //  Task<Evento> Filtro (string NomeEvento,  Evento evento);

         Task<Evento> Post(Evento evento);
            
         Task <Evento> Put (int id ,Evento evento);
    }
}