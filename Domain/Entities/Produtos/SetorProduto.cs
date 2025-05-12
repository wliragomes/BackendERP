using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class SetorProduto : EntityIdDescricao
    {
        public string CodigoSetor { get; set; }
        public bool Componente { get; set; }
        public int Cmax { get; set; }
        public int Cmin { get; set; }
        public int Lmax { get; set; }
        public int Lmin { get; set; }
        public bool Perfil { get; set; }
        public int CobrancaMinima { get; set; }
        public bool SetorFabricacao { get; set; }
        public bool Pvb { get; set; }
        public bool Argonio { get; set; }
        public bool MostrarCadastro { get; set; }
        public virtual PlanejamentoProducao PlanejamentoProducao { get; set; }

        public SetorProduto(string codigoSetor, bool componente, int cmax, int cmin, int lmax, int lmin, string descricao, 
                            bool perfil, int cobrancaMinima, bool setorFabricacao, bool pvb, bool argonio, bool mostrarCadastro)
        {
            SetId(Guid.NewGuid());
            CodigoSetor = codigoSetor;
            Componente = componente;
            Cmax = cmax;
            Cmin = cmin;
            Lmax = lmax;
            Lmin = lmin;
            Perfil = perfil;
            CobrancaMinima = cobrancaMinima;
            SetorFabricacao = setorFabricacao;
            SetDescricao(descricao);
            Pvb = pvb;
            Argonio = argonio;
            MostrarCadastro = mostrarCadastro;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string codigoSetor, bool componente, int cmax, int cmin, int lmax, int lmin, string descricao, 
                           bool perfil, int cobrancaMinima, bool setorFabricacao, bool pvb, bool argonio, bool mostrarCadastro)
        {
            CodigoSetor = codigoSetor;
            Componente = componente;
            Cmax = cmax;
            Cmin = cmin;
            Lmax = lmax;
            Lmin = lmin;
            Perfil = perfil;
            CobrancaMinima = cobrancaMinima;
            SetorFabricacao = setorFabricacao;
            SetDescricao(descricao);
            Pvb = pvb;
            Argonio = argonio;
            MostrarCadastro = mostrarCadastro;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}

