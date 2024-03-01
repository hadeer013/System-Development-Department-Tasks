using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductOrderManagement.ApplicationContext;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.Controllers
{
    public class CustomerController : Controller
    {
        CustomerOrderContext context = new CustomerOrderContext();



        public ActionResult Index()
        {
            var customers = context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = context.Customers.Where(o => o.Id == id).FirstOrDefault();

            return View(customer);
        }


        public ActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Customer Customer)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var newCustomer = new Customer()
                    {
                        Name = Customer.Name,
                        Email = Customer.Email,
                        Gender = Customer.Gender,
                        phoneNum = Customer.phoneNum
                    };
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(Customer);
                }
            }
            return View(Customer);
        }


        public ActionResult Edit(int id)
        {
            var customer = context.Customers.Find(id);
            if(customer == null) { return NotFound(); }
            return View(customer);
        }


        [HttpPost]
        public ActionResult Edit(int id, Customer model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customer = context.Customers.Find(id);
                    if(customer == null ) { return NotFound(); }

                    customer.Name = model.Name;
                    customer.phoneNum = model.phoneNum;
                    customer.Gender= model.Gender;
                    customer.Email = model.Email;
                     


                    context.Customers.Update(customer);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }


        public ActionResult Delete(int id)
        {
            var customer = context.Customers.Include(c => c.Orders).Where(c => c.Id == id).FirstOrDefault();
            if (customer != null)
            {
                
                foreach (var item in customer.Orders)
                {
                    context.Orders.Remove(item);
                }
                context.Customers.Remove(customer);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
