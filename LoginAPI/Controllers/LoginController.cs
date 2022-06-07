using LoginAPI.Application.Login;
using LoginAPI.Models.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public ILoginApplication _loginApplication;

        public LoginController(ILoginApplication application)
        {
            _loginApplication = application;
        }


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
