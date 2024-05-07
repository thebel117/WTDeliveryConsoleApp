using System;
using System.Collections.Generic;
using System.Linq;

namespace WTDelivery
{
    // Class definition for Delivery within the WarnerTransitDelivery namespace
    public class Delivery 
    {
        // Properties for Delivery class
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? DeliveryStatus { get; set; }
        public string? ItemNumber { get; set; }
        public int ItemQuantity { get; set; }
        public double CustomerID { get; set; }
        public int DeliveryId { get; set; }

        // Constructor for Delivery class
        public Delivery(int customerId, string itemNumber, int itemQuantity, DateTime orderDate, DateTime deliveryDate, string deliveryStatus, int deliveryId)
        {
            // Assigning values to properties within the constructor
            CustomerID = customerId;
            ItemNumber = itemNumber;
            ItemQuantity = itemQuantity;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            DeliveryStatus = deliveryStatus;
            DeliveryId = deliveryId;
        }
    }

    // Enum definition for DeliveryStatus within the same WarnerTransitDelivery namespace
    public enum DeliveryStatus
    {
        Scheduled,
        EnRoute,
        Complete,
        Canceled
    }
};
