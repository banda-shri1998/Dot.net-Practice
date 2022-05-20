using System;
using System.Collections.Generic;
using System.Text;

namespace Practice01
{
    class GetClassObj
    {
        public CSVBaseXML GetCSVBaseXML() {
            return new CSVBaseXML();

        }
        public CSVBaseJson GetCSVBaseJson() {
            return new CSVBaseJson();
        }
        public FileManger GetFileManger() {
            return new FileManger();
            /*var data = f.read(f);
            return data;*/
        }
    }
}
