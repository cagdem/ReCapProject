using Bussiness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
        public List<Car> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _productDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _productDal.GetAll(c=>c.ColorId == id);
        }
    }
}
