using DataAccessLayer.Data;
using EntityLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatoSen.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            var user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);
            User user = context.Users.FirstOrDefault(x => x.user_id == user_id);
            return View(user);
        }

        public IActionResult UpdateCountrtCode(string cc)
        {
            Context context = new Context();
            var user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);
            User user = context.Users.FirstOrDefault(x => x.user_id == user_id);
            user.country_code = cc;
            context.Users.Update(user);
            context.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }

    }
}
