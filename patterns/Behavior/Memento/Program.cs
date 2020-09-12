using System; 
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Hero hero = new Hero();
        hero.Shoot(); // we make a shot, there are 9 rounds left
        GameHistory game = new GameHistory();

        game.History.Push(hero.SaveState()); // save game

        hero.Shoot(); //we make a shot, there are 8 rounds left

        hero.RestoreState(game.History.Pop());

        hero.Shoot(); //we make a shot, there are 8 rounds left

        Console.Read();
    }
}

// Originator
class Hero
{
    private int patrons = 10; // number of bullets
    private int lives = 5; // number of lives

    public void Shoot()
    {
        if (patrons > 0)
        {
            patrons--;
            Console.WriteLine("We make a shot. {0} rounds left", patrons);
        }
        else
            Console.WriteLine("No more bullets");
    }
    // saving state
    public HeroMemento SaveState()
    {
        Console.WriteLine("Retention of game. Parameters: {0} bullets, {1} lives", patrons, lives);
        return new HeroMemento(patrons, lives);
    }

    // restoring a state
    public void RestoreState(HeroMemento memento)
    {
        this.patrons = memento.Patrons;
        this.lives = memento.Lives;
        Console.WriteLine("Restore the game. Parameters: {0} bullets, {1} lives", patrons, lives);
    }
}
// Memento
class HeroMemento
{
    public int Patrons { get; private set; }
    public int Lives { get; private set; }

    public HeroMemento(int patrons, int lives)
    {
        this.Patrons = patrons;
        this.Lives = lives;
    }
}

// Caretaker
class GameHistory
{
    public Stack<HeroMemento> History { get; private set; }
    public GameHistory()
    {
        History = new Stack<HeroMemento>();
    }
}