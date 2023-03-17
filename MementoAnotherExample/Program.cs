/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: ХРАНИТЕЛЬ / СНИМОК "Memento"
 * Пример с GitHub
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объекты проекта и репозитория
        Project some_project = new Project("Некоторый проект");
        Repository git = new Repository();

        // Выполняем действия над проектом
        some_project.CreateFile("Class1.cs");
        some_project.CreateFile("Class2.cs");
        some_project.CreateFile("Class3.cs");
        some_project.AboutProject();

        // Решаем, что нужно закоммитить проект на git
        git.Push(some_project.CommitToGit());

        // Выполняем действия над проектом
        some_project.CreateFile("Class4.cs");
        some_project.DeleteFile("Class3.cs");
        some_project.AboutProject();

        // Проект сломался, решаем восстановить последний коммит (последнюю версию проекта)
        some_project.RecoverFromGit(git.RecoverLastCommit());
        some_project.AboutProject();

        // Выполняем действия над проектом
        some_project.CreateFile("Class5.cs");
        some_project.CreateFile("Class6.cs");
        some_project.AboutProject();
    }
}

// Объект Originator (проект) - создает объект хранителя для сохранения своего состояния
class Project
{
    public string Name { get; set; }
    private List<string> files;

    public Project(string name)
    {
        this.Name = name;
        files = new List<string>();
    }

    public void CreateFile(string file)
    {
        files.Add(file);
        Console.WriteLine("Файл {0} создан", file);
    }

    public void DeleteFile(string file)
    {
        files.Remove(file);
        Console.WriteLine("Файл {0} удален", file);
    }

    public void AboutProject()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Файлы в проекте: ");
        foreach (string file in files)
            Console.Write("{0} | ", file);
        Console.ResetColor();
        Console.WriteLine();
    }

    // Сохраняем состояние проекта
    public Commit CommitToGit()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Отправка проекта на Git... -> Количество файлов {0}", files.Count);
        Console.ResetColor();
        return new Commit(files);
    }

    // Восстанавливаем состояние проекта
    public void RecoverFromGit(Commit commit)
    {
        this.files = commit.Files.ToList();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Проект восстановлен -> Количество файлов {0}", files.Count);
        Console.ResetColor();
    }
}

// Объкт Memento (хранитель, копия) - создает объект с сохраненным состоянием Originator (проекта)
class Commit
{
    public List<string> Files { get; private set; }

    public Commit(List<string> files)
    {
        this.Files = files.ToList();
    }
}

// Объект Caretaker (история сохранений проекта) - хранит объекы Memento (сохраненные версии проекта)
class Repository
{
    public List<Commit> Commits { get; private set; }

    public Repository()
    {
        Commits = new List<Commit>();
    }

    public void Push(Commit commit)
    {
        Commits.Add(commit);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Проект загружен на Git");
        Console.ResetColor();
    }

    public Commit RecoverCommit(int index)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Восстановление проекта...");
        Console.ResetColor();
        return Commits[index];
    }

    public Commit RecoverLastCommit()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Восстановление проекта из последнего коммита...");
        Console.ResetColor();
        return Commits.Last();
    }
}