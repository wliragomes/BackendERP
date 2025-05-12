using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class PlanoDeContas : EntityId
    {
        public string PlanoDeContasCompleto { get; set; }
        public int ContaPrincipal { get; set; }
        public int SubGrupo { get; set; }
        public int Analitico { get; set; }
        public int AnaliticoDetalhado { get; set; }
        public int Especifico { get; set; }
        public string PositivoNegativo { get; set; }
        public string Conta { get; set; }
        public int Natureza { get; set; }
        public int Nivel { get; set; }

        public PlanoDeContas() { }

        public PlanoDeContas(string planoDeContasCompleto, int contaPrincipal, int subGrupo, int analitico, int analiticoDetalhado,
                             int especifico, string positivoNegativo, string conta, int natureza, int nivel)
        {
            SetId(Guid.NewGuid());
            PlanoDeContasCompleto = planoDeContasCompleto;
            ContaPrincipal = contaPrincipal;
            SubGrupo = subGrupo;
            Analitico = analitico;
            AnaliticoDetalhado = analiticoDetalhado;
            Especifico = especifico;
            PositivoNegativo = positivoNegativo;
            Conta = conta;
            Natureza = natureza;
            Nivel = nivel;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string planoDeContasCompleto, int contaPrincipal, int subGrupo, int analitico, int analiticoDetalhado,
                           int especifico, string positivoNegativo, string conta, int natureza, int nivel)
        {
            PlanoDeContasCompleto = planoDeContasCompleto;
            ContaPrincipal = contaPrincipal;
            SubGrupo = subGrupo;
            Analitico = analitico;
            AnaliticoDetalhado = analiticoDetalhado;
            Especifico = especifico;
            PositivoNegativo = positivoNegativo;
            Conta = conta;
            Natureza = natureza;
            Nivel = nivel;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
