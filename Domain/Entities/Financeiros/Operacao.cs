using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Operacao : EntityIdNome
    {
        public bool DescontaFinanceiro { get; set; }
        public bool LancaComissao { get; set; }

        public Operacao(string nome, bool descontaFinanceiro, bool lancaComissao)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            DescontaFinanceiro = descontaFinanceiro;
            LancaComissao = lancaComissao;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, bool descontaFinanceiro, bool lancaComissao)
        {
            SetNome(nome);
            DescontaFinanceiro = descontaFinanceiro;
            LancaComissao = lancaComissao;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
