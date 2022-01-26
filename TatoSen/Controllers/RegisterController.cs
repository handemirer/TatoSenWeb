using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using EntityLayer.Model;
using TatoSen.Models;

namespace TatoSen.Controllers
{
    public class RegisterController : Controller
    {



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(User user)
        {
            user.role = 1;

            using (var sha256provider = new SHA256CryptoServiceProvider())
            {
                var hash = sha256provider.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                user.password = BitConverter.ToString(hash).Replace("-", "");
            }

            Context context = new Context();
            context.Users.Add(user);

            // TODO user packslerini oluştur
            // context.SaveChanges();
            ErrorViewModel error = new ErrorViewModel();
            error.RequestId = "Register not available cause this website in develop state";
            return RedirectToAction("Error", "Home", error);
            //return RedirectToAction("Index", "Home");
            //return View();
        }

    }
}
