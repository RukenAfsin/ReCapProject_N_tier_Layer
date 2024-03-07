using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarImageDetailDto:IDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public string BrandName { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
    }
}
