using System;
using System.Collections.Generic;

// Интерфейс "Книга"
public interface IBook
{
    bool IsAvailable();
    void Borrow();
    void Return();
    string GetTitle();
}

// Класс "Книга в библиотеке"
public class LibraryBook : IBook
{
    private string title;
    private bool isBorrowed;

    public LibraryBook(string title)
    {
        this.title = title;
        isBorrowed = false;
    }

    public bool IsAvailable()
    {
        return !isBorrowed;
    }

    public void Borrow()
    {
        if (IsAvailable())
        {
            isBorrowed = true;
            Console.WriteLine($"Книга \"{title}\" выдана.");
        }
        else
        {
            Console.WriteLine($"Книга \"{title}\" уже выдана.");
        }
    }

    public void Return()
    {
        if (IsAvailable())
        {
            Console.WriteLine($"Книгу \"{title}\" нельзя вернуть, так как она не выдавалась.");
        }
        else
        {
            isBorrowed = false;
            Console.WriteLine($"Книга \"{title}\" возвращена.");
        }
    }

    public string GetTitle()
    {
        return title;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество книг: ");
        if (!int.TryParse(Console.ReadLine(), out int bookCount) || bookCount <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректное количество книг.");
            Console.ReadLine();
            return;
        }

        List<IBook> library = new List<IBook>();

        Console.WriteLine("Введите информацию о книгах:");
        for (int i = 0; i < bookCount; i++)
        {
            Console.Write("Введите название книги: ");
            string input = Console.ReadLine();

            IBook book = new LibraryBook(input);
            library.Add(book);
        }

        Console.WriteLine("Список книг в библиотеке:");
        foreach (var book in library)
        {
            Console.WriteLine($"Название: {book.GetTitle()}");
            if (book.IsAvailable())
            {
                Console.WriteLine("Статус: доступна");
            }
            else
            {
                Console.WriteLine("Статус: выдана");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Желаете взять или вернуть книгу? (введите 'взять' или 'вернуть', или 'q' для выхода):");
        while (true)
        {
            string action = Console.ReadLine();
            if (action.ToLower() == "q")
                break;

            Console.Write("Введите название книги: ");
            string bookTitle = Console.ReadLine();

            IBook book = library.Find(b => b.GetTitle() == bookTitle);
            if (book == null)
            {
                Console.WriteLine($"Книга с названием \"{bookTitle}\" не найдена.");
                continue;
            }

            if (action.ToLower() == "взять")
            {
                book.Borrow();
            }
            else if (action.ToLower() == "вернуть")
            {
                book.Return();
            }

            Console.WriteLine("Желаете продолжить операции с книгами? (введите 'взять' или 'вернуть', или 'q' для выхода):");
        }

        Console.WriteLine("Завершение работы программы.");
        Console.ReadLine();
    }
}
