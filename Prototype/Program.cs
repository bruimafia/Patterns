/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: ПРОТОТИП "Prototype"
 */

class Program
{
    static void Main(string[] args)
    {
        // Создаем прототип террориста и коллекцию для будущих копий
        HeroPrototype terrorist_prototype = new Terrorist(40, 50, 100, 60, 70, 70, 40);
        List<HeroPrototype> terrorists = new List<HeroPrototype>();

        // Создаем прототип спецназовца и коллекцию для будущих копий
        HeroPrototype counterTerrorist_prototype = new CounterTerrorist(60, 40, 100, 70, 60, 40, 40);
        List<HeroPrototype> counterTerrorists = new List<HeroPrototype>();

        // Заполняем коллекцию клонами террориста
        for (int i = 0; i < 20; i++)
            terrorists.Add(terrorist_prototype.Clone());

        // Заполняем коллекцию клонами спецназовца
        for (int i = 0; i < 6; i++)
            counterTerrorists.Add(counterTerrorist_prototype.Clone());

        // Выводим все на экран и проверяем результат
        foreach (HeroPrototype terrorist in terrorists)
            terrorist.GetInfo();
        foreach (HeroPrototype counterTerrorist in counterTerrorists)
            counterTerrorist.GetInfo();
    }
}

// Абстрактный класс или интерфейс с методом Clone()
abstract class HeroPrototype
{
    public int Power { get; private set; } // Сила
    public int Dexterity { get; private set; } // Ловкость
    public int Health { get; private set; } // Здоровье
    public int Intelligence { get; private set; } // Интеллект
    public int Wisdom { get; private set; } // Мудрость
    public int Charisma { get; private set; } // Харизма
    public int Luck { get; private set; } // Удача

    public HeroPrototype(int power, int dexterity, int health, int intelligence, int wisdom, int charisma, int luck)
    {
        Power = power;
        Dexterity = dexterity;
        Health = health;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Luck = luck;
    }

    public void GetInfo()
    {
        Console.WriteLine("Объект {0}. Хар-ки: P {1}, D {2}, H {3}, I {4}, W {5}, C {6}, L {7}", this.GetType().Name, Power, Dexterity, Health, Intelligence, Wisdom, Charisma, Luck);
    }

    public abstract HeroPrototype Clone(); // Метод для клонирования самого себя
}

class CounterTerrorist : HeroPrototype
{
    public CounterTerrorist(int power, int dexterity, int health, int intelligence, int wisdom, int charisma, int luck)
        : base(power, dexterity, health, intelligence, wisdom, charisma, luck)
    { }

    // Реализуем метод Clone(), возвращая новый такой же объект с текущим состоянием полей
    public override HeroPrototype Clone()
    {
        return new CounterTerrorist(Power, Dexterity, Health, Intelligence, Wisdom, Charisma, Luck);
    }

    // В C# можно заменить ручное создание объекта с полями вызовом метода MemberwiseClone(), однако он клонирует только примитивные типы 
    //public HeroPrototype ShallowClone()
    //{
    //    return (HeroPrototype)this.MemberwiseClone();
    //}

    // Для полной копии объекта необходимо ссылочные типы клонировать вручную
    //public HeroPrototype DeepClone()
    //{
    //    HeroPrototype clone = (HeroPrototype)this.MemberwiseClone();
    //    clone.Name = "Name"; // String - это тоже ссылочный тип, копируем его вручную
    //    return clone;
    //}
}

class Terrorist : HeroPrototype
{
    public Terrorist(int power, int dexterity, int health, int intelligence, int wisdom, int charisma, int luck)
        : base(power, dexterity, health, intelligence, wisdom, charisma, luck)
    { }

    public override HeroPrototype Clone()
    {
        return new Terrorist(Power, Dexterity, Health, Intelligence, Wisdom, Charisma, Luck);
    }
}
