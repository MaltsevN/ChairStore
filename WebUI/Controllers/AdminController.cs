using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IChairRepository repository;

        public AdminController(IChairRepository rep)
        {
            repository = rep;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Chairs);
        }

        public ViewResult Edit(int chairId)
        {
            Chair chair = repository.Chairs
                .FirstOrDefault(g => g.ChairId == chairId);
            return View(chair);
        }

        [HttpPost]
        public ActionResult Edit(Chair chair, HttpPostedFileBase image= null)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    chair.ImageMimeType = image.ContentType;
                    chair.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(chair.ImageData, 0, image.ContentLength);
                }
                repository.SaveChair(chair);
                TempData["message"] = string.Format("Changes in \"{0}\" saved", chair.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(chair);
            }
        }

        public ActionResult Create()
        {
            return View("Edit", new Chair());
        }

        [HttpPost]
        public ActionResult Delete(int chairId)
        {
            Chair deletedChair = repository.DeleteChair(chairId);
            if (deletedChair != null)
            {
                TempData["message"] = string.Format("Chair \"{0}\" was deleted",
                    deletedChair.Name);
            }
            return RedirectToAction("Index");
        }
    }
}