using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTDelivery;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateDelivery_AddsDeliveryToList()
        {
            // Arrange
            var deliveryRepository = new DeliveryRepository();
            var delivery = new Delivery(123, "ABC123", 2, DateTime.Now, DateTime.Now, "Scheduled", 1);

            // Act
            deliveryRepository.CreateDelivery(delivery);
            var deliveries = deliveryRepository.GetAllDeliveries();

            // Assert
            Assert.IsTrue(deliveries.Any(d => d.Equals(delivery)));
        }

        [TestMethod]
        public void GetEnRouteDeliveries_ReturnsEnRouteDeliveries()
        {
            // Arrange
            var deliveryRepository = new DeliveryRepository();
            var enRouteDelivery = new Delivery(123, "ABC123", 2, DateTime.Now, DateTime.Now, "EnRoute", 1);
            var scheduledDelivery = new Delivery(456, "DEF456", 1, DateTime.Now, DateTime.Now, "Scheduled", 2);
            deliveryRepository.CreateDelivery(enRouteDelivery);
            deliveryRepository.CreateDelivery(scheduledDelivery);

            // Act
            var enRouteDeliveries = deliveryRepository.GetEnRouteDeliveries();

            // Assert
            Assert.IsTrue(enRouteDeliveries.Any(d => d.Equals(enRouteDelivery)));
            Assert.IsFalse(enRouteDeliveries.Any(d => d.Equals(scheduledDelivery)));
        }
    }
}
