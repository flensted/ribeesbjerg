using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RibeEsbjergHH.Models;

namespace RibeEsbjergHH.Controllers
{
    public class SkoleAdminController : Controller
    {
        //
        // GET: /SkoleAdmin/

        public ActionResult Index()
        {
            var repo = new ParticipantRepository();
            return View(repo.GetAll());
        }

        //
        // GET: /SkoleAdmin/Details/5

        public ActionResult Details(int id)
        {
            var repo = new ParticipantRepository();
            return View(repo.Get(id));
        }

        public ActionResult FullList()
        {
            var repo = new ParticipantRepository();
            return View(repo.GetAll());
        }

        public ActionResult CSV()
        {
            var repo = new ParticipantRepository();
            return View(repo.GetAll());
        }



        //
        // GET: /SkoleAdmin/Create

        //public ActionResult Create()
        //{
        //    return View(new Participant());
        //}

        ////
        //// POST: /SkoleAdmin/Create

        //[HttpPost]
        //public ActionResult Create(Participant newParticipant)
        //{
        //    try
        //    {
        //        var repo = new ParticipantRepository();
        //        repo.Add(newParticipant);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /SkoleAdmin/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    var repo = new ParticipantRepository();
        //    return View(repo.Get(id));
        //}

        ////
        //// POST: /SkoleAdmin/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, Participant newParticipant)
        //{
        //    try
        //    {
        //        var repo = new ParticipantRepository();
        //        repo.Change(id, newParticipant);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /SkoleAdmin/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var repo = new ParticipantRepository();
        //        repo.Delete(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// POST: /SkoleAdmin/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        var repo = new ParticipantRepository();
        //        repo.Delete(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
