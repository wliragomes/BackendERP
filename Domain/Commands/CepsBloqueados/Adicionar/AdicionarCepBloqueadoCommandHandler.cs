using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CepsBloqueados.Adicionar
{
    public class AdicionarCepBloqueadoCommandHandler : IRequestHandler<AdicionarCepBloqueadoCommand, FormularioResponse<AdicionarCepBloqueadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarCepBloqueadoCommand> _validator;
        private const int _indece = 0;

        public AdicionarCepBloqueadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarCepBloqueadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarCepBloqueadoCommand>> Handle(AdicionarCepBloqueadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarCepBloqueadoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            CepBloqueado cepBloqueado = new
            (
                command.NumeroCep,
                command.Descricao,
                command.NumeroDe,
                command.NumeroAte,
                command.Par,
                command.Impar);
            {

                await _unitOfWork.CepBloqueadoRepository.Adicionar(cepBloqueado);
                response.Formulario!.SetId(cepBloqueado.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
