using MVCTask_Day3.Models;

namespace MVCTask_Day3.Utilities
{
    public class CarListAddition
    {
        public static void InitializeCarList(CarList cars)
        {
            cars.AddCar(new Car() { Num = 10, Color = "RED", Manufacture = "Egypt", Model = "Abc",ImgUrl="1.jpg" });
            cars.AddCar(new Car() { Num = 20, Color = "RED", Manufacture = "Egypt", Model = "Abc", ImgUrl = "2.jpg" });
            cars.AddCar(new Car() { Num = 30, Color = "RED", Manufacture = "Egypt", Model = "Abc", ImgUrl = "3.jpg" });
            cars.AddCar(new Car() { Num = 40, Color = "RED", Manufacture = "Egypt", Model = "Abc", ImgUrl = "4.jpg" });
            cars.AddCar(new Car() { Num = 50, Color = "RED", Manufacture = "Egypt", Model = "Abc", ImgUrl = "5.jpg" });
            cars.AddCar(new Car() { Num = 60, Color = "RED", Manufacture = "Egypt", Model = "Abc", ImgUrl = "6.jpg" });
        }
    }
}
