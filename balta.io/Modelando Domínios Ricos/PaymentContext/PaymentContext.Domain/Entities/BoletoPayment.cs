namespace PaymentContext.Domain.Entities;
public class BoletoPayment : Payment
{
    public BoletoPayment(string barCod, string boletoNumber, DateTime paidDate, DateTime expireDate,
                         decimal total, decimal totalPaid, string payer, string document, string address,
                         string email)
    : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
        BarCod = barCod;
        BoletoNumber = boletoNumber;
    }

    public string BarCod { get; private set; }
    public string BoletoNumber { get; private set; }
}