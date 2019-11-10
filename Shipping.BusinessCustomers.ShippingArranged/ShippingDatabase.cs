using Shipping.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BusinessCustomers.ShippingArranged
{
    public static class ShippingDatabase
    {
        private static List<ShippingOrder> Orders = new List<ShippingOrder>();

        public static void AddOrderDetails(ShippingOrder order)
        {
            Orders.Add(order);
        }

        public static string GetCustomerAddress(string orderId)
        {
            var order = Orders
                        .Single(o => o.OrderId == orderId);

            return string.Format(
                "{0}, Address ID: {1}",
                order.UserId, order.AddressId
            );
        }
    }
}
