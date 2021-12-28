using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            HomeVM home = new HomeVM()
            {
                heroes=_context.MyProperty.ToList(),
                Sliders=_context.Sliders.ToList(),
                abouts=_context.Abouts.ToList(),
                services=_context.Services.ToList(),
                cards=_context.Cards.ToList(),
                features=_context.Features.ToList(),
                testimoniols=_context.Testimoniols.ToList(),
                categories=_context.Categories.Include(x=> x.CategoryProductes).ThenInclude(x=>x.Product).ToList(),




            };
                 //List<Hero> heroes = _context.MyProperty.ToList();
                 //List<Slider> sliders = _context.Sliders.ToList();
            return View(home);
        }
    }
}
