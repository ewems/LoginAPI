using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Models.Cadastro
{
    public class Usuario
    {
        public string? Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string? CPF { get; set; }
        public string? Natural { get; set; }
        public string? UF { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
