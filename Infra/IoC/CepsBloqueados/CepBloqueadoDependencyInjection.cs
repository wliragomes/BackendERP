using Application.Interfaces.CepsBloqueados;
using Application.Interfaces.Queries;
using Application.Services.CepsBloqueados;
using Domain.Commands.CepsBloqueados;
using Domain.Commands.CepsBloqueados.Adicionar;
using Domain.Commands.CepsBloqueados.Atualizar;
using Domain.Commands.CepsBloqueados.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.CepsBloqueados;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.CepsBloqueados
{
    public static class CepBloqueadoDependencyInjection
    {
        public static void AddCepBloqueadoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarCepBloqueadoCommand, FormularioResponse<AdicionarCepBloqueadoCommand>>, AdicionarCepBloqueadoCommandHandler>();
            services.AddTransient<IValidator<AdicionarCepBloqueadoCommand>, AdicionarCepBloqueadoCommandValidation>();
            services.AddTransient<IValidator<CepBloqueadoCommand<AdicionarCepBloqueadoCommand>>, CepBloqueadoCommandValidation<AdicionarCepBloqueadoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarCepBloqueadoCommand, FormularioResponse<AtualizarCepBloqueadoCommand>>, AtualizarCepBloqueadoCommandHandler>();
            services.AddTransient<IValidator<AtualizarCepBloqueadoCommand>, AtualizarCepBloqueadoCommandValidation>();
            services.AddTransient<IValidator<CepBloqueadoCommand<AtualizarCepBloqueadoCommand>>, CepBloqueadoCommandValidation<AtualizarCepBloqueadoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirCepBloqueadoCommand, List<FormularioResponse<ExcluirCepBloqueadoCommand>>>, ExcluirCepBloqueadoCommandHandler>();

            services.AddScoped<ICepBloqueadoService, CepBloqueadoService>();
            services.AddScoped<ICepBloqueadoQuery, CepBloqueadoQuery>();
            services.AddScoped<ICepBloqueadoRepository, CepBloqueadoRepository>();
        }
    }
}
