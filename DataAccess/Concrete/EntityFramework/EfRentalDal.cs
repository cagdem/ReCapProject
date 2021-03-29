using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, InMemoryDbContext>, IRentalDal
    {
        public List<RentalDto> GetRentalDetails(Expression<Func<RentalDto, bool>> filter=null)
        {
            using (InMemoryDbContext context = new InMemoryDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cus in context.Customers
                             on r.CustomerId equals cus.Id
                             join u in context.Users
                             on cus.UserId equals u.Id
                             select new RentalDto
                             {
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };

                return filter == null
                 ? result.ToList()
                 : result.Where(filter).ToList();

            }
        }

    }
}
