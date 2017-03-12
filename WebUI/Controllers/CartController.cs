using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IChairRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IChairRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int chairId, string returnUrl)
        {
            Chair chair = repository.Chairs
                .FirstOrDefault(g => g.ChairId == chairId);

            if (chair != null)
            {
                cart.AddItem(chair, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int chairId, string returnUrl)
        {
            Chair game = repository.Chairs
                .FirstOrDefault(g => g.ChairId == chairId);

            if (game != null)
            {
                cart.RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart,ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessorOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}