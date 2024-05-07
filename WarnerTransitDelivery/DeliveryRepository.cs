using System;
using System.Collections.Generic;
using System.Linq;
using WTDelivery;

namespace WTDelivery
{
    public class DeliveryRepository
    {
        private readonly List<Delivery> _deliveries = new List<Delivery>();

        public void CreateDelivery(Delivery delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException(nameof(delivery));
            _deliveries.Add(delivery);
        }

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return _deliveries.ToList(); // Return a copy to prevent changes
        }

public List<Delivery> GetEnRouteDeliveries()
{
    return _deliveries.Where(d => d.DeliveryStatus == DeliveryStatus.EnRoute.ToString()).ToList();
}


        public List<Delivery> GetCompletedDeliveries()
        {
            return _deliveries.Where(d => d.DeliveryStatus == DeliveryStatus.Complete.ToString()).ToList();
        }

        public Delivery GetDeliveryByItemNumber(string itemNumber)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _deliveries.FirstOrDefault(d => d.ItemNumber == itemNumber);
#pragma warning restore CS8603 // Possible null reference return.
        }

public void UpdateDeliveryStatus(string itemNumber, DeliveryStatus newStatus)
{
    var delivery = _deliveries.FirstOrDefault(d => d.ItemNumber == itemNumber);
    if (delivery != null)
    {
        // Checks if the new status is a valid enum value
        if (Enum.IsDefined(typeof(DeliveryStatus), newStatus))
        {
            delivery.DeliveryStatus = newStatus.ToString(); // Converts enum to a string
        }
        else
        {
            throw new ArgumentException("Invalid delivery status specified.", nameof(newStatus));
        }
    }
}
        public void CancelDelivery(string itemNumber)
        {
            var delivery = _deliveries.FirstOrDefault(d => d.ItemNumber == itemNumber);
            if (delivery != null)
            {
                _deliveries.Remove(delivery);
            }
        }

        public bool DeleteDelivery(int deliveryId)
        {
    // Find the delivery with the specified ID
            var delivery = _deliveries.FirstOrDefault(d => d.DeliveryId == deliveryId);
            if (delivery != null)
                {
                 // for remove the delivery from the list
                _deliveries.Remove(delivery);
                return true; // Indicates a deletion worked
                }
        return false; // Indicates that a delivery was not found
        }

    }
};
