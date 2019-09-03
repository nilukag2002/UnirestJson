using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace UniRest_Json.Utility
{
    class ReadExcel
    {
        public string getSolutionPath()
        {
            DirectoryInfo assemblyPath = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            DirectoryInfo binPath = Directory.GetParent(assemblyPath.ToString());
            DirectoryInfo solutionPath = Directory.GetParent(binPath.ToString());
            return solutionPath.ToString();
        }
        public string filePathToExcel()
        {

            // return Path.Combine(Directory.GetParent, @"Utility\", "data.xlsx");
            return getSolutionPath() + "\\Data\\data.xlsx";
        }
    }
}
