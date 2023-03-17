/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: ХРАНИТЕЛЬ / СНИМОК "Memento"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объекты персонажа и истории игры
        Character artem = new Character("Артем");
        GameHistory history = new GameHistory();

        // Выполняем действия над персонажем
        artem.Run();
        artem.Run();
        artem.GetInjured();
        artem.Shoot();
        artem.Shoot();
        artem.GetInjured();
        artem.Shoot();

        // Решаем, что нужно сохранить игру (состояние персонажа)
        history.CreateSave(artem.SaveState());

        // Выполняем действия над персонажем
        artem.Run();
        artem.Run();
        artem.GetInjured();
        artem.GetInjured();
        artem.GetInjured();
        artem.GetInjured();

        // Так как персонаж мертв, решаем восстановить последнее сохранение игры (состояние персонажа)
        artem.RecoverState(history.GetLastSave());

        // Выполняем действия над персонажем
        artem.Run();
        artem.GetInjured();
        artem.Shoot();
        artem.Shoot();
    }
}

// Объект Originator (персонаж) - создает объект хранителя для сохранения своего состояния
class Character
{
    public string Name { get; set; }
    private int power = 10;
    private int health = 5;
    private int patrons = 10;

    public Character(string name) { this.Name = name; }

    public void Run()
    {
        power--;
        Console.WriteLine("{0} пробежался. Осталось {1} сил", Name, power);
    }

    public void Shoot()
    {
        patrons--;
        Console.WriteLine("{0} выстрелил. Осталось {1} патронов", Name, patrons);
    }

    public void GetInjured()
    {
        if (health > 1)
        {
            health--;
            Console.WriteLine("{0} получил ранение. Осталось {1} здоровья", Name, health);
        }
        else if (health == 1)
        {
            health--;
            Console.WriteLine("{0} получил смертельное ранение", Name);
        }
        else
            Console.WriteLine("Хватит! {0} и так уже мертв", Name);
    }

    // Сохраняем состояние персонажа
    public CharacterMemento SaveState()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Сохранение игры... -> Сила {0} | Здоровье {1} | Патроны {2}", power, health, patrons);
        Console.ResetColor();
        return new CharacterMemento(power, health, patrons);
    }

    // Восстанавливаем состояние персонажа
    public void RecoverState(CharacterMemento memento)
    {
        this.power = memento.Power;
        this.health = memento.Health;
        this.patrons = memento.Patrons;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Игра восстановлена -> Сила {0} | Здоровье {1} | Патроны {2}", power, health, patrons);
        Console.ResetColor();
    }
}

// Объкт Memento (хранитель, копия) - создает объект с сохраненным состоянием Originator (персонажа)
class CharacterMemento
{
    public int Power { get; private set; }
    public int Health { get; private set; }
    public int Patrons { get; private set; }

    public CharacterMemento(int power, int health, int patrons)
    {
        this.Power = power;
        this.Health = health;
        this.Patrons = patrons;

    }
}

// Объект Caretaker (история сохранений состояния персонажа) - хранит объекы Memento (сохраненные состояния персонажа)
class GameHistory
{
    public List<CharacterMemento> History { get; private set; }

    public GameHistory()
    {
        History = new List<CharacterMemento>();
    }

    public void CreateSave(CharacterMemento memento)
    {
        History.Add(memento);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Игра сохранена");
        Console.ResetColor();
    }

    public CharacterMemento GetSave(int index)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Восстановление игры...");
        Console.ResetColor();
        return History[index];
    }

    public CharacterMemento GetLastSave()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Восстановление игры из последнего сохранения...");
        Console.ResetColor();
        return History.Last();
    }
}