namespace SharedKernel.SharedObjects
{
    public class Ordenacao
    {
        public string? OrdenarPor { get; set; }
        public string? DirecaoOrdenacao { get; set; }

        public Ordenacao(string? orderby, string? direction)
        {
            OrdenarPor = orderby;
            DirecaoOrdenacao = direction;
        }
    }
}
