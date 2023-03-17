/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: АБСТРАКТНАЯ ФАБРИКА "Abstract Factory"
 */

class Program
{
    static void Main(string[] args)
    {
        // Работа кокретной фабрики 1
        AbstractFactory factory1 = new ConcreteFactory1();
        Client client1 = new Client(factory1);
        client1.Run();

        Console.WriteLine();

        // Работа конкретной фабрики 2
        AbstractFactory factory2 = new ConcreteFactory2();
        Client client2 = new Client(factory2);
        client2.Run();
    }
}

// Описание абстрактной фабрики
abstract class AbstractFactory
{
    public AbstractFactory() { Console.WriteLine("Фабрика {0} запущена", this.GetType().Name); }

    public abstract AbstractProductA CreateProductA();

    public abstract AbstractProductB CreateProductB();
}

// Реализация первой конкретной фабрики
class ConcreteFactory1 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }

    public override AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

// Реализация первой конкретной фабрики
class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }

    public override AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}

// Описание абстрактного продукта А
abstract class AbstractProductA
{
    public AbstractProductA() { Console.WriteLine("Продукт {0} создан", this.GetType().Name); }
}

// Описание абстрактного продукта В
abstract class AbstractProductB
{
    public AbstractProductB() { Console.WriteLine("Продукт {0} создан", this.GetType().Name); }

    public abstract void Interact(AbstractProductA a);
}

// Реализация кокретного продукта А первой разновидности А1
class ProductA1 : AbstractProductA { }

// Реализация кокретного продукта А второй разновидности А2
class ProductA2 : AbstractProductA { }

// Реализация кокретного продукта В первой разновидности В1
class ProductB1 : AbstractProductB
{
    public override void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name + " взаимодействует с " + a.GetType().Name);
    }
}

// Реализация кокретного продукта В первой разновидности В2
class ProductB2 : AbstractProductB
{
    public override void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name + " взаимодействует с " + a.GetType().Name);
    }
}

// Реализация клиента для работы с классом фабрики для создания продуктов
class Client
{
    private AbstractProductA abstractProductA;
    private AbstractProductB abstractProductB;

    public Client(AbstractFactory factory)
    {
        abstractProductA = factory.CreateProductA();
        abstractProductB = factory.CreateProductB();
    }

    public void Run()
    {
        abstractProductB.Interact(abstractProductA);
    }
}