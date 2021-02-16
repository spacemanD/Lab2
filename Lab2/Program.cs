using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Designations: \n+ - ∨(disjunction),\n! - Not,\n* - ∧(conjuction),\n@ - →(Implication),\n= - ⇿(Equivalence),\n^ - XOR,\n# - Shifler,\n& - →(Reverse Implication),\n$ - →(Ban Implication for A)\n? - →(Ban Implication for B)\n0- FALSE, 1-TRUE");
            Console.WriteLine("\nInput variables: \n");
            string result = Console.ReadLine();
            Console.WriteLine("\nInput your formula: \n");
            var expr = Console.ReadLine();
            //получаем обратную польскую запись
            var rpn = RPN.ConvertToRPN(expr).ToArray();
            Console.WriteLine($"\n{string.Join(" ", rpn)}\n");
            //перебираем всевозможные комбинации переменных
            var varValues = new Dictionary<char, int>();
            var headerShown = false;
            foreach (var combination in Calculate.GetAllCombinations(result.ToArray(), 0, varValues))
            {
                //вычисляем значение выражения
                var res = Calculate.Calculating(rpn, varValues);
                //отображем шапку таблицы
                if (!headerShown)
                {
                    foreach (var var in varValues.Keys)
                    {
                        Console.Write(var + "\t");
                    }
                    Console.WriteLine(expr);
                    headerShown = true;
                }
                //отображем строку таблицы
                foreach (var var in varValues.Values)
                {
                    Console.Write(var + "\t");
                }
                Console.WriteLine(res);
            }
            Console.ReadKey();
        }
    }
}
        


