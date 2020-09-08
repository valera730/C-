using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Component fileSystem = new Directory("File system");
        // defining a new disk
        Component diskC = new Directory("Disk C");
        // new file
        Component pngFile = new File("12345.png");
        Component docxFile = new File("Document.docx");
        // adding files to disk C
        diskC.Add(pngFile);
        diskC.Add(docxFile);
        // adding disk C to the file system
        fileSystem.Add(diskC);
        // output all data
        fileSystem.Print();
        Console.WriteLine();
        // deleting a file from disk C
        diskC.Remove(pngFile);
        // creating a new folder
        Component docsFolder = new Directory("My documents");
        // adding files to it
        Component txtFile = new File("readme.txt");
        Component csFile = new File("Program.cs");
        docsFolder.Add(txtFile);
        docsFolder.Add(csFile);
        diskC.Add(docsFolder);

        fileSystem.Print();

        Console.Read();
    }
}

abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public virtual void Add(Component component) { }

    public virtual void Remove(Component component) { }

    public virtual void Print()
    {
        Console.WriteLine(name);
    }
}
class Directory : Component
{
    private List<Component> components = new List<Component>();

    public Directory(string name)
        : base(name)
    {
    }

    public override void Add(Component component)
    {
        components.Add(component);
    }

    public override void Remove(Component component)
    {
        components.Remove(component);
    }

    public override void Print()
    {
        Console.WriteLine("Knot " + name);
        Console.WriteLine("Subnodes:");
        for (int i = 0; i < components.Count; i++)
        {
            components[i].Print();
        }
    }
}

class File : Component
{
    public File(string name)
            : base(name)
    { }
}