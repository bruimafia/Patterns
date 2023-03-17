using System.Text;

/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: СТРОИТЕЛЬ "Builder"
 * Пример с директором (распорядителем)
 */

class Program
{
    static void Main(string[] args)
    {
        // Создаем директора и указываем строителя необходимой шавермы
        Director director = new Director(new VipShavermaBuilder());
        
        // Директор запускает создание шавермы
        Shaverma shaverma = director.CreateShaverma();

        Console.WriteLine(shaverma);
    }
}

// Директор по созданию шавермы
public class Director
{
    private Builder builder;

    public Director(Builder builder) { this.builder = builder; }

    public Shaverma CreateShaverma()
    {
        builder.SetName();
        builder.SetLavash();
        builder.SetDobavki();
        builder.SetSouce();
        return builder.Build();
    }
}

// Описание шавермы
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
        str.Append("Состав шавермы" + "\n");
        foreach (object o in composition)
        {
            str.Append(" + " + o.ToString() + " \n");
        }

        return str.ToString();
    }
}

// Описание абстрактного строителя шавермы
public abstract class Builder
{
    public abstract void SetName();
    public abstract void SetLavash();
    public abstract void SetDobavki();
    public abstract void SetSouce();
    public abstract Shaverma Build();
}

// Реализация стандартной шавермы
public class StandartShavermaBuilder : Builder
{
    private Shaverma current_shaverma;

    public StandartShavermaBuilder() { current_shaverma = new Shaverma(); }

    public override void SetName()
    {
        current_shaverma.composition.Add("Шаверма Стандартная");
        current_shaverma.Name = "Стандартная";
    }

    public override void SetLavash()
    {
        current_shaverma.composition.Add("Лаваш: Обычный");
        current_shaverma.Lavash = "Обычный";
    }

    public override void SetDobavki()
    {
        current_shaverma.composition.Add("Мясо: Курица");
        current_shaverma.Meat = "Курица";
        current_shaverma.composition.Add("Огурцы");
        current_shaverma.Cucumber = true;
        current_shaverma.composition.Add("Капуста");
        current_shaverma.Cabbage = true;
        current_shaverma.composition.Add("Помидоры");
        current_shaverma.Tomato = true;
        current_shaverma.composition.Add("Лук");
        current_shaverma.Onion = true;
        current_shaverma.composition.Add("Зелень");
        current_shaverma.Green = true;
    }

    public override void SetSouce()
    {
        current_shaverma.composition.Add("Соус: Обычный");
        current_shaverma.Sauce = "Обычный";
    }

    public override Shaverma Build()
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

// Реализация острой шавермы
public class SpicyShavermaBuilder : Builder
{
    private Shaverma current_shaverma;

    public SpicyShavermaBuilder() { current_shaverma = new Shaverma(); }

    public override void SetName()
    {
        current_shaverma.composition.Add("Шаверма Острая");
        current_shaverma.Name = "Острая";
    }

    public override void SetLavash()
    {
        current_shaverma.composition.Add("Лаваш: Чесночный");
        current_shaverma.Lavash = "Чесночный";
    }

    public override void SetDobavki()
    {
        current_shaverma.composition.Add("Мясо: Курица");
        current_shaverma.Meat = "Курица";
        current_shaverma.composition.Add("Огурцы");
        current_shaverma.Cucumber = true;
        current_shaverma.composition.Add("Помидоры");
        current_shaverma.Tomato = true;
        current_shaverma.composition.Add("Морковь");
        current_shaverma.Carrot = true;
        current_shaverma.composition.Add("Лук");
        current_shaverma.Onion = true;
        current_shaverma.composition.Add("Халапеньо");
        current_shaverma.Jalapeno = true;
        current_shaverma.composition.Add("Специи");
        current_shaverma.Spices = true;
        current_shaverma.composition.Add("Аджика");
        current_shaverma.Adjika = true;
    }

    public override void SetSouce()
    {
        current_shaverma.composition.Add("Соус: Чесночный");
        current_shaverma.Sauce = "Чесночный";
    }

    public override Shaverma Build()
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

// Реализация Vip шавермы
public class VipShavermaBuilder : Builder
{
    private Shaverma current_shaverma;

    public VipShavermaBuilder() { current_shaverma = new Shaverma(); }

    public override void SetName()
    {
        current_shaverma.composition.Add("Шаверма Vip");
        current_shaverma.Name = "Vip";
    }

    public override void SetLavash()
    {
        current_shaverma.composition.Add("Лаваш: Собственный");
        current_shaverma.Lavash = "Собственный";
    }

    public override void SetDobavki()
    {
        current_shaverma.composition.Add("Мясо: Индейка");
        current_shaverma.Meat = "Индейка";
        current_shaverma.composition.Add("Огурцы");
        current_shaverma.Cucumber = true;
        current_shaverma.composition.Add("Помидоры");
        current_shaverma.Tomato = true;
        current_shaverma.composition.Add("Морковь");
        current_shaverma.Carrot = true;
        current_shaverma.composition.Add("Сыр");
        current_shaverma.Cheese = true;
        current_shaverma.composition.Add("Креветки");
        current_shaverma.Shrimp = true;
        current_shaverma.composition.Add("Лук");
        current_shaverma.Onion = true;
        current_shaverma.composition.Add("Халапеньо");
        current_shaverma.Jalapeno = true;
        current_shaverma.composition.Add("Специи");
        current_shaverma.Spices = true;
        current_shaverma.composition.Add("Зелень");
        current_shaverma.Green = true;
    }

    public override void SetSouce()
    {
        current_shaverma.composition.Add("Соус: Смесь");
        current_shaverma.Sauce = "Смесь";
    }

    public override Shaverma Build()
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