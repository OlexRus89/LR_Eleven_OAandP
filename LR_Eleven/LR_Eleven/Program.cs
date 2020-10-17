using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Linq.Expressions;

namespace LR_Eleven
{
    class Program
    {
        static void Main(string[] args)
        {
            /* В файле содержатся сведения о производстве товаров работниками
             * (ID, сотрудник, категория товара, з/п рабочего, количество
             * произведенных товаров, цена за единицу товара).
             * 1. Определите сколько рабочих получают меньше, чем
             * вырабатывают продукции.
             * 2. Количество единиц произведенной продукции без категории.
             * 3. Суммарный объем в валюте произведенной продукции по каждой
             * из 4-х категорий.
             * 4. Количество сотрудников, получающих более 50% от суммы
             * производимого продукта.
             */

            StreamReader FileIn = new StreamReader("lr11_27.csv");

#if !DEBUG
            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(@"lr11_output.txt");
            Console.SetOut(new_out);
#endif

            List<Products> all = new List<Products>();
            try
            {
                String line = FileIn.ReadLine();
                while ((line = FileIn.ReadLine()) != null)
                {
                    all.Add(Products.Create(line));
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("****** Задача 1 ******");
            int TasksCount = 0;
            foreach (var p in all)
            {
                if (p.Salary<p.Composition)
                {
                    TasksCount++;
                }
            }
            Console.WriteLine("Количество работников, которые получают меньше, чем вырабатывают продукции: {0}\n", TasksCount);

            Console.WriteLine("****** Задача 2 ******");

            float Tasks2Count = (from p in all
                                 where (p.Category == CategoryType.Null) && (p.Count == 1)
                                 select p).Count();
            Console.WriteLine("Количество единиц произведенной продукции без категории: {0}\n", Tasks2Count);


            Console.WriteLine("****** Задача 3 ******");

            float Tasks3Count = (from p in all
                                 select p.Composition).Sum();
            var f = System.Globalization.CultureInfo.GetCultureInfo("en-us");
            Console.WriteLine("Суммарный объем в валюте произведенной продукции по каждой из 4-х категорий: {0}\n", Tasks3Count.ToString("C", f));

            Console.WriteLine("****** Задача 4 ******");
            int Tasks4Count = 0;
            foreach (var p in all)
            {
                if (p.Procent>0.5)
                {
                    Tasks4Count++;
                }
            }
            Console.WriteLine("Количество сотрудников, получающих более 50% от суммы производимого продукта: {0}", Tasks4Count);

#if !DEBUG
            Console.SetOut(save_out);
            new_out.Close();
#endif
        }
    }
}
