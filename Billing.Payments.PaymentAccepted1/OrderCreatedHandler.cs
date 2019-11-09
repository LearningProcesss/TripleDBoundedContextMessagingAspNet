using NServiceBus;
using Sales.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.Messages.Commands;

namespace Billing.Payments.PaymentAccepted1
{
    public class OrderCreatedHandler : IHandleMessages<OrderCreated>
    {
        public IBus bus { get; set; }

        public void Handle(OrderCreated message)
        {
            Console.WriteLine(@"OrderCreatedHandler->Handle->OrderCreated OrderId: {0}", message.OrderId);

            //Db operation

            // Send only to the local bus
            bus.SendLocal(new RecordPaymentAttempt() { OrderId = message.OrderId, Status = PaymentStatus.Accepted });
        }
    }
}
