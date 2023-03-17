/*
 * СТРУКТУРНЫЙ ПАТТЕРН: ДЕКОРАТОР "Decorator"
 * Пример с комплектациями и типами машин
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем машину Седан
        Car car = new Sedan();
        car.PrintInfo();

        // Добавляем оборудование из версии Комфорт
        car = new ComfortVersion(car);
        car.PrintInfo();

        // Добавляем оборудование из версии Люкс
        car = new LuxuryVersion(car);
        car.PrintInfo();
    }
}

// Абстрактный класс, описывающий машину
abstract class Car
{
    public string Name { get; set; }
    public string Version { get; set; }

    public List<string> equipment = new List<string>();

    public Car(string name)
    {
        this.Name = name;
        this.Version = "[базовая]";
        this.equipment.Add("Климат-контроль");
        this.equipment.Add("Подогрев передних седений");
        this.equipment.Add("Омыватель фар");
        this.equipment.Add("ABS – антиблокировочная тормозная система");
    }

    public void PrintInfo()
    {
        Console.WriteLine(this.Name + " " + this.Version);
        foreach (string part in equipment)
            Console.WriteLine(" - " + part);
    }
}

// Класс, описывающий машину Седан
class Sedan : Car
{
    public Sedan() : base("Седан") { }
}

// Класс, описывающий машину Хэтчбек
class Hatchback : Car
{
    public Hatchback() : base("Хэтчбек") { }
}

// Класс, описывающий машину Универсал
class Wagon : Car
{
    public Wagon() : base("Универсал") { }
}

// Абстрактный класс декоратор - имеет тот же базовый класс, что и декорируемые объекты
abstract class VersionDecorator : Car
{
    // Класс декоратора также хранит ссылку на декорируемый объект
    protected Car car;

    public VersionDecorator(Car car, string name) : base(name)
    {
        this.car = car;
    }
}

// Класс Комплектация Комфорт представляет дополнительную функциональность для декорируемого объекта
class ComfortVersion : VersionDecorator
{
    public ComfortVersion(Car car) : base(car, car.Name)
    {
        this.Version = "[комфорт]";
        equipment.Add("EBA – электронная система усиления экстренного торможения");
        equipment.Add("TCS – противобуксовочная система");
        equipment.Add("Боковые шторки безопасности");
        equipment.Add("Электропривод складывания боковых зеркал");
    }
}

// Класс Комплектация Люкс представляет дополнительную функциональность для декорируемого объекта
class LuxuryVersion : VersionDecorator
{
    public LuxuryVersion(Car car) : base(car, car.Name)
    {
        this.Version = "[люкс]";
        equipment.Add("EBA – электронная система усиления экстренного торможения");
        equipment.Add("TCS – противобуксовочная система");
        equipment.Add("Боковые шторки безопасности");
        equipment.Add("Электропривод складывания боковых зеркал");
        equipment.Add("DSC – система динамической стабилизации");
        equipment.Add("Apple CarPlay и Android Auto");
        equipment.Add("Датчик дождя и света");
    }
}