using NServiceBus;
using Sales.Messages.Commands;
using System;

namespace Sales.Orders.OrderCreated
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IBus Bus { get; set; }// Dependency injected by NServiceBus

        public void Handle(PlaceOrder message)
        {
           Console.WriteLine($"$Order for Products : {message.ProductIds}" +
                             $" with Shipping Type {message.ShippingTypeId}" +
                             $"made by user {message.UserId} {string.Join(",",message.ProductIds)}");
        }
    }
}
