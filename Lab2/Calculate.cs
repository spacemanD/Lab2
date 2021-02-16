using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    enum Operation
    {
        Not='!',
        Disjunction='+',
        Conjuction='*',
        Implication='@',
        Equivalence='=',
        XOR = '^',
        Shifler = '#',
        ReverseImplication = '&',
        BanImplicationforA = '$',
        BanImplicationforB = '?'
    }
    public class Calculate
    {
        //вычисление выражения на основании обратной польской записи и значений переменных
        public static int Calculating(IEnumerable<char> rpn, Dictionary<char, int> variableValue)
        {
            var stack = new Stack<bool>();
            foreach (var token in rpn)
            {
                switch (token)
                {
                    case (char)Operation.Not:
                        stack.Push(!stack.Pop());
                        break;
                    case (char)Operation.Disjunction:
                        stack.Push(stack.Pop() | stack.Pop());
                        break;
                    case (char)Operation.Conjuction:
                        stack.Push(stack.Pop() & stack.Pop());
                        break;
                    case (char)Operation.Implication:
                        stack.Push(stack.Pop() | !stack.Pop());
                        break;
                    case (char)Operation.BanImplicationforA:
                        stack.Push(stack.Pop() & !stack.Pop());
                        break;
                    case (char)Operation.BanImplicationforB:
                        stack.Push(!stack.Pop() & stack.Pop());
                        break;
                    case (char)Operation.ReverseImplication:
                        stack.Push(!stack.Pop() | stack.Pop());
                        break;
                    case (char)Operation.Equivalence:
                        stack.Push(stack.Pop() == stack.Pop());
                        break;
                    case (char)Operation.XOR:
                        stack.Push(stack.Pop() ^ stack.Pop());
                        break;
                    case '0':
                        stack.Push(false);
                        break;
                    case '1':
                        stack.Push(true);
                        break;
                    default:
                        stack.Push(variableValue[token] == 1);
                        break;
                }
            }
            return stack.Pop() ? 1 : 0;
        }
        //перебор всевозможных комбинаций переменных
        public static IEnumerable GetAllCombinations(IList<char> variables, int index, Dictionary<char, int> varValues)
        {

            if (index >= variables.Count)
            {
                yield return null;
            }
            else
            {
                //создается последовательность элементов (от 0 до 2 строго)
                foreach (var val in Enumerable.Range(0, 2))
                {
                    varValues[variables[index]] = val;
                    foreach (var temp in GetAllCombinations(variables, index + 1, varValues))
                    {
                        yield return temp;
                    }
                }
            }
        }
    }
    
}

