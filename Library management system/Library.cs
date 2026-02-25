using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system
{
    internal class Library
    {
        private List<Book> booksList = new List<Book>();
        private string optionID = string.Empty;
        public void AddBook()
        {
            Book book = new Book(
                this.GetInfoFromUser("the Title"),
                this.GetInfoFromUser("the Author"),
                this.GenerateISBN()
            );
            booksList.Add(book);
            Console.WriteLine("You have successfully added " + book.Title + " to the library.");
        }

        public void ViewBooks()
        {
            foreach (Book book in booksList)
            {
                book.DisplayBookInfo();
            }
        }

        public void BorrowBook()
        {
            string wantedTitle = this.GetInfoFromUser("Title of the wanted book");
            foreach (Book book in booksList)
            {
                if (book.Title != wantedTitle) continue;
                book.BorrowBook();
                return;
            }
            Console.WriteLine("\n\nNo such piece has ever existed among those shelves.");
        }

        public void ReturnBook()
        {
            string wantedTitle = this.GetInfoFromUser("Title of the book being return");
            foreach (Book book in booksList)
            {
                if (book.Title != wantedTitle) continue;
                book.ReturnBook();
                return;
            }
            Console.WriteLine("\n\nNo such piece has ever existed among those shelves.");
        }

        public void UpdateBook()
        {
            string wantedTitle = this.GetInfoFromUser("Title of the book you want to update.");
            foreach (Book book in booksList)
            {
                if (book.Title != wantedTitle) continue;
                Console.WriteLine(
                "\nSelect a parameter you want to update: " +
                "\n1. Title" +
                "\n2. Author"
                );

                optionID = Console.ReadLine();
                switch (optionID)
                {
                    case "1":
                        book.Update(1);
                        break;
                    case "2":
                        book.Update(2);
                        break;
                    default:
                        Console.WriteLine("\nINCORRECT, you fool! Again.");
                        this.UpdateBook();
                        break;
                }
                return;
            }
            Console.WriteLine("\n\nNo such piece has ever existed among those shelves.");
        }

        public void DeleteBook()
        {
            string wantedTitle = this.GetInfoFromUser("Title of the book you want to destroy.");
            foreach (Book book in booksList)
            {
                if (book.Title != wantedTitle) continue;
                booksList.Remove(book);
                Console.WriteLine("You have successfully destroyed " + book.Title);
                return;
            }
            Console.WriteLine("\n\nNo such piece has ever existed among those shelves.");
        }




        private string GetInfoFromUser(String message)
        {
            Console.WriteLine("\nEnter " + message + ": ");
            return Console.ReadLine();
        }

        private int GenerateISBN()
        {
            Random random = new Random();
            return random.Next(0, 9999999);
        }
        //private int GetNumbericInfoFromUser(String message)
        //{
        //    Console.WriteLine("Enter " + message + ": ");
        //    if (Int32.TryParse(Console.ReadLine(), out outNumber)) 
        //    { 
        //        return outNumber;
        //    }
        //    else 
        //    { 
        //        Console.WriteLine("Incorrect, you fool! Again.");
        //        return GetNumbericInfoFromUser(message);
        //    }
        //}
    }
}