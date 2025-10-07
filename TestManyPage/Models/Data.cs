using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManyPage.Models
{
    internal class Data
    {
        public static List<string> ActionsList = new List<string>() { "Сложение", "Вычитание", "Умножение", "Деление" };

        public static double first1;
        public static double second2;

        public static char Oper;

        public static string result;
        public static char selectedOperations23;
        public static string _selectedOperations;


        public static List<string> History = new List<string>();
        public const int MaxHistoryCount = 3;

    }
}
