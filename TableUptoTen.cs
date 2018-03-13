using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBasic1
{
    class TableUptoTen
    {
        public static void WriteToFile()
        {
            using (StreamWriter sw = File.CreateText(@"E:\BizRun.NET\table.tbl"))
            {
                sw.WriteLine("Please find the below generated table of 1 to 10:");
                sw.WriteLine("");
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        sw.WriteLine("{0}x{1}= {2}", i, j, (i * j));
                    }
                    sw.WriteLine("==============");
                }
            }
        }
        public static void ReadFromFile()
        {
            using (StreamReader sr = File.OpenText(@"E:\BizRun.NET\table.tbl"))
            {
                string tables = null;
                while ((tables = sr.ReadLine()) != null)
                {
                    Console.WriteLine("{0}", tables);
                }
            }
        }
        static void Main(string[] args)
        {
            WriteToFile();
            ReadFromFile();
            Console.ReadKey();
        }
    }
}
