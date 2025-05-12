using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Pessoas
{
    public class PessoaCommandValidation<T> : AbstractValidator<PessoaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PessoaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            //RuleFor(c => c.IdRegiao)
            //   .Cascade(CascadeMode.Stop)
            //   .NotEmpty()
            //   .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            //   .MustAsync(async (s, cancellation) => await RegiaoExisteNoDB(s))
            //   .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c)
                .MustAsync(async (command, cancellation) => await ValidaIdRegiao(command.IdRegiao!, command.Cliente, command.Fornecedor))
                .OverridePropertyName(x => x.IdRegiao)
                .WithState(x => x.IdRegiao)
                .WithMessage("Região inválida");

            //RuleFor(c => c.IdOrigem)
            //   .Cascade(CascadeMode.Stop)
            //   .NotEmpty()
            //   .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            //   .MustAsync(async (s, cancellation) => await OrigemExisteNoDB(s))
            //   .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c)
                .MustAsync(async (command, cancellation) => await ValidaIdOrigem(command.IdOrigem!, command.Cliente, command.Fornecedor))
                .OverridePropertyName(x => x.IdOrigem)
                .WithState(x => x.IdOrigem)
                .WithMessage("Origem inválida");

            //RuleFor(c => c.IdSegmentoCliente)
            //   .Cascade(CascadeMode.Stop)
            //   .NotEmpty()
            //   .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            //   .MustAsync(async (s, cancellation) => await SegmentoClienteExisteNoDB(s))
            //   .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c)
                .MustAsync(async (command, cancellation) => await ValidaIdSegmentoCliente(command.IdSegmentoCliente!, command.Cliente, command.Fornecedor))
                .OverridePropertyName(x => x.IdSegmentoCliente)
                .WithState(x => x.IdSegmentoCliente)
                .WithMessage("Segmento Cliente inválido");

            //RuleFor(c => c.IdSegmentoEstrategico)
            //   .Cascade(CascadeMode.Stop)
            //   .NotEmpty()
            //   .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            //   .MustAsync(async (s, cancellation) => await SegmentoEstrategicoExisteNoDB(s))
            //   .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c)
                .MustAsync(async (command, cancellation) => await ValidaIdSegmentoEstrategico(command.IdSegmentoEstrategico!, command.Cliente, command.Fornecedor))
                .OverridePropertyName(x => x.IdSegmentoEstrategico)
                .WithState(x => x.IdSegmentoEstrategico)
                .WithMessage("Segmento Estrategico inválido");

            RuleFor(c => c.CnpjCpf)
              .NotEmpty()
              .WithMessage(ConstantGeneral.REQUIRED_FIELD);

            RuleFor(c => c.RazaoSocial)
              .NotEmpty()
              .WithMessage(ConstantGeneral.REQUIRED_FIELD);
        }

        private async Task<bool> ValidaIdRegiao(Guid? id, bool cliente, bool? fornecedor)
        {
            if(cliente == true || fornecedor == true)
            {
                return await RegiaoExisteNoDB(id);
            }

            return true;
        }

        private async Task<bool> ValidaIdOrigem(Guid? id, bool cliente, bool? fornecedor)
        {
            if (cliente == true || fornecedor == true)
            {
                return await OrigemExisteNoDB(id);
            }

            return true;
        }
        
        private async Task<bool> ValidaIdSegmentoCliente(Guid? id, bool cliente, bool? fornecedor)
        {
            if (cliente == true || fornecedor == true)
            {
                return await SegmentoClienteExisteNoDB(id);
            }

            return true;
        }
        
        private async Task<bool> ValidaIdSegmentoEstrategico(Guid? id, bool cliente, bool? fornecedor)
        {
            if (cliente == true || fornecedor == true)
            {
                return await SegmentoEstrategicoExisteNoDB(id);
            }

            return true;
        }

        private async Task<bool> RegiaoExisteNoDB(Guid? id)
        {
            var idRegiao = id ?? Guid.Empty;
            if (idRegiao == Guid.Empty)
                return false;

            return await _unitOfWork.RegiaoRepository.ExisteIdAsync(idRegiao);
        }

        private async Task<bool> OrigemExisteNoDB(Guid? id)
        {
            var idOrigem = id ?? Guid.Empty;
            if (idOrigem == Guid.Empty)
                return false;

            return await _unitOfWork.OrigemRepository.ExisteIdAsync(idOrigem);
        }

        private async Task<bool> SegmentoClienteExisteNoDB(Guid? id)
        {
            var idSegmentoCliente = id ?? Guid.Empty;
            if (idSegmentoCliente == Guid.Empty)
                return false;

            return await _unitOfWork.SegmentoClienteRepository.ExisteIdAsync(idSegmentoCliente);
        }

        private async Task<bool> SegmentoEstrategicoExisteNoDB(Guid? id)
        {
            var idSegmentoEstrategico = id ?? Guid.Empty;
            if (idSegmentoEstrategico == Guid.Empty)
                return false;

            return await _unitOfWork.SegmentoEstrategicoRepository.ExisteIdAsync(idSegmentoEstrategico);
        }
    }
}
