namespace Core.Entities.OrderAggregate
{
    public class DeliveryMethod: BaseEntity
    {
        public string ShortName { get; set; }


        public string DeliverytTime { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        
    }
}