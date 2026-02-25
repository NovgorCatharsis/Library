using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system
{
    internal class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int ISBN { get; }
        public bool Status { get; set; }


        public Book(string title, string author, int isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Status = true;
        }

        internal void DisplayBookInfo()
        {
            Console.WriteLine(
                "\n\nTitle: " + this.Title +
                "\nAuthor: " + this.Author +
                "\nISBN: " + this.ISBN +
                "\nStatus: " + (this.Status ? "Available" : "Borrowed"));
        }

        internal void BorrowBook()
        {
            if (this.Status)
            {
                this.Status = false;
                Console.WriteLine("You have successfully borrowed " + this.Title);
            }
            else
            {
                Console.WriteLine(this.Title + " is already in possesion of the other.");
            }
        }

        internal void ReturnBook()
        {
            if (!this.Status)
            {
                this.Status = true;
                Console.WriteLine("You have successfully returned " + this.Title);
            }
            else
            {
                Console.WriteLine(this.Title + " is not yours to return.");
            }
        }

        internal void Update(int parameter)
        {
            switch (parameter)
            {
                case 1:
                    Console.WriteLine("\nEnter new title: ");
                    string newTitle = Console.ReadLine();
                    this.Title = newTitle;
                    Console.WriteLine("You have successfully updated the title of the book to " + this.Title);
                    break;
                case 2:
                    Console.WriteLine("\nEnter new author: ");
                    string newAuthor = Console.ReadLine();
                    this.Author = newAuthor;
                    Console.WriteLine("You have successfully updated the author of the book to " + this.Author);
                    break;
                default:
                    Console.WriteLine("\nINCORRECT, you fool! Again.");
                    this.Update(parameter);
                    break;
            }
        }
    }
}
