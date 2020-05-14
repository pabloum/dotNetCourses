using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {
        
        // This goes to a path, and then brings a list in descendent order os the files in that path
        public static string ShowFilesWithoutLinq(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            foreach (FileInfo file in files)
            {
                Console.WriteLine($"The name {file.Name, -20}, the size: {file.Length, 10}");
            }

            return "";
        }

        // This goes to a path, and then brings a list in descendent order os the files in that path
        public static string ShowFilesWithLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            var query = from file in directory.GetFiles()
                        orderby file.Length descending
                        select file;

            var query2 = directory.GetFiles()
                         .OrderByDescending(f => f.Length)
                         .Take(5);
            
            foreach (var file in query.Take(5)) // Just take the 5 first elements
            {
                Console.WriteLine($"The name {file.Name,-20}, the size: {file.Length,10}");
            }



            return "";
        }

        static void Main(string[] args)
        {
            string path = @"C:/Users/pablo.uribe/Documents/";
            var response1 = ShowFilesWithoutLinq(path);
            Console.WriteLine("----**-----");
            var response2 = ShowFilesWithLinq(path);
        }
    }

    class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
