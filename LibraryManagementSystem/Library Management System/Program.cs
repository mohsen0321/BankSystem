using System;


namespace Library_Management_System
{


    class Program
    {
        public static void Main(string[] args)
        {
            LibraryService library = new LibraryService();
            Console.WriteLine("Welcome in my Library");
            bool exit = false;
        
            while (!exit)
            {
                Console.WriteLine("please choose one of this:");
                Console.WriteLine("1-Add Book");
                Console.WriteLine("2-View Books");
                Console.WriteLine("3-Search Book by Title");
                Console.WriteLine("4-Search Book by Author");
                Console.WriteLine("5-Borrow Book");
                Console.WriteLine("6-Return Book");
                Console.WriteLine("7-Delete Book");
                Console.WriteLine("8-View Available Books");
                Console.WriteLine("9-View Borrowed Books");
                Console.WriteLine("10-Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        library.AddBook();
                       
                        break;
                    case 2:
                        library.viewBook();
                        break;
                    
                    case 3:
                        library.SearchBookByTitle();
                        break;
                    case 4:
                        library.SearchBookByAuthor();
                        break;
                    case 5:
                        library.BorrowBook();
                        break;
                    case 6:
                        library.ReturnBook();
                        break;
                    case 7:
                        library.DeleteBook();
                        break;
                    case 8:
                        library.ViewAvailableBooks();
                        break;
                    case 9:
                        library.ViewBorrowedBooks();
                        break;
                    case 10:
                        Console.WriteLine("are you sure to exit? enter(yes-no)");
                        string result = Console.ReadLine();
                        if (result.ToLower() == "yes")
                        {
                            exit = true;
                            Console.WriteLine("thanks, Goodbuy");
                            break;
                        }
                        else
                        {
                            exit = false;
                            break;
                        }
                        
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }

            }

          
        }



       
    }



}