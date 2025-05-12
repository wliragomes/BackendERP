using SharedKernel.Utils;

namespace SharedKernel.SharedObjects.Paginations
{
    public class Pagination
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int TotalFilteredRecords { get; set; }
        public int TotalRecords { get; set; }

        public int TotalPages
        {
            get
            {
                return CalculateTotalPages();
            }
            private set { }
        }

        public Pagination(int? pageNumber, int? pageSize, int totalRecords, int totalFilteredRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalFilteredRecords = totalFilteredRecords;
            TotalRecords = totalRecords;
        }

        private int CalculateTotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalFilteredRecords / (PageSize ?? DefaultValuesPagination.DefaultPageSize));
        }
    }
}
