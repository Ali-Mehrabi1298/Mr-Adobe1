using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Models
{
    public class Categoty
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<CategoryToproduct> CategoryToProducts { get; set; }




    }
}
