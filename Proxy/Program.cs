/*
 * СТРУКТУРНЫЙ ПАТТЕРН: ЗАМЕСТИТЕЛЬ "Proxy"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объект заместителя, будем работать с ним
        IInternet internet = new InternetProxy();

        // Переходим на первую страницу
        InternetPage request = internet.GoToPage("www.ya.ru");
        Console.WriteLine(request.Name);

        // Переходим на вторую страницу
        request = internet.GoToPage("www.vk.com");
        Console.WriteLine(request.Name);

        // Переходим (возвращаемся) опять на первую страницу   
        request = internet.GoToPage("www.ya.ru");
        Console.WriteLine(request.Name);
    }
}

// Объекты, с которыми работают классы
class InternetPage
{
    public string URL { get; set; }
    public string Name { get; set; }

    public InternetPage(string url, string name)
    {
        this.URL = url;
        this.Name = name;
    }
}

// Общий интерфейс или абстрактный класс для реального класса и класса заместителя
interface IInternet
{
    InternetPage GoToPage(string link);
}

// Реальный класс, для которого создается прокси
class Internet : IInternet
{
    private List<InternetPage> pages = new List<InternetPage>
    {
        new InternetPage("www.vk.com", "ВКонтакте"),
        new InternetPage("www.ok.com", "Одноклассники"),
        new InternetPage("www.ya.ru", "Яндекс"),
        new InternetPage("www.google.ru", "Google"),
        new InternetPage("www.gosuslugi.ru", "Госуслуги")
    };

    public InternetPage GoToPage(string link)
    {
        return pages.FirstOrDefault(p => p.URL == link);
    }
}

// Класс заместитель реального класса
// Хранит ссылку на объект реального класса (может управлять его созданием и удалением)
// При необходимости InternetProxy переадресует запросы объекту реального класса Internet
class InternetProxy : IInternet
{
    private Internet internet;

    public List<InternetPage> pages = new List<InternetPage>();

    public InternetPage GoToPage(string link)
    {
        InternetPage page = pages.FirstOrDefault(p => p.URL == link);
        if (page == null)
        {
            if (internet == null)
                internet = new Internet();
            page = internet.GoToPage(link);
            pages.Add(page);
        }
        else Console.Write("Загружено из кэша -> ");

        return page;
    }
}