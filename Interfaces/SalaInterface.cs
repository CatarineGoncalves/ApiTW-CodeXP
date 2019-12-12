using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;

namespace WebApiTw.Interfaces
{
    public interface SalaInterface
    {
         Task <List<Sala>> Get ();

         Task <Sala> Post (Sala sala);

         Task <Sala> Put ( int id ,Sala sala);

         


    }
}