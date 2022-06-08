using LoginAPI.Application.Cadastro;
using LoginAPI.Models.Cadastro;
using Microsoft.AspNetCore.Mvc;



namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    #pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
    public class CadastroController : ControllerBase
   
    {
        public ICadastroApplication _cadastroApplication;

        public CadastroController(ICadastroApplication application)
        #pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
        {
            _cadastroApplication = application;
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CadastroUsuario
        ///     {
        ///         "nome": "Nome Completo",        Apenas texto, máx 50 caracteres
        ///         "dtNascimento": "0000-00-00",   AAAA-MM-DD
        ///         "cpf": "00000000000",           Apenas números, 11 caracteres
        ///         "natural": "Nome da Cidade",    Apenas texto, max 20 caracteres
        ///         "uf": "SP",                     Apenas texto, 2 caracteres
        ///         "tel": "00000000000",           Código DDD + Número, 10 - 11 caracteres
        ///         "email": "user@example.com",    E-mail válido, máx 50 carácteres
        ///         "username": "username",         Texto, número e o carac especial '.', máx 15 caracteres
        ///         "password": "password"          Texto, número e os carac especiais: . ! @, máx 15 caracteres
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Usuário cadastrado com sucesso!</response>
        /// <response code="400">Usuário não cadastrado.</response>
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
