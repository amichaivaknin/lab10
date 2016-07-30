using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        private static string _search;
        private static List<string> _files=new List<string>();

        private static void CheckFile(string fileName)
        {
            try
            {
                var reader = new StreamReader(fileName);
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        return;
                    }
                    if (!line.Contains(_search)) continue;
                    FileInfo fileInfo = new FileInfo(fileName);
                    _files.Add("Name: "+fileInfo.Name+" Length: "+ fileInfo.Length);
                    return;
                }
            }/**
                You should handle all IOExceptions
                * Consider this:
                * https://msdn.microsoft.com/en-us/library/ms164917.aspx
                */
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static void Main(string[] args)
        {

////////////////////////////////////////////////////////////////////////////////
#if DEBUG
            args = new[] {$@"C:\Users\Ami\Documents\Visual Studio 2015\Projects\codeValue\lab10\Personnel\bin\Debug", "Simpson" };
#endif
////////////////////////////////////////////////////////////////////////////////

            if (args.Length < 2)
            {
                Console.WriteLine("Parameter missing");
                return;
            }

            string directory = args[0];
            _search = args[1];
            if (Directory.Exists(directory))
            {
                string[] fileEntries = Directory.GetFiles(directory, "*.txt");
                foreach (string fileName in fileEntries)
                {
                    CheckFile(fileName);
                }

                foreach (var file in _files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Wrong path or directory not found");
            }
        }
    }
}
