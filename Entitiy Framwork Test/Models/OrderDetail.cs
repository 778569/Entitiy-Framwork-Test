namespace Entitiy_Framwork_Test.Models
{
    public sealed class OrderDetail
    {

        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
        // this two represent foregn key ids

        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}