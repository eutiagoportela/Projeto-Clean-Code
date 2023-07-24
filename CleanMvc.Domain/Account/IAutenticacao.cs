
namespace CleanMvc.Domain.Account;

public interface IAutenticacao
{
    Task<bool> Autenticar(string email,string senha);

    Task<bool> RegistrarUsuario(string email, string senha);

    Task Logout();
}
