using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.ApplicationContext;
using ProductOrderManagement.Models;
using ProductOrderManagement.Models.ViewModels;
using static NuGet.Packaging.PackagingConstants;

namespace ProductOrderManagement.Controllers
{
	public class OrderController : Controller
	{
        private readonly CustomerOrderContext context;

        public OrderController(CustomerOrderContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
		{
			var orders = context.Orders.Include(o => o.Customer).ToList();
			ViewBag.AllCus = new SelectList(context.Customers.ToList(), "Id", "Name");

			return View(orders);
		}

		[HttpPost]
		public ActionResult Index(int Id)
		{
			List<Order> orders = context.Orders.Include(o => o.Customer).ToList();
			ViewBag.AllCus = new SelectList(context.Customers.ToList(), "Id", "Name");
			if (Id != 0)
			{
				orders = context.Orders.Include(o => o.Customer).Where(o => o.CustID == Id).ToList();
			}

			return View(orders);
		}

		
		public ActionResult Details(int id)
		{
			var order = context.Orders.Include(o=>o.Customer).Where(o=>o.Id == id).FirstOrDefault();

			return View(order);
		}

		
		public ActionResult Create(int Id) //Id=> customer Id
		{
			return View(new OrderViewModel { CustID = Id });
		}

		
		[HttpPost]
		public ActionResult Create(OrderViewModel model)
		{
			if(ModelState.IsValid)
			{
                try
                {
                    var newOrder = new Order()
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now),
                        TotalPrice = model.TotalPrice,
                        CustID = model.CustID
                    };
                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(new OrderViewModel() { Id = model.Id, TotalPrice = model.TotalPrice, CustID = model.CustID });
                }
            }
            return View(new OrderViewModel() { Id = model.Id, TotalPrice = model.TotalPrice, CustID = model.CustID });
        }

		
		public ActionResult Edit(int id)
		{
			ViewBag.AllCus = new SelectList(context.Customers.ToList(), "Id", "Name");
			var Order = context.Orders.Find(id);

			return View(new OrderViewModel() { Id=id, TotalPrice=Order.TotalPrice, CustID=Order.CustID});
		}

		
		[HttpPost]
		public ActionResult Edit(int id, OrderViewModel model)
		{
			if(ModelState.IsValid)
			{
                try
                {
                    var order = context.Orders.Find(id);
                    if (order == null) return NotFound();

                    order.TotalPrice = model.TotalPrice;
                    order.CustID = model.CustID;

                    context.Orders.Update(order);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.AllCus = new SelectList(context.Customers.ToList(), "Id", "Name");
                    return View(new OrderViewModel() { Id = model.Id, TotalPrice = model.TotalPrice, CustID = model.CustID });
                }
            }
            ViewBag.AllCus = new SelectList(context.Customers.ToList(), "Id", "Name");
            return View(new OrderViewModel() { Id = model.Id, TotalPrice = model.TotalPrice, CustID = model.CustID });
        }

	
		public ActionResult Delete(int id)
		{
			var order = context.Orders.Find(id);	
			if (order != null)
			{
				context.Orders.Remove(order);
				context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
			return NotFound();
		}

		
	}
}
