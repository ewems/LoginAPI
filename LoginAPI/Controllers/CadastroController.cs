using LoginAPI.Application.Cadastro;
using LoginAPI.Models.Cadastro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        public ICadastroApplication _cadastroApplication;

        public CadastroController(ICadastroApplication application)
        {
            _cadastroApplication = application;
        }

        [HttpPost("CadastroUsuario")]
        public ActionResult Cadastro(Usuario usuario)
        {
            try
            {
                _cadastroApplication.Cadastro(usuario);
                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Usuário não cadastrado.\nDescrição do erro: {ex.Message}");
            }
           
        }
    }
}
