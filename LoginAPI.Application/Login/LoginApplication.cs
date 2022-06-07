using LoginAPI.Domains.Login;
using LoginAPI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Application.Login
{
    public class LoginApplication : ILoginApplication
    {
        public ILoginDomain _loginDomain;

        public LoginApplication(ILoginDomain login)
        {
            _loginDomain = login;
        }

        public int Login(Credencial credencial)
        {
          return  _loginDomain.Login(credencial);

        }

    }
}
