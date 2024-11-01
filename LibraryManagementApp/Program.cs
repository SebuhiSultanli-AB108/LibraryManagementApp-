using LibraryManagementApp.Models;
using LibraryManagementApp.Services.Concretes;

namespace LibraryManagementApp;
//  /\_/\
// ( o.o )
//   >^<

class Program
{
    static void Main()
    {
        BookService bs = new BookService();
        bs.CreateBook(
            new Book("Test1", 1111)
            {
                Id = 1,
            });
        bs.CreateBook(
            new Book("Test2", 2222)
            {
                Id = 2,
            });
        //bs.DeleteBook(1);
        //Console.WriteLine(bs.GetBookById(2).Title);
        //Console.WriteLine(bs.GetBookByTitle("Test1").Title);
        foreach (var item in bs.GetAllBook())
        {
            Console.WriteLine(item.Title);
        }

    }

}