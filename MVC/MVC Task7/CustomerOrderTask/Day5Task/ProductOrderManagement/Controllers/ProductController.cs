using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.ApplicationContext;
using ProductOrderManagement.Helper;
using ProductOrderManagement.Models;
using ProductOrderManagement.Models.ViewModels;

namespace ProductOrderManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly CustomerOrderContext context;

        public ProductController(CustomerOrderContext context)
        {
            this.context = context;
        }


        public ActionResult Index()
        {
            return View(context.Products.Include(p => p.Customer).ToList());
        }


        public ActionResult Details(int id)
        {
            var product = context.Products.Include(p => p.Customer).Where(p=>p.Id==id).FirstOrDefault();
            var temp = new ProductCustomerVM()
            {
                ProductName = product.Name,
                CustomerName = product.Customer.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
            return View(temp);
        }


        public ActionResult Create()
        {
            ViewBag.AllCustomers = context.Customers.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(AddProductVM productvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Product = new Product()
                    {
                        Id = productvm.Id,
                        Name = productvm.Name,
                        Price = productvm.Price,
                        Description = productvm.Description,
                        CustID = 1//productvm.CustID
                    };

					if (productvm.Image!=null)
						Product.ImageUrl = AddFile.UploadImage(productvm.Image);
                    
					context.Add(Product);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.AllCustomers = context.Customers.ToList();
                    return View(productvm);
                }
            }
            ViewBag.AllCustomers = context.Customers.ToList();
            return View(productvm);

        }


        public ActionResult Edit(int id)
        {
            ViewBag.AllCustomers = context.Customers.ToList();
            var product = context.Products.Find(id);
            var temp = new AddProductVM()
            {
                Id = id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                CustID = product.CustID
            };
            return View(temp);
        }


        [HttpPost]
        public ActionResult Edit(int id, AddProductVM productvm)
        {
            if (id != productvm.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
					var Product = new Product()
					{
						Id = productvm.Id,
						Name = productvm.Name,
						Price = productvm.Price,
						Description = productvm.Description,
						CustID = productvm.CustID
					};

					if (productvm.Image != null)
						Product.ImageUrl = AddFile.UploadImage(productvm.Image);

					context.Products.Update(Product);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.AllCustomers = context.Customers.ToList();
                    return View(productvm);
                }
            }
            ViewBag.AllCustomers = context.Customers.ToList();
            return View(productvm);
        }


        public ActionResult Delete(int id)
        {
            return View(context.Products.Find(id));
        }


        public ActionResult ConfirmDelete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
