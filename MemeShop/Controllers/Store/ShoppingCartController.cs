using BLL.Interfaces;
using MemeShop.Models;
using MemeShop.Models.CartViewModel;
using MemeShop.Models.EmailModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MemeShop.Controllers.Store
{
    public class ShoppingCartController : Controller
    {
        IShopItemService shopItemService { get; set; }
        public ShoppingCartController(IShopItemService shopItemService)
        {
            this.shopItemService = shopItemService;
        }
        
        public ActionResult ShopCart()
        {
            if (Session["cart"] == null)
                return RedirectToAction("EmptyView");

            return View();
        }

        public ActionResult EmptyView()
        {
            return View();
        }

        public ActionResult AddToCart(int id, string sizes)
        {
            StoreClassHelper helper = new StoreClassHelper(shopItemService);

            ShopItemViewModel model = helper.ConvertFromDTOToViewModel(id);

            if (Session["cart"] == null)
            {
                List<Order> cart = new List<Order>();
                cart.Add(new Order { shopItemViewModel = model, size = sizes});
                Session["cart"] = cart;
            }
            else
            {
                List<Order> cart = (List<Order>)Session["cart"];
                cart.Add(new Order { shopItemViewModel = model, size = sizes });
                Session["cart"] = cart;
            }

            return RedirectToAction("ShopCart");
        }

        public ActionResult Remove(int id)
        {
            List<Order> cart = (List<Order>)Session["cart"];
            cart.RemoveAt(isExist(id));
            Session["cart"] = cart;

            return RedirectToAction("ShopCart");
        }

        private int isExist(int id)
        {
            List<Order> cart = (List<Order>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].shopItemViewModel.Id.Equals(id))
                    return i;
            }

            return -1;
        }

        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(EmailSenderViewModel model)
        {
            StoreClassHelper helper = new StoreClassHelper(shopItemService);

            if (ModelState.IsValid)
            {
                helper.SetWebMailSMTP();
                helper.SendMessageToUser(model);
                
                return RedirectToAction("CheckEmail");
            }
                //If some problems, show them to user, and sending back form model
                ViewBag.Status = "We have some problems. Please enter all enabled fields!";
                return View(model);
        }

        public ActionResult CheckEmail()
        {
            Session["cart"] = null;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            shopItemService.Dispose();
            base.Dispose(disposing);
        }
    }
}