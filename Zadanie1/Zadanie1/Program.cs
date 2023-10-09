using System;

// Интерфейс "Фигура"
public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}

// Класс "Круг"
public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Радиус круга должен быть положительным числом.");
        }
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}

// Класс "Прямоугольник"
public class Rectangle : IShape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException("Ширина и высота прямоугольника должны быть положительными числами.");
        }
        this.width = width;
        this.height = height;
    }

    public double CalculateArea()
    {
        return width * height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (width + height);
    }
}

// Класс "Треугольник"
public class Triangle : IShape
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Стороны треугольника должны быть положительными числами.");
        }
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public double CalculateArea()
    {
        double s = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }

    public double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите фигуру:");
        Console.WriteLine("1. Круг");
        Console.WriteLine("2. Прямоугольник");
        Console.WriteLine("3. Треугольник");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                double radius;
                while (true)
                {
                    Console.Write("Введите радиус круга (положительное число): ");
                    if (double.TryParse(Console.ReadLine(), out radius) && radius > 0)
                        break;
                    else
                        Console.WriteLine("Ошибка! Введите положительное число.");
                }

                IShape circle = new Circle(radius);
                Console.WriteLine($"Площадь круга: {circle.CalculateArea()}");
                Console.WriteLine($"Периметр круга: {circle.CalculatePerimeter()}");
                break;

            case 2:
                double width, height;
                while (true)
                {
                    Console.Write("Введите ширину прямоугольника (положительное число): ");
                    if (double.TryParse(Console.ReadLine(), out width) && width > 0)
                        break;
                    else
                        Console.WriteLine("Ошибка! Введите положительное число.");
                }

                while (true)
                {
                    Console.Write("Введите высоту прямоугольника (положительное число): ");
                    if (double.TryParse(Console.ReadLine(), out height) && height > 0)
                        break;
                    else
                        Console.WriteLine("Ошибка! Введите положительное число.");
                }

                IShape rectangle = new Rectangle(width, height);
                Console.WriteLine($"Площадь прямоугольника: {rectangle.CalculateArea()}");
                Console.WriteLine($"Периметр прямоугольника: {rectangle.CalculatePerimeter()}");
                break;

            case 3:
                double sideA, sideB, sideC;
                while (true)
                {
                    Console.Write("Введите сторону A треугольника (положительное число): ");
                    if (double.TryParse(Console.ReadLine(), out sideA) && sideA > 0)
                        break;
                    else
                        Console.WriteLine("Ошибка! Введите положительное число.");
                }

                while (true)
                {
                    Console.Write("Введите сторону B треугольника (положительное число): ");
                    if (double.TryParse(Console.ReadLine(), out sideB) && sideB > 0)
                        break;
                    else
                        Console.WriteLine("Ошибка! Введите положительное число.");
                }

                while (true)
                {
                    Console.Write("Введите сторону C треугольника (положительное число): ");
                    if (double.TryParse(Console.ReadLine(), out sideC) && sideC > 0)
                        break;
                    else
                        Console.WriteLine("Ошибка! Введите положительное число.");
                }

                IShape triangle = new Triangle(sideA, sideB, sideC);
                Console.WriteLine($"Площадь треугольника: {triangle.CalculateArea()}");
                Console.WriteLine($"Периметр треугольника: {triangle.CalculatePerimeter()}");
                break;

            default:
                Console.WriteLine("Ошибка! Неверный выбор.");
                break;
        }

        Console.ReadLine();
    }
}
