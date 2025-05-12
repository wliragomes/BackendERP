using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Modalidades.Adicionar
{
    public class AdicionarModalidadeCommandHandler : IRequestHandler<AdicionarModalidadeCommand, FormularioResponse<AdicionarModalidadeCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarModalidadeCommand> _validator;
        private const int _indece = 0;

        public AdicionarModalidadeCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarModalidadeCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarModalidadeCommand>> Handle(AdicionarModalidadeCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarModalidadeCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Modalidade modalidade = new
            (
                command.DescricaoModalidade,
                command.ExigeNumero
            );
            {

                await _unitOfWork.ModalidadeRepository.Adicionar(modalidade);
                response.Formulario!.SetId(modalidade.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
