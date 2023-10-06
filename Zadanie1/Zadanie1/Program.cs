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
                Console.Write("Введите радиус круга: ");
                double radius = double.Parse(Console.ReadLine());
                IShape circle = new Circle(radius);
                Console.WriteLine($"Площадь круга: {circle.CalculateArea()}");
                Console.WriteLine($"Периметр круга: {circle.CalculatePerimeter()}");
                break;

            case 2:
                Console.Write("Введите ширину прямоугольника: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("Введите высоту прямоугольника: ");
                double height = double.Parse(Console.ReadLine());
                IShape rectangle = new Rectangle(width, height);
                Console.WriteLine($"Площадь прямоугольника: {rectangle.CalculateArea()}");
                Console.WriteLine($"Периметр прямоугольника: {rectangle.CalculatePerimeter()}");
                break;

            case 3:
                Console.Write("Введите сторону A треугольника: ");
                double sideA = double.Parse(Console.ReadLine());
                Console.Write("Введите сторону B треугольника: ");
                double sideB = double.Parse(Console.ReadLine());
                Console.Write("Введите сторону C треугольника: ");
                double sideC = double.Parse(Console.ReadLine());
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
