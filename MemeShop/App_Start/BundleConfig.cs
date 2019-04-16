using System.Web;
using System.Web.Optimization;

namespace MemeShop
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //CSS
            bundles.Add(new StyleBundle("~/bundels/bootstrap").Include("~/Content/bootstrap.css"));


            //JS
            bundles.Add(new ScriptBundle("~/bundels/jsbootstrap").Include("~/Scripts/bootstrap*"));
        }
    }
}
