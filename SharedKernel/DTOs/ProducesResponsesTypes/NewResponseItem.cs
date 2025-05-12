namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class NewResponseItem<T>
    {
        public NewResponseItem(T item)
        {
            Item = item;
        }

        public T Item { get; set; }
    }
}
