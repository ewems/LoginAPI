using LoginAPI.Models.Login;


namespace LoginAPI.Application.Login
{
    public interface ILoginApplication
    {
        int Login(Credencial credencial);
    }
}
