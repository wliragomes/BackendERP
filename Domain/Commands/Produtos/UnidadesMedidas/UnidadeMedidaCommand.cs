using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.UnidadesMedidas
{
    public abstract class UnidadeMedidaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int CasaDecimal { get; set; }   
        
        public UnidadeMedidaCommand()
        {

        }

        public UnidadeMedidaCommand(Guid id, string descricao, string sigla, int casadecimal)
        {
            Id = id;
            Descricao = descricao;
            Sigla = sigla;
            CasaDecimal = casadecimal;            
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
