using System;
using System.Collections.Generic;
using System.Linq;

// Author class
public class Author
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Bio { get; set; }

    public Author(string firstName, string lastName, DateTime dateOfBirth, string bio)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Bio = bio;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

// Book class
public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, Author author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, ISBN: {ISBN}, Published: {PublicationYear}";
    }
}

// Library class
public class Library
{
    private List<Book> books = new List<Book>();

    // Add a book to the library
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Remove a book from the library by ISBN
    public void RemoveBook(string isbn)
    {
        Book bookToRemove = books.FirstOrDefault(book => book.ISBN == isbn);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
    }

    // Search for books by title or author name
    public List<Book> SearchBooks(string query)
    {
        return books.Where(book =>
            book.Title.ToLower().Contains(query.ToLower()) ||
            book.Author.ToString().ToLower().Contains(query.ToLower())).ToList();
    }

    // Display all books in the library
    public void DisplayBooks()
    {
        Console.WriteLine("Books in the Library:");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create authors
        Author author1 = new Author("J.K.", "Rowling", new DateTime(1965, 7, 31), "British author best known for the Harry Potter series.");
        Author author2 = new Author("George", "Orwell", new DateTime(1903, 6, 25), "English novelist and essayist, best known for the dystopian novel 1984.");

        // Create books
        Book book1 = new Book("Harry Potter and the Sorcerer's Stone", author1, "978-0439708180", 1997);
        Book book2 = new Book("1984", author2, "978-0451524935", 1949);

        // Create library and add books
        Library library = new Library();
        library.AddBook(book1);
        library.AddBook(book2);

        // Display all books in the library
        library.DisplayBooks();

        // Search for books
        Console.WriteLine("\nSearch Results:");
        List<Book> searchResults = library.SearchBooks("rowling");
        foreach (var result in searchResults)
        {
            Console.WriteLine(result);
        }

        // Remove a book
        library.RemoveBook("978-0451524935");
        Console.WriteLine("\nBooks after removal:");
        library.DisplayBooks();
    }
}

