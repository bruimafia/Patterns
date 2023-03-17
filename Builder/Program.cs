using System.Text;

/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: СТРОИТЕЛЬ "Builder"
 */

class Program
{
    static void Main(string[] args)
    {
        // Создаем шаверму через строителя с необходимыми ингредиентами
        Shaverma shaverma = new ShavermaBuilder()
            .TypeLavash("Сырный")
            .TypeMeat("Курица")
            .TypeSauce("Чесночный")
            .AddAdjika()
            .AddCheese()
            .AddGreen()
            .build();

        Console.WriteLine(shaverma);
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

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append("Состав шавермы:" + "\n");
        foreach (object o in composition)
        {
            str.Append(" + " + o.ToString() + " \n");
        }

        return str.ToString();
    }
}

public class ShavermaBuilder
{
    private Shaverma current_shaverma;

    public ShavermaBuilder() { current_shaverma = new Shaverma(); }

    public ShavermaBuilder Type(string name)
    {
        current_shaverma.composition.Add("Шаверма " + name);
        current_shaverma.Name = name;
        return this;
    }

    public ShavermaBuilder TypeLavash(string lavash)
    {
        current_shaverma.composition.Add("Лаваш: " + lavash);
        current_shaverma.Lavash = lavash;
        return this;
    }

    public ShavermaBuilder TypeMeat(string meat)
    {
        current_shaverma.composition.Add("Мясо: " + meat);
        current_shaverma.Meat = meat;
        return this;
    }

    public ShavermaBuilder TypeSauce(string sauce)
    {
        current_shaverma.composition.Add("Соус: " + sauce);
        current_shaverma.Sauce = sauce;
        return this;
    }

    public ShavermaBuilder AddCucumber()
    {
        current_shaverma.composition.Add("Огурцы");
        current_shaverma.Cucumber = true;
        return this;
    }

    public ShavermaBuilder AddTomato()
    {
        current_shaverma.composition.Add("Помидоры");
        current_shaverma.Tomato = true;
        return this;
    }

    public ShavermaBuilder AddCabbage()
    {
        current_shaverma.composition.Add("Капуста");
        current_shaverma.Cabbage = true;
        return this;
    }

    public ShavermaBuilder AddOnion()
    {
        current_shaverma.composition.Add("Лук");
        current_shaverma.Onion = true;
        return this;
    }

    public ShavermaBuilder AddCarrot()
    {
        current_shaverma.composition.Add("Морковь");
        current_shaverma.Carrot = true;
        return this;
    }

    public ShavermaBuilder AddShrimp()
    {
        current_shaverma.composition.Add("Креветки");
        current_shaverma.Shrimp = true;
        return this;
    }

    public ShavermaBuilder AddJalapeno()
    {
        current_shaverma.composition.Add("Халапеньо");
        current_shaverma.Jalapeno = true;
        return this;
    }

    public ShavermaBuilder AddCheese()
    {
        current_shaverma.composition.Add("Сыр");
        current_shaverma.Cheese = true;
        return this;
    }

    public ShavermaBuilder AddSpices()
    {
        current_shaverma.composition.Add("Специи");
        current_shaverma.Spices = true;
        return this;
    }

    public ShavermaBuilder AddAdjika()
    {
        current_shaverma.composition.Add("Аджика");
        current_shaverma.Adjika = true;
        return this;
    }

    public ShavermaBuilder AddGreen()
    {
        current_shaverma.composition.Add("Зелень");
        current_shaverma.Green = true;
        return this;
    }

    public Shaverma build()
    {
        if (ValidateShaverma())
            return current_shaverma;
        else
            Console.WriteLine("Шаверма не может быть создана без обязательных параметров");

        return null;
    }

    private bool ValidateShaverma()
    {
        return (current_shaverma.Lavash != null && current_shaverma.Lavash != "") &&
            (current_shaverma.Meat != null && current_shaverma.Meat != "") &&
            (current_shaverma.Sauce != null && current_shaverma.Sauce != "");
    }
}