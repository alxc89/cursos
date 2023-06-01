namespace Payments
{
    class Program
    {
        static void Main(string[] args)
        {
            PagamentoBoleto pagamentoBoleto = new PagamentoBoleto();
            pagamentoBoleto.Pagar();
            pagamentoBoleto.Vencimento = DateTime.Today;
            pagamentoBoleto.NumeroBoleto = "1234";
            pagamentoBoleto.ToString();
            Pagamento pagamento = new Pagamento();
        }
        class Pagamento
        {
            //Propriedades
            public DateTime Vencimento;

            //Métodos
            public virtual void Pagar()
            {

            }

            public override string ToString()
            {
                return Vencimento.ToString("dd/mm/yyyy");
            }
        }

        class PagamentoBoleto : Pagamento
        {
            public string? NumeroBoleto;

            public override void Pagar()
            {
                //Regra do Boleto
            }
        }

        class PagamentoCartaoCredito : Pagamento
        {
            public string? Numero;

            public override void Pagar()
            {
                //Regra do Cartão de crédito
            }
        }
    }
}