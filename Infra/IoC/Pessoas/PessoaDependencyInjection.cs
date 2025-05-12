using Application.Interfaces.Queries;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Pessoas;
using Application.Services.Pessoas;
using Infra.Queries.Pessoas;
using Domain.Commands.Pessoas.Adicionar;
using SharedKernel.SharedObjects;
using MediatR;
using FluentValidation;
using Domain.Commands.Pessoas;
using Domain.Commands.Pessoas.Atualizar;
using Domain.Commands.Pessoas.Excluir;
using Infra.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Commands.Pessoas.ValidarCpfCnpjs;
using Domain.Commands.ValidarCpfCnpjs.Adicionar;
using Domain.Commands.ValidarCpfCnpjs;

namespace Infra.IoC.Pessoas
{
    public static class PessoaDependencyInjection
    {
        public static void AddPessoaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarPessoaCommand, FormularioResponse<AdicionarPessoaCommand>>, AdicionarPessoaCommandHandler>();
            services.AddTransient<IValidator<AdicionarPessoaCommand>, AdicionarPessoaCommandValidation>();
            services.AddTransient<IValidator<PessoaCommand<AdicionarPessoaCommand>>, PessoaCommandValidation<AdicionarPessoaCommand>>();

            services.AddScoped<IRequestHandler<AdicionarValidarCpfCnpjCommand, FormularioResponse<AdicionarValidarCpfCnpjCommand>>, AdicionarValidarCpfCnpjCommandHandler>();
            services.AddTransient<IValidator<AdicionarValidarCpfCnpjCommand>, AdicionarValidarCpfCnpjCommandValidation>();
            services.AddTransient<IValidator<ValidarCpfCnpjCommand<AdicionarValidarCpfCnpjCommand>>, ValidarCpfCnpjCommandValidation<AdicionarValidarCpfCnpjCommand>>();

            services.AddScoped<IRequestHandler<AtualizarPessoaCommand, FormularioResponse<AtualizarPessoaCommand>>, AtualizarPessoaCommandHandler>();
            services.AddTransient<IValidator<AtualizarPessoaCommand>, AtualizarPessoaCommandValidation>();
            services.AddTransient<IValidator<PessoaCommand<AtualizarPessoaCommand>>, PessoaCommandValidation<AtualizarPessoaCommand>>();

            services.AddScoped<IRequestHandler<ExcluirPessoaCommand, List<FormularioResponse<ExcluirPessoaCommand>>>, ExcluirPessoaCommandHandler>();

            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaQuery, PessoaQuery>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
        }
    }
}
