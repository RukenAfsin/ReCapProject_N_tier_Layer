﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int RentalId { get; set; }
        public string? ImagePath { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public DateTime Date { get; set; }
    }
}
