using LoginAPI.Application.Login;
using LoginAPI.Models.Login;
using Microsoft.AspNetCore.Mvc;


namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    #pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
    public class LoginController : ControllerBase

    {
        public ILoginApplication _loginApplication;


        public LoginController(ILoginApplication application)
        #pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            _loginApplication = application;
        }

        /// <summary>
        /// Reliza login no sistema
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CadastroUsuario
        ///     {
        ///         "username": "username",         Usuário cadastrado
        ///         "password": "password"          Senha cadastrada para o usuário informado
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Usuário logado com sucesso!</response>
        /// <response code="400">Usuário e/ou senha incorreta.</response>
        [HttpPost("LoginUsuario")]
        public ActionResult Login(Credencial credencial)
        {
            try
            {
                var Erro = _loginApplication.Login(credencial);

                if (Erro == 1)
                {
                    return BadRequest("Usuário inválido/não encontrado.");
                }
                else if (Erro == 2)
                {
                    return BadRequest("Senha incorreta.");
                }
                else
                {
                    return Ok("Usuário logado com sucesso!");
                }
                
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
