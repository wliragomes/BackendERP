using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class MedidaParametro
    {
        public decimal ToneladaFrete { get; set; }
        public decimal PesoVidro { get; set; }

        public MedidaParametro(decimal toneladaFrete, decimal pesoVidro)
        {
            ToneladaFrete = toneladaFrete;
            PesoVidro = pesoVidro;
        }

        public void Update(decimal toneladaFrete, decimal pesoVidro)
        {
            ToneladaFrete = toneladaFrete;
            PesoVidro = pesoVidro;
        }
    }
}
