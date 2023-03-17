/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: ФАБРИЧНЫЙ МЕТОД "Factory Method"
 */

class Program
{
    static void Main(string[] args)
    {
        // Создаем кассира
        VkusnoITochka kassir = new RusVkusnoITochka(); // либо русского филиала
        //VkusnoITochka kassir = new KazVkusnoITochka(); // либо казахского филиала

        // Делаем заказ у кассира желаемого набора
        kassir.CreateOrder("premium");

        // Вывод информации о заказе
        Console.WriteLine("Вы заказали набор {0} в {1}:", kassir.Nabor, kassir.GetType().Name);
        if (kassir.DishsInNabor == null)
            Console.WriteLine(" - Такого набор нет в {0}.", kassir.GetType().Name);
        else
        {
            foreach (Dish dish in kassir.DishsInNabor)
                Console.WriteLine(" - {0} за {1}", dish.Name, dish.Price);
            Console.WriteLine();
        }
    }
}

// Описание абстрактного продукта
abstract class Dish
{
    public string Name { get; set; }
    public double Price { get; set; }
}

// Реализация конкретных продуктов
class RusBurger : Dish { public RusBurger() { Name = "Русский бургер"; Price = 149; } }

class RusNuggets : Dish { public RusNuggets() { Name = "Русские наггетсы"; Price = 228; } }

class RusDrink : Dish { public RusDrink() { Name = "Русский напиток"; Price = 59; } }

class KazBurger : Dish { public KazBurger() { Name = "Казахский бургер"; Price = 239; } }

class KazNuggets : Dish { public KazNuggets() { Name = "Казахские наггетсы"; Price = 195; } }

class KazDrink : Dish { public KazDrink() { Name = "Казахский напиток"; Price = 97; } }

// Описание абстрактного создателя
abstract class VkusnoITochka
{
    public string Nabor { get; set; } // Название набора
    public List<Dish> DishsInNabor; // Список блюд в наборе

    // Фабричный метод, который необходимо будет реализовать
    public abstract void CreateOrder(string nabor);
}

// Реализация конкретного создателя (русский филиал ВкусноИТочка)
class RusVkusnoITochka : VkusnoITochka
{
    // Добавляем блюда в зависимости от набора
    public override void CreateOrder(string nabor)
    {
        Nabor = nabor;
        switch (nabor)
        {
            case "only drink":
                DishsInNabor = new List<Dish> { new RusDrink() };
                break;
            case "standart":
                DishsInNabor = new List<Dish> { new RusBurger(), new RusDrink() };
                break;
            case "premium":
                DishsInNabor = new List<Dish> { new RusBurger(), new RusNuggets(), new RusDrink() };
                break;
        }
    }
}

// Реализация конкретного создателя (казахский филиал ВкусноИТочка)
class KazVkusnoITochka : VkusnoITochka
{
    public override void CreateOrder(string nabor)
    {
        Nabor = nabor;
        switch (nabor)
        {
            case "only drink":
                DishsInNabor = new List<Dish> { new KazDrink() };
                break;
            case "standart":
                DishsInNabor = new List<Dish> { new KazBurger(), new KazDrink() };
                break;
            case "standart child":
                DishsInNabor = new List<Dish> { new KazNuggets(), new KazDrink() };
                break;
        }
    }
}
