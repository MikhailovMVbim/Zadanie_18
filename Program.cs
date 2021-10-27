using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Дана строка, содержащая скобки трёх видов (круглые, квадратные и фигурные) и любые другие символы.
 * Проверить, корректно ли в ней расставлены скобки. Например, в строке ([]{})[] скобки расставлены корректно, а в строке ([]] — нет.
 * Указание: задача решается однократным проходом по символам заданной строки слева направо;
 * для каждой открывающей скобки в строке в стек помещается соответствующая закрывающая,
 * каждая закрывающая скобка в строке должна соответствовать скобке из вершины стека (при этом скобка с вершины стека снимается);
 * в конце прохода стек должен быть пуст.
 */

namespace Zadanie_18
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "";
            Console.WriteLine("Задание 18.Корректно ли в расставлены скобки в строке?");
            Console.WriteLine("------------------------------------------------------");
            string test = "gd({}{})({[]})[9][hfgh][9fdg]]";
            //string test = "t[e(s{t(1)})23]{}";
            Stack <char> st1 = new Stack<char>();
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i]=='(')
                {
                    st1.Push(')');
                }
                if (test[i] == '{')
                {
                    st1.Push('}');
                }
                if (test[i] == '[')
                {
                    st1.Push(']');
                }
                try
                {
                    if ((test[i] == ')') && st1.Peek() == ')')
                    {
                        st1.Pop();
                    }
                    if ((test[i] == '}') && st1.Peek() == '}')
                    {
                        st1.Pop();
                    }
                    if ((test[i] == ']') && st1.Peek() == ']')
                    {
                        st1.Pop();
                    }
                }
                catch (InvalidOperationException) when (st1.Count==0)
                {

                    msg="Стек пуст, но количество закрывающих скобок превышает количество открывающих.";
                }

            }
            Console.WriteLine("Был выполнен анализ строки: "+test);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Результат анализа строки:");
            if (st1.Count==0&&msg=="")
            {
                Console.WriteLine("Стек пуст! Скобки расставлены корректно!");
            }
            else if (st1.Count == 0 && msg != "")
            {
                Console.WriteLine(msg);
            }
            else
            {
                Console.WriteLine("Скобки расставлены не корректно! В стеке остались элементы:");
                foreach (var item in st1)
                {
                    Console.Write(item);
                }
            }
            Console.ReadKey();

        }
    }
}
