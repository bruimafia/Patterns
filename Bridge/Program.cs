/*
 * СТРУКТУРНЫЙ ПАТТЕРН: МОСТ "Bridge"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объект преподавателя и говорим ему проводить пары по Основам программирования
        Teacher teacher = new Assistant(new OsnovyProgrammirovaniya());
        teacher.DoLaboratory();
        teacher.DoPractice();
        teacher.DoLecture();

        // Теперь говорим нашему преподавателю проводить пары по Физике
        teacher.SetSubject(new Fizika());
        teacher.DoLaboratory();
        teacher.DoPractice();
        teacher.DoLecture();
    }
}

// Описывает базовый класс и хранит ссылку на объект Subject (Предмет)
// Выполнение операций делегируется методам объекта Subject (Предмет)
abstract class Teacher
{
    protected Subject subject;

    public Teacher(Subject subject)
    {
        this.subject = subject;
    }

    public void SetSubject(Subject subject)
    {
        this.subject = subject;
    }

    public virtual void DoLecture() { Console.Write(this.subject.GetType().Name + " | Лекция -> "); }

    public virtual void DoLaboratory() { Console.Write(this.subject.GetType().Name + " | Лабораторная -> "); }

    public virtual void DoPractice() { Console.Write(this.subject.GetType().Name + " | Практика -> "); }
}

// Конкретная реализация класса Teacher
class Assistant : Teacher
{
    public Assistant(Subject subject) : base(subject) { }

    public override void DoLaboratory()
    {
        base.DoLaboratory();
        this.subject.Laboratory();
    }

    public override void DoLecture()
    {
        base.DoLecture();
        Console.WriteLine("Ассистент не может проводить лекции");
    }

    public override void DoPractice()
    {
        base.DoPractice();
        this.subject.Practice();
    }
}

// Конкретная реализация класса Teacher
class Professor : Teacher
{
    public Professor(Subject subject) : base(subject) { }

    public override void DoLaboratory()
    {
        base.DoLaboratory();
        this.subject.Laboratory();
    }

    public override void DoLecture()
    {
        base.DoLecture();
        this.subject.Lecture();
    }

    public override void DoPractice()
    {
        base.DoPractice();
        this.subject.Practice();
    }
}

// Описывает базовый класс для конкретных реализаций
abstract class Subject
{
    public abstract void Lecture();
    public abstract void Laboratory();
    public abstract void Practice();
}

// Конкретная реализация класса Subject
class OsnovyProgrammirovaniya : Subject
{
    public override void Laboratory()
    {
        Console.WriteLine("Работаем за компьютерами, пишем лабы");
    }

    public override void Lecture()
    {
        Console.WriteLine("Изучаем язык программирования");
    }

    public override void Practice()
    {
        Console.WriteLine("Отрабатываем навыки программирования, решаем алгоритмические задачи");
    }
}

// Конкретная реализация класса Subject
class Fizika : Subject
{
    public override void Laboratory()
    {
        Console.WriteLine("Работаем с оборудованием, снимаем показания");
    }

    public override void Lecture()
    {
        Console.WriteLine("Изучаем физические законы и явления");
    }

    public override void Practice()
    {
        Console.WriteLine("Решаем задачи");
    }
}