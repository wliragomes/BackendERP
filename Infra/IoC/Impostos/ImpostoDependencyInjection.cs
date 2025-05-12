using Application.Interfaces.Impostos;
using Application.Interfaces.Queries;
using Application.Services.Produtos;
using Domain.Commands.Impostos.CstIcmss;
using Domain.Commands.Impostos.CstIcmss.Adicionar;
using Domain.Commands.Impostos.CstIcmss.Atualizar;
using Domain.Commands.Impostos.CstIcmss.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.Impostos;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.Impostos
{
    public static class ImpostoDependencyInjection
    {
        public static void AddImpostoDependencyInjection(this IServiceCollection services)
        {    
            services.AddScoped<IImpostoService, ImpostoService>();
            services.AddScoped<IImpostoQuery, ImpostoQuery>();            
        }
    }
}
