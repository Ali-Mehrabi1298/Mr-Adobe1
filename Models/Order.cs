using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Models
{
    public class Order
    {




        [Key]
        
        public int OrderId { get; set; }

 
        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int Sum { get; set; }

        public string UserName { get; set; }
        public int productId { get; set; }
        public bool IsFinaly { get; set; }


        [ForeignKey("OrderId")]
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
