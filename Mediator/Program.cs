/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: МЕДИАТОР "Mediator"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем посредника
        TaxiAggregator mobile_app = new TaxiAggregator();

        // Создаем пассажира и устанавливаем ему объект-посредника
        Passenger passenger = new Passenger("Сергей");
        passenger.SetMediator(mobile_app);

        // Создаем водителей и устанавливаем им объект-посредника
        Driver driver1 = new Driver("Карлос");
        driver1.SetMediator(mobile_app);
        Driver driver2 = new Driver("Диего");
        driver2.SetMediator(mobile_app);
        Driver driver3 = new Driver("Доминик");
        driver3.SetMediator(mobile_app);

        // Добавляем водителей и пассажира в объект-посредник
        mobile_app.Drivers.Add(driver1);
        mobile_app.Drivers.Add(driver2);
        mobile_app.Drivers.Add(driver3);
        mobile_app.Passenger = passenger;

        // Пассажир делает запрос, водитель3 ему отвечает
        passenger.Send("Невский проспект, 28");
        driver3.Send("OK");
    }
}

// Абстрактное описание Colleague, интерфейс для взаимодействия с объектом Mediator
abstract class User
{
    protected Mediator mediator;
    public string Name;

    public User(string name)
    {
        this.Name = name;
    }

    public void SetMediator(Mediator mediator)
    {
        this.mediator = mediator;
    }
}

// Конкретный класс Colleague (водитель), который обменивается информацией через объект Mediator
class Driver : User
{
    public Driver(string name) : base(name) { }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message, User user)
    {
        Console.WriteLine("Сообщение для водителя {0}: заказ от {1} на адрес {2}", this.Name, user.Name, message);
    }
}

// Конкретный класс Colleague (пассажир), который обменивается информацией через объект Mediator
class Passenger : User
{
    public Passenger(string name) : base(name) { }

    public void Send(string address)
    {
        mediator.Send(address, this);
    }

    public void Notify(string message, User user)
    {
        Console.WriteLine("Сообщение для пассажира {0}: водитель {1} скоро приедет", this.Name, user.Name);
    }
}

// Абстрактное описание Mediator для взаимодействия с объектами Colleague
abstract class Mediator
{
    public abstract void Send(string msg, User user);
}

// Конкретный посредник (агрегатор такси), реализующий интерфейс типа Mediator
class TaxiAggregator : Mediator
{
    public Passenger Passenger { get; set; }
    public List<Driver> Drivers { get; set; }

    public TaxiAggregator()
    {
        Drivers = new List<Driver>();
    }

    public override void Send(string msg, User user)
    {
        if (user == Passenger)
        {
            for (int i = 0; i < Drivers.Count; i++)
                Drivers[i].Notify(msg, user);
        }
        else
            Passenger.Notify(msg, user);
    }
}