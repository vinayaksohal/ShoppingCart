using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    [Table("ShoppingCartItems")]
    public class ShoppingCartItem
    {   
        [Key]
        public int ItemId { get; set; }
        public Course Course { get; set; }
        public decimal Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
