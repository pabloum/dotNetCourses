using System;

namespace Introduction
{
    class Program
    {
        
        // This goes to a path, and then brings a list in descendent order os the files in that path
        public static string ShowFilesWithoutLinq(string path)
        {
            return "";
        }

        // This goes to a path, and then brings a list in descendent order os the files in that path
        public static string ShowFilesWithLinq(string path)
        {
            return "";
        }

        static void Main(string[] args)
        {
            string path = @"C:/windows";
            var response1 = ShowFilesWithoutLinq(path);
            var response2 = ShowFilesWithLinq(path);
        }
    }
}
