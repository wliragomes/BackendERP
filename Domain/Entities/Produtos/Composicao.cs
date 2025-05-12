using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class Composicao : Entity
    {
        public Guid IdProduto { get; set; }
        public Guid IdComposicao { get; set; }
        public int? SequenciaComposicao { get; set; }
        public int? PerfilH { get; set; }
        public int? PerfilL { get; set; }
        public bool? Etiqueta { get; set; }
        public Produto? Produto { get; set; }
        
        public Composicao() { }

        public void Update(Guid idComposicao, int? sequenciaComposicao, int? perfilH, int? perfilL, bool? etiqueta)
        {
            IdComposicao = idComposicao;
            SequenciaComposicao = sequenciaComposicao;
            PerfilH = perfilH;
            PerfilL = perfilL;
            Etiqueta = etiqueta;
            
            ChangeUpdateAtToDateTimeNow();
        }
        public Composicao(Guid idProduto, Guid idComposicao, int? sequenciaComposicao, int? perfilH, int? perfilL, bool? etiqueta)
        {
            IdProduto = idProduto;
            IdComposicao = idComposicao;
            SequenciaComposicao = sequenciaComposicao;
            PerfilH = perfilH;
            PerfilL = perfilL;
            Etiqueta = etiqueta;

            SetCreateAtAndUpdateAtToNow();
        }        
    }
}