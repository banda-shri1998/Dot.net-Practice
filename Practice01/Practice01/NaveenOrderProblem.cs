using System;
using System.Collections.Generic;
using System.Text;

namespace Practice01
{
    class NaveenOrderProblem
    {
        public void count(string[] lines)
        {
            int m = 0, f = 0; int o = 0;
            var csv = new List<string[]>();
            foreach (string line in lines)
                csv.Add(line.Split(','));
            var properties = lines[0].Split(',');
            for (int i = 1; i < lines.Length; i++)
            {
                if (csv[i][1] == "male" || csv[i][1] == "Male")
                {
                    m++;
                }
                else if (csv[i][1] == "female" || csv[i][1] == "Female")
                {
                    f++;
                }
                else
                    o++;
            }
            Console.WriteLine("male=" + m);
            Console.WriteLine("female=" + f);
            Console.WriteLine("other=" + o);
        }
        public void CountVeg(string[] lines) {
            int m = 0, f = 0; 
            int o= 0;
            var csv = new List<string[]>();
            foreach (string line in lines)
                csv.Add(line.Split(','));
            //var properties = lines[0].Split(',');
            for (int i = 1; i < lines.Length; i++) 
            {
                if (csv[i][1] == "male" || csv[i][1] == "Male") {
                    if (csv[i][15].Contains("Non Veg foods"))
                    {
                        break;
                    }
                    else {
                        m++;
                    }
                }
                if (csv[i][1] == "Female" || csv[i][1] == "Female")
                {
                    if (csv[i][15].Contains("Non Veg foods"))
                    {
                        break;
                    }
                    else
                    {
                        f++;
                    }
                }
            }
            Console.WriteLine("male=" + m);
            Console.WriteLine("female=" + f);
        } 
    }
}
