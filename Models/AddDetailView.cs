using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Models
{
    public class AddDetailView
    {

       
        public Product product { get; set; }

        public List<Categoty> categories { get; set; }
        public   Order order  { get; set; }
        public OrderDetail OrderDetail { get; set; }
       
        public List<Filess> Filess { get; set; }

    }
}
