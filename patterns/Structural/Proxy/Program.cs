using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (IBook book = new BookStoreProxy())
        {
            // reading the first page
            Page page1 = book.GetPage(1);
            Console.WriteLine(page1.Text);
            // reading the second page
            Page page2 = book.GetPage(2);
            Console.WriteLine(page2.Text);
            // back to the first page    
            page1 = book.GetPage(1);
            Console.WriteLine(page1.Text);
        }

        Console.Read();
    }
}
class Page
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Text { get; set; }
}
class PageContext : DbContext
{
    public DbSet<Page> Pages { get; set; }
}

interface IBook : IDisposable
{
    Page GetPage(int number);
}

class BookStore : IBook
{
    PageContext db;
    public BookStore()
    {
        db = new PageContext();
    }
    public Page GetPage(int number)
    {
        return db.Pages.FirstOrDefault(p => p.Number == number);
    }

    public void Dispose()
    {
        db.Dispose();
    }
}

class BookStoreProxy : IBook
{
    List<Page> pages;
    BookStore bookStore;
    public BookStoreProxy()
    {
        pages = new List<Page>();
    }
    public Page GetPage(int number)
    {
        Page page = pages.FirstOrDefault(p => p.Number == number);
        if (page == null)
        {
            if (bookStore == null)
                bookStore = new BookStore();
            page = bookStore.GetPage(number);
            pages.Add(page);
        }
        return page;
    }

    public void Dispose()
    {
        if (bookStore != null)
            bookStore.Dispose();
    }
}