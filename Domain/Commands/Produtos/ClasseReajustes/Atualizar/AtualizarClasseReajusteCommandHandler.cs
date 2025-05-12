using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.ClasseReajustes.Atualizar
{
    public class AtualizarClasseReajusteCommandHandler : IRequestHandler<AtualizarClasseReajusteCommand, FormularioResponse<AtualizarClasseReajusteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarClasseReajusteCommand> _validator;
        private const int _indice = 0;

        public AtualizarClasseReajusteCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarClasseReajusteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarClasseReajusteCommand>> Handle(AtualizarClasseReajusteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarClasseReajusteCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ClasseReajusteUpdate = await _unitOfWork.ClasseReajusteRepository.ObterPorId(command.Id);
            ClasseReajusteUpdate!.Update(command.Nome,
                                         command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarClasseReajusteCommand(
                command.Id,
                command.Nome,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
