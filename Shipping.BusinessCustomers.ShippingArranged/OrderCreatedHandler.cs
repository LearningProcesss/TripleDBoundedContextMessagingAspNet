using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Sales.Messages.Events;
using Billing.Messages.Events;
using Shipping.Messages.Commands;
using Shipping.Messages.Events;

namespace Shipping.BusinessCustomers.ShippingArranged
{
    public class OrderCreatedHandler : IHandleMessages<OrderCreated>
    {
        public IBus Bus { get; set; }

        // updated Handle accepting a V2
        public void Handle(OrderCreated message)
        {
            //Console.WriteLine(
            //    "Shipping BC storing: Order: {0} User: {1} Shipping Type: {2}",
            //    message.OrderId, message.UserId, message.ShippingTypeId, message.AddressId
            //);
            Console.WriteLine(
                "Shipping BC storing: Order: {0} User: {1} Shipping Type: {2}",
                message.OrderId, message.UserId, message.ShippingTypeId
            );
            var order = new ShippingOrder
            {
                UserId = message.UserId,
                OrderId = message.OrderId,
                //AddressId = message.AddressId,
                ShippingTypeId = message.ShippingTypeId
            };
            //ShippingDatabase.AddOrderDetails(order);
            //DB
        }

        public class PaymentAcceptedHandler : IHandleMessages<PaymentAccepted>
        {
            // dependency injected by NServiceBus
            public IBus Bus { get; set; }

            public void Handle(PaymentAccepted message)
            {
                var address = ShippingDatabase.GetCustomerAddress(message.OrderId);
                var confirmation = ShippingProvider.ArrangeShippingFor(address, message.OrderId);
                if (confirmation.Status == ShippingStatus.Success)
                {
                    var evnt = new ShippingArrangeds
                    {
                        OrderId = message.OrderId
                    };
                    Bus.Publish(evnt);
                    Console.WriteLine(
                        "Shipping BC arranged shipping for Order: {0}",
                        message.OrderId, address
                    );
                }
                else
                {
                    // .. notify failed shipping instead
                }
            }
        }



    }
}
