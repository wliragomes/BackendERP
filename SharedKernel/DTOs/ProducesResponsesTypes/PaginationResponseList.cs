namespace SharedKernel.DTOs.ProducesResponsesTypes
{
    public class PaginationResponseList<T>
    {
        public PaginationResponseList(T item)
        {
            List = new List<T>();
        }

        public List<T> List { get; set; }
    }
}
