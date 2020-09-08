using System;

class Program
{
    static void Main(string[] args)
    {
        ManagerMediator mediator = new ManagerMediator();
        Colleague customer = new CustomerColleague(mediator);
        Colleague programmer = new ProgrammerColleague(mediator);
        Colleague tester = new TesterColleague(mediator);
        mediator.Customer = customer;
        mediator.Programmer = programmer;
        mediator.Tester = tester;
        customer.Send("I have an order, I need to make a program");
        programmer.Send("The program is ready, we need to test it");
        tester.Send("The program is tested and ready for sale");

        Console.Read();
    }
}

abstract class Mediator
{
    public abstract void Send(string msg, Colleague colleague);
}
abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Send(string message)
    {
        mediator.Send(message, this);
    }
    public abstract void Notify(string message);
}
// customer's class
class CustomerColleague : Colleague
{
    public CustomerColleague(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to the requester: " + message);
    }
}
// programmer class
class ProgrammerColleague : Colleague
{
    public ProgrammerColleague(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to the programmer: " + message);
    }
}
// tester class
class TesterColleague : Colleague
{
    public TesterColleague(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to the tester: " + message);
    }
}

class ManagerMediator : Mediator
{
    public Colleague Customer { get; set; }
    public Colleague Programmer { get; set; }
    public Colleague Tester { get; set; }
    public override void Send(string msg, Colleague colleague)
    {
        // if the sender is a customer, then there is a new order
        // we send a message to the programmer to complete the order
        if (Customer == colleague)
            Programmer.Notify(msg);
        // if the sender is a programmer, you can start testing
        // sending a message to the tester
        else if (Programmer == colleague)
            Tester.Notify(msg);
        // if the sender is a test, then the product is ready
        // sending a message to the customer
        else if (Tester == colleague)
            Customer.Notify(msg);
    }
}