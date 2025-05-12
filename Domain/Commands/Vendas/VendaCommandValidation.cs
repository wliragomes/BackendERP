using Domain.Constant;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Vendas
{
    public class VendaCommandValidation<T> : AbstractValidator<VendaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public VendaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.IdCliente)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage(ConstantGeneral.REQUIRED_FIELD)
               .MustAsync(async (s, cancellation) => await ClienteExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c.IdVendedor)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage(ConstantGeneral.REQUIRED_FIELD)
               .MustAsync(async (s, cancellation) => await VendedorExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            //RuleFor(c => c.Totais.NaturezaOperacao)
            //    .NotEmpty()
            //    .WithMessage(ConstantGeneral.REQUIRED_FIELD);

            //RuleFor(c => c.Id)
            //   .NotEmpty()
            //   .WithMessage(ConstantGeneral.REQUIRED_FIELD);
        }

        private async Task<bool> ClienteExisteNoDB(Guid? id)
        {
            var idCliente = id ?? Guid.Empty;
            if (idCliente == Guid.Empty)
                return false;

            return await _unitOfWork.PessoaRepository.ExisteIdAsync(idCliente);
        }

        private async Task<bool> VendedorExisteNoDB(Guid? id)
        {
            var idVendedor = id ?? Guid.Empty;
            if (idVendedor == Guid.Empty)
                return false;

            return await _unitOfWork.PessoaRepository.ExisteIdAsync(idVendedor);
        }
    }
}
