using System;

class Program
{
    static void Main(string[] args)
{
// traveler
Driver driver = new Driver();
// car
Auto auto = new Auto();
// going on a trip
driver.Travel(auto);
// met sand, need to use a camel
Camel camel = new Camel();
// using the adapter
ITransport camelTransport = new CamelToTransportAdapter(camel);
// continue our way through the desert Sands
driver.Travel(camelTransport);

Console.Read();
}
}
interface ITransport
{
    void Drive();
}
// класс машины
class Auto : ITransport
{
    public void Drive()
    {
        Console.WriteLine("The car is on the road");
    }
}
class Driver
{
    public void Travel(ITransport transport)
    {
        transport.Drive();
    }
}
// animal interface
interface IAnimal
{
    void Move();
}
// camel class
class Camel : IAnimal
{
    public void Move()
    {
        Console.WriteLine("A camel walks on the desert Sands");
    }
}
// Adapter from Camel to ITransport
class CamelToTransportAdapter : ITransport
{
    Camel camel;
    public CamelToTransportAdapter(Camel c)
    {
        camel = c;
    }

    public void Drive()
    {
        camel.Move();
    }
}