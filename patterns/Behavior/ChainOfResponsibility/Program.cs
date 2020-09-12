using System; 

class Program
{
    static void Main(string[] args)
    {
        Receiver receiver = new Receiver(false, true, true);

        PaymentHandler bankPaymentHandler = new BankPaymentHandler();
        PaymentHandler moneyPaymentHadler = new MoneyPaymentHandler();
        PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
        bankPaymentHandler.Successor = paypalPaymentHandler;
        paypalPaymentHandler.Successor = moneyPaymentHadler;

        bankPaymentHandler.Handle(receiver);

        Console.Read();
    }
}

class Receiver
{
    // bank transfer
    public bool BankTransfer { get; set; }
    // bank transfer - WesternUnion, Unistream
    public bool MoneyTransfer { get; set; }
    // transfer via PayPal
    public bool PayPalTransfer { get; set; }
    public Receiver(bool bt, bool mt, bool ppt)
    {
        BankTransfer = bt;
        MoneyTransfer = mt;
        PayPalTransfer = ppt;
    }
}
abstract class PaymentHandler
{
    public PaymentHandler Successor { get; set; }
    public abstract void Handle(Receiver receiver);
}

class BankPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.BankTransfer == true)
            Console.WriteLine("Make a Bank transfer");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}

class PayPalPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.PayPalTransfer == true)
            Console.WriteLine("Make a transfer via PayPal");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}
// transfers using the money transfer system
class MoneyPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.MoneyTransfer == true)
            Console.WriteLine("Make transfers via money transfer systems");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}