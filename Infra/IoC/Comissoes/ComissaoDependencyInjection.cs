using Application.Interfaces.Comissoes;
using Application.Interfaces.Queries;
using Application.Services.Comissoes;
using Domain.Commands.Comissoes;
using Domain.Commands.Comissoes.Adicionar;
using Domain.Commands.Comissoes.Atualizar;
using Domain.Commands.Comissoes.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Comissoes;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Comissoes
{
    public static class ComissaoDependencyInjection
    {
        public static void AddComissaoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarComissaoCommand, FormularioResponse<AdicionarComissaoCommand>>, AdicionarComissaoCommandHandler>();
            services.AddTransient<IValidator<AdicionarComissaoCommand>, AdicionarComissaoCommandValidation>();
            services.AddTransient<IValidator<ComissaoCommand<AdicionarComissaoCommand>>, ComissaoCommandValidation<AdicionarComissaoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarComissaoCommand, FormularioResponse<AtualizarComissaoCommand>>, AtualizarComissaoCommandHandler>();
            services.AddTransient<IValidator<AtualizarComissaoCommand>, AtualizarComissaoCommandValidation>();
            services.AddTransient<IValidator<ComissaoCommand<AtualizarComissaoCommand>>, ComissaoCommandValidation<AtualizarComissaoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirComissaoCommand, List<FormularioResponse<ExcluirComissaoCommand>>>, ExcluirComissaoCommandHandler>();

            services.AddScoped<IComissaoService, ComissaoService>();
            services.AddScoped<IComissaoQuery, ComissaoQuery>();
            services.AddScoped<IComissaoRepository, ComissaoRepository>();
        }
    }
}
