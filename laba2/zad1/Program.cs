using System;
using System.IO;
using System.Text.Json;
class DecimalCounter
{
    private int minValue; // Мінімальне значення лічильника
    private int maxValue; // Максимальне значення лічильника
    private int currentValue; // Поточне значення лічильника
    public int MinValue
    {
        get {return minValue;}
        set {minValue = value;}
    }
    public int MaxValue
    {
        get {return maxValue;}
        set {maxValue = value;}
    }
    public int CurrentValue
    {
        get {return minValue;}
        set {
            if (value => minValue && value <= maxValue)
                currentValue = value;
            else
                throw new ArgumentOutOfRangeException("Значення", "Значення має бути в діапазоні MinValue і MaxValue.");
            }
    }
    public DecimalCounter()
    {
        minValue = 0;
        maxValue = 100;
        currentValue = minValue; // Початкове значення - мінімальне
    }
    public DecimalCounter(int min, int max)
    {
        minValue = min;
        maxValue = max;
        currentValue = minValue; // Початкове значення - мінімальне
    }
    public void Increment() // Метод для збільшення значення лічильника
    {
        if (currentValue < maxValue)
            currentValue++;
    }
    public void Decrement() // Метод для зменшення значення лічильника
    {
        if (currentValue > minValue)
            currentValue--;
    }
    public int GetValue() // Метод-геттер для отримання поточного значення лічильника
    {
        return currentValue;
    }
    public void SaveToJson(string filePath) // Метод для збереження об'єкта у JSON файл
    {
        string jsonString = JsonSerializer.Serialize(this);
        File.WriteAllText(filePath, jsonString);
    }
    public static DecimalCounter LoadFromJson(string filePath) // Метод для завантаження об'єкта з JSON файлу
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<DecimalCounter>(jsonString);
    }
}
class Program
{
    static void Main(string[] args)
    {
        DecimalCounter counter1 = new DecimalCounter();
        counter1.SaveToJson("counter1.json"); // Зберігаємо об'єкт у JSON файл
        DecimalCounter counterLoaded = DecimalCounter.LoadFromJson("counter1.json"); // Завантажуємо об'єкт з JSON файлу
        Console.WriteLine("Значення лiчильника: " + counterLoaded.GetValue()); // Використовує завантажений об'єкт
        counterLoaded.Increment(); // Збільшення значення на одиницю
        Console.WriteLine("Пiсля збiльшення: " + counterLoaded.GetValue());
        counterLoaded.Decrement(); // Зменшення значення на одиницю
        Console.WriteLine("Пiсля зменшення: " + counterLoaded.GetValue());
        DecimalCounter counter2 = new DecimalCounter(5, 10); // Створення об'єкта класу DecimalCounter з власними значеннями меж діапазону
        Console.WriteLine("----------------------");
        Console.WriteLine("Значення лiчильника: " + counter2.GetValue());
        counter2.Increment(); // Збільшення значення на одиницю
        Console.WriteLine("Пiсля збiльшення: " + counter2.GetValue());
        counter2.Decrement(); // Зменшення значення на одиницю
        Console.WriteLine("Пiсля зменшення: " + counter2.GetValue());
    }
}
