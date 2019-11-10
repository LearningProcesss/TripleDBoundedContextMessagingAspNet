using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Messages.Commands
{
    public class ShippingOrder
    {
        public string UserId { get; set; }

        public string OrderId { get; set; }

        public string ShippingTypeId { get; set; }

        public string AddressId { get; set; }
    }
}
