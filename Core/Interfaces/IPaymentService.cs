using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
         Task<CustomerBasket> CreateorUpdatePaymentIntent(string basketId);
         Task<Order> UpdateOrderPaymentSucceeded(string paymentIntetnId);
         Task<Order> UpdateOrderPaymentFailed(string paymentIntetnId);
    }
}