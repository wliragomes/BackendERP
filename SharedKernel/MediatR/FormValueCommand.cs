namespace SharedKernel.MediatR
{
    public class FormValueCommand<T>
    {
        public int Index { get; set; }
        public T? FormValues { get; set; }
    }
}
