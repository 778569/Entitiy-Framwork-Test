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
