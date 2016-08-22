using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using spWeb.Models.Abstract;
using spWeb.Models.Entitys;

namespace spWeb.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IRepository _repository = new ProductRepository();

        public IEnumerable<Product> GetProducts()
        {
            return _repository.Products;
        }
        public IHttpActionResult GetProduct(int id)
        {
            var result = _repository.Products.FirstOrDefault(product => product.Id == id);
            return result==null? (IHttpActionResult) BadRequest("No items found"):Ok(result);
        }

        [Authorize(Roles = "Administrator")]
        public async Task PostProduct(Product product)
        {
            await _repository.SaveProductAsync(product);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            var result = await _repository.DeleteProductAsync(id);
            return result != null ? Ok(result.Title+"Was deleted sucsesful") : (IHttpActionResult) BadRequest("No product found");
        }
    }
}
