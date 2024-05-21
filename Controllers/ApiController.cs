﻿using Microsoft.AspNetCore.Mvc;
using MSIT158Site.Models;
using Newtonsoft.Json;

namespace MSIT158Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _context;
        public ApiController(MyDBContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000);
            return Content("<h2>世界, 您好!!</h2>", "text/html", System.Text.Encoding.UTF8);
        }

        public IActionResult Cities()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult Avatar(int id = 1)
        {
            Member? member = _context.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                if (img != null)
                {
                    return File(img, "image/jpeg");
                }

            }
            return NotFound();
        }

        public IActionResult Register(int id,string name,int age=20 )
        {
            if (string.IsNullOrEmpty(name)) 
            {
                name = "guest";
            }
            return Content($"{id} - {name}好!! 你{age}歲了","text/html",System.Text.Encoding.UTF8);
        }



    }
}