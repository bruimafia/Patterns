/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: СТРОИТЕЛЬ "Builder"
 * Плохой пример с телескопическим конструктором и сеттерами (без применения паттерна Строитель)
 */

class Program
{
    private static void Main(string[] args)
    {
        // Вариант через телескопический конструктор
        Shaverma shaverma = new Shaverma("Острая", "Сырный", "Индейка", "Барбекю", true, false, false, true, true, false, true, false, true, true, false);
        shaverma.ToPrint();

        // Вариант через сеттеры
        Shaverma shaverma1 = new Shaverma("Индейка", "Барбекю", true, false, false, true, true, false, true, false, true, true, false);
        shaverma1.Name = "Своя";
        shaverma1.Lavash = "Чесночный";
        shaverma1.Sauce = "Острый";
        shaverma1.Carrot = true;
        shaverma1.Cucumber = false;
        shaverma1.Cheese = false;
        shaverma1.ToPrint();
    }
}

public class Shaverma
{
    public string Name { get; set; } // Название
    public string Lavash { get; set; } // Лаваш (обязательный параметр)
    public string Meat { get; set; } // Мясо (обязательный параметр)
    public string Sauce { get; set; } // Соус (обязательный параметр)
    public bool Cucumber { get; set; } = false; // Огурцы
    public bool Tomato { get; set; } = false; // Помидоры
    public bool Cabbage { get; set; } = false; // Капуста
    public bool Onion { get; set; } = false; // Лук
    public bool Carrot { get; set; } = false; // Морковь
    public bool Shrimp { get; set; } = false; // Креветки
    public bool Jalapeno { get; set; } = false; // Халапеньо
    public bool Cheese { get; set; } = false; // Сыр
    public bool Spices { get; set; } = false; // Специи
    public bool Adjika { get; set; } = false; // Аджика
    public bool Green { get; set; } = false; // Зелень

    public List<object> composition = new List<object>();

    public Shaverma(string name, string lavash, string meat, string sauce, bool cucumber, bool tomato, bool cabbage, bool onion, bool carrot, bool shrimp, bool jalapeno, bool cheese, bool spices, bool adjika, bool green)
    {
        this.Name = name;
        this.Lavash = lavash;
        this.Meat = meat;
        this.Sauce = sauce;
        this.Cucumber = cucumber;
        if (Cucumber) composition.Add("Огурцы");
        this.Tomato = tomato;
        if (Tomato) composition.Add("Помидоры");
        this.Cabbage = cabbage;
        if (Cabbage) composition.Add("Капуста");
        this.Onion = onion;
        if (Onion) composition.Add("Лук");
        this.Carrot = carrot;
        if (Carrot) composition.Add("Морковь");
        this.Shrimp = shrimp;
        if (Shrimp) composition.Add("Креветки");
        this.Jalapeno = jalapeno;
        if (Jalapeno) composition.Add("Халапеньо");
        this.Cheese = cheese;
        if (Cheese) composition.Add("Сыр");
        this.Spices = spices;
        if (Spices) composition.Add("Специи");
        this.Adjika = adjika;
        if (Adjika) composition.Add("Аджика");
        this.Green = green;
        if (Green) composition.Add("Зелень");
    }

    public Shaverma(string meat, string sauce, bool cucumber, bool tomato, bool cabbage, bool onion, bool carrot, bool shrimp, bool jalapeno, bool cheese, bool spices, bool adjika, bool green)
    {
        this.Name = "Стандартная";
        this.Lavash = "Обычный";
        this.Meat = meat;
        this.Sauce = sauce;
        this.Cucumber = cucumber;
        if (Cucumber) composition.Add("Огурцы");
        this.Tomato = tomato;
        if (Tomato) composition.Add("Помидоры");
        this.Cabbage = cabbage;
        if (Cabbage) composition.Add("Капуста");
        this.Onion = onion;
        if (Onion) composition.Add("Лук");
        this.Carrot = carrot;
        if (Carrot) composition.Add("Морковь");
        this.Shrimp = shrimp;
        if (Shrimp) composition.Add("Креветки");
        this.Jalapeno = jalapeno;
        if (Jalapeno) composition.Add("Халапеньо");
        this.Cheese = cheese;
        if (Cheese) composition.Add("Сыр");
        this.Spices = spices;
        if (Spices) composition.Add("Специи");
        this.Adjika = adjika;
        if (Adjika) composition.Add("Аджика");
        this.Green = green;
        if (Green) composition.Add("Зелень");
    }

    public void ToPrint()
    {
        Console.WriteLine("Шаверма {0}", Name);
        Console.WriteLine("Состав шавермы:");
        Console.WriteLine("Лаваш: {0}", Lavash);
        Console.WriteLine("Мясо: {0}", Meat);
        Console.WriteLine("Соус: {0}", Sauce);
        foreach (object o in composition)
            Console.WriteLine(" + " + o.ToString());
    }
}