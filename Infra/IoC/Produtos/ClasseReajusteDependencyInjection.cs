using Domain.Interfaces.Repositories;
using FluentValidation;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.SharedObjects;
using Domain.Commands.Produtos.ClasseReajustes.Adicionar;
using Domain.Commands.Produtos.ClasseReajustes;
using Domain.Commands.Produtos.ClasseReajustes.Atualizar;
using Domain.Commands.Produtos.ClasseReajustes.Excluir;
using Domain.Commands.Produtos;

namespace Infra.IoC.Produtos
{
    public static class ClasseReajusteDependencyInjection
    {
        public static void AddClasseReajusteDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AdicionarClasseReajusteCommand, FormularioResponse<AdicionarClasseReajusteCommand>>, AdicionarClasseReajusteCommandHandler>();
            services.AddTransient<IValidator<AdicionarClasseReajusteCommand>, AdicionarClasseReajusteCommandValidation>();
            services.AddTransient<IValidator<ClasseReajusteCommand<AdicionarClasseReajusteCommand>>, ClasseReajusteCommandValidation<AdicionarClasseReajusteCommand>>();

            services.AddScoped<IRequestHandler<AtualizarClasseReajusteCommand, FormularioResponse<AtualizarClasseReajusteCommand>>, AtualizarClasseReajusteCommandHandler>();
            services.AddTransient<IValidator<AtualizarClasseReajusteCommand>, AtualizarClasseReajusteCommandValidation>();
            services.AddTransient<IValidator<ClasseReajusteCommand<AtualizarClasseReajusteCommand>>, ClasseReajusteCommandValidation<AtualizarClasseReajusteCommand>>();

            services.AddScoped<IRequestHandler<ExcluirClasseReajusteCommand, List<FormularioResponse<ExcluirClasseReajusteCommand>>>, ExcluirClasseReajusteCommandHandler>();

            services.AddScoped<IClasseReajusteRepository, ClasseReajusteRepository>();
        }
    }
}