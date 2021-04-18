using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeProductsApi.Business.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldDate { get; set; }
        public bool IsActive { get; set; }
    }
}
