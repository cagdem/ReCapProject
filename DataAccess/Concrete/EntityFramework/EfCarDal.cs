using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, InMemoryDbContext>, IProductDal
    {
        public List<CarDetailDto> GetProductDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (InMemoryDbContext context = new InMemoryDbContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join b in context.Brands
                             on p.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = p.Id,
                                 BrandName = b.BrandName,
                                 CarName = p.CarName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();

            }
        }
    }
}
