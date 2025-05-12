using Application.Interfaces.Feriados;
using Application.Interfaces.Queries;
using Application.Services.Feriados;
using Domain.Commands.Feriados;
using Domain.Commands.Feriados.Adicionar;
using Domain.Commands.Feriados.Atualizar;
using Domain.Commands.Feriados.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Feriados;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Feriados
{
    public static class FeriadoDependencyInjection
    {
        public static void AddFeriadoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarFeriadoCommand, FormularioResponse<AdicionarFeriadoCommand>>, AdicionarFeriadoCommandHandler>();
            services.AddTransient<IValidator<AdicionarFeriadoCommand>, AdicionarFeriadoCommandValidation>();
            services.AddTransient<IValidator<FeriadoCommand<AdicionarFeriadoCommand>>, FeriadoCommandValidation<AdicionarFeriadoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarFeriadoCommand, FormularioResponse<AtualizarFeriadoCommand>>, AtualizarFeriadoCommandHandler>();
            services.AddTransient<IValidator<AtualizarFeriadoCommand>, AtualizarFeriadoCommandValidation>();
            services.AddTransient<IValidator<FeriadoCommand<AtualizarFeriadoCommand>>, FeriadoCommandValidation<AtualizarFeriadoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirFeriadoCommand, List<FormularioResponse<ExcluirFeriadoCommand>>>, ExcluirFeriadoCommandHandler>();

            services.AddScoped<IFeriadoService, FeriadoService>();
            services.AddScoped<IFeriadoQuery, FeriadoQuery>();
            services.AddScoped<IFeriadoRepository, FeriadoRepository>();
        }
    }
}
