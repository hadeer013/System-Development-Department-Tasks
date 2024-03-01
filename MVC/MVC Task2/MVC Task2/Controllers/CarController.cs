using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;
using MVC_Task2.Utilities;
using MVC_Task2.ViewModels;
using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace MVC_Task2.Controllers
{
    public class CarController : Controller
    {
       static CarList carList=new CarList();

        public IActionResult Index()
        {
            ViewData["AllCars"] = carList.GetAlllCars();
            return View();
        }

		public IActionResult CreateCar()
		{
			return View();
		}
		public IActionResult SaveCreateCar(CarViewModel carViewModel)
		{
			var Car = new Car()
			{ Color = carViewModel.Color, Manufacture = carViewModel.Manufacture, Model = carViewModel.Model, Num = carViewModel.Num };

			if(carViewModel.Img!=null) 
			{
				Car.ImgUrl = AddFile.UploadImage(carViewModel.Img);
			}


			carList.AddCar(Car);
			return RedirectToAction("Index");
		}
		public IActionResult CarDetails(int Num)
        {
			ViewData["SelectedCar"] = carList.GetCarByNum(Num);
            return View();
		}
        

        public IActionResult UpdateCar(int Num)
        {
			ViewData["SelectedCar"] = carList.GetCarByNum(Num);
			return View();
		}

		public IActionResult SaveUpdateCar(CarViewModel carViewModel)
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
