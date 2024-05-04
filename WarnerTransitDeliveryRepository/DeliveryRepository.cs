using System;
using System.Collections.Generic;
using System.Linq;

namespace WarnerTransitDelivery // Corrected the namespace
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
            return _deliveries.ToList(); // Return a copy to prevent modifications
        }

        public List<Delivery> GetEnRouteDeliveries()
        {
            return _deliveries.Where(d => d.Status == DeliveryStatus.EnRoute).ToList();
        }

        public List<Delivery> GetCompletedDeliveries()
        {
            return _deliveries.Where(d => d.Status == DeliveryStatus.Complete).ToList();
        }

        public Delivery GetDeliveryByItemNumber(string itemNumber)
        {
            return _deliveries.FirstOrDefault(d => d.ItemNumber == itemNumber);
        }

        public void UpdateDeliveryStatus(string itemNumber, WarnerTransitDelivery.ClassLibrary.DeliveryStatus newStatus)
        {
            var delivery = _deliveries.FirstOrDefault(d => d.ItemNumber == itemNumber);
            if (delivery != null)
            {
                delivery.Status = newStatus;
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
    }
}
