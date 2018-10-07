using NServiceBus;
using Sales.Messages.Commands;
using System;
using System.Data;

namespace Sales.Orders.OrderCreated
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus Bus { get; set; } // Dependency injected by NServiceBus

        public void Handle(PlaceOrder message)
        {
            Console.WriteLine($"$Order for Products : {message.ProductIds}" +
                              $" with Shipping Type {message.ShippingTypeId}" +
                              $"made by user {message.UserId} {string.Join(",", message.ProductIds)}");


            var orderId = Database.SaveOrder(
                message.ProductIds, message.UserId, message.ShippingTypeId);

            Console.WriteLine($"Created Order for Products : {message.ProductIds}" +
                              $" with Shipping Type {message.ShippingTypeId}" +
                              $"made by user {message.UserId} {string.Join(",", message.ProductIds)}");

            var orderCreatedEvent = new Sales.Messages.Events.OrderCreated
            {
                OrderId = orderId,
                UserId = message.UserId,
                ProductIds = message.ProductIds,
                ShippingTypeId = message.ShippingTypeId,
                TimeStamp = DateTime.Now,
                Amount = CalculateCostOf(message.ProductIds)
            };

            Bus.Publish(orderCreatedEvent);
        }

        private double CalculateCostOf(string[] productIds)
        {
            //db lookup etc
            return 1000;
        }
    }
}

    

