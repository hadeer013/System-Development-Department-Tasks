using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAreaProj.Areas.HR.Controllers
{
	public class HRDeptController : Controller
	{
		// GET: HRDeptController
		public ActionResult Index()
		{
			return View();
		}

		// GET: HRDeptController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: HRDeptController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: HRDeptController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HRDeptController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: HRDeptController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: HRDeptController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: HRDeptController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
