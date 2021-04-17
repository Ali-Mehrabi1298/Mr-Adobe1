using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Data
{
    public class Eshopecontex : IdentityDbContext
    {



        public Eshopecontex(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }



        public DbSet<Product> Product { get; set; }
        public DbSet<Categoty> categories { get; set; }

        public DbSet<CategoryToproduct> CategoryToproducts { get; set; }
        //public DbSet<Order> orders { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> orderdetails { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Filess> Filesses { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {


           

            builder.Entity<Categoty>().HasData(new Categoty()
            {

                Id = 1,
                Name = "جدیدترین ها",
                Description = "",


            },
       new Categoty()
       {


           Id = 2,
           Name = "محبوب ترین دوره ها",
           Description = "  ها",


       });




            builder.Entity<Product>().HasData(new Product()
            {

                ProductId = 1,
                Title = "اکولایزر ",
                Text = "دوره  پروژه محور اکولایزر ",
                Price = 200000,
               

            },
 new Product()
 {


     ProductId = 2,
     Title = "افترافکت",
     Text= "دوره پروژه محور افتر افکت",
     Price = 158000,


 });






            base.OnModelCreating(builder);
        }

    }
}



