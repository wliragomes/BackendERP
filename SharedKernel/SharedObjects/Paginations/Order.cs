namespace SharedKernel.SharedObjects.Paginations
{
    public class Order
    {
        public string? Orderby { get; set; }
        public string? Direction { get; set; }

        public Order(string? orderby, string? direction)
        {
            Orderby = orderby;
            Direction = direction;
        }
    }
}
