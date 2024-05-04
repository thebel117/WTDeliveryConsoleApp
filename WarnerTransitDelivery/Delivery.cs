using System;

namespace WarnerTransitDelivery
{
    public class Delivery
    {
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DeliveryStatus Status { get; set; }
        public string? ItemNumber { get; set; }
        public int ItemQuantity { get; set; }
        public double CustomerID { get; set; }
    }

    public enum DeliveryStatus
    {
        Scheduled,
        EnRoute,
        Complete,
        Canceled
    }
}