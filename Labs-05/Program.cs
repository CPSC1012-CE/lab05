using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Labs_05
{
    internal class Program
    {
        public const int markCount = 35;
        static void Main(string[] args)
        {           //Purpose:  Utilize arrays, Use File I / O ,Construct modular code ,Practice program maintenance
                    //Input: double[] marks, string path
                    //Output: double[] marks, double percentage, double averagePercentage, int pass, int fail 
                    //Written by: Dilpreet Chinna
                    //Written for: Carlos Estoy
                    //Section: E01
                    //Last Modified Date: 2022-11-19
            string path = @"C:\CPSC1012\Lab5\QuizMarks.txt";
            double[] marks = new double[25];

            Console.WriteLine("Welcome to the Quiz Mark Calculator");
            Console.WriteLine("===================================");

           

            if (!File.Exists(path))
            {
                Console.WriteLine("The file, {0} does not exist", path);
            }
            else
            {
                Console.WriteLine("Quiz Total marks = " + markCount);
                string[] data = LoadData(path, marks);

                Console.WriteLine("marks");
                for (int i = 0; i < data.Length; i++)
                {
                    marks[i] = Convert.ToDouble(data[i]);
                    Console.WriteLine(marks[i]);
                }

                Console.WriteLine("Percentage");
                double percentage = 0;
                for (var i = 0; i < data.Length; i++)
                {
                    percentage = marks[i] / markCount;
                    percentage = percentage * 100;
                    Console.WriteLine(Math.Round(percentage, 2));
                }
                double averagePercentage = Averagepercentage(marks, markCount);
                Console.WriteLine("The class average is " + averagePercentage + "%");
                PrintPassesAndFails(marks, markCount);
            }
            
        }
        public static string[] LoadData(string dataFilePath, double[] marks)
        {
            string[] text = new string[25];             
            text = File.ReadAllLines(dataFilePath).ToArray();           
            return text;
        }
        public static double PrintMarks(double[] marks, int markCount)
        {
            double percentage = 0;
            for (var i = 0; i <= marks.Length - 1; i++)
            {
                percentage = marks[i] / markCount;
                percentage = percentage * 100;
            }

            return percentage;
        }
        public static double Averagepercentage(double[] marks, int markcount)
        {
            double percentage = 0;
            double count = 0;
            for (var i = 0; i <= marks.Length - 1; i++)
            {
                percentage = marks[i] / markCount;
                percentage = percentage * 100;
                count += percentage;
            }

            return Math.Round(count / marks.Length, 2);
        }
        public static void PrintPassesAndFails(double[] marks, int markCount)
        {
            double individualPercentage = 0;
            int pass = 0, fail = 0;
            for (var i = 0; i <= marks.Length - 1; i++)
            {
                individualPercentage = marks[i] / markCount;
                individualPercentage = individualPercentage * 100;
                if (individualPercentage >= 50)
                {
                    pass += 1;
                }
                if (individualPercentage < 50)
                {
                    fail += 1;
                }
            }
            Console.WriteLine("There were {0} passes and {1} fails", pass, fail);
        }

    }
}