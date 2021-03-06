using System;
using System.Collections.Generic;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress, 
        DeliveryMethod deliveryMethod, decimal subtotal,string paymentIntendId)
        {
            this.BuyerEmail = buyerEmail;
            this.ShipToAddress = shipToAddress;
            this.DeliveryMethod = deliveryMethod;
            this.Subtotal = subtotal;
            this.OrderItems = orderItems;
            PaymentIntendId=paymentIntendId;

        }
        public string BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public Address ShipToAddress { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public decimal Subtotal { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public string PaymentIntendId { get; set; }

        public decimal GetTotal()
        {

            return Subtotal + DeliveryMethod.Price;
        }








    }
}