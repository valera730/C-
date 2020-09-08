using System;

class Program
{
    static void Main(string[] args)
    {
        TextEditor textEditor = new TextEditor();
        Compiller compiller = new Compiller();
        CLR clr = new CLR();

        VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

        Programmer programmer = new Programmer();
        programmer.CreateApplication(ide);

        Console.Read();
    }
}
// text editor
class TextEditor
{
    public void CreateCode()
    {
        Console.WriteLine("Writing code");
    }
    public void Save()
    {
        Console.WriteLine("Saving code");
    }
}
class Compiller
{
    public void Compile()
    {
        Console.WriteLine("Compilation of the application");
    }
}
class CLR
{
    public void Execute()
    {
        Console.WriteLine("Eexecution of the application");
    }
    public void Finish()
    {
        Console.WriteLine("Shutting down the app");
    }
}

class VisualStudioFacade
{
    TextEditor textEditor;
    Compiller compiller;
    CLR clr;
    public VisualStudioFacade(TextEditor te, Compiller compil, CLR clr)
    {
        this.textEditor = te;
        this.compiller = compil;
        this.clr = clr;
    }
    public void Start()
    {
        textEditor.CreateCode();
        textEditor.Save();
        compiller.Compile();
        clr.Execute();
    }
    public void Stop()
    {
        clr.Finish();
    }
}

class Programmer
{
    public void CreateApplication(VisualStudioFacade facade)
    {
        facade.Start();
        facade.Stop();
    }
}