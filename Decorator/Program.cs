/*
 * СТРУКТУРНЫЙ ПАТТЕРН: ДЕКОРАТОР "Decorator"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем персонажа Солдат
        Character hero = new Soldier();
        hero.PrintInfo();
        hero.GetInjured(); // Получает ранение
        hero.PrintInfo();

        // Персонаж надевает легкую броню
        hero = new LightArmor(hero);
        hero.PrintInfo();
        hero.GetInjured(); // Получает ранение
        hero.PrintInfo();

        // Персонаж надевает тяжелую броню
        hero = new HeavyArmor(hero);
        hero.PrintInfo();
        hero.GetInjured(); // Получает ранение
        hero.PrintInfo();
    }
}

// Абстрактный класс, описывающий персонажа
abstract class Character
{
    public int Health { get; set; }
    public int Armor { get; set; }
    public int Speed { get; set; }

    public string Name { get; set; }

    public Character(string name, int health = 100, int armor = 0, int speed = 100)
    {
        this.Name = name;
        this.Health = health;
        this.Armor = armor;
        this.Speed = speed;
    }

    public virtual void GetInjured()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0} получил ранение", this.Name);
        Console.ResetColor();
    }

    public void PrintInfo()
    {
        Console.Write(this.Name + " | ");
        Console.WriteLine("Здоровье {0}, Броня {1}, Скорость {2}", this.Health, this.Armor, this.Speed);
    }
}

// Класс, описывающий персонажа Солдат
class Soldier : Character
{
    public Soldier() : base("Солдат") { }

    public override void GetInjured()
    {
        base.GetInjured();
        this.Health -= 20;
        this.Speed -= 20;
    }
}

// Класс, описывающий персонажа Бандит
class Bandit : Character
{
    public Bandit() : base("Бандит") { }

    public override void GetInjured()
    {
        base.GetInjured();
        this.Health -= 20;
        this.Speed -= 20;
    }
}

// Класс, описывающий персонажа Гражданский
class Civilian : Character
{
    public Civilian() : base("Гражданский") { }

    public override void GetInjured()
    {
        base.GetInjured();
        this.Health -= 20;
        this.Speed -= 20;
    }
}

// Абстрактный класс декоратор - имеет тот же базовый класс, что и декорируемые объекты
abstract class ArmorDecorator : Character
{
    // Класс декоратора также хранит ссылку на декорируемый объект
    protected Character character;

    public ArmorDecorator(Character character, string name) : base(name, character.Health, character.Armor, character.Speed)
    {
        this.character = character;
    }
}

// Класс Легкая броня представляет дополнительную функциональность для декорируемого объекта
class LightArmor : ArmorDecorator
{
    public LightArmor(Character character) : base(character, character.Name + "[легкая броня]")
    {
        this.Armor += 100;
        this.Speed -= 20;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0} надел легкую броню", character.Name);
        Console.ResetColor();
    }

    public override void GetInjured()
    {
        base.GetInjured();
        this.Health -= 10;
        this.Armor -= 30;
        this.Speed -= 10;
    }
}

// Класс Тяжелая броня представляет дополнительную функциональность для декорируемого объекта
class HeavyArmor : ArmorDecorator
{
    public HeavyArmor(Character character) : base(character, character.Name + "[тяжелая броня]")
    {
        this.Armor += 100;
        this.Speed -= 30;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0} надел тяжелую броню", character.Name);
        Console.ResetColor();
    }

    public override void GetInjured()
    {
        base.GetInjured();
        this.Health -= 5;
        this.Armor -= 20;
        this.Speed -= 10;
    }
}