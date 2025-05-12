namespace Application.DTOs.PlanosDeContas
{
    public class PlanoDeContasDto
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
    }
}
