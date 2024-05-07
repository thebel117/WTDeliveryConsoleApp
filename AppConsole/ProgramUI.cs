using System;
using WTDelivery;
// using WarnerTransitDeliveryRepository;

namespace WarnerTransitConsole
{
    public class ProgramUI
    {
        private DeliveryRepository _deliveryRepository = new();

        public void Run()
        {

            Console.WriteLine("Welcome to the Warner Transit Order Tracking System");

            // Seed data for deliveries
            _deliveryRepository.CreateDelivery(new Delivery(
                1,
                "1001",
                5,
                new DateTime(2024, 05, 07),
                new DateTime(2024, 05, 15),
                DeliveryStatus.Scheduled.ToString(),
                12345
            ));

            _deliveryRepository.CreateDelivery(new Delivery(
                2,
                "1002",
                3,
                new DateTime(2024, 05, 08),
                new DateTime(2024, 05, 16),
                DeliveryStatus.EnRoute.ToString(),
                54321
            ));

            _deliveryRepository.CreateDelivery(new Delivery(
                3,
                "1003",
                7,
                new DateTime(2024, 05, 09),
                new DateTime(2024, 05, 17),
                DeliveryStatus.Complete.ToString(),
                98765
            ));

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
                        Console.WriteLine("Enter the item number of the delivery to update:");
                        string itemNumber = Console.ReadLine();
                        Console.WriteLine("Enter the new status (Scheduled, EnRoute, Complete, Canceled):");
                        if (Enum.TryParse(Console.ReadLine(), out DeliveryStatus newStatus))
                        {
                            bool updateResult = UpdateDeliveryStatus(itemNumber, newStatus);
                            if (updateResult)
                                Console.WriteLine("Delivery status updated successfully.");
                            else
                                Console.WriteLine("Failed to update delivery status.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid status entered.");
                        }
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

    // Get delivery details from user 
    DateTime? orderDate = null;
    DateTime deliveryDate;
    int itemNumber;
    int itemQuantity;
    int customerId;
    DeliveryStatus status;

    DateTime tempDate; // Declare tempDate here

    // Prompt and validate order date
    Console.WriteLine("Please enter order date (DD-MM-YY):");
    while (!DateTime.TryParse(Console.ReadLine(), out tempDate))
    {
        Console.WriteLine("Invalid date format. Please enter order date (DD-MM-YY):");
    }
    orderDate = tempDate;

    // Prompt and validate delivery date
    Console.WriteLine("Please enter delivery date (DD-MM-YY):");
    while (!DateTime.TryParse(Console.ReadLine(), out deliveryDate))
    {
        Console.WriteLine("Invalid date format. Please enter delivery date (DD-MM-YY):");
    }

    // Prompt and validate item number
    Console.WriteLine("Please enter item number:");
    while (!int.TryParse(Console.ReadLine(), out itemNumber))
    {
        Console.WriteLine("Invalid input. Please enter item number:");
    }

    // Prompt and validate item quantity
    Console.WriteLine("Please enter item quantity:");
    while (!int.TryParse(Console.ReadLine(), out itemQuantity))
    {
        Console.WriteLine("Invalid input. Please enter item quantity:");
    }

    // Prompt and validate customer ID
    Console.WriteLine("Please enter customer ID:");
    while (!int.TryParse(Console.ReadLine(), out customerId))
    {
        Console.WriteLine("Invalid input. Please enter customer ID:");
    }

    // Prompt and validate delivery status
    Console.WriteLine("Please enter delivery status (Scheduled/EnRoute/Complete/Canceled):");
    while (!Enum.TryParse(Console.ReadLine(), out status))
    {
        Console.WriteLine("Invalid status. Please enter delivery status (Scheduled/EnRoute/Complete/Canceled):");
    }

    int deliveryId = GenerateDeliveryId(); // Assuming this method generates or fetches an ID

    // Create a new Delivery object
    Delivery newDelivery = new Delivery(
        deliveryId,                 // Passes deliveryId
        itemNumber.ToString(),      // Converts itemNumber to string
        itemQuantity,               // Passes itemQuantity
        orderDate.Value,            // Passes orderDate directly (ensure it's not null)
        deliveryDate,               // Passes deliveryDate directly
        status.ToString(),          // Converts status to a string
        customerId                  // Passes thee customerId
    );

    _deliveryRepository.CreateDelivery(newDelivery);

    Console.WriteLine("Delivery added successfully.");
}


private void GetAllDeliveries()
    {
        var allDeliveries = _deliveryRepository.GetAllDeliveries();
        Console.WriteLine("\nAll Deliveries:");

        foreach (var delivery in allDeliveries)
            {
                Console.WriteLine($"Delivery ID: {delivery.CustomerID}, Status: {delivery.DeliveryStatus}");
            }
    }

private void GetCompletedDeliveries()
    {
        var completedDeliveries = _deliveryRepository.GetCompletedDeliveries();
        Console.WriteLine("\nCompleted Deliveries:");

            foreach (var delivery in completedDeliveries)
            {
                Console.WriteLine($"Delivery ID: {delivery.CustomerID}, Status: {delivery.DeliveryStatus}");
            }
    }

public bool UpdateDeliveryStatus(string itemNumber, DeliveryStatus newStatus)
    {
        var delivery = _deliveryRepository.GetDeliveryByItemNumber(itemNumber);
        if (delivery != null)
            {
                delivery.DeliveryStatus = newStatus.ToString();
                return true; // shows that the update was successful
            }
        return false; // shows that the delivery was not found or update failed
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

private int GenerateDeliveryId()
    {
        // This method would generate a unique delivery ID if any of this was actually real//
        return new Random().Next(1000, 9999);
    }
    }
};