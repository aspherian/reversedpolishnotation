using System;
using System.Collections.Generic;

public class Program
{
    public static List<string> ReversePolishNotation(string str)
    {
        List<string> elements = Parse(str);
        List<string> str2 = new List<string>();
        List<string> resultstr = new List<string>();
        List<string> operands = new List<string> { "+", "-", "*", "/", "(", ")" };
        foreach (string element in elements)
        {
            if (element == "(")
            {
                str2.Insert(0, element);
            }
            else if (operands.Contains(element))
            {
                if (str2.Count == 0)
                {
                    str2.Insert(0, element);
                }
                else if (element == ")")
                {
                    while (true)
                    {
                        string q = str2[0];
                        str2.RemoveAt(0);
                        if (q == "(")
                        {
                            break;
                        }
                        resultstr.Add(q);
                    }
                }
                else if (Priority(str2[0]) < Priority(element))
                {
                    str2.Insert(0, element);
                }
                else
                {
                    while (true)
                    {
                        if (str2.Count == 0)
                        {
                            break;
                        }
                        string q = str2[0];
                        resultstr.Add(q);
                        str2.RemoveAt(0);
                        if (Priority(q) == Priority(element))
                        {
                            break;
                        }
                    }
                    str2.Insert(0, element);
                }
            }
            else
            {
                resultstr.Add(element);
            }
        }
        while (str2.Count != 0)
        {
            string q = str2[0];
            resultstr.Add(q);
            str2.RemoveAt(0);
        }
        return resultstr;
    }

    public static int Priority(string o)
    {
        if (o == "+" || o == "-")
        {
            return 1;
        }
        else if (o == "*" || o == "/")
        {
            return 2;
        }
        else if (o == "(")
        {
            return 0;
        }
        return -1;
    }

    public static List<string> Parse(string str)
    {
        List<string> delims = new List<string> { "+", "-", "*", "/", "(", ")" };
        List<string> elements = new List<string>();
        string tmp = "";
        foreach (char c in str)
        {
            if (c != ' ')
            {
                if (delims.Contains(c.ToString()))
                {
                    if (tmp != "")
                    {
                        elements.Add(tmp);
                    }
                    elements.Add(c.ToString());
                    tmp = "";
                }
                else
                {
                    tmp += c;
                }
            }
        }
        if (tmp != "")
        {
            elements.Add(tmp);
        }
        return elements;
    }

    public static void Main()
    {
        List<string> result = ReversePolishNotation("(9+12)-10*(40-20)");
        foreach (string element in result)
        {
            Console.Write(element + " ");
        }
    }
}