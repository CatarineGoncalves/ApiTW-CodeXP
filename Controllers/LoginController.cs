
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BancoDeDadosTw.Models;
using BancoDeDadosTw.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APITW.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        BancoDeDadosEventsContext _context = new BancoDeDadosEventsContext();
  //Define uma variável para percorrer nossos métodos com as configurações do appSettings.json
        private IConfiguration _config;

        //Definimos um método contrutor para validar as informações do appSettings.js
        public LoginController (IConfiguration config){
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginViewModel login){
            //Cria uma variável do tipo IActionResult que por padão é Não Autorizado
            IActionResult resposta = Unauthorized();

            //Valida se o usuário passado no post existe no nosso banco de dados
            var usuario  = autenticarUsuario(login);

            //Verifica se usuário é diferente de nulo
            if(usuario != null){
                //Cria uma variável que armazena o valor do nosso token
                var tokenLinha = gerarJsonWebToken(usuario);
                //Define que a resposta será 200 OK e retornará um objeto chamado token com o token 
                resposta = Ok(new { token = tokenLinha });
            }
            //retorna a resposta
            return resposta;
        }

        /// <summary>
        /// Método privado que valida se um usuário existe no nosso banco de dados
        /// </summary>
        /// <param name="login">Objeto do tipo usuário</param>
        /// <returns>Objeto do tipo usuário</returns>
        private Usuario autenticarUsuario(LoginViewModel login){
            //Declara uma variável que busca no nosso banco de dados um usuário
            //que tenha o email e a senha presente no banco de dados
            var usuario = _context.Usuario.FirstOrDefault(user => user.Email == login.Email && user.Senha == login.Senha);

            //Verifica se a resposta do banco de dados é diferente de null
       
            //Retorna usuário
            return usuario;
        }

        private string gerarJsonWebToken(Usuario infoUsuario){
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            //Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            //a qualquer momento enquanto o token for ativo
            var claims = new[]{
               
                new Claim(JwtRegisteredClaimNames.Email, infoUsuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, infoUsuario.IdTipoUsuario.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

 }