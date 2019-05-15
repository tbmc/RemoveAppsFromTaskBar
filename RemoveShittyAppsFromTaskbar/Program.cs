using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;


namespace RemoveShittyAppsFromTaskbar
{
    class Program
    {
        public static List<string> ReadFileLineByLine(string path)
        {
            List<string> output = new List<string>();
            string line;
            var file = new System.IO.StreamReader(path);
            while((line = file.ReadLine()) != null)
            {
                if(line.Length > 1)
                {
                    output.Add(line);
                }
            }
            file.Close();
            return output;
        }

        static int Main(string[] args)
        {
            string fileName = "file_list.txt";
            if(args.Length >= 1)
            {
                fileName = args[0];
            }

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found");
            }

            var list = ReadFileLineByLine(fileName);
            bool success = RemoveFromTaskBar.RemoveListFromTaskbar(list);

            Console.WriteLine($"L'opération s'est bien déroulé : {success}");
            Thread.Sleep(1000);
            return success ? 0 : 1;
        }
    }
}
