using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCard.AppContext;
using ProductCard.Models;


namespace ProductCard.Controllers
{
    public class ProductController : Controller
    {
        productContext context = new productContext();
        public IActionResult ShowDefaultProduct()
        {
            return View(
                new Product
                { Id = 1, Name = "Anime", Description = "Product pic", ImageUrl = "/images/1.jpg", Price = 500 }
            );
        }


        //string Name, string Picture, double Price, string Description
        public IActionResult ShowProductDetails(int Id)
        {
            var product = context.Products.Find(Id);
            if (product != null)
            {
                return View(product);
            }
            return View(
                new Product
                { Id = 2, Name = "Anime", Description = "Product pic", ImageUrl = "wwwroot/images/2.jpg", Price = 500 }
            );
        }


    }
}
