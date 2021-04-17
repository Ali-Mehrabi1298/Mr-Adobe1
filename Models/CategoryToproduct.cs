using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Models
{
    public class CategoryToproduct
    {

        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

      
        //public int FilesssID { get; set; }

        //Navigation Property
        public Categoty Category { get; set; }
        public Product Product { get; set; }

        //public Filesss Filesss { get; set; }



    }
}
