/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: ОДИНОЧКА "Singleton" (потокобезопасный вариант)
 */

class Program
{
    static void Main(string[] args)
    {
        /* НЕБОЛЬШОЕ ОТСТУПЛЕНИЕ */
        // КАК СОЗДАВАТЬ ДРУГИЕ ПОТОКИ
        Console.WriteLine("Главный поток запущен");
        Thread alternative = new Thread(() => Thread.Sleep(5000)); // Задача альтернативного потока спать 5 секунд
        alternative.Start(); // Стартуем альтернативный поток
        alternative.Join(); // Ждем пока выполнятся все действия в альтернативном потоке
        Console.WriteLine("Поток alternative завершен"); // Надпись выведется через 5 секунд
        /* НЕБОЛЬШОЕ ОТСТУПЛЕНИЕ */

        // Пытаемся создать объекты класса одиночки в разных потоках
        Thread alternative1 = new Thread(() =>
        {
            Test_RectorMultiThread("Объект был создан потоком alternative1");
        });
        Thread alternative2 = new Thread(() =>
        {
            Test_RectorMultiThread("Объект был создан потоком alternative2");
        });

        alternative1.Start();
        alternative2.Start();

        alternative1.Join();
        alternative2.Join();
    }

    // Тестирование потоков: попытка создать объект одиночки и вывод его значения Value на экран
    public static void Test_RectorMultiThread(string value)
    {
        RectorMultiThread rector = RectorMultiThread.GetInstance(value);
        Console.WriteLine(rector.Value);
    }
}

sealed class RectorMultiThread
{
    private static readonly object _lock = new object(); // Объект-блокировка для синхронизации потоков во время первого доступа к Одиночке
    public string Value { get; set; } // Используем поле, чтобы доказать, что Одиночка действительно работает

    private static RectorMultiThread _instance; // Статическое поле собственного типа

    // Конструктор всегда должен быть приватным, чтобы предотвратить создание объекта через оператор new
    private RectorMultiThread() { }

    // Статический метод, управляющий доступом к экземпляру класса
    public static RectorMultiThread GetInstance(string value)
    {
        // Дополнительное условие для того, чтобы не останавливать потоки блокировкой после того, как объект уже создан
        if (_instance == null)
        {
            // Представьте, что программа была только-только запущена. 
            // Объект ещё никто не создавал, поэтому несколько потоков вполне могли одновременно
            // пройти через предыдущее условие и достигнуть блокировки. 
            // Самый быстрый поток поставит блокировку и двинется внутрь секции,
            // пока другие будут здесь его ожидать
            lock (_lock)
            {
                // Первый поток проходит внутрь и создает объект.
                // Как только этот поток покинет секцию и освободит блокировку, 
                // следующий поток может снова установить блокировку и зайти внутрь.
                // Однако теперь экземпляр одиночки уже будет создан и поток не сможет
                // пройти через это условие, а значит новый объект не будет создан
                if (_instance == null)
                {
                    _instance = new RectorMultiThread();
                    _instance.Value = value;
                }
            }
        }

        return _instance;
    }

    // Разумеется, скорее всего будет присутствовать какая-то бизнес-логика в других функциях
    public void SomeBusinessLogic()
    {
        // некоторая бизнес-логика
    }
}
