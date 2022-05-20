//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;



namespace Practice01
{
    class FileManger
    {
        //private string sourceDir= @"D:\Untitled spreadsheet.csv";
        //private string backupDir= @"D:\Naveen.txt";
        public string[] read(string textfile)
        {
            string[] lines = File.ReadAllLines(textfile);
            return lines;
        }
        
        public static async Task ExampleAsync(string name, string lastName, int age)
        {
            string[] lines =
            {
                name, lastName, age.ToString()
            };
            await File.WriteAllLinesAsync(@"D:\Untitled spreadsheet.csv", lines);
        }
        public void Write(string res)
        {
            string destinationFile = "D:\\Training\\Naveen Assignment\\Naveen.txt";
            File.WriteAllText(destinationFile, res);
        }
        public void Properties(string FilePath) {
            Console.WriteLine("Last access Time:" + File.GetLastAccessTime(FilePath).Date);
            Console.WriteLine("Creation Time:" + File.GetCreationTime(FilePath).Date);
            Console.WriteLine("Attributes of the File: " + File.GetAttributes(FilePath));
        }
        public void delete(string P) {
            File.Delete(P);
        }
    }
}