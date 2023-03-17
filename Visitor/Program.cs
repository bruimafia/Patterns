/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: ПОСЕТИТЕЛЬ "Visitor"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем список космических объектов
        List<SpaceObject> space_objects = new List<SpaceObject>
        {
            new Star{ Name = "Солнце", DistanceToTheObject = 150_000_000 },
            new Satellite{ Name = "Луна", DistanceToTheObject = 384_400 },
            new Meteorite{ Name = "Челябинский", DistanceToTheObject = 100_000 },
            new Planet{ Name = "Сатурн", DistanceToTheObject = 1_500_000_000 },
            new BlackHole{ Name = "Стрелец А*", DistanceToTheObject = int.MaxValue }
        };

        // Запускаем у космических объектов функцию расчета времени полета до космического объекта
        IVisitor visitor = new TravelTime(40_000);
        foreach (SpaceObject so in space_objects)
            so.Accept(visitor);

        Console.WriteLine();

        // Запускаем у космических объектов функцию расчета местонахождения космического объекта в конкретную дату
        IVisitor visitor1 = new WhereLocation(new DateTime(2030, 2, 24));
        foreach (SpaceObject so in space_objects)
            so.Accept(visitor1);
    }
}

// Абстрактное описание объектов
// Описывает метод Accept(), в котором в качестве параметра принимается объект Visitor
interface SpaceObject { void Accept(IVisitor visitor); }

// Конкретный космический объект (звезда)
class Star : SpaceObject
{
    public string Name { get; set; }
    public long DistanceToTheObject { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitStar(this);
    }

    public void DescriptionTrajectory() { }
}

// Конкретный космический объект (спутник)
class Satellite : SpaceObject
{
    public string Name { get; set; }
    public long DistanceToTheObject { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitSatellite(this);
    }

    public void DescriptionTrajectory() { }
}

// Конкретный космический объект (метеорит)
class Meteorite : SpaceObject
{
    public string Name { get; set; }
    public long DistanceToTheObject { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitMeteorite(this);
    }

    public void DescriptionTrajectory() { }
}

// Конкретный космический объект (планета)
class Planet : SpaceObject
{
    public string Name { get; set; }
    public long DistanceToTheObject { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitPlanet(this);
    }

    public void DescriptionTrajectory() { }
}

// Конкретный космический объект (черная дыра)
class BlackHole : SpaceObject
{
    public string Name { get; set; }
    public long DistanceToTheObject { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitBlackHole(this);
    }

    public void DescriptionTrajectory() { }
}

// Интерфейс посетителя - определяет метод Visit() для каждого объекта SpaceObject
interface IVisitor
{
    void VisitStar(Star space_object);
    void VisitSatellite(Satellite space_object);
    void VisitMeteorite(Meteorite space_object);
    void VisitPlanet(Planet space_object);
    void VisitBlackHole(BlackHole space_object);
}

// Конкретный класс посетителя (функция расчета времени полета до космического объекта)
class TravelTime : IVisitor
{
    public double Speed { get; set; }

    public TravelTime(double speed) { this.Speed = speed; }

    public void VisitStar(Star space_object)
    {
        Console.WriteLine("Время в пути до звезды {0} займет {1} ч", space_object.Name, space_object.DistanceToTheObject / Speed);
    }

    public void VisitSatellite(Satellite space_object)
    {
        Console.WriteLine("Время в пути до спутника {0} займет {1} ч", space_object.Name, space_object.DistanceToTheObject / Speed);
    }

    public void VisitMeteorite(Meteorite space_object)
    {
        Console.WriteLine("Время в пути до метеорита {0} займет {1} ч", space_object.Name, space_object.DistanceToTheObject / Speed);
    }

    public void VisitPlanet(Planet space_object)
    {
        Console.WriteLine("Время в пути до планеты {0} займет {1} ч", space_object.Name, space_object.DistanceToTheObject / Speed);
    }

    public void VisitBlackHole(BlackHole space_object)
    {
        Console.WriteLine("Время в пути до черной звезды {0} займет {1} ч", space_object.Name, space_object.DistanceToTheObject / Speed);
    }
}

// Конкретный класс посетителя (функция расчета местонахождения космического объекта в конкретную дату)
class WhereLocation : IVisitor
{
    public DateTime Date { get; set; }

    public WhereLocation(DateTime date) { this.Date = date; }

    public void VisitStar(Star space_object)
    {
        space_object.DescriptionTrajectory();
        Console.WriteLine("Звезда {0} {1} будет находиться на расстоянии {2} км", space_object.Name, Date, new Random().Next(148_000_000, 152_000_000));
    }

    public void VisitSatellite(Satellite space_object)
    {
        space_object.DescriptionTrajectory();
        Console.WriteLine("Спутник {0} {1} будет находиться на расстоянии {2} км", space_object.Name, Date, new Random().Next(360_000, 406_000));
    }

    public void VisitMeteorite(Meteorite space_object)
    {
        space_object.DescriptionTrajectory();
        Console.WriteLine("Метеорит {0} {1} будет находиться на расстоянии {2} км", space_object.Name, Date, new Random().Next(500, 1_000));
    }

    public void VisitPlanet(Planet space_object)
    {
        space_object.DescriptionTrajectory();
        Console.WriteLine("Планета {0} {1} будет находиться на расстоянии {2} км", space_object.Name, Date, new Random().Next(1_195_000_000, 1_660_000_000));
    }

    public void VisitBlackHole(BlackHole space_object)
    {
        space_object.DescriptionTrajectory();
        Console.WriteLine("Черная звезда {0} {1} будет находиться на расстоянии {2} км", space_object.Name, Date, new Random().Next(int.MaxValue, int.MaxValue));
    }
}
