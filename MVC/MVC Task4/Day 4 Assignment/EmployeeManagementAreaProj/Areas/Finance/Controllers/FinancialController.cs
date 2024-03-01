using EmployeeManagementAreaProj.ApplicationContext;
using EmployeeManagementAreaProj.Areas.Finance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAreaProj.Areas.Finance.Controllers
{
	public class FinancialController : Controller
	{
		// GET: FinancialController
		EmployeeManagementContext context = new EmployeeManagementContext();

		public ActionResult Index()
		{
			return View(context.FinancialSectors.ToList());
		}

		// GET: FinancialController/Details/5
		public ActionResult Details(int id)
		{
			var temp = context.FinancialSectors.Find(id);
			return View(temp);
		}

		// GET: FinancialController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FinancialController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FinancialSector financialSector)
		{
			try
			{
				context.Add(financialSector);
				context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: FinancialController/Edit/5
		public ActionResult Edit(int id)
		{
			
			return View(context.FinancialSectors.Find(id));
		}

		// POST: FinancialController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, FinancialSector financialSector)
		{
			try
			{
				context.FinancialSectors.Update(financialSector);
				context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(financialSector);
			}
		}



		// POST: FinancialController/Delete/5
		
		
		public IActionResult Delete(int Id)
		{
			try
			{
				context.FinancialSectors.Remove(context.FinancialSectors.Find(Id));
				context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
