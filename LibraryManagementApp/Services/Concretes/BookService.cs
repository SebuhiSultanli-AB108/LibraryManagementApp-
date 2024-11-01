using LibraryManagementApp.Exceptions;
using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Abstraction;
using Newtonsoft.Json;


namespace LibraryManagementApp.Services.Concretes;

internal class BookService : IBookService
{
    List<Book> books = new();
    public void CreateBook(Book book)
    {
        books = Read();
        bool contains = false;
        if (book.Id == GetBookById(book.Id).Id) contains = true;
        if (!contains) books.Add(book);
        Write(books);
    }
    public void DeleteBook(int id)
    {
        books = Read();
        books.Remove(GetBookById(id));
        using StreamWriter writer = new StreamWriter(@"C:\Users\ca r221.14\Desktop\LibraryManagementApp\LibraryManagementApp\Data\BookData.json", false);
        writer.WriteLine(JsonConvert.SerializeObject(books));
    }

    public Book GetBookById(int id)
    {
        books = Read();
        Book? book = books.Find(x => x.Id == id);
        if (book == null) throw new CustomLibraryItemException("Cant find the book!");
        return book;
    }
    public List<Book> GetAllBook()
    {
        List<Book> newBooks = Read();

        return newBooks;
    }

    public Book GetBookByTitle(string title)
    {
        books = Read();
        Book? book = books.Find(x => x.Title == title);
        if (book == null) throw new CustomLibraryItemException("Cant find the book!");
        return book;
    }

    public void Write(object? obj)
    {
        using StreamWriter writer = new StreamWriter(@"C:\Users\ca r221.14\Desktop\LibraryManagementApp\LibraryManagementApp\Data\BookData.json", false);
        writer.WriteLine(JsonConvert.SerializeObject(obj));
    }

    public List<Book> Read()
    {
        using StreamReader reader = new StreamReader(@"C:\Users\ca r221.14\Desktop\LibraryManagementApp\LibraryManagementApp\Data\BookData.json");
        List<Book> books = JsonConvert.DeserializeObject<List<Book>>(reader.ReadToEnd());
        return books;
    }
}
