using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasPadrao.Adicionar
{
    public class AdicionarObraPadraoCommandHandler : IRequestHandler<AdicionarObraPadraoCommand, FormularioResponse<AdicionarObraPadraoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarObraPadraoCommand> _validator;
        private const int _indece = 0;

        public AdicionarObraPadraoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarObraPadraoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarObraPadraoCommand>> Handle(AdicionarObraPadraoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarObraPadraoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ObraPadrao obraFase = new(command.Nome);
            {
                await _unitOfWork.ObraPadraoRepository.Adicionar(obraFase);
                response.Formulario!.SetId(obraFase.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
