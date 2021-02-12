using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfCarDal());

            foreach (var car in productManager.GetAll())
            {
                Console.WriteLine(car.Id);
            }

        }
    }
}
