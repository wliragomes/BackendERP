﻿using Domain.Commands.Classificacoes;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Classificacoes.Atualizar
{
    public class AtualizarClassificacaoCommandValidation : AbstractValidator<AtualizarClassificacaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarClassificacaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new ClassificacaoCommandValidation<AtualizarClassificacaoCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.ClassificacaoRepository.ExisteIdAsync(id.Value);
        }
    }
}
