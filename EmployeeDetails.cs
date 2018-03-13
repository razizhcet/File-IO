using System;
using System.IO;

namespace ConsoleAppBasic1
{
    class EmployeeDetails
    {
        static void CreateFile()
        {

            string fileName = "e:\\binaryfile.dat";
            FileStream fs;
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
                fs = new FileStream(fileName, FileMode.Append);
            else
                fs = new FileStream(fileName, FileMode.Create);

            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                Console.WriteLine("Enter Employee Detail : ");
                Console.Write("Employee Name      : ");
                writer.Write(Console.ReadLine());

            i:
                try
                {
                    Console.Write("Employee Age       : ");
                    writer.Write(Convert.ToInt16(Console.ReadLine()));
                }
                catch (FormatException ex) { Console.WriteLine(ex.Message); goto i; }

            j:
                try
                {
                    Console.Write("Employee Salary    : ");
                    writer.Write(Convert.ToDouble(Console.ReadLine()));
                }
                catch (FormatException ex) { Console.WriteLine(ex.Message); goto j; }

            k:
                try
                {
                    Console.Write("Parmanent Position : ");
                    writer.Write(Convert.ToBoolean(Console.ReadLine()));
                }
                catch (FormatException ex) { Console.WriteLine(ex.Message); goto k; }
            }
        }
        static void ReadFile()
        {

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open("e:\\binaryfile.dat", FileMode.Open)))
                {
                    Console.WriteLine("\nRead Employee Detail From File : ");
                    Console.WriteLine("Employee Name     : " + reader.ReadString());
                    Console.WriteLine("Employee Age      : " + reader.ReadInt16());
                    Console.WriteLine("Employee Salary   : " + reader.ReadDouble());
                    if (reader.ReadBoolean())
                        Console.WriteLine("Employee Position : Parmanent");
                    else
                        Console.WriteLine("Employee Position : Temporary");
                }
            }
            catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }
        }
        static void Main(string[] args)
        {
            CreateFile();
            ReadFile();
            Console.ReadKey();
        }
    }
}
