using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ChairController : Controller
    {
        private IChairRepository repository;
        public int pageSize = 4;
        public ChairController(IChairRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
        {
            ChairsListViewModel model = new ChairsListViewModel
            {
                Chairs = repository.Chairs
                    .Where(p => category==null || p.Category==category)
                    .OrderBy(chair => chair.ChairId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category==null ?
                    repository.Chairs.Count() : 
                    repository.Chairs.Where(chair => chair.Category == category).Count()
                },
                CurrentCategory = category
                
            };
            return View(model);
        }
        public FileContentResult GetImage(int chairId)
        {
            Chair chair = repository.Chairs.FirstOrDefault(
                ch => ch.ChairId == chairId);
            if (chair != null)
            {
                return File(chair.ImageData, chair.ImageMimeType);
            }
            else
            {
                return null;
            }
              
        }
    }
}