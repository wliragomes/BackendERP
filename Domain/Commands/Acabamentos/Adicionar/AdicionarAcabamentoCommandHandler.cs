using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Acabamentos.Adicionar
{
    public class AdicionarAcabamentoCommandHandler : IRequestHandler<AdicionarAcabamentoCommand, FormularioResponse<AdicionarAcabamentoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarAcabamentoCommand> _validator;
        private const int _indece = 0;

        public AdicionarAcabamentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarAcabamentoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarAcabamentoCommand>> Handle(AdicionarAcabamentoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarAcabamentoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Acabamento acabamento = new
            (
                command.Descricao,
                command.Tolerancia
            );
            {

                await _unitOfWork.AcabamentoRepository.Adicionar(acabamento);
                response.Formulario!.SetId(acabamento.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
