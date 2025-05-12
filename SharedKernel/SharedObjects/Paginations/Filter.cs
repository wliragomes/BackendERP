namespace SharedKernel.SharedObjects.Paginations
{
    public class Filter
    {
        public string? FilterBy { get; set; }
        public string? Value { get; set; }

        public Filter(string? filterBy, string? value)
        {
            FilterBy = filterBy;
            Value = value;
        }
    }
}
