using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Messages.Events
{
    public class PaymentAccepted
    {
        public string OrderId { get; set; }
    }
}
