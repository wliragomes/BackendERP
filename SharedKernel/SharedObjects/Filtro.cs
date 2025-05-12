namespace SharedKernel.SharedObjects
{
    public class Filtro
    {
        public string? FiltrarPor
        { get; set; }

        public string? Valor { get; set; }

        public Filtro(string? filtrarPor, string? valor)
        {
            FiltrarPor = filtrarPor;
            Valor = valor;
        }
    }
}
