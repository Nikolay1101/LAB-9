using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_9
{
    internal class Program
    {
        static bool CheckExpression(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in expression)
            {
                if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    if (stack.Count == 0 || stack.Peek() != '(')
                    {
                        return false; // Не найдена соответствующая открывающая скобка
                    }
                    stack.Pop(); // Удаляем соответствующую открывающую скобку из стека
                }
            }

            return stack.Count == 0; // Если стек пуст, все скобки закрыты правильно
        }

        static void Main(string[] args)
        {
            string[] expressions = {
            "(2+3)(1+6)(((2-3)(5+1)))",
            "2(3)(1+6(7+2))((2-3)(5+1))",
            "2(3+5(((6)))",
            "((2+3)(4-1)))",
            "2(3+5(((6))"
        };

            foreach (string expression in expressions)
            {
                Console.WriteLine($"Выражение: {expression}");
                bool isValid = CheckExpression(expression);
                Console.WriteLine($"Корректное: {isValid}");
                Console.WriteLine();
            }
        }
    }
}
