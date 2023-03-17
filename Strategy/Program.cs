/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: СТРАТЕГИЯ "Strategy"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем файл и выводим информацию о нем
        File file = new File("text", "pdf");
        Console.WriteLine(file.Name + "." + file.Format);

        // Создаем конвертер, указываем ему файл и тип конвертации, конвертируем, выводим информацию о файле
        Converter converter = new Converter();
        converter.CurrentFile = file;
        converter.ConversionType = new PdfToDoc();
        converter.Conversion();
        Console.WriteLine(file.Name + "." + file.Format);

        // Снова указываем конвертеру тип конвертации, конвертируем, выводим информацию о файле
        converter.ConversionType = new DocToTxt();
        converter.Conversion();
        Console.WriteLine(file.Name + "." + file.Format);

        // Снова указываем конвертеру тип конвертации, конвертируем, выводим информацию о файле
        converter.ConversionType = new DocToPdf();
        converter.Conversion();
        Console.WriteLine(file.Name + "." + file.Format);
    }
}

// Конвертируемый объект
class File
{
    public string Name { get; set; }
    public string Format { get; set; }

    public File(string name, string format = "")
    {
        this.Name = name;
        this.Format = format;
    }
}

// Реализация конвертера, хранит ссылку на объект стратегии
class Converter
{
    public File CurrentFile { private get; set; }
    public IConversion ConversionType { private get; set; }

    public void Conversion()
    {
        if (ConversionType != null && CurrentFile != null)
            ConversionType.Conversion(CurrentFile);
    }
}

// Абстрактное описание для всех стратегий
interface IConversion
{
    void Conversion(File file);
}

// Описание конкретной стратегии (перевод из PDF в DOC)
class PdfToDoc : IConversion
{
    public void Conversion(File file)
    {
        if (file.Format == "pdf")
        {
            Console.WriteLine("Файл {0} конвертирован из PDF в DOC", file.Name);
            file.Format = "doc";
        }
        else Console.WriteLine("Конвертация не удалась - файл не в формате PDF");
    }
}

// Описание конкретной стратегии (перевод из DOC в PDF)
class DocToPdf : IConversion
{
    public void Conversion(File file)
    {
        if (file.Format == "doc")
        {
            Console.WriteLine("Файл {0} конвертирован из DOC в PDF", file.Name);
            file.Format = "pdf";
        }
        else Console.WriteLine("Конвертация не удалась - файл не в формате DOC");
    }
}

// Описание конкретной стратегии (перевод из DOC в TXT)
class DocToTxt : IConversion
{
    public void Conversion(File file)
    {
        if (file.Format == "doc")
        {
            Console.WriteLine("Файл {0} конвертирован из DOC в TXT", file.Name);
            file.Format = "txt";
        }
        else Console.WriteLine("Конвертация не удалась - файл не в формате DOC");
    }
}