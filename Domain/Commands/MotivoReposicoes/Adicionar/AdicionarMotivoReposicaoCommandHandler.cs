using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoReposições.Adicionar
{
    public class AdicionarMotivoReposicaoCommandHandler : IRequestHandler<AdicionarMotivoReposicaoCommand, FormularioResponse<AdicionarMotivoReposicaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarMotivoReposicaoCommand> _validator;
        private const int _indece = 0;

        public AdicionarMotivoReposicaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarMotivoReposicaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarMotivoReposicaoCommand>> Handle(AdicionarMotivoReposicaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarMotivoReposicaoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            MotivoReposicao motivoReposicao = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.MotivoReposicaoRepository.Adicionar(motivoReposicao);
                response.Formulario!.SetId(motivoReposicao.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
