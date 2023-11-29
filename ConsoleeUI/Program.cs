using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleeUI
{
     class Program
    {
        static void Main(string[] args)
        {
            //CarGetAll();

            //BrandGetAll();

            //ColorGetAll();

            //CarAdd();

            //BrandAdd();

            //ColorAdd();

            //CarGetById();

            CarDelete();

        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                carManager.Delete(car);
            }
        }

        //private static void CarGetById()
        //{
        //    try
        //    {
        //        CarManager carManager = new CarManager(new EfCarDal());
        //        var car = carManager.GetById(1);
        //        if(car==null)
        //        {
        //            Console.WriteLine("liste boş");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }


        //}

        //private static void ColorAdd()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Color color = new Color();
        //    color.ColorName = "red";
        //    color.ColorId = 1;

        //    colorManager.Add(color);
        //}

        //private static void BrandAdd()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    Brand brand = new Brand();
        //    brand.BrandName = "Volkswagen";
        //    brand.BrandId = 1;

        //    brandManager.Add(brand);
        //}

        //private static void CarAdd()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Car car1 = new Car();
        //    car1.BrandId = 2;
        //    car1.ColorId = 1;
        //    car1.CarName = "Bmw";
        //    car1.DailyPrice = 10560;
        //    car1.Description = "Description";

        //    carManager.Add(car1);
        //}

        //private static void ColorGetAll()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.ColorName);
        //    }
        //}

        //private static void BrandGetAll()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}

        //private static void CarGetAll()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.CarName);
        //    }
        //}
    }
}
