using System; 
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Context context = new Context();
        int x = 5;
        int y = 8;
        int z = 2;

        //adding data to context
        context.SetVariable("x", x);
        context.SetVariable("y", y);
        context.SetVariable("z", z);
        //creating object for x + y - z
        IExpression expression = new SubtractExpression(
            new AddExpression(
                new NumberExpression("x"), new NumberExpression("y")
            ),
            new NumberExpression("z")
        );

        int result = expression.Interpret(context);
        Console.WriteLine("result: {0}", result);

        Console.Read();
    }
}

class Context
{
    Dictionary<string, int> variables;
    public Context()
    {
        variables = new Dictionary<string, int>();
    }
    //get value by variable name
    public int GetVariable(string name)
    {
        return variables[name];
    }

    public void SetVariable(string name, int value)
    {
        if (variables.ContainsKey(name))
            variables[name] = value;
        else
            variables.Add(name, value);
    }
}

//interpreter interface
interface IExpression
{
    int Interpret(Context context);
}
//terminal expression
class NumberExpression : IExpression
{
    string name; //name
    public NumberExpression(string variableName)
    {
        name = variableName;
    }
    public int Interpret(Context context)
    {
        return context.GetVariable(name);
    }
}
//nonterminal expression
class AddExpression : IExpression
{
    IExpression leftExpression;
    IExpression rightExpression;

    public AddExpression(IExpression left, IExpression right)
    {
        leftExpression = left;
        rightExpression = right;
    }

    public int Interpret(Context context)
    {
        return leftExpression.Interpret(context) + rightExpression.Interpret(context);
    }
}
//nonterminal expression for subtraction
class SubtractExpression : IExpression
{
    IExpression leftExpression;
    IExpression rightExpression;

    public SubtractExpression(IExpression left, IExpression right)
    {
        leftExpression = left;
        rightExpression = right;
    }

    public int Interpret(Context context)
    {
        return leftExpression.Interpret(context) - rightExpression.Interpret(context);
    }
}