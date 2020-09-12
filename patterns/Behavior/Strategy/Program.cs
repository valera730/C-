using System; 


class Program
{
    static void Main(string[] args)
    {
        Car auto = new Car(4, "Volvo", new PetrolMove());
        auto.Move();
        auto.Movable = new ElectricMove();
        auto.Move();

        Console.ReadLine();
    }
}
interface IMovable
{
    void Move();
}

class PetrolMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Moving on gasoline");
    }
}

class ElectricMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Moving on electricity");
    }
}
class Car
{
    protected int passengers;
    protected string model;

    public Car(int num, string model, IMovable mov)
    {
        this.passengers = num;
        this.model = model;
        Movable = mov;
    }
    public IMovable Movable { private get; set; }
    public void Move()
    {
        Movable.Move();
    }
}