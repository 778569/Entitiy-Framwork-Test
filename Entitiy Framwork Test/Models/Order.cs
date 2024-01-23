namespace Entitiy_Framwork_Test.Models
{
    public sealed class Order
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime OrderFulfilled { get; set; }

        public int CustomerId { get; set; }

        // IF we created or not this Customer ID property EF core Create any way
        // This call shadow property

        public Customer Customer { get; set; }
         = null!;
        // Another navation property that specifing one customer entitiy for order 
        //included customer ID property to represent the forign key relationship to the customer table that will be generated.


        public  ICollection<OrderDetail>  OrderDetails { get; set; } = null!;
    }
}