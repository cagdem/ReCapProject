using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            BrandTest();
            ColorTest();
        }


        private static void ProductTest()
        {
            Car car1 = new Car() { Id = 6,CarName="Test0", BrandId = 2, ColorId = 1, DailyPrice = 50000, ModelYear = 1995 };
            ProductManager productManager = new ProductManager(new EfCarDal());

            foreach (var car in productManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);

            }
            Console.WriteLine("-------");

            productManager.Add(car1);

            foreach (var car in productManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("-------");

            Console.WriteLine(productManager.GetById(6).Data.CarName +" / "+ productManager.GetById(6).Data.ColorId);
            productManager.Update(new Car() { Id = 6,CarName="Test1", BrandId = 3, ColorId = 2, DailyPrice = 50000, ModelYear = 1995 });
            Console.WriteLine(productManager.GetById(6).Data.CarName +" / "+ productManager.GetById(6).Data.ColorId);
            productManager.Delete(car1);
            Console.WriteLine("-------");

            foreach (var car in productManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("-------");

            foreach (var car in productManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
            Console.WriteLine("-------");

        }
        private static void BrandTest()
        {
            Brand brand1 = new Brand() { BrandId = 5, BrandName = "Mercedes" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);

            }
            Console.WriteLine("-------");

            brandManager.Add(brand1);

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine("-------");

            Console.WriteLine(brandManager.GetById(5).Data.BrandId + " / " + brandManager.GetById(5).Data.BrandName);
            brandManager.Update(new Brand() { BrandId = 5, BrandName = "Tesla" });
            Console.WriteLine(brandManager.GetById(5).Data.BrandId + " / " + brandManager.GetById(5).Data.BrandName);
            brandManager.Delete(brand1);
            Console.WriteLine("-------");

            foreach (var car in brandManager.GetAll().Data)
            {
                Console.WriteLine(car.BrandName);
            }
            Console.WriteLine("-------");

        }

        private static void ColorTest()
        {
            Color color1 = new Color() { ColorId = 6, ColorName = "Purple" };
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var brand in colorManager.GetAll().Data)
            {
                Console.WriteLine(brand.ColorName);

            }
            Console.WriteLine("-------");

            colorManager.Add(color1);

            foreach (var brand in colorManager.GetAll().Data)
            {
                Console.WriteLine(brand.ColorName);
            }
            Console.WriteLine("-------");

            Console.WriteLine(colorManager.GetById(6).Data.ColorId + " / " + colorManager.GetById(6).Data.ColorName);
            colorManager.Update(new Color() { ColorId = 6, ColorName = "Yellow" });
            Console.WriteLine(colorManager.GetById(6).Data.ColorId + " / " + colorManager.GetById(6).Data.ColorName);
            colorManager.Delete(color1);
            Console.WriteLine("-------");

            foreach (var car in colorManager.GetAll().Data)
            {
                Console.WriteLine(car.ColorName);
            }
            Console.WriteLine("-------");

        }
    }
}
