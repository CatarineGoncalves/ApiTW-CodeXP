using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;

namespace WebApiTw.Interfaces
{
    public interface CategoriaInterface
    {
         Task <List<Categoria>> Get();

         Task <List<Categoria>> Filtro (string filtro);

         Task <Categoria> Post (Categoria categoria);

         Task <Categoria> Put (int Id, Categoria categoria);

         

    }
}