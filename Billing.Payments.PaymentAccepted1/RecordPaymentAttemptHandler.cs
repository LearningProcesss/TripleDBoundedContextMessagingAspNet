using Billing.Messages.Commands;
using Billing.Messages.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Payments.PaymentAccepted1
{
    public class RecordPaymentAttemptHandler : IHandleMessages<RecordPaymentAttempt>
    {
        public IBus bus { get; set; }

        public void Handle(RecordPaymentAttempt message)
        {
            Console.WriteLine(@"RecordPaymentAttemptHandler->Handle->RecordPaymentAttempt OrderId: {0}", message.OrderId);

            if (message.Status == PaymentStatus.Accepted)
            {
                bus.Publish(new PaymentAccepted() { OrderId = message.OrderId });
            }
            else
            {
                //pub a payment rejected event 
            }
        }
    }
}
