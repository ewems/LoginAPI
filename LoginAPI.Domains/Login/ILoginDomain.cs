using LoginAPI.Models.Login;

namespace LoginAPI.Domains.Login
{
    public interface ILoginDomain
    {
        int Login(Credencial credencial);
    }
}
