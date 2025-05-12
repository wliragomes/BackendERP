using Domain.Entities.Faturas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Vendas
{
    public class VendaRecebimentoTipo : EntityId
    {
        public int QuantidadeParcela { get; set; }
        public bool PagamentoAntecipado { get; set; }
        public int ParcelaPartir { get; set; }
        public int Periodo { get; set; }
        public int QuantidadeDias { get; set; }

        public virtual RelacionaFaturaVendaRecebimentoTipo RelacionaFaturaVendaRecebimentoTipo { get; set; }
        public ICollection<VendaRecebimentoParcela> VendaRecebimentoParcela { get; set; }

        public VendaRecebimentoTipo() { }

        public VendaRecebimentoTipo(int quantidadeParcela, bool pagamentoAntecipado, int parcelaPartir, int periodo, int quantidadeDias)
        {
            QuantidadeParcela = quantidadeParcela;
            PagamentoAntecipado = pagamentoAntecipado;
            ParcelaPartir = parcelaPartir;
            Periodo = periodo;
            QuantidadeDias = quantidadeDias;

            SetId(new Guid());
            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(int quantidadeParcela, bool pagamentoAntecipado, int parcelaPartir, int periodo, int quantidadeDias)
        {
            QuantidadeParcela = quantidadeParcela;
            PagamentoAntecipado = pagamentoAntecipado;
            ParcelaPartir = parcelaPartir;
            Periodo = periodo;
            QuantidadeDias = quantidadeDias;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
