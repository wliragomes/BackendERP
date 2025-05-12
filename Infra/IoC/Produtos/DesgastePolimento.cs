using Domain.Commands.Produtos.ClasseReajustes;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.DesgastePolimentos.Adicionar;
using Domain.Commands.Produtos.AtualizarDesgastes.Atualizar;
using Domain.Commands.Produtos.DesgastePolimentos.Atualizar;
using Domain.Commands.Produtos.DesgastePolimentos.Excluir;
using Domain.Commands.Produtos;

namespace Infra.IoC.Produtos
{
    public static class DesgastePolimentoDependencyInjection
    {
        public static void AddDesgastePolimentoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarDesgastePolimentoCommand, FormularioResponse<AdicionarDesgastePolimentoCommand>>, AdicionarDesgastePolimentoCommandHandler>();
            services.AddTransient<IValidator<AdicionarDesgastePolimentoCommand>, AdicionarDesgastePolimentoCommandValidation>();
            services.AddTransient<IValidator<DesgastePolimentoCommand<AdicionarDesgastePolimentoCommand>>, DesgastePolimentoCommandValidation<AdicionarDesgastePolimentoCommand>>();

            services.AddScoped<IRequestHandler<AtualizarDesgastePolimentoCommand, FormularioResponse<AtualizarDesgastePolimentoCommand>>, AtualizarDesgastePolimentoCommandHandler>();
            services.AddTransient<IValidator<AtualizarDesgastePolimentoCommand>, AtualizarDesgastePolimentoCommandValidation>();
            services.AddTransient<IValidator<DesgastePolimentoCommand<AtualizarDesgastePolimentoCommand>>, DesgastePolimentoCommandValidation<AtualizarDesgastePolimentoCommand>>();

            services.AddScoped<IRequestHandler<ExcluirDesgastePolimentoCommand, List<FormularioResponse<ExcluirDesgastePolimentoCommand>>>, ExcluirDesgastePolimentoCommandHandler>();

            services.AddScoped<IDesgastePolimentoRepository, DesgastePolimentoRepository>();
        }
    }
}