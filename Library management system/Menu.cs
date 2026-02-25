using System.Diagnostics.Metrics;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_management_system
{
    internal class Menu
    {
        private Library library = new Library();
        private User user;
        private string optionID = string.Empty;
        private string titleID = string.Empty;
        private int outNumber;

        //internal void Start()
        //{
        //    this.CreateAccount();

        //    Console.WriteLine(
        //        "\n\nSelect your title: " +
        //        "\n1. A Keeper" +
        //        "\n2. An Apprentice" +
        //        "\n3. I bear no title and wish not to be here any longer.");

        //    titleID = Console.ReadLine();
        //    switch (titleID)
        //    {
        //        case "1":
        //            this.KeeperOptions();
        //            break;
        //        case "2":
        //            this.ApprenticeOptions();
        //            break;
        //        case "3":
        //            Environment.Exit(0);
        //            break;
        //        default:
        //            Console.WriteLine("\n\nINCORRECT, you fool! Again.");
        //            this.Start();
        //            break;
        //    }
        //}

        internal void Start()
        {
            this.CreateAccount();
            switch (user.TitleID)
            {
                case 1:
                    this.KeeperOptions();
                    break;
                case 2:
                    this.ApprenticeOptions();
                    break;
                default:
                    Console.WriteLine("\n\nYour account is corrupted. Create a new one");
                    this.CreateAccount();
                    break;
            }
        }


        private void KeeperOptions()
        {
            Console.WriteLine(
                "\n\nAs a Keeper of the Books you may: " +
                "\n1. Add a new book" +
                "\n2. View existing books" +
                "\n3. Update a book" +
                "\n4. Destroy a book" +
                "\n5. Start again" +
                "\n6. Exit"
                );

            optionID = Console.ReadLine();
            switch (optionID)
            {
                case "1":
                    this.library.AddBook();
                    this.KeeperOptions();
                    break;
                case "2":
                    this.library.ViewBooks();
                    this.KeeperOptions();
                    break;
                case "3":
                    this.library.UpdateBook();
                    this.KeeperOptions();
                    break;
                case "4":
                    this.library.DeleteBook();
                    this.KeeperOptions();
                    break;
                case "5":
                    this.Start();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n\nINCORRECT, you fool! Again.");
                    this.KeeperOptions();
                    break;
            }
        }

        private void ApprenticeOptions()
        {
            Console.WriteLine(
                "\n\nAs an Apprentice you may: " +
                "\n1. View existing books" +
                "\n2. Borrow a book" +
                "\n3. Return a book" +
                "\n4. Start again" +
                "\n5. Exit"
                );

            optionID = Console.ReadLine();
            switch (optionID)
            {
                case "1":
                    this.library.ViewBooks();
                    this.ApprenticeOptions();
                    break;
                case "2":
                    this.library.BorrowBook();
                    this.ApprenticeOptions();
                    break;
                case "3":
                    this.library.ReturnBook();
                    this.ApprenticeOptions();
                    break;
                case "4":
                    this.Start();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n\nINCORRECT, you fool! Again.");
                    this.ApprenticeOptions();
                    break;
            }
        }


        public void CreateAccount()
        {
            user = new User(
                this.GetInfoFromUser("Name"),
                this.GetNumericInfoFromUser("Title (1 - Keeper; 2 - Apprentice)"),
                this.GenerateUserID()
            );
        }
        private string GetInfoFromUser(String message)
        {
            Console.WriteLine("\nEnter " + message + ": ");
            return Console.ReadLine();
        }

        private int GetNumericInfoFromUser(String message)
        {
            Console.WriteLine("Enter " + message + ": ");
            if (Int32.TryParse(Console.ReadLine(), out outNumber) && (outNumber == 1 || outNumber == 2))
            {
                return outNumber;
            }
            else
            {
                Console.WriteLine("Incorrect, you fool! Again.");
                return GetNumericInfoFromUser(message);
            }
        }

        private int GenerateUserID()
        {
            Random random = new Random();
            return random.Next(0, 100);
        }
    }
}
