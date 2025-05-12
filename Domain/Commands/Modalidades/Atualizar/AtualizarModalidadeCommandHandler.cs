using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Modalidades.Atualizar
{
    public class AtualizarModalidadeCommandHandler : IRequestHandler<AtualizarModalidadeCommand, FormularioResponse<AtualizarModalidadeCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarModalidadeCommand> _validator;
        private const int _indice = 0;

        public AtualizarModalidadeCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarModalidadeCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarModalidadeCommand>> Handle(AtualizarModalidadeCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarModalidadeCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ModalidadeUpdate = await _unitOfWork.ModalidadeRepository.ObterPorId(command.Id);
            ModalidadeUpdate!.Update(command.DescricaoModalidade, command.ExigeNumero);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarModalidadeCommand(
                command.Id,
                command.DescricaoModalidade,
                command.ExigeNumero);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
