using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class RPN
    {
        public static String ConvertToRPN(String input)
        {
            Stack<char> stack = new Stack<char>();
            String str = input.Replace(" ", string.Empty);
            StringBuilder formula = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char x = str[i];
                //поиск скобок в формуле
                if (x == '(')
                {
                    stack.Push(x);
                }
                else if (x == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        formula.Append(stack.Pop());//добавляет в конец скроки
                    }
                    stack.Pop();
                }
                //поиск переменных в формуле
                else if (IsOperandus(x))
                {
                    formula.Append(x);
                }
                //поиск операторов в формуле
                else if (IsOperator(x))
                {
                    //копирует первый элемент и проверяет приоритетность
                    while (stack.Count > 0 && stack.Peek() != '(' && Prior(x) <= Prior(stack.Peek()))
                    {
                        formula.Append(stack.Pop());
                    }
                    stack.Push(x);
                }
                else
                {
                    char y = stack.Pop();
                    if (y != '(')
                    {
                        formula.Append(y);
                    }
                }
            }
            while (stack.Count > 0)
            {
                //перетягиваем из стека в строку
                formula.Append(stack.Pop());
            }
            return formula.ToString();
        }
        //если использован имеено этот оператор из ряда, то выводим true, иначе false
        static bool IsOperator(char c)
        {
            return (c == '@' || c == '+' || c == '*' || c == '=' || c == '^' || c == '#' || c == '!' || c == '&' || c == '$' || c == '?');
        }
        //если использован имеено эта буква из ряда, то выводим true, иначе false
        static bool IsOperandus(char c)
        {
            return (c >= 'a' && c <= 'z');
        }
        static int Prior(char c)
        {
            switch (c)
            {
                case '!':
                    return 0;
                case '*':
                    return 1;       
                case '+':
                    return 2;
                case '^':
                    return 3;
                case '@':
                    return 4;
                case '$':
                    return 4;
                case '?':
                    return 4;
                case '&':
                    return 4;
                case '=':
                    return 5;
                case '#':
                    return 6;
                default:
                    throw new ArgumentException("Incorect input");
            }
        }
    }
}
  

    
   




