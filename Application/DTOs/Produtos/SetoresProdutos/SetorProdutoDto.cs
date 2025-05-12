namespace Application.DTOs.Produtos.SetoresDeProdutos
{
    public class SetorProdutoDto
    {        
        public string CodigoSetor { get; set; }
        public bool Componente { get; set; }
        public int Cmax { get; set; }
        public int Cmin { get; set; }
        public int Lmax { get; set; }
        public int Lmin { get; set; }
        public string Descricao { get; set; }
        public bool Perfil { get; set; }
        public int CobrancaMinima { get; set; }
        public bool SetorFabricação { get; set; }
        public bool Pvb { get; set; }
        public bool Argonio { get; set; }
        public bool MostrarCadastro { get; set; }
    }
}
