using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBasic1
{
    class FileSystem
    {
        public void SingleByte()
        {
            FileStream fs = new FileStream("E:\\BizRun.NET\\abc.txt", FileMode.OpenOrCreate);//creating file stream
            fs.WriteByte(65);////writing byte into stream 
            fs.WriteByte(64);
            fs.WriteByte(66);
            fs.Close();     //closing stream
        }
        public void MultiByte()
        {
            FileStream fs = new FileStream("E:\\BizRun.NET\\abc1.txt", FileMode.OpenOrCreate);
            for (int i = 65; i <= 90; i++)
            {
                fs.WriteByte((Byte)i);
            }
            fs.Close();
        }
        public void ReadByte()
        {
            FileStream fs = new FileStream("E:\\BizRun.NET\\abc1.txt", FileMode.OpenOrCreate);
            int i = 0;
            while ((i = fs.ReadByte()) != -1)
            {
                Console.Write((char)i);
            }
            Console.WriteLine();
            fs.Close();
        }
        public void StreamWrite()
        {
            FileStream fs = new FileStream("E:\\BizRun.NET\\abc2.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Welcome to Bizruntime for C#");
            sw.Write("again same");
            sw.Write(" in the same line");
            sw.Close();
            fs.Close();
        }
        public void StreamRead()
        {
            FileStream fs = new FileStream("E:\\BizRun.NET\\abc2.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            Console.WriteLine(line);
            sr.Close();
            fs.Close();
        }
        public void ReadAllLine()
        {
            FileStream fs = new FileStream("E:\\BizRun.NET\\abc2.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            sr.Close();
            fs.Close();
        }
        public void TextWrite()
        {
            using (TextWriter tw = File.CreateText("E:\\BizRun.NET\\abc3.txt"))
            {
                tw.WriteLine("Hi every one");
                tw.WriteLine("This is Razi Ahmad");
                tw.WriteLine("living in Bangalore");
                tw.WriteLine("working in Bizruntime");
            }
        }
        public void TextRead()
        {
            using (TextReader tr = File.OpenText("E:\\BizRun.NET\\abc3.txt"))
            {
                Console.WriteLine(tr.ReadToEnd());
            }
        }
        public void SingleLine()
        {
            using (TextReader tr = File.OpenText("E:\\BizRun.NET\\abc3.txt"))
            {
                Console.WriteLine(tr.ReadLine());
            }
        }
        public void BinaryWrite()
        {
            string file = "E:\\BizRun.NET\\binaryFile.dat";
            BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create));
            using (bw)
            {
                bw.Write(14.52);
                bw.Write("little busy");
                bw.Write(true);
            }
        }
        public void BinaryRead()
        {
            string file = "E:\\BizRun.NET\\binaryFile.dat";
            BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open));
            using (br)
            {
                Console.WriteLine("double value:" + br.ReadDouble());
                Console.WriteLine("string value:" + br.ReadString());
                Console.WriteLine("boolean value:" + br.ReadBoolean());
            }
        }
        public void StrWritRead()
        {
            string text = "Hi, My name is Razi Ahmad \n" +
                         "living in Banglore \n" +
                         "Currently trainee in bizruntime";
            StringBuilder sb = new StringBuilder();     //creating string builder instance
            StringWriter writer = new StringWriter(sb);//Passing StringBuilder instance into StringWriter 
            writer.WriteLine(text);//writing text into StringWriter
            writer.Flush(); //to clear the buffer and the stream will remain open
            writer.Close();

            StringReader reader = new StringReader(sb.ToString());
            while(reader.Peek() > -1)
            {
                Console.WriteLine(reader.ReadLine());
            }
        }
        public void FileCreateInfo()
        {
            try
            {
                FileInfo file = new FileInfo("E:\\BizRun.NET\\abc4.txt");
                file.Create();      //creating an empty file
            }
            catch (IOException ex) { Console.WriteLine(ex.Message); }
        }
        public void FileWriteInfo()
        {
            try
            {
                FileInfo file = new FileInfo("E:\\BizRun.NET\\abc4.txt");
                StreamWriter sw = file.CreateText();    //Creating an file instance to write  
                sw.WriteLine("new file text");
                sw.WriteLine("write new line");
                sw.WriteLine("again write one more line");
                sw.Close();
            }
            catch (IOException ex) { Console.WriteLine(ex.Message); }
        }
        public void FileReadInfo()
        {
            try
            {
                FileInfo file = new FileInfo("E:\\BizRun.NET\\abc4.txt");
                StreamReader sr = file.OpenText();
                string data = "";
                while ((data = sr.ReadLine()) != null)
                {
                    Console.WriteLine(data);
                }
            }
            catch (IOException e) { Console.WriteLine("Something went wrong: " + e); }
        }
        public void CreateDir()
        {
            DirectoryInfo dir = new DirectoryInfo(@"E:\BizRun.NET\abc");
            try
            {
                if (dir.Exists)
                {
                    Console.WriteLine("Directory already exist.");
                    return;
                }
                dir.Create();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void DeleteDir()
        {
            DirectoryInfo dir = new DirectoryInfo(@"E:\BizRun.NET\abc");
            try
            {
                dir.Delete();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static void Main(string[] args)
        {
            FileSystem fsy = new FileSystem();
            //fsy.SingleByte();
            //fsy.MultiByte();
            //fsy.ReadByte();
            //fsy.StreamWrite();
            //fsy.StreamRead();
            //fsy.ReadAllLine();
            //fsy.TextWrite();
            //fsy.TextRead();
            //fsy.SingleLine();
            //fsy.BinaryWrite();
            //fsy.BinaryRead();
            //fsy.StrWritRead();
            //fsy.FileCreateInfo();
            //fsy.FileWriteInfo();
            //fsy.FileReadInfo();
            //fsy.CreateDir();
            fsy.DeleteDir();
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
