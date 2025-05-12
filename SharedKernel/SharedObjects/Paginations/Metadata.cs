namespace SharedKernel.SharedObjects.Paginations
{
    public class Metadata
    {
        public Pagination? Pagination { get; set; }
        public Order Order { get; set; }
        public Filter Filter { get; set; }

        public void AddPagination(int? pageNumber, int? pageSize, int totalRecords, int totalFilteredRecords)
        {
            Pagination = new Pagination(pageNumber, pageSize, totalRecords, totalFilteredRecords);
        }

        public void AddOrder(string? orderby, string? direction)
        {
            Order = new Order(orderby, direction);
        }

        public void AddFilter(string? filterBy, string? value)
        {
            Filter = new Filter(filterBy, value);
        }
    }
}
