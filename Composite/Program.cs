/*
 * СТРУКТУРНЫЙ ПАТТЕРН: КОМПОНОВЩИК "Composite"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем компонент университета
        Component university = new University("ГУАП");

        // Создаем компоненты институтов и добавляем их в университет
        Component institute_1 = new Institute("Институт #1"); university.Add(institute_1);
        Component institute_2 = new Institute("Институт #2"); university.Add(institute_2);
        Component institute_3 = new Institute("Институт #3"); university.Add(institute_3);
        Component institute_4 = new Institute("Институт #4"); university.Add(institute_4);
        Component institute_5 = new Institute("Институт #5"); university.Add(institute_5);
        Component institute_6 = new Institute("Институт #6"); university.Add(institute_6);
        Component institute_8 = new Institute("Институт #8"); university.Add(institute_8);

        // Создаем компоненты кафедр и добавляем их в соответствующие институты
        Component department_11 = new Department("Кафедра 11"); institute_1.Add(department_11);
        Component department_12 = new Department("Кафедра 12"); institute_1.Add(department_12);
        Component department_13 = new Department("Кафедра 13"); institute_1.Add(department_13);
        Component department_14 = new Department("Кафедра 14"); institute_1.Add(department_14);

        Component department_21 = new Department("Кафедра 21"); institute_2.Add(department_21);
        Component department_22 = new Department("Кафедра 22"); institute_2.Add(department_22);
        Component department_23 = new Department("Кафедра 23"); institute_2.Add(department_23);
        Component department_24 = new Department("Кафедра 24"); institute_2.Add(department_24);
        //Component department_25 = new Department("Кафедра 25");

        Component department_31 = new Department("Кафедра 31"); institute_3.Add(department_31);
        Component department_32 = new Department("Кафедра 32"); institute_3.Add(department_32);
        Component department_33 = new Department("Кафедра 33"); institute_3.Add(department_33);

        Component department_41 = new Department("Кафедра 41"); institute_4.Add(department_41);
        //Component department_42 = new Department("Кафедра 42");
        Component department_43 = new Department("Кафедра 43"); institute_4.Add(department_43);
        Component department_44 = new Department("Кафедра 44"); institute_4.Add(department_44);

        Component department_51 = new Department("Кафедра 51"); institute_5.Add(department_51); // => Кафедра 33
        Component department_52 = new Department("Кафедра 52"); institute_5.Add(department_52); // => Кафедра 25
        Component department_53 = new Department("Кафедра 53"); institute_5.Add(department_53); // => Кафедра 42

        Component department_61 = new Department("Кафедра 61"); institute_6.Add(department_61);
        Component department_62 = new Department("Кафедра 62"); institute_6.Add(department_62);
        Component department_63 = new Department("Кафедра 63"); institute_6.Add(department_63);
        Component department_64 = new Department("Кафедра 64"); institute_6.Add(department_64);

        Component department_81 = new Department("Кафедра 81"); institute_8.Add(department_81);
        Component department_82 = new Department("Кафедра 82"); institute_8.Add(department_82);
        Component department_83 = new Department("Кафедра 83"); institute_8.Add(department_83);
        Component department_84 = new Department("Кафедра 84"); institute_8.Add(department_84);
        Component department_85 = new Department("Кафедра 85"); institute_8.Add(department_85);

        // Создаем военную кафедру и добавляем ее напрямую в университет
        Component department_army = new Department("Военная кафедра"); university.Add(department_army);

        // Выводим на экран
        university.Print();
        Console.WriteLine();

        // Удаляем узел Институт 5, создаем и добавляем новые кафедры в соответствующие институты
        university.Delete(institute_5);
        Component department_25 = new Department("Кафедра 25"); institute_2.Add(department_25);
        Component department_42 = new Department("Кафедра 42"); institute_4.Add(department_42);

        // Выводим на экран
        university.Print();
    }
}

// Описание общего абстрактного класса или интерфейса для всех компонентов
abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public virtual void Add(Component component) { }

    public virtual void Delete(Component component) { }

    public virtual void Print()
    {
        Console.WriteLine(name);
    }
}

// Компонент Университет: может содержать другие компоненты, реализует функции для их добавления и удаления
class University : Component
{
    private List<Component> components = new List<Component>();

    public University(string name) : base(name) { }

    public override void Add(Component component)
    {
        components.Add(component);
    }

    public override void Delete(Component component)
    {
        components.Remove(component);
    }

    public override void Print()
    {
        Console.WriteLine("> " + name);
        for (int i = 0; i < components.Count; i++)
        {
            Console.Write("  > ");
            components[i].Print();
        }
    }
}

// Компонент Институт: может содержать другие компоненты, реализует функции для их добавления и удаления
class Institute : Component
{
    private List<Component> components = new List<Component>();

    public Institute(string name) : base(name) { }

    public override void Add(Component component)
    {
        components.Add(component);
    }

    public override void Delete(Component component)
    {
        components.Remove(component);
    }

    public override void Print()
    {
        Console.WriteLine(name);
        for (int i = 0; i < components.Count; i++)
        {
            Console.Write("    > ");
            components[i].Print();
        }
    }
}

// Компонент Кафедра: не может содержать внутри другие компоненты
class Department : Component
{
    public Department(string name) : base(name) { }
}