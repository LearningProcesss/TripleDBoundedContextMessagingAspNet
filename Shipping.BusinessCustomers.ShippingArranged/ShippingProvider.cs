using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BusinessCustomers.ShippingArranged
{
    public static class ShippingProvider
    {
        public static ShippingConfirmation ArrangeShippingFor(string address, string referenceCode)
        {
            return new ShippingConfirmation { Status = ShippingStatus.Success };
        }
    }

    public class ShippingConfirmation
    {
        public ShippingStatus Status { get; set; }
    }

    public enum ShippingStatus
    {
        Success,
        Failure
    }
}
