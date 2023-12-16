using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentACarContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails()
        {
            using(RentACarContext context = new RentACarContext())

            {

                var result = from b in context.Brand
                             join c in context.Car
                             on b.BrandId equals c.BrandId
                             select new BrandDetailDto
                             {
                                 BrandId = b.BrandId,
                                 BrandName=b.BrandName,
                                 Year = c.Year

                             }; 
                return result.ToList();
        
            }
        }
    }
}
