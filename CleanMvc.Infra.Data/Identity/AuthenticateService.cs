using CleanMvc.Domain.Account;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;


namespace CleanMvc.Infra.Data.Identity;

public class AuthenticateService : IAutenticacao
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager; 
    }
    
    public async Task<bool> Autenticar(string email, string senha)
    {
        var resultado = await _signInManager.PasswordSignInAsync(email,senha,false,lockoutOnFailure:false);

        return resultado.Succeeded;
    }

    public async Task<bool> RegistrarUsuario(string email, string senha)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        var resultado = await _userManager.CreateAsync(applicationUser, senha);
        if(resultado.Succeeded)
        {
            await _signInManager.SignInAsync(applicationUser,isPersistent:false);
        }

        return resultado.Succeeded;
    }

    public async Task Logout()
    {
       await _signInManager.SignOutAsync();
    }

   
}
