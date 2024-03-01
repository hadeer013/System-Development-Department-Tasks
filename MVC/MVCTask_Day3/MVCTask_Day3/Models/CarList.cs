using Microsoft.AspNetCore.Components.Forms;
using MVCTask_Day3.Utilities;
using System;
using System.Runtime.ConstrainedExecution;

namespace MVCTask_Day3.Models
{
    public  class CarList : List<Car>
    {
        public CarList()
        {
            CarListAddition.InitializeCarList(this);
        }

        public List<Car> GetAlllCars()
        {
            return this;
        }
        public int AddCar(Car car)
        {
            this.Add(car);
            return 1;
        }
        public Car GetCarByNum(int Num)
        {
            return this.Where(c=>c.Num==Num).FirstOrDefault();
        }
        public int UpdateCar(Car car)
        {
            var edited = this.Where(c => c.Num == car.Num).FirstOrDefault();
            if(edited != null)
            {
                edited.Color = car.Color;
                edited.Model = car.Model;
                edited.Manufacture=car.Manufacture;
				edited.ImgUrl = !string.IsNullOrEmpty(car.ImgUrl) ? car.ImgUrl : edited.ImgUrl;
				return 1;
            }
            return 0;
        }
        public int DeleteCar(int carNum)
        {
            var deleted = this.Where(c => c.Num == carNum).FirstOrDefault();
            if (deleted != null)
            {
                this.Remove(deleted);
                return 1;
            }
            return 0;
        }
    }
}
