using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoClientes.Adicionar
{
    public class AdicionarSegmentoClienteCommandHandler : IRequestHandler<AdicionarSegmentoClienteCommand, FormularioResponse<AdicionarSegmentoClienteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarSegmentoClienteCommand> _validator;
        private const int _indece = 0;

        public AdicionarSegmentoClienteCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarSegmentoClienteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarSegmentoClienteCommand>> Handle(AdicionarSegmentoClienteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarSegmentoClienteCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            SegmentoCliente segmentocliente = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.SegmentoClienteRepository.Adicionar(segmentocliente);
                response.Formulario!.SetId(segmentocliente.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
