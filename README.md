# Entity Framework Usage Guide

This guide provides a step-by-step process for using Entity Framework in a .NET project.

## Install Entity Framework

Open your Visual Studio project and install Entity Framework using the NuGet Package Manager Console or Package Manager UI:

```bash
Install-Package EntityFramework

```
## Define Your Model
Create classes that represent your database tables. These classes will be your entities. Add necessary attributes and relationships between entities using annotations or fluent API.

```bash

public sealed class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public ICollection<Order> Orders { get; set; } // Collection of order object, This is call navigation property, 
    // this indicates that a customer may have zero or more oders 
    // this creates a one or many relationship in the database.

    public string? Email { get; set; }
}

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy_Framwork_Test.Models
{
    public sealed class Product
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        // I want to put only two decimal pleases, 2 point of pricition

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; } 

    }
}
```
## Create a DbContext
Create a class that inherits from DbContext and represents your database context.<br>
Configure Connection String<br>
In your application configuration file (e.g., app.config or web.config), add a connection string for your database.

```
csharp
using Entitiy_Framwork_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy_Framwork_Test.Database
{
    public class DataBase_Context : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStraing = "Server=DESKTOP-0D8DMT4;Initial Catalog=EF;Integrated Security=true; User Id=sa;password =778569119119; MultipleActiveResultSets=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionStraing);
        }
    }
}
```
## Initialize Database
Use Entity Framework migration commands to create and apply migrations to your database.

```bash
Copy code
Enable-Migrations
Add-Migration InitialCreate
Update-Database
```
# Get , Create, Update, Delete , Entity Framework

```

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




