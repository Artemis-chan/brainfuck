using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    private const int CellCount = 30000;
    static void Main(string[] r)
    {
        byte[] a = new byte[CellCount];
        int p = 0;
        Stack<int> l = new Stack<int>();
        string str = File.ReadAllText(r[0]);
        for (int i = 0; i < str.Length; i++)
        {
            switch (str[i])
            {
                case '>':
                    p++;
                    if(p > CellCount) p = 0;
                    break;
                case '<':
                    p--;
                    if (p < 0) p = CellCount - 1;
                    break;
                case '+':
                    a[p]++;
                    break;
                case '-':
                    a[p]--;
                    break;
                case ',':
                    a[p] = (byte)Console.Read();
                    break;
                case '.':
                    Console.Write((char)a[p]);
                    break;
                case '[':
                    l.Push(i);
                    break;
                case ']':
                    if(a[p] > 0)
                        i = l.Peek();
                    else
                        l.Pop();
                    break;
                default:
                    break;
            }
        }
    }
}
