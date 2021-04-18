using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeProductsApi.Data.Entities
{
    public class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
