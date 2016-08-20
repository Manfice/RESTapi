using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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

        public async Task<ActionResult> SaveProduct(Product product)
        {
            await _repository.SaveProductAsync(product);
            return RedirectToAction("Product");
        }

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
    }
}