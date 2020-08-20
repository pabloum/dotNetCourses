using System;
using SamuraiApp.Domain;
using SamuraiApp.Data;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        //private static SamuraiContext context = new SamuraiContext();

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new SamuraiContext())
            {
                context.Database.EnsureCreated();
            }

            GetSamurais("Before Add: ");
            AddSamurai();
            GetSamurais("After Add: ");

            Console.Write("Press any key");
            Console.ReadKey(); 
        }
            
        private static void AddSamurai()
        {
            using (var context = new SamuraiContext())
            {
                var samurai = new Samurai { Name = "Vero" };
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }

        private static void GetSamurais(string text)
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }
    }
}
