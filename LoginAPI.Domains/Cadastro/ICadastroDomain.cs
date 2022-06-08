using LoginAPI.Models.Cadastro;


namespace LoginAPI.Domains.Cadastro
{
    public interface ICadastroDomain
    {
        void Cadastro(Usuario usuario);
    }
}
