using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Messages.Events
{
    public class OrderCreated
    {

        public string OrderId { get; set; }

        public string UserId { get; set; }

        public string[] ProductIds { get; set; }

        public string ShippingTypeId { get; set; }

        public DateTime TimeStamp { get; set; }

        public double Amount { get; set; }
    }

    public class OrderCreated_V2 : OrderCreated
    {
        public string AddressId { get; set; }
    }
}
