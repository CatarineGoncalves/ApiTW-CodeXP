using System.Collections.Generic;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;

namespace WebApiTw.Interfaces
{
    public interface UsuarioInterface
    {
         Task <List<Usuario>> Get ();

        //  Task <List<Usuario>> FiltroPorNome (string NomeUsuario , Usuario usuario);

         Task <Usuario> Post (Usuario usuario );

         Task <Usuario> Put (int id, Usuario usuario);
    }
}