using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class CSVReader
    {
        public CSVReader()
        {

        }

        public List<string> getLines(string filename)
        {
            List<string> positionList = new List<string>();

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                positionList.Add(line);
            }

            return positionList;
        }
    }
}
