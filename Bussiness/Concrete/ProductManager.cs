using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
            _productDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _productDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _productDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _productDal.Get(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _productDal.GetProductDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _productDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _productDal.GetAll(c=>c.ColorId == id);
        }

        public void Update(Car car)
        {
            _productDal.Update(car);
        }
    }
}
