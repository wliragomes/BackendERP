using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Projetos.Adicionar
{
    public class AdicionarProjetoCommandHandler : IRequestHandler<AdicionarProjetoCommand, FormularioResponse<AdicionarProjetoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarProjetoCommand> _validator;
        private const int _indece = 0;

        public AdicionarProjetoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarProjetoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarProjetoCommand>> Handle(AdicionarProjetoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarProjetoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            Projeto projeto = new
            (
                command.Nome,
                command.Apitar,
                command.Tarja,
                command.Agrupar,
                command.FProjeto
            );
            {

                await _unitOfWork.ProjetoRepository.Adicionar(projeto);
                response.Formulario!.SetId(projeto.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
