using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BrandDetailDto:IDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CarId { get; set; }

        public int Year { get; set; }
    }
}
