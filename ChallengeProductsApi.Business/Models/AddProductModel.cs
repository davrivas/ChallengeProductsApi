using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeProductsApi.Business.Models
{
    public class AddProductModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldDate { get; set; }
        public bool IsActive { get; set; }
        public int ProductTypeId { get; set; }
    }
}
