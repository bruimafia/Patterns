/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: ФАБРИЧНЫЙ МЕТОД "Factory Method"
 * Пример с формированием различных документов из разных страниц
 */

class Program
{
    static void Main(string[] args)
    {
        // Создаем коллекцию документов (пакет документов)
        // Добавляем в коллекцию резюме и доклад
        List<Document> my_documents = new List<Document> { new Resume(), new Report() };

        // Формируем документы методом CreatePages(), но они будут формироваться по-разному
        my_documents[0].CreatePages();
        my_documents[1].CreatePages();

        // Выводим на экран список документов и содержащихся в них страниц
        foreach (Document document in my_documents)
        {
            Console.WriteLine(document + " содержит в себе:");
            foreach (Page page in document.Pages)
                Console.WriteLine(" - " + page);
            Console.WriteLine();
        }

    }
}

// Описание абстрактного продукта (страница)
abstract class Page
{
    public override string ToString()
    {
        return this.GetType().Name;
    }
}

// Реализация конкретных продуктов (страниц)
class SkillsPage : Page { } // Страница Достижения

class EducationPage : Page { } // Страница Образование

class ExperiencePage : Page { } // Страница Опыт

class IntroductionPage : Page { } // Страница Введение

class SummaryPage : Page { } // Страница Сводная

class ResultsPage : Page { } // Страница Результаты

class ConclusionPage : Page { } // Страница Заключение

class BibliographyPage : Page { } // Страница Библиографическая


// Описание абстрактного создателя (документ)
abstract class Document
{
    // Список страниц в документе
    public List<Page> Pages { get; set; }

    // Фабричный метод, который необходимо будет реализовать
    public abstract void CreatePages();

    public override string ToString()
    {
        return this.GetType().Name;
    }
}

// Реализация конкретного создателя (резюме)
class Resume : Document
{
    public override void CreatePages()
    {
        // Добавляем страницы необходимые для резюме
        Pages = new List<Page>
            {
                new SkillsPage(),
                new EducationPage(),
                new ExperiencePage()
            };
    }
}

// Реализация конкретного создателя (доклад)
class Report : Document
{
    // Добавляем страницы необходимые для доклада
    public override void CreatePages()
    {
        Pages = new List<Page>
            {
                new IntroductionPage(),
                new ResultsPage(),
                new ConclusionPage(),
                new SummaryPage(),
                new BibliographyPage()
            };
    }
}
