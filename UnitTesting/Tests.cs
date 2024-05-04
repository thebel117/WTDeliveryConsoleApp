namespace Testing;

public class DeliveryRepositoryTests
{
    [Fact]
    public void CreateDelivery_AddsDeliveryToList()
    {
        // Arrange (test setup)
        DeliveryRepository repo = new DeliveryRepository();
        Delivery delivery = new Delivery { ItemNumber = "ABC123" };

        // Act (perform the action being tested)
        repo.CreateDelivery(delivery);

        // Assert (verify the expected outcome)
        Assert.True(repo.GetAllDeliveries().Any(d => d.ItemNumber == "ABC123"), "Delivery not found in list after creation");
    }
}