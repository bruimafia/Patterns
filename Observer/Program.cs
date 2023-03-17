/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: НАБЛЮДАТЕЛЬ "Observer"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем наблюдаемые объекты
        TV3YoutubeChannell tv3 = new TV3YoutubeChannell();
        THTYoutubeChannell tnt = new THTYoutubeChannell();

        // Создаем наблюдателей
        User sergey = new User("Сергей");
        User sofia = new User("Софья");

        // Подписываем наблюдателей на наблюдаемые объекты
        sergey.Subscribe(tv3);
        sergey.Subscribe(tnt);
        sofia.Subscribe(tv3);

        // Запускаем деятельность на youtube-каналах
        tv3.SomeBusinessLogic();
        tnt.SomeBusinessLogic();
        Console.WriteLine();

        // Отписываем наблюдателя от наблюдаемых объектов
        sergey.Unsubscribe(tv3);
        sergey.Unsubscribe(tnt);

        // Запускаем деятельность на youtube-каналах
        tv3.SomeBusinessLogic();
        tnt.SomeBusinessLogic();
    }
}

// Абстрактный наблюдатель, подписывается на все уведомления наблюдаемого объекта
interface IObserver
{
    void Update(IObservable obs);
}

// Конкретный наблюдатель (пользователь)
class User : IObserver
{
    public string Name { get; set; }

    public User(string name)
    {
        this.Name = name;
    }

    public void Subscribe(IObservable channell)
    {
        channell.RegisterObserver(this);
    }

    public void Unsubscribe(IObservable channell)
    {
        channell.RemoveObserver(this);
    }

    public void Update(IObservable obs)
    {
        Console.Write("Пользователь {0} получил уведомление: ", this.Name);
        Console.WriteLine("На канале {0} вышел новый ролик", obs.GetType().Name);
    }
}

// Абстрактный наблюдаемый объект
interface IObservable
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Конкретный наблюдаемый объект (YouTube-канал ТНТ)
class THTYoutubeChannell : IObservable
{
    private List<IObserver> observers;

    public THTYoutubeChannell()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
            observer.Update(this);
    }

    public void SomeBusinessLogic()
    {
        Console.WriteLine("Я ({0}) загрузил новое видео", this.GetType().Name);
        this.NotifyObservers();
    }
}

// Конкретный наблюдаемый объект (YouTube-канал ТВ3)
class TV3YoutubeChannell : IObservable
{
    private List<IObserver> observers;

    public TV3YoutubeChannell()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
            observer.Update(this);
    }

    public void SomeBusinessLogic()
    {
        Console.WriteLine("Я ({0}) загрузил новое видео", this.GetType().Name);
        this.NotifyObservers();
    }
}