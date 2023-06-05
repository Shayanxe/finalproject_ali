/*
 *
 *
 * 
 علی باقری سرشکی *
 برنامه سازی پیشرفته تایم 13 تا 15 *
 *
 *
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public int Price { get; set; }

        public Book()
        {
        }

        public Book(int ID, string Title, string Writer, int Price)
        {
            this.ID = ID;
            this.Title = Title;
            this.Writer = Writer;
            this.Price = Price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Declaring a bool to keep running application 

            bool run = true;

            var bookList = new List<Book>();
            bookList.Add(new Book(1, "Fooled by randomness", "Nasim nicolas taleb", 20));
            bookList.Add(new Book(2, "Skin in the game", "Nasim nicolas taleb", 40));
            bookList.Add(new Book(3, "Black swan", "Nasim nicolas taleb", 32));

            while (run)
            {
                Console.WriteLine("1 - add new book. ");
                Console.WriteLine("2 - search the books by name & show details. ");
                Console.WriteLine("3 - show all the books. ");
                Console.WriteLine("4 - remove the book by ID ");
                Console.WriteLine("5 - show the most expensive book. ");
                Console.WriteLine("6 - show the cheapest book. ");
                Console.WriteLine("7 - show the number of books. ");
                Console.WriteLine("8 - show the books by price ( sort by price ). ");
                Console.WriteLine("9 - show the books between two prices. ");
                Console.WriteLine("0 - quit!");

                // get value from user

                Console.WriteLine("Please enter a number: ");
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        run = false;
                        break;

                    case 1:
                        Console.Write("Enter ID: ");
                        var newBookID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Title: ");
                        var newBookTitle = Console.ReadLine();

                        Console.Write("Enter Writer: ");
                        var newBookWriter = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        var newBookPrice = Convert.ToInt32(Console.ReadLine());

                        var newBook = new Book(newBookID, newBookTitle, newBookWriter, newBookPrice);
                        bookList.Add(newBook);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:

                        var temp = new List<Book>();

                        Console.WriteLine("Please enter the book title: ");
                        var searchedBook = Console.ReadLine();

                        foreach (Book book in bookList)
                        {
                            if (book.Title.ToLower().Contains(searchedBook))
                            {
                                temp.Add(book);
                            }
                        }

                        if (temp.Count > 0)
                        {
                            foreach (Book book in bookList)
                            {
                                if (book.Title.ToLower().Contains(searchedBook))
                                {
                                    Console.WriteLine(
                                        $"ID: {book.ID}, Title: {book.Title}, Writer: {book.Writer}, Price: {book.Price}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nothing found!");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:

                        foreach (Book book in bookList)
                        {
                            Console.WriteLine(
                                $"ID: {book.ID}, Title: {book.Title}, Writer: {book.Writer}, Price: {book.Price}");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("Please enter the book id to remove: ");
                        int selectedBook = Convert.ToInt32(Console.ReadLine());

                        foreach (var book in bookList)
                        {
                            if (book.ID == selectedBook)
                            {
                                bookList.Remove(book);
                            }
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        if (bookList.Count > 0)
                        {
                            Book mostExpensiveBook = bookList.OrderByDescending(b => b.Price).First();
                            Console.WriteLine("Most expensive book:");
                            Console.WriteLine(
                                $"ID: {mostExpensiveBook.ID}, Title: {mostExpensiveBook.Title}, Writer: {mostExpensiveBook.Writer}, Price: {mostExpensiveBook.Price}");
                        }
                        else
                        {
                            Console.WriteLine("No books in the library.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        if (bookList.Count > 0)
                        {
                            Book cheapestBook = bookList.OrderBy(b => b.Price).First();
                            Console.WriteLine("Cheapest book:");
                            Console.WriteLine(
                                $"ID: {cheapestBook.ID}, Title: {cheapestBook.Title}, Writer: {cheapestBook.Writer}, Price: {cheapestBook.Price}");
                        }
                        else
                        {
                            Console.WriteLine("No books in the library.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 7:
                        Console.WriteLine($"Number of books: {bookList.Count}");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 8:


                        var tempList = bookList;
                        tempList.Sort((model, bookModel) => bookModel.Price - model.Price);

                        if (tempList.Count > 0)
                        {
                            Console.WriteLine("Books within the price range:");
                            foreach (Book book in tempList)
                            {
                                Console.WriteLine(
                                    $"ID: {book.ID}, Title: {book.Title}, Writer: {book.Writer}, Price: {book.Price}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books found within the price range.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 9:

                        Console.WriteLine("Enter minimum price:");
                        double minPrice = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter maximum price:");
                        double maxPrice = Convert.ToDouble(Console.ReadLine());

                        List<Book> matchingBooks =
                            bookList.Where(b => b.Price >= minPrice && b.Price <= maxPrice).ToList();

                        if (matchingBooks.Count > 0)
                        {
                            Console.WriteLine("Books within the price range:");
                            foreach (Book book in matchingBooks)
                            {
                                Console.WriteLine(
                                    $"ID: {book.ID}, Title: {book.Title}, Writer: {book.Writer}, Price: {book.Price}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books found within the price range.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}