using EmployeeManagementAreaProj.ApplicationContext;
using EmployeeManagementAreaProj.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAreaProj.Areas.Admin.Controllers
{
	public class EmployeeController : Controller
	{
		EmployeeManagementContext context = new EmployeeManagementContext();


		public IActionResult GetAllEmployees()
		{
			ViewBag.Departments = new SelectList(context.Departments.ToList(), "DepartmentId", "Name");
			return View(context.Employees.Include(e=>e.Department).ToList());
		}


		[HttpPost]
		public IActionResult GetAllEmployees(IFormCollection formData)
		{
			ViewBag.Departments = new SelectList(context.Departments.ToList(), "DepartmentId", "Name");
			int DeptId = int.Parse(formData["SelectedDept"]);
			if (DeptId != 0)
			{
				return View(context.Employees.Where(e => e.DepartmentId == DeptId).ToList());
			}
			return View(context.Employees.ToList());
		}

		public IActionResult GetEmployee(int Id)
		{
			var Em = context.Employees.Find(Id);
			if (Em != null)
			{
				var dept = context.Departments.Find(Em.DepartmentId);
				if (dept != null)
				{
					ViewBag.dept = dept;
					return View(Em);
				}
			}
			return NotFound();
		}

		public IActionResult UpdateEmployee(int Id)
		{
			var entity = context.Employees.Find(Id);
			if (entity != null)
			{
				ViewBag.Departments = new SelectList(context.Departments.ToList(), "DepartmentId", "Name");
				return View(entity);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult UpdateEmployee(int Id,Employee employee)
		{
			if (Id != employee.EmployeeID) return BadRequest();
			if(employee != null)
			{
				var entity = context.Employees.Find(employee.EmployeeID);
				if (entity != null)
				{
					entity.Email = employee.Email;
					entity.PhoneNum= employee.PhoneNum;
					entity.Name = employee.Name;
					entity.JoinDate = employee.JoinDate;
					entity.Password = employee.Password;
					entity.Salary = employee.Salary;
					entity.DepartmentId = employee.DepartmentId;

					context.Employees.Update(entity);
					context.SaveChanges();
					return RedirectToAction("GetAllEmployees");
				}

			}
			return NotFound(employee);
		}

		public IActionResult AddNewEmployee()
		{
			ViewBag.Departments = new SelectList(context.Departments.ToList(), "DepartmentId", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult AddNewEmployee(Employee employee)
		{
			try
			{
				context.Employees.Add(employee);
				context.SaveChanges();
				return RedirectToAction("GetAllEmployees");
			}
			catch
			{
				return BadRequest();
			}
		}

		public IActionResult DeleteEmployee(int Id) 
		{
			var emp = context.Employees.Find(Id);
			if(emp != null)
			{
				context.Employees.Remove(emp);
				context.SaveChanges();
				return RedirectToAction("GetAllEmployees");
			}
			else
				return NotFound();
		}

	}
}
