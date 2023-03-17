/*
 * СТРУКТУРНЫЙ ПАТТЕРН: ФАСАД "Facade"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Работа с товаром без фасада
        /*
        ProductDB productDB = new ProductDB();
        DiscountDB discountDB = new DiscountDB();
        ShoppingList shoppingList = new ShoppingList();
        string product = "Молоко";
        
        if (productDB.SearchProduct(product))
        {
            discountDB.SearchProduct(product);
            shoppingList.Add(product);
            productDB.ReduceCountProduct(product);
        }
        shoppingList.Show();
        
        string product1 = "Сосиски";
        if (productDB.SearchProduct(product1))
        {
            discountDB.SearchProduct(product1);
            shoppingList.Add(product1);
            productDB.ReduceCountProduct(product1);
        }
        shoppingList.Show();

        string product2 = "Сидр";
        if (productDB.SearchProduct(product2))
        {
            discountDB.SearchProduct(product2);
            shoppingList.Add(product2);
            productDB.ReduceCountProduct(product2);
        }
        shoppingList.Show();
        */
        
        // Создаем объект фасада
        KassirFacade kassir = new KassirFacade();

        // Отправляем фададу на обработку товары
        kassir.Processing("Молоко");
        kassir.Processing("Сосиски");
        kassir.Processing("Сидр");

        // Выводим список покупок
        Console.WriteLine();
        kassir.ShowShoppingList();
    }
}

// Класс-фасад, который предоставляет интерфейс для работы с компонентами сложной системы
class KassirFacade
{
    private ProductDB productDB;
    private DiscountDB discountDB;
    private ShoppingList shoppingList;

    public KassirFacade()
    {
        this.productDB = new ProductDB();
        this.discountDB = new DiscountDB();
        this.shoppingList = new ShoppingList();
    }

    public void Processing(string product)
    {
        if (productDB.SearchProduct(product))
        {
            discountDB.SearchProduct(product);
            shoppingList.Add(product);
            productDB.ReduceCountProduct(product);
        }
    }

    public void ShowShoppingList()
    {
        Console.WriteLine("Вы купили следующие товары:");
        shoppingList.Show();
    }
}

// Компонент сложной системы, явлющийся самостоятельным компонентом (база товаров)
class ProductDB
{
    private List<string> products = new List<string> { "Молоко", "Кефир", "Сосиски", "Картошка", "Добрый Кола" };

    public bool SearchProduct(string product)
    {
        if (products.FirstOrDefault(p => p == product) == null)
        {
            Console.WriteLine("Товар \"{0}\" не найден в магазине", product);
            return false;
        }

        return true;
    }

    public void ReduceCountProduct(string product) { products.Remove(product); }
}

// Компонент сложной системы, явлющийся самостоятельным компонентом (база скидок)
class DiscountDB
{
    private List<string> discount_products = new List<string> { "Сосиски", "Добрый Кола" };

    public void SearchProduct(string product)
    {
        if (discount_products.FirstOrDefault(p => p == product) == null)
            Console.WriteLine("На товар \"{0}\" нет скидки", product);
        else
            Console.WriteLine("На товар \"{0}\" скидка 10%", product);
    }
}

// Компонент сложной системы, явлющийся самостоятельным компонентом (список покупок)
class ShoppingList
{
    private List<string> shoping_products = new List<string>();

    public void Add(string product) { shoping_products.Add(product); }

    public void Delete(string product) { shoping_products.Remove(product); }

    public void Show()
    {
        foreach (string product in shoping_products)
            Console.WriteLine(" - " + product);
    }
}