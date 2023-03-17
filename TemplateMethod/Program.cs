/*
 * ПОВЕДЕНЧЕСКИЙ ПАТТЕРН: ШАБЛОННЫЙ МЕТОД "Template Method"
 */

class Program
{
    private static void Main(string[] args)
    {
        // Создаем объекты больницы, частного дома и торгового центра
        Hospital hospital = new Hospital();
        PrivateHouse private_house = new PrivateHouse();
        ShoppingCenter shopping_center = new ShoppingCenter();

        // Строим больницу
        hospital.Build();
        Console.WriteLine();

        // Строим частный дом
        private_house.Build();
        Console.WriteLine();

        // Строим торговый центр
        shopping_center.Build();
        Console.WriteLine();
    }
}

abstract class Building
{
    // Шаблонный метод, который реализует некий алгоритм
    // Алгоритм может состоять из последовательности вызовов других методов
    // Сам шаблонный метод, представляющий структуру алгоритма, переопределяться не должен
    public void Build()
    {
        LandPurchase();
        ProjectDocumentation();
        FoundationPreparation();
        MainConstruction();
        RoughFinish();
        FinishingRepairs();
        CommissioningFacility();
    }

    public abstract void LandPurchase(); // Покупка земли
    public abstract void ProjectDocumentation(); // Составление проектной документации
    public abstract void FoundationPreparation(); // Подготовка фундамента
    public abstract void MainConstruction(); // Основное строительство
    public abstract void RoughFinish(); // Черновая отделка
    public abstract void FinishingRepairs(); // Чистовой ремонт
    public abstract void CommissioningFacility(); // Ввод объекта в эксплуатацию
}

// Класс Больница
class Hospital : Building
{
    public override void LandPurchase()
    {
        Console.WriteLine("Покупаем землю под больницу");
    }

    public override void ProjectDocumentation()
    {
        Console.WriteLine("Составляем проект больницы");
    }

    public override void FoundationPreparation()
    {
        Console.WriteLine("Готовим фундамент больницы");
    }

    public override void MainConstruction()
    {
        Console.WriteLine("Строим каркас больницы");
    }

    public override void RoughFinish()
    {
        Console.WriteLine("Выполняем черновой ремонт больницы");
    }

    public override void FinishingRepairs()
    {
        Console.WriteLine("Выполняем чистовую отделку больницы");
    }

    public override void CommissioningFacility()
    {
        Console.WriteLine("Вводим больницу в эксплуатацию");
    }
}

// Класс Частный дом
class PrivateHouse : Building
{
    public override void LandPurchase()
    {
        Console.WriteLine("Покупаем землю под частный дом");
    }

    public override void ProjectDocumentation()
    {
        Console.WriteLine("Составляем проект частного дома");
    }

    public override void FoundationPreparation()
    {
        Console.WriteLine("Готовим фундамент частного дома");
    }

    public override void MainConstruction()
    {
        Console.WriteLine("Строим каркас частного дома");
    }

    public override void RoughFinish()
    {
        Console.WriteLine("Выполняем черновой ремонт частного дома");
    }

    public override void FinishingRepairs()
    {
        Console.WriteLine("Выполняем чистовую отделку частного дома");
    }

    public override void CommissioningFacility()
    {
        Console.WriteLine("Вводим частный дом в эксплуатацию");
    }
}

// Класс Торговый центр
class ShoppingCenter : Building
{
    public override void LandPurchase()
    {
        Console.WriteLine("Покупаем землю под торговый центр");
    }

    public override void ProjectDocumentation()
    {
        Console.WriteLine("Составляем проект торгового центра");
    }

    public override void FoundationPreparation()
    {
        Console.WriteLine("Готовим фундамент торгового центра");
    }

    public override void MainConstruction()
    {
        Console.WriteLine("Строим каркас торгового центра");
    }

    public override void RoughFinish()
    {
        Console.WriteLine("Выполняем черновой ремонт торгового центра");
    }

    public override void FinishingRepairs()
    {
        Console.WriteLine("Выполняем чистовую отделку торгового центра");
    }

    public override void CommissioningFacility()
    {
        Console.WriteLine("Вводим торговый центр в эксплуатацию");
    }
}