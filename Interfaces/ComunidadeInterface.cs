using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;

namespace WebApiTw.Interfaces
{
    public interface ComunidadeInterface
    {
         Task<List<Comunidade>> Get ();

         Task<Comunidade> Post (Comunidade comunidade);

         Task <Comunidade> Put(int Id, Comunidade comunidade);


    }
}