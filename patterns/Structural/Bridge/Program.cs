using System; 

class Program
{
    static void Main(string[] args)
    {
        // creating a new programmer that works with C++
        Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
        freelancer.DoWork();
        freelancer.EarnMoney();
        // I received a new order, but now I need c#
        freelancer.Language = new CSharpLanguage();
        freelancer.DoWork();
        freelancer.EarnMoney();

        Console.Read();
    }
}

interface ILanguage
{
    void Build();
    void Execute();
}

class CPPLanguage : ILanguage
{
    public void Build()
    {
        Console.WriteLine("Using the C++ compiler, we compile the program into binary code");
    }

    public void Execute()
    {
        Console.WriteLine("Run the executable file of the program");
    }
}

class CSharpLanguage : ILanguage
{
    public void Build()
    {
        Console.WriteLine("Using the Roslyn compiler, we compile the source code into an exe file");
    }

    public void Execute()
    {
        Console.WriteLine("JIT compiles the program binary code");
        Console.WriteLine("The CLR executes compiled binary code");
    }
}

abstract class Programmer
{
    protected ILanguage language;
    public ILanguage Language
    {
        set { language = value; }
    }
    public Programmer(ILanguage lang)
    {
        language = lang;
    }
    public virtual void DoWork()
    {
        language.Build();
        language.Execute();
    }
    public abstract void EarnMoney();
}

class FreelanceProgrammer : Programmer
{
    public FreelanceProgrammer(ILanguage lang) : base(lang)
    {
    }
    public override void EarnMoney()
    {
        Console.WriteLine("We receive payment for the completed order");
    }
}
class CorporateProgrammer : Programmer
{
    public CorporateProgrammer(ILanguage lang)
        : base(lang)
    {
    }
    public override void EarnMoney()
    {
        Console.WriteLine("We receive a salary at the end of the month");
    }
}