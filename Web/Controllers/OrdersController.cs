using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Place(string userId, string productIds, string shippingTypeId)
        {
            var placeOrderCommand = new Sales.Messages.Commands.PlaceOrder()
            {
                UserId = userId,
                ProductIds = productIds.Split(','),
                ShippingTypeId = shippingTypeId,
                TimeStamp = DateTime.Now
            };

            MvcApplication.Bus.Send("Sales.Orders.OrderCreated", placeOrderCommand);

            return Content("Your Order has been placed.");
        }
    }
}