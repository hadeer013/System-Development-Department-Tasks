using MVC_Task2.Models;

namespace MVC_Task2.Utilities
{
    public class CarListAddition
    {
        public static void InitializeCarList(CarList cars)
        {
            cars.AddCar(new Car() { Num = 10, Color = "Red", Manufacture = "Egypt", Model = "A",ImgUrl="1.jpg" });
            cars.AddCar(new Car() { Num = 20, Color = "Blue", Manufacture = "china", Model = "B", ImgUrl = "2.jpg" });
            cars.AddCar(new Car() { Num = 30, Color = "Green", Manufacture = "Germany", Model = "C", ImgUrl = "3.jpg" });
            cars.AddCar(new Car() { Num = 40, Color = "Black", Manufacture = "USA", Model = "D", ImgUrl = "4.jpg" });
            cars.AddCar(new Car() { Num = 50, Color = "Pink", Manufacture = "Canada", Model = "E", ImgUrl = "5.jpg" });
            cars.AddCar(new Car() { Num = 60, Color = "Orange", Manufacture = "Morocoo", Model = "F", ImgUrl = "6.jpg" });
        }
    }
}
