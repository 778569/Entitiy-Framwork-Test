
using Entitiy_Framwork_Test.Database;
using Entitiy_Framwork_Test.Models;


internal class Program
{
    private static void Main(string[] args)
    {
       



        //Product product = new Product()
        //{
        //    Name = "Veggie Special Pizza",
        //    Price = 9.99M
        //};

        //Product product1 = new Product()
        //{
        //    Name = "Deluxe Meat Pizza",
        //    Price = 12.99M
        //};

        DataBase_Context context = new DataBase_Context();
        //context.Products.Add(product1);
        //context.Products.Add(product);

        //context.SaveChanges();


        //Select Price grater than 10.00M

        //fluent API





        //update


        //var updatedata = context.Products.
        //                         Where(x => x.Name == "Veggie Special Pizza").FirstOrDefault();

        //if (updatedata is Product)
        //{
        //    updatedata.Price = 10.99M;
        //}

        //context.SaveChanges();



        // delete


        //update


        var deletedata = context.Products.
                                 Where(x => x.Name == "Veggie Special Pizza").FirstOrDefault();

        if (deletedata is Product)
        {
            context.Remove(deletedata);
        }

        context.SaveChanges();





        var products = context.Products.
            Where(x => x.Price > 10.00M)
            .OrderBy(p => p.Name);

        //link Syntax

        var linkproduct = from product in context.Products
                          where product.Price > 10.00M
                          orderby product.Name
                          select product;

        foreach (var product in products)
        {
            Console.WriteLine($"Id: {product.Id}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine(new string('-', 20));
        }



    }
}