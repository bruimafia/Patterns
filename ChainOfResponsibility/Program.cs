/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: ЦЕПОЧКА ОБЯЗАННОСТЕЙ "Chain of responsibility"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объекты обработчиков
        DrivingHandler dh1 = new Underground();
        DrivingHandler dh2 = new Car();
        DrivingHandler dh3 = new Train();
        DrivingHandler dh4 = new Plane();

        // Назначаем у обработчиков ссылку на следующий обработчик
        dh1.Successor = dh2;
        dh2.Successor = dh3;
        dh3.Successor = dh4;

        // Делаем запрос
        dh1.Handle("Великие Луки");
    }
}

// Абстрактный класс для обработки запроса, содержит ссылку на следующий обработчик запроса
abstract class DrivingHandler
{
    protected List<string> possible_locations;

    public DrivingHandler Successor { get; set; }

    public abstract void Handle(string destination);
}

// Конкретный обработчик (Метро)
// При невозможности обработки и наличия ссылки на следующий обработчик, передают запрос этому обработчику
class Underground : DrivingHandler
{
    public Underground()
    {
        possible_locations = new List<string>() { "Старая деревня", "Горьковская", "Парнас", "Автово", "Проспект Ветеранов", "Чёрная речка", "Беговая", "Ладожская" };
    }

    public override void Handle(string destination)
    {
        string place = possible_locations.FirstOrDefault(p => p == destination);

        if (place != null)
            Console.WriteLine("До места {0} ходит метро", destination);
        else if (Successor != null)
            Successor.Handle(destination);
    }
}

// Конкретный обработчик (Автомобиль)
// При невозможности обработки и наличия ссылки на следующий обработчик, передают запрос этому обработчику
class Car : DrivingHandler
{
    public Car()
    {
        possible_locations = new List<string>() { "Пушкин", "Павловск", "Выборг", "Кронштадт", "Сосновый бор", "Зеленогорск" };
    }

    public override void Handle(string destination)
    {
        string place = possible_locations.FirstOrDefault(p => p == destination);

        if (place != null)
            Console.WriteLine("До места {0} нужно ехать на автомобиле", destination);
        else if (Successor != null)
            Successor.Handle(destination);
    }
}

// Конкретный обработчик (Поезд)
// При невозможности обработки и наличия ссылки на следующий обработчик, передают запрос этому обработчику
class Train : DrivingHandler
{
    public Train()
    {
        possible_locations = new List<string>() { "Пенза", "Ростов", "Великие Луки", "Калининград", "Саратов", "Москва", "Красноярск" };
    }

    public override void Handle(string destination)
    {
        string place = possible_locations.FirstOrDefault(p => p == destination);

        if (place != null)
            Console.WriteLine("До места {0} можно доехать на поезде", destination);
        else if (Successor != null)
            Successor.Handle(destination);
    }
}

// Конкретный обработчик (Самолет)
// При невозможности обработки и наличия ссылки на следующий обработчик, передают запрос этому обработчику
class Plane : DrivingHandler
{
    public Plane()
    {
        possible_locations = new List<string>() { "Стамбул", "Париж", "Мадрид", "Лиссабон", "Каир", "Нью-Йорк", "Куала-Лумпур" };
    }

    public override void Handle(string destination)
    {
        string place = possible_locations.FirstOrDefault(p => p == destination);

        if (place != null)
            Console.WriteLine("До места {0} можно добраться только на самолёте", destination);
        else if (Successor != null)
            Successor.Handle(destination);
    }
}