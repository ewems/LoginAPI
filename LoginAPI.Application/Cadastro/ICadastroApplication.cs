using LoginAPI.Models.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Application.Cadastro
{
    public interface ICadastroApplication
    {
        void Cadastro(Usuario usuario);
    }
}
