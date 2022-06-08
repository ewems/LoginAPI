using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Models.Cadastro
{

    public class Usuario
    {
        [DefaultValue("Nome Completo")]
        public string? Nome { get; set; } 

        [DefaultValue("0000-00-00")]
        public DateTime DtNascimento { get; set; }


        [DefaultValue("00000000000")]
        public string? CPF { get; set; }


        [DefaultValue("Nome da Cidade")]
        public string? Natural { get; set; }


        [DefaultValue("UF")]
        public string? UF { get; set; }

        [Phone]
        [DefaultValue("00000000000")]
        public string? Tel { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


        [DefaultValue("username")]
        public string? Username { get; set; }


        [DefaultValue("password")]
        public string? Password { get; set; }
    }
}
