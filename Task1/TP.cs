using System;

// Клас, що представляє запит користувача
public class UserRequest
{
    public string Request { get; set; }

    public UserRequest(string request)
    {
        Request = request;
    }
}

// Абстрактний клас для обробників запитів
public abstract class SupportHandler
{
    protected SupportHandler NextHandler;

    // Метод для встановлення наступного обробника в ланцюжку
    public void SetNextHandler(SupportHandler handler)
    {
        NextHandler = handler;
    }

    // Абстрактний метод для обробки запиту
    public abstract void HandleRequest(UserRequest request);
}

// Конкретні обробники запитів
public class Level1Support : SupportHandler
{
    public override void HandleRequest(UserRequest request)
    {
        Console.WriteLine("Доброго дня, вас вітає тех підтримка Київстар.\n Натисніть 1, якщо бажаєте поповнити рахунок\n Натисніть 2, якщо бажаєте розмову з оператором");
        string response = Console.ReadLine();
        if (response.ToLower() == "2")
        {
            Console.WriteLine("З'єдную з оператором , зачекайте.");
        }
        else if (NextHandler != null && response.ToLower() == "1")
        {
            NextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Неправильний вибір, відміна дзвінка.");
        }
    }
}

public class Level2Support : SupportHandler
{
    public override void HandleRequest(UserRequest request)
    {
        Console.WriteLine("\n Натисніть 1, якщо бажаєте вибрати сумму \n Натисніть 2, якщо бажаєте вийти");
        string response = Console.ReadLine();
        if (response.ToLower() == "2")
        {
            Console.WriteLine("Допобачення.");
        }
        else if (NextHandler != null && response.ToLower() == "1")
        {
            NextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Неправильний вибір, відміна дзвінка.");
        }
    }
}

public class Level3Support : SupportHandler
{
    public override void HandleRequest(UserRequest request)
    {
        Console.WriteLine("\n Натисніть 1, якщо бажаєте поповнити на 200 грн \n Натисніть 2, якщо бажаєте вийти");
        string response = Console.ReadLine();
        if (response.ToLower() == "2")
        {
            Console.WriteLine("Допобачення.");
        }
        else if (NextHandler != null && response.ToLower() == "1")
        {
            NextHandler.HandleRequest(request);
        }
        else
        {
            Console.WriteLine("Неправильний вибір, відміна дзвінка.");
        }
    }
}

public class Level4Support : SupportHandler
{
    public override void HandleRequest(UserRequest request)
    {
        Console.WriteLine("\n Натисніть 1, якщо бажаєте підтвердити \n Натисніть 2, якщо бажаєте вийти");
        string response = Console.ReadLine();
        if (response.ToLower() == "1")
        {
            Console.WriteLine("Допобачення. Рахунок поповнено на 200 грн");
        }
        else
        {
            Console.WriteLine("Бажаєте повернутись до початкового меню?");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        SupportHandler level1 = new Level1Support();
        SupportHandler level2 = new Level2Support();
        SupportHandler level3 = new Level3Support();
        SupportHandler level4 = new Level4Support();

        
        level1.SetNextHandler(level2);
        level2.SetNextHandler(level3);
        level3.SetNextHandler(level4);

        
        Console.WriteLine("Дзвоним *100# ");

        bool handled = false;
        while (!handled)
        {
            level1.HandleRequest(new UserRequest("")); 
            string response = Console.ReadLine();
            if (response.ToLower() != "ні")
            {
                handled = true; 
            }
        }
    }
}

