using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.EF.Models;

namespace ProjectManager.EF
{
    public class ProgramEF
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ProjectManager;Integrated Security=True;TrustServerCertificate=True";

            ContextEF ctx = new ContextEF(connectionString);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DELETE DB");
            Console.ForegroundColor = ConsoleColor.White;
            ctx.Database.EnsureDeleted(); // De volledige DB verwijderen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CREATE DB");
            Console.ForegroundColor = ConsoleColor.White;
            ctx.Database.EnsureCreated();
            //ctx.SeedData();

            //Console.WriteLine("-------------------------------------------");

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Read DB");
            //Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
