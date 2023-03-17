using System.Collections;

/*
 * СТРУКТУРНЫЙ ПАТТЕРН: ПРИСПОСОБЛЕНЕЦ (ЛЕГКОВЕС) "Flyweight"
 */

class Program
{
    static void Main(string[] args)
    {
        // Создаем фабрику по производству растений
        PlantFactory plantFactory = new PlantFactory();

        // Рисуем объекты Дерево
        for (int i = 0; i < 5; i++)
        {
            Plant plant = plantFactory.GetPlant("Дерево");
            if (plant != null)
                plant.Draw(Rand(), Rand());
        }
        Console.WriteLine();

        // Рисуем объекты Цветок
        for (int i = 0; i < 10; i++)
        {
            Plant plant = plantFactory.GetPlant("Цветок");
            if (plant != null)
                plant.Draw(Rand(), Rand());
        }
        Console.WriteLine();

        // Рисуем объекты Куст
        for (int i = 0; i < 7; i++)
        {
            Plant plant = plantFactory.GetPlant("Куст");
            if (plant != null)
                plant.Draw(Rand(), Rand());
        }
    }

    static double Rand() { return Math.Round(((new Random()).NextDouble() * 100), 2); }
}

// Общий класс приспособленца, через который приспособленцы-разделяемые объекты могут получать внешнее состояние или воздействовать на него
abstract class Plant
{
    protected string Texture; // внутреннее состояние

    public abstract void Draw(double x, double y); // функция принимает внешнее состояние
}

// Конкретный класс разделяемого приспособленца (Дерево)
// Реализует все из типа Plant и при необходимости добавляет внутреннее состояние
// Любое сохраняемое им состояние должно быть внутренним, не зависящим от контекста
class Tree : Plant
{
    public Tree()
    {
        Texture = "текстура дерева";
    }

    public override void Draw(double x, double y)
    {
        Console.WriteLine("Дерево нарисовано по координатам x:{0} y:{1}", x, y);
    }
}

// Конкретный класс разделяемого приспособленца (Куст)
// Реализует все из типа Plant и при необходимости добавляет внутреннее состояние
// Любое сохраняемое им состояние должно быть внутренним, не зависящим от контекста
class Bush : Plant
{
    public Bush()
    {
        Texture = "текстура куста";
    }

    public override void Draw(double x, double y)
    {
        Console.WriteLine("Куст нарисован по координатам x:{0} y:{1}", x, y);
    }
}

// Конкретный класс разделяемого приспособленца (Цветок)
// Реализует все из типа Plant и при необходимости добавляет внутреннее состояние
// Любое сохраняемое им состояние должно быть внутренним, не зависящим от контекста
class Flower : Plant
{
    public Flower()
    {
        Texture = "текстура цветка";
    }

    public override void Draw(double x, double y)
    {
        Console.WriteLine("Цветок нарисован по координатам x:{0} y:{1}", x, y);
    }
}

// Фабрика по созданию объектов разделяемых приспособленцев
class PlantFactory
{
    public Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

    public PlantFactory()
    {
        plants.Add("Дерево", new Tree());
        plants.Add("Куст", new Bush());
        plants.Add("Цветок", new Flower());
    }

    public Plant GetPlant(string key)
    {
        if (plants.ContainsKey(key))
            return (Plant)plants[key];
        else
            return null;
    }
}