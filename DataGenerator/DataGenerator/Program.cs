using System;
using System.IO;
using System.Linq;
using CsvHelper;

namespace DataGenerator
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GenerateCsvData();
        }

      
        

        public static void GenerateCsvData()
        {
            Random random = new Random();
            
            
            


            var records = new System.Collections.Generic.List<EmpData>();
            for(int i=1;i<1000;i++)
            {
                //var empData = new EmpData();
                
                for (int j = 0; j < 100; j++)
                {
                    var empData = new EmpData();
                    empData.Id = i;
                    empData.JobId = 1001 + j;
                    empData.DepId = 10000 + j;
                    empData.Year = 2000 + j;
                    empData.Q1 = random.Next(10000, 80000);
                    empData.Q2 = random.Next(10000, 80000);
                    empData.Q3 = random.Next(10000, 80000);
                    empData.Q4 = random.Next(10000, 80000);
                    empData.Bonus =Math.Round( empData.Q1 + (empData.Q1 / 10) * 100 + empData.Q2 + (empData.Q2 / 9) * 100 + empData.Q3 + (empData.Q3 / 8) * 100 + empData.Q4 + (empData.Q4 / 12) * 100,2);
                    empData.Salary = empData.Q1 + empData.Q2 + empData.Q3 + empData.Q4 + empData.Bonus;
                    records.Add(empData);
                    
                }
                
            }
            var result = records.OrderBy(item => random.Next());

            string path = Directory.GetCurrentDirectory();
            string filename = path + "/file.csv";
           

            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(result);
            }
        }
        
    }
}
