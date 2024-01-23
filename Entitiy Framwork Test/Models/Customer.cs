using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy_Framwork_Test.Models
{
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
}
