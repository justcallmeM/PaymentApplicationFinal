using System.Linq;

namespace Application
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
