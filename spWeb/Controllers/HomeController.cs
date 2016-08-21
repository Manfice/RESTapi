using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using spWeb.Infrastructure.Identity;
using spWeb.Models.Abstract;
using spWeb.Models.Entitys;

namespace spWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController()
        {
            _repository = new ProductRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            return View(_repository.Products);
        }

        public ActionResult Orders()
        {
            return View(_repository.Orders);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> SaveProduct(Product product)
        {
            await _repository.SaveProductAsync(product);
            return RedirectToAction("Product");
        }
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteProductAsync(id);
            return RedirectToAction("Product");
        }

        public async Task<ActionResult> SaveOrder(Order order)
        {
            await _repository.SaveOrderAsync(order);
            return RedirectToAction("Orders");
        }

        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _repository.DeleteOrderAsync(id);
            return RedirectToAction("Orders");
        }

        public async Task<ActionResult> SignIn()
        {
            var authMgr = HttpContext.GetOwinContext().Authentication;
            var userMgr = HttpContext.GetOwinContext().GetUserManager<SsUserMeneger>();

            var user = await userMgr.FindAsync("Admin", "secret");
            authMgr.SignIn(await userMgr.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie));
            return RedirectToAction("Product");
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}