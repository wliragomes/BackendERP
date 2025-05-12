using Domain.Entities.Pessoas;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoEstrategicos.Adicionar
{
    public class AdicionarSegmentoEstrategicoCommandHandler : IRequestHandler<AdicionarSegmentoEstrategicoCommand, FormularioResponse<AdicionarSegmentoEstrategicoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarSegmentoEstrategicoCommand> _validator;
        private const int _indece = 0;

        public AdicionarSegmentoEstrategicoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarSegmentoEstrategicoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarSegmentoEstrategicoCommand>> Handle(AdicionarSegmentoEstrategicoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarSegmentoEstrategicoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            SegmentoEstrategico segmentoestrategico = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.SegmentoEstrategicoRepository.Adicionar(segmentoestrategico);
                response.Formulario!.SetId(segmentoestrategico.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
