/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: СОСТОЯНИЕ "State"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объект офицера
        Officer officer = new Officer();

        // Присваиваем офицеру звание
        officer.Rank = new Lieutenant();

        // Производим операции понижения и повышения в звании и командуем доступным формированием
        officer.Promotion();
        officer.Demotion();
        officer.Demotion();
        officer.Rank.CommandToForming();
        officer.Promotion();
        officer.Promotion();
        officer.Promotion();
        officer.Rank.CommandToForming();
        officer.Promotion();
        officer.Demotion();
        officer.Promotion();
        officer.Promotion();
        officer.Rank.CommandToForming();
    }
}

// Объект, поведение которого должно динамически изменяться в соответствии с состоянием
// Выполнение же конкретных действий делегируется объекту состояния
class Officer
{
    public IRank Rank { get; set; }

    public void Promotion()
    {
        if (Rank != null)
            Rank.Promotion(this);
    }

    public void Demotion()
    {
        if (Rank != null)
            Rank.Demotion(this);
    }
}

// Абстрактное описание состояния
interface IRank
{
    void Promotion(Officer officer);
    void Demotion(Officer officer);
    void CommandToForming();
}

// Конкретное состояние - Лейтенант
class Lieutenant : IRank
{
    public void Promotion(Officer officer)
    {
        Console.WriteLine("Повышение до капитана");
        officer.Rank = new Captain();
    }

    public void Demotion(Officer officer)
    {
        Console.WriteLine("Разжаловать некуда");
    }

    public void CommandToForming()
    {
        CommandToPlatoon();
    }

    // Командовать взводом
    private void CommandToPlatoon() { Console.WriteLine("Командуем взводом"); }
}

// Конкретное состояние - Капитан
class Captain : IRank
{
    public void Promotion(Officer officer)
    {
        Console.WriteLine("Повышение до майора");
        officer.Rank = new Major();
    }

    public void Demotion(Officer officer)
    {
        Console.WriteLine("Разжалование до лейтенанта");
        officer.Rank = new Lieutenant();
    }

    public void CommandToForming()
    {
        CommandToCompany();
    }

    // Командовать ротой
    private void CommandToCompany() { Console.WriteLine("Командуем ротой"); }
}

// Конкретное состояние - Майор
class Major : IRank
{
    public void Promotion(Officer officer)
    {
        Console.WriteLine("Повышение до полковника");
        officer.Rank = new Colonel();
    }

    public void Demotion(Officer officer)
    {
        Console.WriteLine("Разжалование до капитана");
        officer.Rank = new Captain();
    }

    public void CommandToForming()
    {
        CommandToBattalion();
    }

    // Командовать батальоном
    private void CommandToBattalion() { Console.WriteLine("Командуем батальоном"); }
}

// Конкретное состояние - Полковник
class Colonel : IRank
{
    public void Promotion(Officer officer)
    {
        Console.WriteLine("Повышение до генерала");
        officer.Rank = new General();
    }

    public void Demotion(Officer officer)
    {
        Console.WriteLine("Разжалование до майора");
        officer.Rank = new Major();
    }

    public void CommandToForming()
    {
        CommandToRegiment();
    }

    // Командовать полком
    private void CommandToRegiment() { Console.WriteLine("Командуем полком"); }
}

// Конкретное состояние - Генерал
class General : IRank
{
    public void Promotion(Officer officer)
    {
        Console.WriteLine("Повышать некуда");
    }

    public void Demotion(Officer officer)
    {
        Console.WriteLine("Разжалование до полковника");
        officer.Rank = new Colonel();
    }

    public void CommandToForming()
    {
        CommandToDivision();
    }

    // Командовать дивизией
    private void CommandToDivision() { Console.WriteLine("Командуем дивизией"); }
}