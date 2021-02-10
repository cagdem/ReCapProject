using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        public InMemoryProductDal()
        {
            //fake veri tabani
            _cars = new List<Car> {
            new Car { Id = 1, BrandId = 1, ColorId = "Red", DailyPrice = 100000, Description = "spor", ModelYear = 2020 },
            new Car { Id = 2, BrandId = 2, ColorId = "White", DailyPrice = 70000, Description = "coupe", ModelYear = 2018 },
            new Car { Id = 3, BrandId = 1, ColorId = "Black", DailyPrice = 110000, Description = "sedan", ModelYear = 2010 },
            new Car { Id = 4, BrandId = 3, ColorId = "Green", DailyPrice = 80000, Description = "truck", ModelYear = 2021 },
            new Car { Id = 5, BrandId = 4, ColorId = "Blue", DailyPrice = 55000, Description = "sedan", ModelYear = 2019 },
            };

            _brands = new List<Brand>
            {
                new Brand{BrandId = 1, BrandName="BMW"},
                new Brand{BrandId = 2, BrandName="Opel"},
                new Brand{BrandId = 3, BrandName="Toyota"},
                new Brand{BrandId = 4, BrandName="Fiat"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

        }
    }
}
