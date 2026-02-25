using System.Diagnostics.Metrics;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
        }
    }
}
