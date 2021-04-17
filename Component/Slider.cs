using Microsoft.AspNetCore.Mvc;
using MohamadShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohamadShop.Component
{
    public class Slider : ViewComponent
    {

        private IGroupRepository _groupRepository;
        public Slider(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/slider.cshtml", _groupRepository.Sliders());

        }



    }

    }
