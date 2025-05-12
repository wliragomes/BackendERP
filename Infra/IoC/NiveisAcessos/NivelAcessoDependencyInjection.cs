using Application.Interfaces.NiveisAcessos;
using Application.Interfaces.Queries;
using Application.Services.NiveisAcessos;
using Domain.Commands.NiveisAcessos;
using Domain.Commands.NiveisAcessos.Adicionar;
using Domain.Commands.NiveisAcessos.Atualizar;
using Domain.Commands.NiveisAcessos.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.NiveisAcessos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.NiveisAcessos
{
    public static class NivelAcessoDependencyInjection
    {
        public static void AddNivelAcessoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarNivelAcessoCommand, FormularioResponse<AdicionarNivelAcessoCommand>>, AdicionarNivelAcessoCommandHandler>();
            services.AddTransient<IValidator<AdicionarNivelAcessoCommand>, AdicionarNivelAcessoCommandValidation>();
            services.AddTransient<IValidator<NivelAcessoCommand<AdicionarNivelAcessoCommand>>, NivelAcessoCommandValidation<AdicionarNivelAcessoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarNivelAcessoCommand, FormularioResponse<AtualizarNivelAcessoCommand>>, AtualizarNivelAcessoCommandHandler>();
            services.AddTransient<IValidator<AtualizarNivelAcessoCommand>, AtualizarNivelAcessoCommandValidation>();
            services.AddTransient<IValidator<NivelAcessoCommand<AtualizarNivelAcessoCommand>>, NivelAcessoCommandValidation<AtualizarNivelAcessoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirNivelAcessoCommand, List<FormularioResponse<ExcluirNivelAcessoCommand>>>, ExcluirNivelAcessoCommandHandler>();

            services.AddScoped<INivelAcessoService, NivelAcessoService>();
            services.AddScoped<INivelAcessoQuery, NivelAcessoQuery>();
            services.AddScoped<INivelAcessoRepository, NivelAcessoRepository>();
        }
    }
}
