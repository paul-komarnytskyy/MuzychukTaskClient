using System;

namespace Core.Model.DTO
{
    public class Order
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateProcessed { get; set; }

        public DateTime DateDelivered { get; set; }
    }
}
