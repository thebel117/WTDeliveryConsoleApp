using System;
using WarnerTransitDelivery;
// using WarnerTransitDeliveryRepository;

namespace WarnerTransitConsole
{
    public class ProgramUI
    {
    private DeliveryRepository _deliveryRepository = new();        

        public void Run()
        {
            Console.WriteLine("Welcome to the Order Tracking System");

            while (true)
            {
                Console.WriteLine("\nPlease select an option below:");
                Console.WriteLine("1. Add New Delivery");
                Console.WriteLine("2. View All Deliveries");
                Console.WriteLine("3. List Completed Deliveries");
                Console.WriteLine("4. Update A Delivery's Status");
                Console.WriteLine("5. Cancel A Delivery");
                Console.WriteLine("6. Exit Tracking System");

                Console.Write("\nEnter choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateDelivery();
                        break;
                    case "2":
                        GetAllDeliveries();
                        break;
                    case "3":
                        GetCompletedDeliveries();
                        break;
                    case "4":
                        GetEnRouteDeliveries();
                        break;
                    case "5":
                        UpdateDeliveryStatus();
                        break;
                    case "6":
                        CancelDelivery();
                        break;
                    case "7":
                        Console.WriteLine("Exiting Tracking System...");
                        return;
                    default:
                        Console.WriteLine("Please try again.");
                        break;
                }
            }
        }

        private void GetEnRouteDeliveries()
        {
            throw new NotImplementedException();
        }

        private void CreateDelivery()
        {
            Console.WriteLine("Please enter new delivery's details:");

            // Get delivery details from user input
            DateTime? orderDate = null;
            DateTime deliveryDate;
            int itemNumber;
            int itemQuantity;
            int customerId;
            DeliveryStatus status;

            DateTime tempDate;
            while (!DateTime.TryParse(Console.ReadLine(), out tempDate))
            {
                Console.WriteLine("Invalid date format. Please enter order date (DD-MM-YY):");
            }
            orderDate = tempDate;

            while (!DateTime.TryParse(Console.ReadLine(), out deliveryDate))
            {
                Console.WriteLine("Invalid date format. Please enter delivery date (DD-MM-YY):");
            }

            while (!int.TryParse(Console.ReadLine(), out itemNumber))
            {
                Console.WriteLine("Invalid input. Please enter item number:");
            }

            while (!int.TryParse(Console.ReadLine(), out itemQuantity))
            {
                Console.WriteLine("Invalid input. Please enter item quantity:");
            }

            while (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Invalid input. Please enter customer ID:");
            }

            while (!Enum.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Invalid status. Please enter delivery status (Scheduled/EnRoute/Complete/Canceled):");
            }

            Delivery newDelivery = new Delivery
            {
                OrderDate = orderDate.Value,
                DeliveryDate = deliveryDate,
                ItemNumber = itemNumber.ToString(),
                ItemQuantity = itemQuantity,
                CustomerId = customerId.ToString(),
                Status = status
            };

            _deliveryRepository.CreateDelivery(newDelivery);

            Console.WriteLine("Delivery added successfully.");
        }

        private void GetAllDeliveries()
        {
            var allDeliveries = _deliveryRepository.GetAllDeliveries();
            Console.WriteLine("\nAll Deliveries:");

            foreach (var delivery in allDeliveries)
            {
                Console.WriteLine($"Delivery ID: {delivery.Id}, Status: {delivery.Status}");
            }
        }

        private void GetCompletedDeliveries()
        {
            var completedDeliveries = _deliveryRepository.GetCompletedDeliveries();
            Console.WriteLine("\nCompleted Deliveries:");

            foreach (var delivery in completedDeliveries)
            {
                Console.WriteLine($"Delivery ID: {delivery.Id}, Status: {delivery.Status}");
            }
        }

        private void UpdateDeliveryStatus()
        {
            Console.WriteLine("Enter the ID of the delivery you want to update:");
            int deliveryId;

            while (!int.TryParse(Console.ReadLine(), out deliveryId))
            {
                Console.WriteLine("Invalid input. Please enter delivery ID:");
            }

            Console.WriteLine("Enter the new status for the delivery (Scheduled/EnRoute/Complete/Canceled):");
            OrderStatus newStatus;

            while (!Enum.TryParse(Console.ReadLine(), out newStatus))
            {
                Console.WriteLine("Invalid status. Please enter delivery status (Scheduled/EnRoute/Complete/Canceled):");
            }

            if (_deliveryRepository.UpdateDeliveryStatus(deliveryId, newStatus))
            {
                Console.WriteLine("Delivery status updated successfully.");
            }
            else
            {
                Console.WriteLine("Delivery not found or update failed.");
            }
        }

        private void CancelDelivery()
        {
            Console.WriteLine("Enter the ID of the delivery you want to cancel:");
            int deliveryId;

            while (!int.TryParse(Console.ReadLine(), out deliveryId))
            {
                Console.WriteLine("Invalid input. Please enter delivery ID:");
            }

            if (_deliveryRepository.DeleteDelivery(deliveryId))
            {
                Console.WriteLine("Delivery canceled successfully.");
            }
            else
            {
                Console.WriteLine("Delivery not found or cancellation failed.");
            }
        }
    }
}
