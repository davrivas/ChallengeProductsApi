using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeProductsApi.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldDate { get; set; }
        public bool IsActive { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
