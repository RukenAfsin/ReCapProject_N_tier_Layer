using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleeUI
{
     class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
           foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
                Console.WriteLine("Hello, World!");
        }
    }
}
