namespace SharedKernel.DTOs
{
    public class FormularioDto<T>
    {
        public int? Indice { get; set; }
        public T Formulario { get; set; }
    }
}