using Application.Interfaces.Bancos;
using Application.Interfaces.Queries;
using Application.Services.Bancos;
using Domain.Commands.Funcionalidades;
using Domain.Commands.Funcionalidades.Adicionar;
using Domain.Commands.Funcionalidades.Atualizar;
using Domain.Commands.Funcionalidades.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.NiveisAcessos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Funcionalidades
{
    public static class FuncionalidadeDependencyInjection
    {
        public static void AddFuncionalidadeDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFuncionalidadeCommand, FormularioResponse<AdicionarFuncionalidadeCommand>>, AdicionarFuncionalidadeCommandHandler>();
            services.AddTransient<IValidator<AdicionarFuncionalidadeCommand>, AdicionarFuncionalidadeCommandValidation>();
            services.AddTransient<IValidator<FuncionalidadeCommand<AdicionarFuncionalidadeCommand>>, FuncionalidadeCommandValidation<AdicionarFuncionalidadeCommand>>();

            services.AddScoped<IRequestHandler<AtualizarFuncionalidadeCommand, FormularioResponse<AtualizarFuncionalidadeCommand>>, AtualizarFuncionalidadeCommandHandler>();
            services.AddTransient<IValidator<AtualizarFuncionalidadeCommand>, AtualizarFuncionalidadeCommandValidation>();
            services.AddTransient<IValidator<FuncionalidadeCommand<AtualizarFuncionalidadeCommand>>, FuncionalidadeCommandValidation<AtualizarFuncionalidadeCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFuncionalidadeCommand, List<FormularioResponse<ExcluirFuncionalidadeCommand>>>, ExcluirFuncionalidadeCommandHandler>();

            services.AddScoped<IFuncionalidadeService, FuncionalidadeService>();
            services.AddScoped<IFuncionalidadeQuery, FuncionalidadeQuery>();
            services.AddScoped<IFuncionalidadeRepository, FuncionalidadeRepository>();
        }
    }
}
