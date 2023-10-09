using System;
using System.Collections.Generic;

// Интерфейс "Товар"
public interface IProduct
{
    string GetName();
    double GetPrice(); // Изменим тип метода на double
    int GetStock();
}

// Класс "Продукт"
public class Product : IProduct
{
    private string name;
    private double priceInDollars; // Изменим тип поля на double
    private int stock;

    public Product(string name, double priceInDollars, int stock) // Изменим параметр на double
    {
        this.name = name;
        this.priceInDollars = priceInDollars;
        this.stock = stock;
    }

    public string GetName()
    {
        return name;
    }

    public double GetPrice() // Изменим тип метода на double
    {
        return priceInDollars;
    }

    public int GetStock()
    {
        return stock;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество продуктов: ");
        if (!int.TryParse(Console.ReadLine(), out int productCount) || productCount <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректное количество продуктов.");
            Console.ReadLine();
            return;
        }

        List<IProduct> products = new List<IProduct>();

        Console.WriteLine("Введите информацию о продуктах:");
        for (int i = 0; i < productCount; i++)
        {
            Console.Write("Введите название продукта: ");
            string name = Console.ReadLine();

            Console.Write("Введите цену продукта в долларах: "); // Обновим запрос на ввод цены в долларах
            if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректную цену.");
                i--; // Возвращаемся на предыдущий шаг в цикле
                continue;
            }

            Console.Write("Введите количество продукта на складе: ");
            if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
            {
                Console.WriteLine("Ошибка! Введите корректное количество.");
                i--; // Возвращаемся на предыдущий шаг в цикле
                continue;
            }

            IProduct product = new Product(name, price, stock);
            products.Add(product);
        }

        Console.WriteLine("Информация о продуктах:");
        foreach (var product in products)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"Название: {product.GetName()}");
            Console.WriteLine($"Цена в долларах: ${product.GetPrice():N2}"); // Выводим цену в долларах с двумя знаками после запятой
            Console.WriteLine($"Остаток на складе: {product.GetStock()}");
            Console.WriteLine("=============================================");
        }

        Console.ReadLine();
    }
}
