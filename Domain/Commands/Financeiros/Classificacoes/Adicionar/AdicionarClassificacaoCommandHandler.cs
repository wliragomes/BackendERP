using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Classificacoes.Adicionar
{
    public class AdicionarClassificacaoCommandHandler : IRequestHandler<AdicionarClassificacaoCommand, FormularioResponse<AdicionarClassificacaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarClassificacaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarClassificacaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarClassificacaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarClassificacaoCommand>> Handle(AdicionarClassificacaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarClassificacaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Classificacao classificacao = new
            (
                command.Nome
            );
            {

                await _unitOfWork.ClassificacaoRepository.Adicionar(classificacao);
                response.Formulario!.SetId(classificacao.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
