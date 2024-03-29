namespace PaymentContext.Domain.Entities;
public class Subscription
{
    private readonly IList<Payment> _payments;
    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.UtcNow;
        ExpireDate = expireDate;
        Active = true;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }
    public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }
    public void AddPayment(Payment payment)
        => _payments.Add(payment);
    public void MakeAtive(bool active)
    {
        Active = active;
        LastUpdateDate = DateTime.Now;
    }
}