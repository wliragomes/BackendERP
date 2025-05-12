using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class PrecosTributacoes : EntityId    {
        
        public Guid IdProduto { get; set; }
        public Guid IdNcm { get; set; }
        public Guid IdOrigemMaterial { get; set; }
        public Guid IdTipoPreco { get; set; }
        public Guid IdClasseReajuste { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal? PrecoVenda { get; set; }
        public bool? Inativo { get; set; }
        public Produto? Produto { get; set; }

        public PrecosTributacoes() { }

        public PrecosTributacoes(Guid idProduto, Guid idNcm, Guid idOrigemMaterial, Guid idTipoPreco, Guid IdclasseReajuste, decimal? precoCusto, decimal? precoVenda, bool? inativo)
        {
            SetId(Guid.NewGuid());

            IdProduto = idProduto;
            IdNcm = idNcm;
            IdOrigemMaterial = idOrigemMaterial;
            IdTipoPreco = idTipoPreco;
            IdClasseReajuste = IdclasseReajuste;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            Inativo = inativo;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idNcm, Guid idOrigemMaterial, Guid idTipoPreco, Guid idClasseReajuste, decimal? precoCusto, decimal? precoVenda, bool? inativo)
        {            
            IdNcm = idNcm;
            IdOrigemMaterial = idOrigemMaterial;
            IdTipoPreco = idTipoPreco;
            IdClasseReajuste = idClasseReajuste;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            Inativo = inativo;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
