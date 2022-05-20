using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Practice01
{
    class CSVBaseXML: FileManger
    {
        /*public CSVBaseXML(string path) : base(path)
        {
        }*/

        public  void ConvertToXml(string[] lines)
        {
            var xmlTree = new XElement("TopElement");
            foreach (var line in lines)
            {
                var currentTree = new XElement("Item");
                const string delimiter = ","; // Can be changed based on the actual situation
                string[] slices = line.Split(delimiter);
                for (int i = 0; i < slices.Count(); i++)
                    currentTree.Add(new XElement($"Column{i}", slices[i].ToString()));
                xmlTree.Add(currentTree);
            }
            xmlTree.Save(Path.Combine("D:\\Training\\Naveen Assignment\\", @"output.xml"));
            Console.WriteLine(xmlTree);
        }
    }
}
