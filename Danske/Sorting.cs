using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Sorting
    {
        public string[] SortByDate(string[] contentsOfFile)
        {
            var sorted = contentsOfFile.OrderBy(i => i);
            string[] sortedFile = sorted.ToArray();

            return sortedFile;
        }
    }
}
