using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LR_Eleven
{
    enum CategoryType
    {
        A,
        B,
        C,
        D,
        Null
    }
    class Products
    {
        String ID { get; set; }
        String Name { get; set;}
        public CategoryType Category { get; set; }
        public float Salary { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public float Composition { get; set; }
        public float Procent { get; set; }

        public static Products Create(String str)
        {
            Products p = new Products();
            string[] e = str.Split(',');
            p.ID = e[0].Trim();
            p.Name = e[1].Trim();
            String tmp = e[2].Trim();
            if (tmp == "A")
                p.Category = CategoryType.A;
            else if (tmp == "B")
                p.Category = CategoryType.B;
            else if (tmp == "C")
                p.Category = CategoryType.C;
            else if (tmp == "D")
                p.Category = CategoryType.D;
            else
                p.Category = CategoryType.Null;
            p.Salary = Convert.ToSingle(e[3].TrimStart('$').Replace('.',','));
            p.Count = Convert.ToInt32(e[4].Trim());
            p.Price = Convert.ToSingle(e[5].TrimStart('$').Replace('.', ','));
            p.Composition = p.Price * p.Count;
            p.Procent = p.Composition / p.Salary;
            return p;
        }

        public override string ToString()
        {
            String s = string.Format(
                "***********************************************************************************\n" +
                "ID: {0}, Сотрудник: {1}, Категория товара: {2}\n" +
                "З/П рабочего: {3}, Количество произведенных товаров: {4}\n" +
                "Цена за единицу товара: {5}", ID, Name, CategoryToStr(Category) , Salary, Count, Price );

            return s;
        }

        private static String CategoryToStr(CategoryType g)
        {
            if (g == CategoryType.A) return "A";
            else if (g == CategoryType.B) return "B";
            else if (g == CategoryType.C) return "C";
            else if (g == CategoryType.D) return "D";
            else return "Нет категории";
        }
    }
}
