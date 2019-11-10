using Billing.Messages.Events;
using Shipping.Messages.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BusinessCustomers.ShippingArranged
{
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
