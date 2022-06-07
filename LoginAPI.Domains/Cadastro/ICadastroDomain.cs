using LoginAPI.Models.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Domains.Cadastro
{
    public interface ICadastroDomain
    {
        void Cadastro(Usuario usuario);
    }
}
