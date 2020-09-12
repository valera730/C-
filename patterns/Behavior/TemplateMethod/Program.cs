using System; 

class Program
{
    static void Main(string[] args)
    {
        School school = new School();
        University university = new University();

        school.Learn();
        university.Learn();

        Console.Read();
    }
}
abstract class Education
{
    public void Learn()
    {
        Enter();
        Study();
        PassExams();
        GetDocument();
    }
    public abstract void Enter();
    public abstract void Study();
    public virtual void PassExams()
    {
        Console.WriteLine("We pass final exams");
    }
    public abstract void GetDocument();
}

class School : Education
{
    public override void Enter()
    {
        Console.WriteLine("Going to first class");
    }

    public override void Study()
    {
        Console.WriteLine("We attend classes and do homework");
    }

    public override void GetDocument()
    {
        Console.WriteLine("Getting a certificate of secondary education");
    }
}

class University : Education
{
    public override void Enter()
    {
        Console.WriteLine("We pass entrance exams and enter the UNIVERSITY");
    }

    public override void Study()
    {
        Console.WriteLine("We attend lectures");
        Console.WriteLine("Going through practice");
    }

    public override void PassExams()
    {
        Console.WriteLine("Passing the exam in the specialty");
    }

    public override void GetDocument()
    {
        Console.WriteLine("Get a diploma of higher education");
    }
}