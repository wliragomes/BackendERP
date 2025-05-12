using Application.Interfaces.Modalidades;
using Application.Interfaces.Queries;
using Application.Services.Modalidades;
using Domain.Commands.Modalidades;
using Domain.Commands.Modalidades.Adicionar;
using Domain.Commands.Modalidades.Atualizar;
using Domain.Commands.Modalidades.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Modalidades;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Modalidades
{
    public static class ModalidadeDependencyInjection
    {
        public static void AddModalidadeDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarModalidadeCommand, FormularioResponse<AdicionarModalidadeCommand>>, AdicionarModalidadeCommandHandler>();
            services.AddTransient<IValidator<AdicionarModalidadeCommand>, AdicionarModalidadeCommandValidation>();
            services.AddTransient<IValidator<ModalidadeCommand<AdicionarModalidadeCommand>>, ModalidadeCommandValidation<AdicionarModalidadeCommand>>();

            services.AddScoped<IRequestHandler<AtualizarModalidadeCommand, FormularioResponse<AtualizarModalidadeCommand>>, AtualizarModalidadeCommandHandler>();
            services.AddTransient<IValidator<AtualizarModalidadeCommand>, AtualizarModalidadeCommandValidation>();
            services.AddTransient<IValidator<ModalidadeCommand<AtualizarModalidadeCommand>>, ModalidadeCommandValidation<AtualizarModalidadeCommand>>();

            services.AddScoped<IRequestHandler<ExcluirModalidadeCommand, List<FormularioResponse<ExcluirModalidadeCommand>>>, ExcluirModalidadeCommandHandler>();

            services.AddScoped<IModalidadeService, ModalidadeService>();
            services.AddScoped<IModalidadeQuery, ModalidadeQuery>();
            services.AddScoped<IModalidadeRepository, ModalidadeRepository>();
        }
    }
}
