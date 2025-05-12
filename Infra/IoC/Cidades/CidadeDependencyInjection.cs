using Application.Interfaces.Cidades;
using Application.Interfaces.Queries;
using Application.Services.Cidade;
using Domain.Commands.Cidades;
using Domain.Commands.Cidades.Adicionar;
using Domain.Commands.Cidades.Atualizar;
using Domain.Commands.Cidades.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Cidades;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Cidades
{
    public static class CidadeDependencyInjection
    {
        public static void AddCidadeDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCidadeCommand, FormularioResponse<AdicionarCidadeCommand>>, AdicionarCidadeCommandHandler>();
            services.AddTransient<IValidator<AdicionarCidadeCommand>, AdicionarCidadeCommandValidation>();
            services.AddTransient<IValidator<CidadeCommand<AdicionarCidadeCommand>>, CidadeCommandValidation<AdicionarCidadeCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCidadeCommand, FormularioResponse<AtualizarCidadeCommand>>, AtualizarCidadeCommandHandler>();
            services.AddTransient<IValidator<AtualizarCidadeCommand>, AtualizarCidadeCommandValidation>();
            services.AddTransient<IValidator<CidadeCommand<AtualizarCidadeCommand>>, CidadeCommandValidation<AtualizarCidadeCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCidadeCommand, List<FormularioResponse<ExcluirCidadeCommand>>>, ExcluirCidadeCommandHandler>();

            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<ICidadeQuery, CidadeQuery>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}
