using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnversoftExerciese2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadCSVandWriteToFile1();
            ReadCSVandWriteToFile2();

            if (File.Exists("Names.txt") && File.Exists("Addresses.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Files already exist, contents have been re-written.\n \n");
            }
            else
            {
                Console.Write("Files successfully created.\n \n ");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== Please Note: The files are stored in the Debug folder of the project. =====");
            Console.WriteLine("***** Root: Exerciese2/EnversoftExerciese2/bin/Debug *****\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press Enter to exist the program.");
            Console.ReadLine();
        }

        static void ReadCSVandWriteToFile1()
        {
            try
            {
                var file1 = File.ReadAllLines("Data.csv");
                var records = new List<contactModel>();
                foreach (var line in file1)
                {
                    var result = line.Split(',');
                    var contacts = new contactModel() { firstName = result[0], lastName = result[1]};
                    records.Add(contacts);
                }
                var list = records.OrderBy(x => x.firstName + " " + x.lastName)
                  .ThenBy(x => x)
                  .ToList();
                var freq = records.Count(x => x == records.FirstOrDefault());
                list.ForEach(a => File.AppendAllText("Names.txt", a.firstName + " " + a.lastName + "," + freq+"\n"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ReadCSVandWriteToFile2()
        {
            try
            {
                var file2 = File.ReadAllLines("Data.csv");
                var records = new List<contactModel>();
                foreach (var line in file2)
                {
                    var result = line.Split(',');
                    var contacts = new contactModel() { address = result[2]};
                    records.Add(contacts);
                }
                var list = records.OrderBy(x => x.address)
                  .ToList();
                list.ForEach(a => File.AppendAllText("Addresses.txt", a.address + "\n"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
