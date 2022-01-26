using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using EntityLayer.Model;

namespace TatoSen.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {

        Context c = new Context();

        public IActionResult Index()
        {
            ViewBag.users = c.Users.ToList().Count;
            ViewBag.packs = c.Packs.ToList().Count;
            ViewBag.sentences = c.Sentences.ToList().Count;

            return View();
        }

        public IActionResult Users()
        {
            var users = c.Users.ToList();
            return View(users);
        }

        public IActionResult Packs()
        {
            var packs = c.Packs.ToList();
            return View(packs);
        }

        public IActionResult Sentences()
        {
            //var list = new List<Sentence>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(c.Sentences.ToList().ElementAt(i));
            //}
            //return View(list);

            var sentences = c.Sentences.ToList();
            return View(sentences);
        }
    }

}
