using System;
using SamuraiApp.Domain;
using SamuraiApp.Data;
using System.Linq;
using System.Collections.Generic;

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

            InsertSamuraiWithQuotes();

            GetSamurais("Before Add: ");
            AddSamurai();
            InsertMultipleSamurais();
            InsertVariousTypes();
            GetSamurais("After Add: ");

            Console.Write("Press any key");
            Console.ReadKey(); 
        }

        private static void InsertVariousTypes()
        {
            // Conext also has Add() and AddRange(). It infers which DbSet to Use. 
            // Particularly useful to insert various records of different types
            using (var context = new SamuraiContext())
            {
                var samurai = new Samurai { Name = "MaVero" };
                var clan = new Clan { ClanName = "Globant" };

                context.AddRange(samurai, clan);

                context.SaveChanges();
            }
        }

        private static void InsertMultipleSamurais()
        {
            // This is a bulk operation. 
            using (var context = new SamuraiContext())
            {
                var samurai1 = new Samurai { Name = "Andrea" };
                var samurai2 = new Samurai { Name = "ValentinaV" };
                var samurai3 = new Samurai { Name = "Vanesa" };
                var samurai4 = new Samurai { Name = "Ana María" };
                var samurai5 = new Samurai { Name = "ValentinaC" };
                var samurai6 = new Samurai { Name = "Leidy" };

                var list = new List<Samurai>() { samurai3, samurai4, samurai5, samurai6 };

                context.Samurais.AddRange(samurai1, samurai2);  // Way 1
                context.Samurais.AddRange(list);                // Way 2

                context.SaveChanges();
            }
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

        private static void AddBattle()
        {

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


        private static void InsertSamuraiWithQuotes()
        {
            var samurai = new Samurai
            {
                Name = "poca luz",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "Ich weiss es nicht" }
                }
            };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }

        }

        private static void AddQuoteToExistingSamurai()
        {
            using (var context = new SamuraiContext())
            {
                var samurai = context.Samurais.FirstOrDefault();
                samurai.Quotes.Add(new Quote
                {
                    Text = "Aliens are not here"
                });
                context.SaveChanges();
            }
        }


    }
}
