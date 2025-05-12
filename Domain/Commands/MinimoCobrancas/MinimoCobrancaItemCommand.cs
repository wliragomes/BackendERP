using SharedKernel.MediatR;

namespace Domain.Commands.MinimoCobrancas
{
    public class MinimoCobrancaItemCommand
    {
        public Guid IdMinimoCobranca { get; set; }
        public Guid IdSetorProduto { get; set; }
        public string DescricaoSetorProduto { get; set; }

        public MinimoCobrancaItemCommand()
        {

        }

        public MinimoCobrancaItemCommand(Guid idMinimoCobranca, Guid idSetorProduto, string descricaoSetorProduto)
        {
            IdMinimoCobranca = idMinimoCobranca;
            IdSetorProduto = idSetorProduto;
            DescricaoSetorProduto = descricaoSetorProduto;
        }
    }
}