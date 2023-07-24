﻿using CleanMvc.Application.Interfaces;
using CleanMvc.Application.Mappings;
using CleanMvc.Application.Services;
using CleanMvc.Domain.Account;
using CleanMvc.Domain.Interfaces;
using CleanMvc.Infra.Data.Context;
using CleanMvc.Infra.Data.Identity;
using CleanMvc.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanMvc.Infra.IoC;

public static class InjecaoDependenciaWebAPI //tem que adicionar o automapper / depedencyinjection
{
    public static IServiceCollection AddInfrasctruture(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //definicao Usuario
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IAutenticacao, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


        services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

        services.AddScoped<IProdutotService, ProductService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddAutoMapper(typeof(DominioToDTOPerfilMapeamento));

        return services;
    }
}
