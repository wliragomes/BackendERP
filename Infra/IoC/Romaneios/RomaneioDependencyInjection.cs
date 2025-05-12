using Application.Interfaces.Queries;
using Application.Interfaces.Romaneios;
using Application.Services.Romaneios;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Commands.OrdensFabricacoes.Atualizar;
using Domain.Commands.Romaneios;
using Domain.Commands.Romaneios.Atualizar;
using Domain.Commands.Romaneios.Excluir;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Queries.OrdensFabricacoes;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;

namespace Infra.IoC.OrdensFabricacoes
{
    public static class RomaneioDependencyInjection
    {
        public static void AddRomaneioDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarRomaneioCommand, FormularioResponse<AdicionarRomaneioCommand>>, AdicionarRomaneioCommandHandler>();
            services.AddTransient<IValidator<AdicionarRomaneioCommand>, AdicionarRomaneioCommandValidation>();
            services.AddTransient<IValidator<RomaneioCommand<AdicionarRomaneioCommand>>, RomaneioCommandValidation<AdicionarRomaneioCommand>>();

            services.AddScoped<IRequestHandler<AtualizarRomaneioCommand, FormularioResponse<AtualizarRomaneioCommand>>, AtualizarRomaneioCommandHandler>();
            services.AddTransient<IValidator<AtualizarRomaneioCommand>, AtualizarRomaneioCommandValidation>();
            services.AddTransient<IValidator<RomaneioCommand<AtualizarRomaneioCommand>>, RomaneioCommandValidation<AtualizarRomaneioCommand>>();

            services.AddScoped<IRequestHandler<ExcluirRomaneioCommand, List<FormularioResponse<ExcluirRomaneioCommand>>>, ExcluirRomaneioCommandHandler>();

            services.AddScoped<IRomaneioService, RomaneioService>();
            services.AddScoped<IRomaneioQuery, RomaneioQuery>();
            services.AddScoped<IRomaneioRepository, RomaneioRepository>();
        }
    }
}
