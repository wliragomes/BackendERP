namespace Domain.Commands.PlanosDeContas.Adicionar
{
    public class AdicionarPlanoDeContasCommand : PlanoDeContasCommand<AdicionarPlanoDeContasCommand>
    {
        public AdicionarPlanoDeContasCommand()
        {

        }

        public AdicionarPlanoDeContasCommand(Guid id, string planoDeContasCompleto, int contaPrincipal, int subGrupo, int analitico, int analiticoDetalhado,
                                            int especifico, string positivoNegativo, string conta, int natureza, int nivel)
            : base(id, planoDeContasCompleto, contaPrincipal, subGrupo, analitico, analiticoDetalhado, especifico, positivoNegativo, 
                  conta, natureza, nivel)
        {
        }
    }
}
