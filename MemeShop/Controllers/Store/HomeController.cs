using BLL.Interfaces;
using System.Web.Mvc;

/// <summary>
/// Simple Controller to Show Home page and store menu with View to current product
/// </summary>
namespace MemeShop.Controllers
{
    //Home and Store Controller
    public class HomeController : Controller
    {
        IShopItemService shopItemService { get; set; }
        public HomeController(IShopItemService shopItemService)
        {
            this.shopItemService = shopItemService;
        }

        //Application start page
        public ActionResult HomePage()
        {
            return View();
        }

        //Store page with all products
        public ActionResult StoreMain()
        {
            StoreClassHelper helper = new StoreClassHelper(shopItemService);

            return View(helper.MapDTOWithViewModel());
        }
        
        //Current item page
        public ActionResult Current(int id)
        {
            StoreClassHelper helper = new StoreClassHelper(shopItemService);
            
            return View(helper.ConvertFromDTOToViewModel(id));
        }

        //IDisposable pattern to close connection to Database
        protected override void Dispose(bool disposing)
        {
            shopItemService.Dispose();
            base.Dispose(disposing);
        }
    }
}