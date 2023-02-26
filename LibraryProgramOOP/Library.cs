using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgramOOP
{
    public class Library
    {
        public Library()
        {
            Books = new List<Book>();
        }

        public string Name { get; set; }
        public List<Book> Books { get; set; }

        private bool isEnd = false;

        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"********###### WELCOME TO {Name.ToUpper()}######********");
            
            Console.ForegroundColor= ConsoleColor.White;

            Console.WriteLine("\n1. Add book information");
            Console.WriteLine("2. Display book information");
            Console.WriteLine("3. List all books of given author");
            Console.WriteLine("4. List the count of books in the library");
            Console.WriteLine("5. ListAllBooks");
            Console.WriteLine("6. Exit");
          

            

            while (true)
            {
                Console.Write("\nSelect operation : ");
                string enter = Console.ReadLine();

                switch (enter)
                {
                    case "1":
                        this.AddBook();
                        break;
                    case "2":
                        this.DisplayBookInformation();
                        break;
                    case "3":
                        this.DisplayBookInformationByAuthor();
                        break;
                    case "4":
                        this.DisplayCountOfBooks();
                        break;
                    case "5":
                        this.ListAllBooks();
                        break;
                    case "6":
                        this.Exit();
                        break;
                   
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is no operation like this!");
                        break;
                }
                if (isEnd == true)
                    break;
            }

        }

        public void AddBook()
        {
            Console.Write("Book name : ");
            string bookName = Console.ReadLine();

            Console.Write("Book type : ");
            string bookType = Console.ReadLine();

            Console.Write("Book page count : ");
            if (int.TryParse(Console.ReadLine(), out int bookPageCount))
            { }
            else
                bookPageCount = 0;
          
            Console.Write("Book author name : ");
            string bookaAuthoraName = Console.ReadLine();

            Book book = new Book
            {
                Name = bookName,
                BookType = bookType,
                PageCount =bookPageCount,
                Author = new Author
                {
                    NameSurname =bookaAuthoraName,
                    Birthday =DateTime.Now

                }
            };

            Books.Add(book);
        }

       private void Print(Book book)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nBook name : {book.Name}");
            Console.WriteLine($"Book type : {book.BookType}");
            Console.WriteLine($"Book author : {book.Author.NameSurname}");
            Console.WriteLine($"Book page count : {book.PageCount}");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DisplayBookInformation()
        {
            Console.Write("\nWrite book name that you want : ");
            string bookName = Console.ReadLine();

            for(int i = 0; i<Books.Count; i++)
            {
                bool bookname = true;
                if (bookname == Books[i].Name.ToLower().Contains( bookName.ToLower()))
                    Print(Books[i]);  
                else
                    Console.WriteLine("There is no such book");
                break;
            }  
        }


        public void DisplayBookInformationByAuthor()
        {
            Console.Write("\nWrite author name that you want books : ");
            string authorName = Console.ReadLine();

            for(int i = 0; i < Books.Count; i++)
            {
                bool authorinfo = true;
                if (authorinfo == this.Books[i].Author.NameSurname.ToLower().Contains(authorName.ToLower()))
                    Print(Books[i]);
                else
                    Console.WriteLine("There is no book with such an author");
                break;

            }

        }

        public void DisplayCountOfBooks()
        {
            Console.WriteLine($"Current count books in the library is {this.Books.Count}");
        }

        public void Exit()
        {
            isEnd = true;
            Console.WriteLine("Good bye!");
        }

        public void ListAllBooks()
        {
           foreach (Book book in this.Books)
            {
                Console.WriteLine(book.Name);
            }
           
        }
    }
}
