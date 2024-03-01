using Microsoft.AspNetCore.Mvc;
using MVCTask_Day3.Models;
using MVCTask_Day3.Utilities;
using MVCTask_Day3.ViewModels;
using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace MVCTask_Day3.Controllers
{
	public class CarController : Controller
	{
		static CarList carList = new CarList();

		public IActionResult Index()
		{
			return View(carList.GetAlllCars());
		}

		public IActionResult CreateCar()
		{
			return View();
		}


		[HttpPost]
		public IActionResult CreateCar(CarViewModel carViewModel)
		{
			var Car = new Car()
			{ Color = carViewModel.Color, Manufacture = carViewModel.Manufacture, Model = carViewModel.Model, Num = carViewModel.Num };

			if (carViewModel.Img != null)
			{
				Car.ImgUrl = AddFile.UploadImage(carViewModel.Img);
			}


			carList.AddCar(Car);
			return RedirectToAction("Index");
		}
		public IActionResult CarDetails(int Num)
		{
			return View(carList.GetCarByNum(Num));
		}


		public IActionResult UpdateCar(int Num)
		{
			return View(carList.GetCarByNum(Num));
		}

		[HttpPost]
		public IActionResult UpdateCar(CarViewModel carViewModel)
		{
			var Car = new Car()
			{ Color = carViewModel.Color, Manufacture = carViewModel.Manufacture, Model = carViewModel.Model, Num = carViewModel.Num };

			if (carViewModel.Img != null)
			{
				Car.ImgUrl = AddFile.UploadImage(carViewModel.Img);
			}


			carList.UpdateCar(Car);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteCar(int Num)
		{
			var selected = carList.GetCarByNum(Num);
			if (selected != null)
			{
				carList.DeleteCar(Num);
				return RedirectToAction("Index");
			}
			return NotFound();
		}

	}
}
