using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Messages.Commands
{
    public class RecordPaymentAttempt
    {
        public string OrderId { get; set; }

        public PaymentStatus Status { get; set; }
    }

    public enum PaymentStatus
    {
        Accepted,
        Rejected
    }
}
