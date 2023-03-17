/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: ИТЕРАТОР "Iterator"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объекты группы и итератора
        Group group = new Group();
        IStudentIterator student_iterator = group.CreateIterator();

        // Перебираем объекты
        while (student_iterator.HasNext())
        {
            Student student = student_iterator.Next();
            Console.WriteLine("{0}, {1} лет", student.Name, student.Age);
        }
    }
}

// Хранящиеся объекты
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// Абстрактное описание интерфейса для создания объекта-итератора
interface IStudentNumerable
{
    IStudentIterator CreateIterator();
    int Count { get; }
    Student this[int index] { get; }
}

// Конкретная реализация IStudentNumerable, хранит элементы, которые надо будет перебирать
class Group : IStudentNumerable
{
    private List<Student> students;

    public Group()
    {
        students = new List<Student>
        {
            new Student {Name="Сергей", Age=18},
            new Student {Name="Олег", Age=21},
            new Student {Name="Марина", Age=19},
            new Student {Name="Елена", Age=17},
            new Student {Name="Владислав", Age=20}
        };
    }

    public IStudentIterator CreateIterator()
    {
        return new GroupIterator(this);
    }

    public int Count
    {
        get { return students.Count; }
    }

    public Student this[int index]
    {
        get { return students[index]; }
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }
}

// Абстрактное описание интерфейса для обхода составных объектов
interface IStudentIterator
{
    bool HasNext();
    Student First();
    Student Next();
}

// Конкретная реализация итератора для обхода объектов Student
class GroupIterator : IStudentIterator
{
    private IStudentNumerable numerable;
    private int index = 0;

    public GroupIterator(IStudentNumerable numerable)
    {
        this.numerable = numerable;
    }

    public bool HasNext()
    {
        return index < numerable.Count;
    }

    public Student First()
    {
        return numerable[0];
    }

    public Student Next()
    {
        return numerable[index++];
    }
}