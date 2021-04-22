using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using MohamadShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Data.Repository
{
   public interface IGroupRepository
    {

        public IEnumerable<Categoty> GetAllCategory();
        public void GetAll(Filess filess);
        public IEnumerable<Product> GetAllProduct(string Name);
        public IEnumerable<ShowGroupViewModel> GetShowGroupViewModels();
        public IEnumerable<Slider> Sliders();

       
    }




    public class GroupRepository : IGroupRepository
    {
        private Eshopecontex _context;
        public GroupRepository(Eshopecontex context)
        {
            _context = context;
        }


        public void GetAll(Filess Filee)
        {
            _context.Filesses.Add(Filee);
            _context.SaveChanges();
        }

        public IEnumerable<Categoty> GetAllCategory()
        {
            return _context.categories;
        }

        public IEnumerable<Product> GetAllProduct(string Name)
        {

            return _context.Product.Where(d => d.Title == Name);
        }


        //public Product GetAllName(string Name)
        //{
        //    return _context.products.SingleOrDefault(k => k.Name == Name);
        //}

        public IEnumerable<ShowGroupViewModel> GetShowGroupViewModels()
        {
            return _context.categories.Select(c => new ShowGroupViewModel()
            {

                GroupId = c.Id,
                Name = c.Name,
                ProductCount = _context.CategoryToproducts.Count(g => g.CategoryId == c.Id)
            }).ToList();
        }



        public IEnumerable<Slider> Sliders()
        {

            return _context.Sliders.Take(1).ToList();

             

        }
    }
}
