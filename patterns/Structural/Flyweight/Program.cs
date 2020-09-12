using System; 
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        double longitude = 37.61;
        double latitude = 55.74;

        HouseFactory houseFactory = new HouseFactory();
        for (int i = 0; i < 5; i++)
        {
            House panelHouse = houseFactory.GetHouse("Panel");
            if (panelHouse != null)
                panelHouse.Build(longitude, latitude);
            longitude += 0.1;
            latitude += 0.1;
        }

        for (int i = 0; i < 5; i++)
        {
            House brickHouse = houseFactory.GetHouse("Brick");
            if (brickHouse != null)
                brickHouse.Build(longitude, latitude);
            longitude += 0.1;
            latitude += 0.1;
        }

        Console.Read();
    }
}

abstract class House
{
    protected int stages; // number of floors

    public abstract void Build(double longitude, double latitude);
}

class PanelHouse : House
{
    public PanelHouse()
    {
        stages = 16;
    }

    public override void Build(double longitude, double latitude)
    {
        Console.WriteLine("Built panel house of 16 floors; coordinates: {0} latitude and {1} longitude",
            latitude, longitude);
    }
}
class BrickHouse : House
{
    public BrickHouse()
    {
        stages = 5;
    }

    public override void Build(double longitude, double latitude)
    {
        Console.WriteLine("Built a brick house with 5 floors; coordinates: {0} latitude and {1} longitude",
            latitude, longitude);
    }
}

class HouseFactory
{
    Dictionary<string, House> houses = new Dictionary<string, House>();
    public HouseFactory()
    {
        houses.Add("Panel", new PanelHouse());
        houses.Add("Brick", new BrickHouse());
    }

    public House GetHouse(string key)
    {
        if (houses.ContainsKey(key))
            return houses[key];
        else
            return null;
    }
}