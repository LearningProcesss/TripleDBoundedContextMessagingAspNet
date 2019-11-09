using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using Sales.Messages.Commands;
using Sales.Messages.Events;

namespace Sales.Orders.OrderCreated1
{
    class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus bus { get; set; }

        public void Handle(PlaceOrder message)
        {
            Console.WriteLine(@"PlaceOrderHandler->Handle->PlaceOrder UserId: {0}", message.UserId);

            bus.Publish(new OrderCreated()
            {
                OrderId = "fake id database"
            });
        }
    }
}
