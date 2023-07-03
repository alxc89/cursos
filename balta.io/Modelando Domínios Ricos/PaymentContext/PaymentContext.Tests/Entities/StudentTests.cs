namespace PaymentContext.Tests.Entities;
[TestClass]
public class StudentTests
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var subscription = new Subscription(null);
        var student = new Student("Alex C.", "Costa", "123", "alex.costa@teste.com");
        student.AddSubscription(subscription);
    }
}