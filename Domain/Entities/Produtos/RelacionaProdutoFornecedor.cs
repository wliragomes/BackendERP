using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class RelacionaProdutoFornecedor : Entity
    {                    
        public Guid IdFornecedor { get; set; }
        public Guid IdProduto { get; set; }
        public string? CodigoProdutoFornecedor { get; set; }
        public Produto? Produto { get; set; }  
        public Pessoa? Pessoa { get; set; }  

        
        public RelacionaProdutoFornecedor() { }

        public RelacionaProdutoFornecedor(Guid idFornecedor, Guid idProduto, string codigoProdutoFornecedor)
        {            
            IdFornecedor = idFornecedor;
            IdProduto = idProduto;
            CodigoProdutoFornecedor = codigoProdutoFornecedor;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string codigoProdutoFornecedor)
        {
            CodigoProdutoFornecedor = codigoProdutoFornecedor;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
