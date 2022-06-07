using LoginAPI.Domains.Cadastro;
using LoginAPI.Models.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Application.Cadastro
{
    public class CadastroApplication: ICadastroApplication
    {
        public ICadastroDomain _cadastroDomain;

        public CadastroApplication(ICadastroDomain cadastro)
        {
            _cadastroDomain = cadastro;
        }

        public void Cadastro(Usuario usuario)
        {
             _cadastroDomain.Cadastro(usuario);
            
        }
    }
}
