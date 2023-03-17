/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: ОДИНОЧКА "Singleton"
 */

class Program
{
    static void Main(string[] args)
    {
        // Пытаемся создать два объекта класса одиночки
        Rector rector1 = Rector.GetInstance();
        Rector rector2 = Rector.GetInstance();

        // Сравниваем объекты и убеждаемся, что они абсолютно одинаковые
        if (rector1 == rector2)
            Console.WriteLine("Объекты rector1 и rector2 абсолютно одинаковые");
        else
            Console.WriteLine("Объекты rector1 и rector2 разные");
    }
}

// Класс Rector является Одиночкой 
// Он предоставляет метод GetInstance(), который ведёт себя как альтернативный конструктор и 
// позволяет клиентам получать один и тот же экземпляр класса при каждом вызове
sealed class Rector
{
    private static Rector _instance; // Статическое поле собственного типа

    // Конструктор всегда должен быть приватным, чтобы предотвратить создание объекта через оператор new
    private Rector() { }

    // Статический метод, управляющий доступом к экземпляру класса
    // При первом запуске - создается экземпляр класса 
    // При последующих запусках - возвращается объект, хранящийся в статическом поле _instance
    public static Rector GetInstance()
    {
        if (_instance == null)
            _instance = new Rector();

        return _instance;
    }

    // Разумеется, скорее всего будет присутствовать какая-то бизнес-логика в других функциях
    public void SomeBusinessLogic()
    {
        // Некоторая бизнес-логика
    }
}
