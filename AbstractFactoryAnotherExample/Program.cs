/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: АБСТРАКТНАЯ ФАБРИКА "Abstract Factory"
 * Пример с созданием образа из разных деталей одежды 
 */

class Program
{
    static void Main(string[] args)
    {
        // Вызов фабрики по производству спортивного образа и создание образа
        IStyle factory1 = new SportStyle();
        Look look1 = new Look(factory1);
        look1.Info();

        Console.WriteLine();

        // Вызов фабрики по производству делового образа и создание образа
        IStyle factory2 = new BusinessStyle();
        Look look2 = new Look(factory2);
        look2.Info();
    }
}

// Реализация клиента, в данном случае обозначает формирование образа в одежде
class Look
{
    private ITop top;  // Любой образ состоит из верхней части одежды
    private IBottom bottom; // Любой образ состоит из нижней части одежды
    private IShoes shoes; // Любой образ состоит из обуви

    private IStyle style;

    public Look(IStyle style)
    {
        this.style = style;

        top = style.CreateTop();
        bottom = style.CreateBottom();
        shoes = style.CreateShoes();
    }

    public void Info()
    {
        Console.WriteLine("Создан образ {0}", style.GetType().Name);
        Console.WriteLine("Образ состоит из:\n - {0}\n - {1}\n - {2}", top.GetType().Name, bottom.GetType().Name, shoes.GetType().Name);
    }
}

// Описание абстрактной верхней детали одежды и конкретных верхних деталей (пиджак и футболка)
interface ITop { }
class Jacket : ITop { }
class T_Shirt : ITop { }

// Описание абстрактной нижней детали одежды и конкретных нижних деталей (брюки и шорты)
interface IBottom { }
class Trousers : IBottom { }
class Shorts : IBottom { }

// Описание абстрактной обуви как элемента гардероба и конкретной обуви (кроссовки и ботинки)
interface IShoes { }
class Sneakers : IShoes { }
class BusinessShoes : IShoes { }

// Описание абстрактной фабрики по созданию образа
interface IStyle
{
    ITop CreateTop();
    IBottom CreateBottom();
    IShoes CreateShoes();
}

// Реализация конкретной фабрики по созданию спортивного образа
class SportStyle : IStyle
{
    public ITop CreateTop()
    {
        return new T_Shirt();
    }

    public IBottom CreateBottom()
    {
        return new Shorts();
    }

    public IShoes CreateShoes()
    {
        return new Sneakers();
    }
}

// Реализация конкретной фабрики по созданию делового образа
class BusinessStyle : IStyle
{
    public ITop CreateTop()
    {
        return new Jacket();
    }

    public IBottom CreateBottom()
    {
        return new Trousers();
    }

    public IShoes CreateShoes()
    {
        return new BusinessShoes();
    }
}