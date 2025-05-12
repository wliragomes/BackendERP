using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Funcionalidades.Adicionar
{
    public class AdicionarFuncionalidadeCommandHandler : IRequestHandler<AdicionarFuncionalidadeCommand, FormularioResponse<AdicionarFuncionalidadeCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarFuncionalidadeCommand> _validator;
        private const int _indice = 0;

        public AdicionarFuncionalidadeCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarFuncionalidadeCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarFuncionalidadeCommand>> Handle(AdicionarFuncionalidadeCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarFuncionalidadeCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var funcionalidade = new Funcionalidade(command.Codigo, command.Nome);
            var relacionaFuncionalidadeNivelAcesso = command.IdNivelAcesso
                .Select(item => new RelacionaFuncionalidadeNivelAcesso(funcionalidade.Id, item))
                .ToList();

            await _unitOfWork.FuncionalidadeRepository.Adicionar(funcionalidade);
            await _unitOfWork.RelacionaFuncionalidadeNivelAcessoRepository.AdicionarEmMassa(relacionaFuncionalidadeNivelAcesso);

            response.Formulario!.SetId(funcionalidade.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}
