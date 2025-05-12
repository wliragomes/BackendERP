using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoCancelamentos.Adicionar
{
    public class AdicionarMotivoCancelamentoCommandHandler : IRequestHandler<AdicionarMotivoCancelamentoCommand, FormularioResponse<AdicionarMotivoCancelamentoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarMotivoCancelamentoCommand> _validator;
        private const int _indece = 0;

        public AdicionarMotivoCancelamentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarMotivoCancelamentoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarMotivoCancelamentoCommand>> Handle(AdicionarMotivoCancelamentoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarMotivoCancelamentoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            MotivoCancelamento motivoCancelamento = new
            (
                command.Nome,
                command.Descricao,
                command.Pedido,
                command.Orcamento,
                command.PedidoInativo,
                command.OrcamentoInativo
            );
            {

                await _unitOfWork.MotivoCancelamentoRepository.Adicionar(motivoCancelamento);
                response.Formulario!.SetId(motivoCancelamento.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
