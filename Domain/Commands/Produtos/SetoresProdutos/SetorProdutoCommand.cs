using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.SetoresProdutos
{
    public abstract class SetorProdutoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string CodigoSetor { get; internal set; }
        public bool Componente { get; internal set; }
        public int Cmax { get; internal set; }
        public int Cmin { get; internal set; }
        public int Lmax { get; internal set; }
        public int Lmin { get; internal set; }
        public string Descricao { get; set; }
        public bool Perfil { get; set; }
        public int CobrancaMinima { get; set; }
        public bool SetorFabricacao { get; set; }
        public bool Pvb { get; set; }
        public bool Argonio { get; set; }
        public bool MostrarCadastro { get; set; }

        public SetorProdutoCommand()
        {
        }

        public SetorProdutoCommand(Guid id, string codigoSetor, bool componente, int cmax, int cmin, int lmax, int lmin, string descricao, 
                                   bool perfil, int cobrancaMinima, bool setorFabricacao, bool pvb, bool argonio, bool mostrarCadastro)
        {
            Id = id;
            Descricao = descricao;
            CodigoSetor = codigoSetor;
            Componente = componente;
            Cmax = cmax;
            Cmin = cmin;
            Lmax = lmax;
            Lmin = lmin;
            Perfil = perfil;
            CobrancaMinima = cobrancaMinima;
            SetorFabricacao = setorFabricacao;
            Pvb = pvb;
            Argonio = argonio;
            MostrarCadastro = mostrarCadastro;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
