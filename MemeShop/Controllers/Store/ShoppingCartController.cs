using BLL.Interfaces;
using MemeShop.Models;
using MemeShop.Models.CartViewModel;
using MemeShop.Models.EmailModel;
using System.Collections.Generic;
using System.Web.Mvc;

/// <summary>
/// Cart controller
/// all functionality of Cart here
/// I'm using Session to keep products in cart
/// And StoreClassHelper to incapsulate all logic from controller to current class
/// </summary>
namespace MemeShop.Controllers.Store
{
    //When person add's products to cart send him on this Controller
    public class ShoppingCartController : Controller
    {
        IShopItemService shopItemService { get; set; }
        IDiscountCodeService discountCodeService { get; set; }
        public ShoppingCartController(IShopItemService shopItemService, IDiscountCodeService discountCodeService)
        {
            this.shopItemService = shopItemService;
            this.discountCodeService = discountCodeService;
        }
        
        //If cart not empty use this action
        public ActionResult ShopCart()
        {
            if (Session["cart"] == null)
                return RedirectToAction("EmptyView");

            return View();
        }

        //If cart is empty use this action
        public ActionResult EmptyView()
        {
            return View();
        }

        //Wher user add's new item use this action
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

        //Action to Remove product from cart
        public ActionResult Remove(int id)
        {
            List<Order> cart = (List<Order>)Session["cart"];
            cart.RemoveAt(isExist(id));
            Session["cart"] = cart;

            return RedirectToAction("ShopCart");
        }

        //To find current product in cart
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

        //Payment action with contact form and send message on users E-Mail
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
                //If some problems, showing them to user, and sending back form model
                ViewBag.Status = "We have some problems. Please enter all enabled fields!";
                return View(model);
        }

        //Simple Action that says to user check his E-Mail
        public ActionResult CheckEmail()
        {
            Session["cart"] = null;

            return View();
        }

        //IDisposable pattern to close connection to Database
        protected override void Dispose(bool disposing)
        {
            shopItemService.Dispose();
            base.Dispose(disposing);
        }
    }
}