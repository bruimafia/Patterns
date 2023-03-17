/*
 * ПОРОЖДАЮЩИЙ ПАТТЕРН: ПРОТОТИП "Prototype"
 * Пример с бактериями: каждые несколько секунд бактерии растут, а также каждые несколько секунд появляется новая бактерия такого же (текущего) размера
 */

class Program
{
    static void Main(string[] args)
    {
        // Создаем коллекцию бактерий и добавляем первую бактерию
        List<ICloneable> bacterias = new List<ICloneable>();
        bacterias.Add(new Bacteria());

        // В альтернативном потоке каждые 4 секунды клонируем любую существующую бактерию (например, первую)
        // Каждая новая копия бактерии будет иметь такой же размер, как все существующие бактерии
        Thread alternative = new Thread(() =>
        {
            while (true)
            {
                for (int i = 0; i < bacterias.Count; i++)
                {
                    Console.WriteLine("Бактерия #{0}. Ее размер {1}", i + 1, ((Bacteria)bacterias[i]).Size);
                }
                Console.WriteLine();

                Thread.Sleep(4000);
                bacterias.Add(bacterias[0].Clone());
            }
        });
        alternative.Start();
        alternative.Join();
    }
}

// Интерфейс с методом Clone()
interface ICloneable { ICloneable Clone(); }

// Бактерия
class Bacteria : ICloneable
{
    public int Size { get; private set; }

    public Bacteria(int size = 1)
    {
        Size = size;
        Thread alternative = new Thread(() =>
        {
            while (true)
            {
                // Каждые 3 секунды размер бактерии увеличивается на 1
                Thread.Sleep(3000);
                Size++;
            }
        });
        alternative.Start();
    }

    // Реализуем метод Clone(), возвращая новый такой же объект с текущим размером
    public ICloneable Clone()
    {
        return new Bacteria(Size);
    }
}
