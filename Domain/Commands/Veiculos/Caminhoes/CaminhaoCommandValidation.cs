using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Caminhoes
{
    public class CaminhaoCommandValidation<T> : AbstractValidator<CaminhaoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CaminhaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            

            RuleFor(c => c.Placa)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.CaminhaoCarreta)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdPessoa)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdTipoRodado)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdTipoCarroceria)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdEstado)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdPessoa)
               .MustAsync(async (s, cancellation) => await PessoaExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c.IdTipoRodado)
               .MustAsync(async (s, cancellation) => await TipoRodadoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c.IdTipoCarroceria)
               .MustAsync(async (s, cancellation) => await TipoCarroceriaExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c.IdEstado)
               .MustAsync(async (s, cancellation) => await EstadoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await PlacaExistInDb(s.Placa!, s.Id))
                .OverridePropertyName(x => x.Placa)
                .WithState(x => x.Placa)
                .WithMessage(CaminhaoConstant.PLACA_JA_REGISTRADA)
                .When(x => !string.IsNullOrEmpty(x.Placa), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> PlacaExistInDb(string nome, Guid? id)
        {
            return !await _unitOfWork.CaminhaoRepository.ExistePlacaAsync(nome, id);
        }

        private async Task<bool> PessoaExisteNoDB(Guid? id)
        {
            var idGrupo = id ?? Guid.Empty;
            if (idGrupo == Guid.Empty)
                return false;

            return await _unitOfWork.PessoaRepository.ExisteIdAsync(id);
        }

        private async Task<bool> TipoRodadoExisteNoDB(Guid? id)
        {
            var idGrupo = id ?? Guid.Empty;
            if (idGrupo == Guid.Empty)
                return false;

            return await _unitOfWork.TipoRodadoRepository.ExisteIdAsync(id);
        }

        private async Task<bool> TipoCarroceriaExisteNoDB(Guid? id)
        {
            var idGrupo = id ?? Guid.Empty;
            if (idGrupo == Guid.Empty)
                return false;

            return await _unitOfWork.TipoCarroceriaRepository.ExisteIdAsync(id);
        }

        private async Task<bool> EstadoExisteNoDB(Guid? id)
        {
            var idGrupo = id ?? Guid.Empty;
            if (idGrupo == Guid.Empty)
                return false;

            return await _unitOfWork.EstadoRepository.ExisteIdAsync(id);
        }
    }
}
