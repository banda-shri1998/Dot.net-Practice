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
        public string ConvertTojson(string[] lines)
        {
            var csv = new List<string[]>();
            foreach (string line in lines)
            {
                csv.Add(line.Split(','));
            }
            var properties = lines[0].Split(',');
            var listObjresult = new List<Dictionary<string, string>>();
            for (int i = 1; i < lines.Length; i++)
            {
                var Objectresult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                {
                    Objectresult.Add(properties[j], csv[i][j]);
                }
                listObjresult.Add(Objectresult);
            }
            return JsonConvert.SerializeObject(listObjresult);
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
            string destinationFile = @"D:\Naveen.txt";
            File.WriteAllText(destinationFile, res);
        }
    }
}