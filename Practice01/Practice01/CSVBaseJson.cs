using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Practice01
{
    class CSVBaseJson:FileManger
    {
        /*public CSVBaseJson(string path) : base(path)
        {
        }*/

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
                //Objectresult.Add("\n"," ");
                listObjresult.Add(Objectresult);
            }
            return JsonConvert.SerializeObject(listObjresult);
        }
        public void ConvertTextFileToCSV(string lines)
        {
            string csvfilePath = @"C:\Users\Public\TestFolder\csv\output.csv";
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\sample3.txt"); foreach (string line in lines)
            {
                var parts = lines.Split(' ');
                string csvLine = string.Join(",", parts);
                Console.WriteLine(csvLine); 
                File.AppendAllText(csvfilePath, csvLine + Environment.NewLine);
            }
            Console.ReadKey();
        }       
    }
}
