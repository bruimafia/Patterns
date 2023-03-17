/*
 * СТРУКТУРНЫЙ ПАТТЕРН: АДАПТЕР "Adapter"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем терминал для оплаты
        Terminal terminal = new Terminal();

        // Можем платить картой Сбербанка и картой ВТБ (так как они реализуют интерфейс IMir)
        terminal.PayOfCard(new SberbankCard());
        terminal.PayOfCard(new VTBCard());

        // Чтобы заплатить картами, реализующими интерфейс IVisa, используем адаптер
        terminal.PayOfCard(new VisaToMirAdapter(new DenizbankCard()));
    }
}

// Реализация терминала с методом оплаты картой Мир
class Terminal
{
    public void PayOfCard(IMir card)
    {
        card.MirPay();
    }
}

// Описание карт, основанных на системе Мир
interface IMir { void MirPay(); }

// Описание карт, основанных на системе Visa
interface IVisa { void VisaPay(); }

// Реализация карты Сбербанка, которая работает на системе Мир
class SberbankCard : IMir
{
    public void MirPay()
    {
        Console.WriteLine("Оплачено российской картой Сбербанка");
    }
}

// Реализация карты ВТБ, которая работает на системе Мир
class VTBCard : IMir
{
    public void MirPay()
    {
        Console.WriteLine("Оплачено российской картой ВТБ");
    }
}

// Реализация карты Denizbank, которая работает на системе Visa
class DenizbankCard : IVisa
{
    public void VisaPay()
    {
        Console.WriteLine("Оплачено турецкой картой Denizbank");
    }
}

// Адаптер, позволяющий работать терминалу с картами Visa
class VisaToMirAdapter : IMir
{
    private IVisa card;

    public VisaToMirAdapter(IVisa card) { this.card = card; }

    public void MirPay()
    {
        card.VisaPay();
    }
}