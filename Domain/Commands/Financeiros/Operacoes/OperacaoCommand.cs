using SharedKernel.MediatR;

namespace Domain.Commands.Operacoes
{
    public abstract class OperacaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool DescontaFinanceiro { get; set; }
        public bool LancaComissao { get; set; }

        public OperacaoCommand()
        {

        }

        public OperacaoCommand(Guid id, string? nome, bool descontaFinanceiro, bool lancaComissao)
        {
            Id = id;
            Nome = nome;
            DescontaFinanceiro = descontaFinanceiro;
            LancaComissao = lancaComissao;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}