using Microsoft.AspNetCore.Mvc;
using MohamadShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Component
{
    public class ProductGroupsComponent : ViewComponent
    {

        private IGroupRepository _groupRepository;
        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetShowGroupViewModels());

        }




       
        //}
 //public async Task<IViewComponentResult> InvokeAsyncA()
        //{
        //    return View("/Views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetShowGroupAuthorName());

    }
}
