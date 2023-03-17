/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: КОМАНДА "Command"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объект пульта
        Pult pult = new Pult();

        // Создаем объекты получателей команд
        Conditioner conditioner = new Conditioner();
        SmartSpeaker smart_speaker = new SmartSpeaker();
        Lamp lamp = new Lamp();

        // Даем пульту инструкцию от кондиционера и нажимаем кнопки
        pult.SetCommand(new ConditionerCommand(conditioner));
        pult.PressDown();
        pult.PressDown();
        pult.PressUp();

        // Даем пульту инструкцию от умной колонки и нажимаем кнопку
        pult.SetCommand(new SmartSpeakerCommand(smart_speaker));
        pult.PressUp();

        // Даем пульту инструкцию от лампы и нажимаем кнопку
        pult.SetCommand(new LampCommand(lamp));
        pult.PressDown();


        // Даем пульту инструкцию от умной колонки и нажимаем кнопки
        pult.SetCommand(new SmartSpeakerCommand(smart_speaker));
        pult.PressUp();
        pult.PressUp();
    }
}

// Инициатор команды Invoker (Общий пульт управления)
// Вызывает команду для выполнения определенного запроса
class Pult
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressUp()
    {
        command.ExecuteUp();
    }

    public void PressDown()
    {
        command.ExecuteDown();
    }
}

// Абстрактное описание команд
interface ICommand
{
    void ExecuteUp();
    void ExecuteDown();
}

// Описание команд кондиционера (инструкция)
class ConditionerCommand : ICommand
{
    private Conditioner conditioner;

    public ConditionerCommand(Conditioner conditioner)
    {
        this.conditioner = conditioner;
    }

    public void ExecuteUp()
    {
        conditioner.TemperatureUp();
    }

    public void ExecuteDown()
    {
        conditioner.TemperatureDown();
    }
}

// Описание команд умной колонки (инструкция)
class SmartSpeakerCommand : ICommand
{
    private SmartSpeaker smart_speaker;

    public SmartSpeakerCommand(SmartSpeaker smart_speaker)
    {
        this.smart_speaker = smart_speaker;
    }

    public void ExecuteUp()
    {
        if (!smart_speaker.IsOn)
            smart_speaker.On();
        smart_speaker.VolumeUp();
    }

    public void ExecuteDown()
    {
        if (!smart_speaker.IsOn)
            smart_speaker.On();
        smart_speaker.VolumeDown();
    }
}

// Описание команд лампы (инструкция)
class LampCommand : ICommand
{
    private Lamp lamp;

    public LampCommand(Lamp lamp)
    {
        this.lamp = lamp;
    }

    public void ExecuteUp()
    {
        lamp.Lighter();
    }

    public void ExecuteDown()
    {
        lamp.Darker();
    }
}

// Конкретный получатель команды Receiver (Кондиционер)
// Определяет действия, которые должны выполняться в результате запроса
class Conditioner
{
    private int temperature = 15;

    public void TemperatureUp()
    {
        temperature++;
        Console.WriteLine("Температура кондиционера повысилась до {0}", temperature);
    }

    public void TemperatureDown()
    {
        temperature--;
        Console.WriteLine("Температура кондиционера понизилась до {0}", temperature);
    }
}

// Конкретный получатель команды Receiver (Умная колонка)
// Определяет действия, которые должны выполняться в результате запроса
class SmartSpeaker
{
    public bool IsOn { get; set; } = false;

    public void VolumeUp()
    {
        Console.WriteLine("Повысилась громкость умной колонки");
    }

    public void VolumeDown()
    {
        Console.WriteLine("Понизилась громкость умной колонки");
    }

    public void On()
    {
        IsOn = true;
        Console.WriteLine("Умная колонка включилась");
    }

    public void Off()
    {
        IsOn = false;
        Console.WriteLine("Умная колонка выключилась");
    }
}

// Конкретный получатель команды Receiver (Лампа/Люстра)
// Определяет действия, которые должны выполняться в результате запроса
class Lamp
{
    public void Lighter()
    {
        Console.WriteLine("Яркость освещения увеличилась");
    }

    public void Darker()
    {
        Console.WriteLine("Яркость освещения уменьшилась");
    }
}