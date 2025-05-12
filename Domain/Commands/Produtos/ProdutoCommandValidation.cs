using Domain.Constants;
using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos
{
    public class ProdutoCommandValidation<T> : AbstractValidator<ProdutoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.IdUnidadeMedida)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage(ConstantGeneral.REQUIRED_FIELD)
               .MustAsync(async (s, cancellation) => await UnidadeMedidaExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);            
            
            RuleFor(c => c.IdSetorProduto)
               .MustAsync(async (s, cancellation) => await SetorProdutoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);
            
            RuleFor(c => c.IdCodigoImportacao)
               .MustAsync(async (s, cancellation) => await CodigoImportacaoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c.IdTipoProduto)
               .MustAsync(async (s, cancellation) => await TipoProdutoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND); 

            RuleFor(c => c.IdGrupo)
               .MustAsync(async (s, cancellation) => await GrupoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND); 

            RuleFor(c => c.IdSubgrupo)
               .MustAsync(async (s, cancellation) => await SubgrupoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND); 

            RuleFor(c => c.IdFamilia)
               .MustAsync(async (s, cancellation) => await FamiliaExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND); 

            RuleFor(c => c.IdSetor)
               .MustAsync(async (s, cancellation) => await SetorExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND); 

            RuleFor(c => c.IdRua)
               .MustAsync(async (s, cancellation) => await RuaExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND); 

            RuleFor(c => c.IdPrateleira)
               .MustAsync(async (s, cancellation) => await PrateleiraExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);  

            RuleFor(c => c.Nome)
               .NotEmpty()
               .WithMessage(ConstantGeneral.REQUIRED_FIELD);

            RuleFor(c => c.Fornecedor)
                .Must(fornecedores => fornecedores == null || fornecedores.Select(f => f.IdFornecedor).Distinct().Count() == fornecedores.Count)
                .WithMessage(ProdutoConstant.FORNECEDOR_DUPLICADO);
        }

        private async Task<bool> UnidadeMedidaExisteNoDB(Guid? id)
        {
            var idUnidadeMedida = id ?? Guid.Empty;
            if (idUnidadeMedida == Guid.Empty)
                return false;

            return await _unitOfWork.UnidadeMedidaRepository.ExisteIdAsync(idUnidadeMedida);
        }        

        private async Task<bool> SetorProdutoExisteNoDB(Guid? id)
        {
            var idSetorProduto = id ?? Guid.Empty;
            if (idSetorProduto == Guid.Empty)
                return false;

            return await _unitOfWork.SetorProdutoRepository.ExisteIdAsync(idSetorProduto);
        }

        private async Task<bool> MateriaPrimaExisteNoDB(Guid? id)
        {
            var IdMateriaPrima = id ?? Guid.Empty;
            if (IdMateriaPrima == Guid.Empty)
                return false;

            return await _unitOfWork.ProdutoRepository.ExisteIdAsync(IdMateriaPrima);
        }

        private async Task<bool> CodigoImportacaoExisteNoDB(Guid? id)
        {
            var idCodigoImportacao = id ?? Guid.Empty;
            if (idCodigoImportacao == Guid.Empty)
                return false;

            return await _unitOfWork.CodigoImportacaoRepository.ExisteIdAsync(idCodigoImportacao);
        }

        private async Task<bool> TipoProdutoExisteNoDB(Guid? id)
        {
            var idTipoProduto = id ?? Guid.Empty;
            if (idTipoProduto == Guid.Empty)
                return false;

            return await _unitOfWork.TipoProdutoRepository.ExisteIdAsync(idTipoProduto);
        }

        private async Task<bool> GrupoExisteNoDB(Guid? id)
        {
            var idGrupo = id ?? Guid.Empty;
            if (idGrupo == Guid.Empty)
                return false;

            return await _unitOfWork.GrupoRepository.ExisteIdAsync(idGrupo);
        }

        private async Task<bool> SubgrupoExisteNoDB(Guid? id)
        {
            var idSubGrupo = id ?? Guid.Empty;
            if (idSubGrupo == Guid.Empty)
                return false;

            return await _unitOfWork.SubgrupoRepository.ExisteIdAsync(idSubGrupo);
        }

        private async Task<bool> FamiliaExisteNoDB(Guid? id)
        {
            var idFamilia = id ?? Guid.Empty;
            if (idFamilia == Guid.Empty)
                return false;

            return await _unitOfWork.FamiliaRepository.ExisteIdAsync(idFamilia);
        }

        private async Task<bool> SetorExisteNoDB(Guid? id)
        {
            var idSetor = id ?? Guid.Empty;
            if (idSetor == Guid.Empty)
                return false;

            return await _unitOfWork.SetorRepository.ExisteIdAsync(idSetor);
        }

        private async Task<bool> RuaExisteNoDB(Guid? id)
        {
            var idRua = id ?? Guid.Empty;
            if (idRua == Guid.Empty)
                return false;

            return await _unitOfWork.RuaRepository.ExisteIdAsync(idRua);
        }

        private async Task<bool> PrateleiraExisteNoDB(Guid? id)
        {
            var idPrateleira = id ?? Guid.Empty;
            if (idPrateleira == Guid.Empty)
                return false;

            return await _unitOfWork.PrateleiraRepository.ExisteIdAsync(idPrateleira);
        }

        private async Task<bool> DesgastePolimentoExisteNoDB(Guid? id)
        {
            var idDesgastePolimento = id ?? Guid.Empty;
            if (idDesgastePolimento == Guid.Empty)
                return false;

            return await _unitOfWork.DesgastePolimentoRepository.ExisteIdAsync(idDesgastePolimento);
        }
    }
}
