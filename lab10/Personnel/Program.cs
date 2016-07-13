using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        public static void ReadFile(List<string> personnels)
        {
            try
            {
                var reader = new StreamReader("PersonnelFile1.txt");
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        return;
                    }
                    personnels.Add(line);
                }
            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
           
        }
        static void Main(string[] args)
        {
            var personnels =  new List<string>();
            ReadFile(personnels);
            foreach (var personnel in personnels)
            {
                Console.WriteLine(personnel);
            }
        }
    }
}
