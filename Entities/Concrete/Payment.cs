using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public long CardNo { get; set; }
        public int ExpiryMonth{ get; set; }
        public int ExpiryYear { get; set; }
        public int CVV { get; set; }
    }
}
