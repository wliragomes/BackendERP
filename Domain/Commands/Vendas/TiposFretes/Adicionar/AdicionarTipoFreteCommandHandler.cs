using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TipoFretes.Adicionar
{
    public class AdicionarTipoFreteCommandHandler : IRequestHandler<AdicionarTipoFreteCommand, FormularioResponse<AdicionarTipoFreteCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarTipoFreteCommand> _validator;
        private const int _indice = 0;

        public AdicionarTipoFreteCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarTipoFreteCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarTipoFreteCommand>> Handle(AdicionarTipoFreteCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarTipoFreteCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            TipoFrete tipoFrete = new
            (
                command.NFrete,
                command.Descricao!,
                command.DescricaoResumida!
            );
            {

                await _unitOfWork.TipoFreteRepository.Adicionar(tipoFrete);
                response.Formulario!.SetId(tipoFrete.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
