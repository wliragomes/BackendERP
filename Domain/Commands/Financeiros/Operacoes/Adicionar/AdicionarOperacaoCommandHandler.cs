using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Operacoes.Adicionar
{
    public class AdicionarOperacaoCommandHandler : IRequestHandler<AdicionarOperacaoCommand, FormularioResponse<AdicionarOperacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarOperacaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarOperacaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarOperacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarOperacaoCommand>> Handle(AdicionarOperacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarOperacaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Operacao operacao = new
            (
                command.Nome,
                command.DescontaFinanceiro,
                command.LancaComissao
            );
            {

                await _unitOfWork.OperacaoRepository.Adicionar(operacao);
                response.Formulario!.SetId(operacao.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
