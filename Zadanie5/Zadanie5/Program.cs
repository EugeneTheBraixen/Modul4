using System;
using System.Collections.Generic;

// Интерфейс "Рисунок"
public interface IDrawing
{
    void DrawLine(int x1, int y1, int x2, int y2);
    void DrawCircle(int centerX, int centerY, int radius);
    void DrawRectangle(int x, int y, int width, int height);
}

// Класс для работы с холстом
public class Canvas : IDrawing
{
    private List<string> canvas;

    public Canvas(int width, int height)
    {
        canvas = new List<string>();
        for (int i = 0; i < height; i++)
        {
            string row = new string(' ', width);
            canvas.Add(row);
        }
    }

    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        if (x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0 || x1 >= canvas[0].Length || x2 >= canvas[0].Length || y1 >= canvas.Count || y2 >= canvas.Count)
        {
            Console.WriteLine("Ошибка! Координаты линии находятся вне холста.");
            return;
        }

        if (x1 == x2)
        {
            // Рисуем вертикальную линию
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
            {
                char[] row = canvas[y].ToCharArray();
                row[x1] = '-';
                canvas[y] = new string(row);
            }
        }
        else if (y1 == y2)
        {
            // Рисуем горизонтальную линию
            char[] row = canvas[y1].ToCharArray();
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
            {
                row[x] = '-';
            }
            canvas[y1] = new string(row);
        }
        else
        {
            Console.WriteLine("Ошибка! Линии могут быть только горизонтальными или вертикальными.");
        }
    }

    public void DrawCircle(int centerX, int centerY, int radius)
    {
        if (centerX < 0 || centerY < 0 || centerX >= canvas[0].Length || centerY >= canvas.Count)
        {
            Console.WriteLine("Ошибка! Координаты круга находятся вне холста.");
            return;
        }

        if (radius <= 0)
        {
            Console.WriteLine("Ошибка! Радиус круга должен быть положительным числом.");
            return;
        }

        for (int y = 0; y < canvas.Count; y++)
        {
            for (int x = 0; x < canvas[0].Length; x++)
            {
                int distanceSquared = (x - centerX) * (x - centerX) + (y - centerY) * (y - centerY);
                if (distanceSquared <= radius * radius)
                {
                    char[] row = canvas[y].ToCharArray();
                    row[x] = '█';
                    canvas[y] = new string(row);
                }
            }
        }
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        if (x < 0 || y < 0 || x >= canvas[0].Length || y >= canvas.Count)
        {
            Console.WriteLine("Ошибка! Координаты прямоугольника находятся вне холста.");
            return;
        }

        if (width <= 0 || height <= 0)
        {
            Console.WriteLine("Ошибка! Ширина и высота прямоугольника должны быть положительными числами.");
            return;
        }

        for (int row = y; row < y + height; row++)
        {
            if (row >= canvas.Count)
                break;

            for (int col = x; col < x + width; col++)
            {
                if (col >= canvas[0].Length)
                    break;

                char[] canvasRow = canvas[row].ToCharArray();
                canvasRow[col] = '█';
                canvas[row] = new string(canvasRow);
            }
        }
    }

    public void Display()
    {
        foreach (var row in canvas)
        {
            Console.WriteLine(row);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите ширину холста: ");
        if (!int.TryParse(Console.ReadLine(), out int canvasWidth) || canvasWidth <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректную ширину холста.");
            Console.ReadLine();
            return;
        }

        Console.Write("Введите высоту холста: ");
        if (!int.TryParse(Console.ReadLine(), out int canvasHeight) || canvasHeight <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректную высоту холста.");
            Console.ReadLine();
            return;
        }

        Canvas canvas = new Canvas(canvasWidth, canvasHeight);

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Нарисовать линию");
            Console.WriteLine("2. Нарисовать круг");
            Console.WriteLine("3. Нарисовать прямоугольник");
            Console.WriteLine("4. Вывести холст");
            Console.WriteLine("5. Выйти");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Ошибка! Введите корректный выбор.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Введите координаты начала линии (x1 y1): ");
                    if (!int.TryParse(Console.ReadLine(), out int x1) || !int.TryParse(Console.ReadLine(), out int y1))
                    {
                        Console.WriteLine("Ошибка! Введите корректные координаты.");
                        continue;
                    }

                    Console.Write("Введите координаты конца линии (x2 y2): ");
                    if (!int.TryParse(Console.ReadLine(), out int x2) || !int.TryParse(Console.ReadLine(), out int y2))
                    {
                        Console.WriteLine("Ошибка! Введите корректные координаты.");
                        continue;
                    }

                    canvas.DrawLine(x1, y1, x2, y2);
                    break;

                case 2:
                    Console.Write("Введите координаты центра круга (x y): ");
                    if (!int.TryParse(Console.ReadLine(), out int centerX) || !int.TryParse(Console.ReadLine(), out int centerY))
                    {
                        Console.WriteLine("Ошибка! Введите корректные координаты.");
                        continue;
                    }

                    Console.Write("Введите радиус круга: ");
                    if (!int.TryParse(Console.ReadLine(), out int radius) || radius <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите корректный радиус.");
                        continue;
                    }

                    canvas.DrawCircle(centerX, centerY, radius);
                    break;

                case 3:
                    Console.Write("Введите координаты верхнего левого угла прямоугольника (x y): ");
                    if (!int.TryParse(Console.ReadLine(), out int rectX) || !int.TryParse(Console.ReadLine(), out int rectY))
                    {
                        Console.WriteLine("Ошибка! Введите корректные координаты.");
                        continue;
                    }

                    Console.Write("Введите ширину прямоугольника: ");
                    if (!int.TryParse(Console.ReadLine(), out int rectWidth) || rectWidth <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите корректную ширину.");
                        continue;
                    }

                    Console.Write("Введите высоту прямоугольника: ");
                    if (!int.TryParse(Console.ReadLine(), out int rectHeight) || rectHeight <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите корректную высоту.");
                        continue;
                    }

                    canvas.DrawRectangle(rectX, rectY, rectWidth, rectHeight);
                    break;

                case 4:
                    Console.WriteLine("Содержимое холста:");
                    canvas.Display();
                    break;

                case 5:
                    Console.WriteLine("Завершение работы программы.");
                    return;

                default:
                    Console.WriteLine("Ошибка! Выберите корректное действие.");
                    break;
            }
        }
    }
}
