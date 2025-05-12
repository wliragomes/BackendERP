using Domain.Commands.SegmentoClientes;
using Domain.Commands.SegmentoClientes.Adicionar;
using Domain.Commands.SegmentoClientes.Atualizar;
using Domain.Commands.SegmentoClientes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Pessoas
{
    public static class SegmentoClienteDependencyInjection
    {
        public static void AddSegmentoClienteDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarSegmentoClienteCommand, FormularioResponse<AdicionarSegmentoClienteCommand>>, AdicionarSegmentoClienteCommandHandler>();
            services.AddTransient<IValidator<AdicionarSegmentoClienteCommand>, AdicionarSegmentoClienteCommandValidation>();
            services.AddTransient<IValidator<SegmentoClienteCommand<AdicionarSegmentoClienteCommand>>, SegmentoClienteCommandValidation<AdicionarSegmentoClienteCommand>>();

            services.AddScoped<IRequestHandler<AtualizarSegmentoClienteCommand, FormularioResponse<AtualizarSegmentoClienteCommand>>, AtualizarSegmentoClienteCommandHandler>();
            services.AddTransient<IValidator<AtualizarSegmentoClienteCommand>, AtualizarSegmentoClienteCommandValidation>();
            services.AddTransient<IValidator<SegmentoClienteCommand<AtualizarSegmentoClienteCommand>>, SegmentoClienteCommandValidation<AtualizarSegmentoClienteCommand>>();

            services.AddScoped<IRequestHandler<ExcluirSegmentoClienteCommand, List<FormularioResponse<ExcluirSegmentoClienteCommand>>>, ExcluirSegmentoClienteCommandHandler>();

            services.AddScoped<ISegmentoClienteRepository, SegmentoClienteRepository>();
        }
    }
}

