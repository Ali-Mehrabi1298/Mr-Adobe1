using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MohamadShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Controllers
{
    public class Components : Controller
    {
        private Eshopecontex _contex;
        public Components(Eshopecontex contex)
        {

            _contex = contex;

        }


        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var categores = _contex.CategoryToproducts.Where(c => c.CategoryId == id)
                .Include(d => d.Product).Select(s => s.Product).ToList();

            return View(categores);
        }

       




    }
}
