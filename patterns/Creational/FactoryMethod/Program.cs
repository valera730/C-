using System;

class Program
{
    static void Main(string[] args)
    {
        Developer dev = new PanelDeveloper("Housestroy");
        House house2 = dev.Create();

        dev = new WoodDeveloper("Investor");
        House house = dev.Create();

        Console.ReadLine();
    }
}
//abstract developer class
abstract class Developer
{
    public string Name { get; set; }

    public Developer(string n)
    {
        Name = n;
    }
    //factgory method
    abstract public House Create();
}
//builds panel houses
class PanelDeveloper : Developer
{
    public PanelDeveloper(string n) : base(n)
    { }

    public override House Create()
    {
        return new PanelHouse();
    }
}
//builds wooden houses
class WoodDeveloper : Developer
{
    public WoodDeveloper(string n) : base(n)
    { }

    public override House Create()
    {
        return new WoodHouse();
    }
}

abstract class House
{ }

class PanelHouse : House
{
    public PanelHouse()
    {
        Console.WriteLine("Panel house builded");
    }
}
class WoodHouse : House
{
    public WoodHouse()
    {
        Console.WriteLine("Wooden house builded");
    }
}