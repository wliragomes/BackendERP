using SharedKernel.MediatR;

namespace Domain.Commands.PlanosDeContas
{
    public class PlanoDeContasCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
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

        public PlanoDeContasCommand()
        {

        }

        public PlanoDeContasCommand(Guid id, string planoDeContasCompleto, int contaPrincipal, int subGrupo, int analitico, int analiticoDetalhado,
                                    int especifico, string positivoNegativo, string conta, int natureza, int nivel)
        {
            Id = id;
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
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}