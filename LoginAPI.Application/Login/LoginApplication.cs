using LoginAPI.Domains.Login;
using LoginAPI.Models.Login;


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
