using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using EntityLayer.Model;
using TatoSen.Models;
using TatoSen.Model;

namespace TatoSen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // TODO get packs
            Context context = new Context();
            var user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);
            var userpacks = context.UserPacks.Where(x => x.user_id == user_id).ToList();

            List<UserPackViewModel> packs = new List<UserPackViewModel>();

            foreach (var item in userpacks)
            {
                UserPackViewModel userPackViewModel = new UserPackViewModel();
                userPackViewModel.index = item.index;
                userPackViewModel.user_id = item.user_id;
                userPackViewModel.user_pack_id = item.user_pack_id;
                userPackViewModel.pack_name = item.pack_name;
                userPackViewModel.last_update = item.last_update;
                userPackViewModel.count = context.UserSentences.Where(x => x.user_id == item.user_id && x.user_pack_id == item.user_pack_id).ToList().Count;
                packs.Add(userPackViewModel);
            }

            return View(packs);
        }
        public IActionResult Packs()
        {
            // TODO get packs

            var user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);
            Context context = new Context();
            var addeds = context.Addeds.Where(x => x.user_id == user_id).ToList();
            var pack_ids = new List<int>();
            foreach (var added in addeds)
            {
                pack_ids.Add(added.pack_id);
            }
            var userpacks = context.Packs.ToList();
            userpacks = userpacks.Where(x => !pack_ids.Contains(Convert.ToInt32(x.pack_id))).ToList();
            return View(userpacks);
        }

        public IActionResult PackShow(int id)
        {
            // TODO get packs
            Context context = new Context();
            var sentences = context.Sentences.ToList();
            sentences = sentences.Where(x => x.pack_id == id).ToList();
            return View(sentences);
        }
        public IActionResult AddPack(int id)
        {
            // TODO get packs
            try
            {
                Context context = new Context();
                var sentences = context.Sentences.AsNoTracking().ToList();
                sentences = sentences.Where(x => x.pack_id == id).ToList();


                foreach (var sentence in sentences)
                {

                    UserSentence userSentence = new UserSentence();
                    userSentence.user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);
                    userSentence.user_pack_id = 0;
                    userSentence.sentence_id = sentence.sentence_id;

                    context.UserSentences.Add(userSentence);
                    context.SaveChanges();
                }

                Added added = new Added();
                added.pack_id = id;
                added.user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);
                context.Addeds.Add(added);
                context.SaveChanges();


                return RedirectToAction("Packs", "Home");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Learn(int id)
        {

            var user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);

            Context context = new Context();
            var userPack = context.UserPacks.FirstOrDefault(x => x.user_pack_id == id && x.user_id == user_id);


            List<UserSentence> userSentences = context.UserSentences.Where(x => x.user_pack_id == userPack.user_pack_id).ToList();

            if (userSentences.Count == 0)
            {
                // TODO info page
                return RedirectToAction("Error", "Home");
            }

            if (userSentences.Count <= userPack.index || userPack.index < 0)
            {
                userPack.index = 0;
                context.UserPacks.Update(userPack);
                context.SaveChanges();
            };
            return View(userSentences.ElementAt(userPack.index));


        }

        public IActionResult ChangeUserPack(int id, int user_sentence_id, int pack_id)
        {
            Context context = new Context();
            UserSentence userSentence = context.UserSentences.FirstOrDefault(x => x.user_sentence_id == user_sentence_id);
            userSentence.user_pack_id = pack_id;
            context.UserSentences.Update(userSentence);
            context.SaveChanges();

            return RedirectToAction("Learn", "Home", new { id = id });


        }

        public IActionResult DeleteUserSentence(int id, int user_sentence_id)
        {
            Context context = new Context();
            UserSentence userSentence = context.UserSentences.FirstOrDefault(x => x.user_sentence_id == user_sentence_id);
            context.UserSentences.Remove(userSentence);
            context.SaveChanges();

            return RedirectToAction("Learn", "Home", new { id = id });


        }

        public IActionResult UpdateIndex(int id, int user_pack_id, int indexDiff)
        {
            Context context = new Context();
            var user_id = Convert.ToInt32(HttpContext.User.FindFirst("userid").Value);


            var userPack = context.UserPacks.FirstOrDefault(x => x.user_pack_id == user_pack_id && x.user_id == user_id);


            userPack.index += indexDiff;
            context.UserPacks.Update(userPack);
            context.SaveChanges();

            return RedirectToAction("Learn", "Home", new { id = id });


        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
