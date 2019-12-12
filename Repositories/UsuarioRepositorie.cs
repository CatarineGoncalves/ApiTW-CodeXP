using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoDeDadosTw.Models;
using Microsoft.EntityFrameworkCore;
using WebApiTw.Interfaces;

namespace WebApiTw.Repositories
{
    public class UsuarioRepositorie : UsuarioInterface
    {
       BancoDeDadosEventsContext  context = new  BancoDeDadosEventsContext  ();
        

        public async Task<List<Usuario>> Get(){
            return await context.Usuario.ToListAsync();

        }

        public async Task <Usuario> Put (int id, Usuario usuario){
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task <Usuario> Post(Usuario usuario){
            
            context.Usuario.Add(usuario);      
             await context.SaveChangesAsync();
            return usuario;
        }

        //  public Task<List<Usuario>> FiltroPorNome(string NomeUsuario, Usuario usuario)
        // {
        //     List<Usuario> usuarios = context.Usuario.Where(c => c.NomeUser.Contains(NomeUsuario)).ToList();

        //     return usuarios;
        // }

    }
}