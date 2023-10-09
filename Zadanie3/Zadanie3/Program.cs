using System;
using System.Collections.Generic;

// Интерфейс "Студент"
public interface IStudent
{
    double CalculateAverageGrade();
    int GetCourse();
    string GetName();
}

// Класс "Студент первого курса"
public class Freshman : IStudent
{
    private string name;
    private double[] grades;
    private int course;

    public Freshman(string name, int course, double[] grades)
    {
        this.name = name;
        this.course = course;
        this.grades = grades;
    }

    public double CalculateAverageGrade()
    {
        if (grades.Length == 0)
        {
            return 0.0; // Если нет оценок, возвращаем 0
        }

        double sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }
        return sum / grades.Length;
    }

    public int GetCourse()
    {
        return course;
    }

    public string GetName()
    {
        return name;
    }
}

// Класс "Студент второго курса"
public class Sophomore : IStudent
{
    private string name;
    private double[] grades;
    private int course;

    public Sophomore(string name, int course, double[] grades)
    {
        this.name = name;
        this.course = course;
        this.grades = grades;
    }

    public double CalculateAverageGrade()
    {
        if (grades.Length == 0)
        {
            return 0.0; // Если нет оценок, возвращаем 0
        }

        double sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }
        return sum / grades.Length;
    }

    public int GetCourse()
    {
        return course;
    }

    public string GetName()
    {
        return name;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество студентов: ");
        if (!int.TryParse(Console.ReadLine(), out int studentCount) || studentCount <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректное количество студентов.");
            Console.ReadLine();
            return;
        }

        List<IStudent> students = new List<IStudent>();

        Console.WriteLine("Введите информацию о студентах:");
        for (int i = 0; i < studentCount; i++)
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите курс студента (от 1 до 4): ");
            if (!int.TryParse(Console.ReadLine(), out int course) || course < 1 || course > 4)
            {
                Console.WriteLine("Ошибка! Введите корректный курс (от 1 до 4).");
                i--; // Возвращаемся на предыдущий шаг в цикле
                continue;
            }

            Console.Write("Введите оценки студента (через пробел): ");
            string gradesInput = Console.ReadLine();
            string[] gradesArray = gradesInput.Split(' ');
            List<double> gradesList = new List<double>();

            foreach (var gradeStr in gradesArray)
            {
                if (double.TryParse(gradeStr, out double grade))
                {
                    gradesList.Add(grade);
                }
                else
                {
                    Console.WriteLine($"Ошибка при вводе оценки: {gradeStr}. Пропускаем ее.");
                }
            }

            IStudent student;
            if (course == 1)
            {
                student = new Freshman(name, course, gradesList.ToArray());
            }
            else
            {
                student = new Sophomore(name, course, gradesList.ToArray());
            }

            students.Add(student);
        }

        Console.WriteLine("Информация о студентах:");
        foreach (var student in students)
        {
            Console.WriteLine($"Имя: {student.GetName()}");
            Console.WriteLine($"Курс: {student.GetCourse()}");
            Console.WriteLine($"Средний балл: {student.CalculateAverageGrade():N2}");
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
