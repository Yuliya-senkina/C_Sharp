/*
    Создать пользовательский строковый класс. С помощью меха¬низма перегрузки 
    операций определите функцию, которая соз¬даёт строку, содержащую пересечение 
    двух строк, то есть общие символы для двух строк. Например, результатом 
    пересечения строк "sdqcg" и "rgfas34" будет строка "sg". Для реализации 
    функции перегрузите оператор * (бинарное умножение).
*/

using System;

public class string_
{
    private string S;
    private int len;
    public string_()
    {
        S = null;
        len = 0;
    }

    public string_(string s)
    {
        len = s.Length;
        S = new string(new char[len]);
        S = s;
    }

    public string_(string_ s)
    {
        len = s.len;
        S = new string(new char[len]);
        S = s.S;
    }


    public string GetStr()
    {
        return S;
    }

    public static string_ operator +(string_ Imp, in string_ str)
    {
        string_ s = new string_();
        s.len = Imp.len + str.len;
        s.S = new string(new char[s.len]);
        s.S = Imp.S;
        s.S = s.S + str.S;
        return new string_(s);
    }


    public string_ CopyFrom(in string_ str)
    {
        if (this == str)
        {
            return this;
        }
        if (len != str.len || len == 0)
        {
            S = null;
            len = str.len;
            S = new string(new char[len]);
        }
        S = str.S;
        return this;
    }
    public static string ChangeCharacter(string sourceString, int charIndex, char newChar)
    {
        return (charIndex > 0 ? sourceString.Substring(0, charIndex) : "")
            + newChar.ToString() + (charIndex < sourceString.Length - 1 ? sourceString.Substring(charIndex + 1) : "");
    }

    public static string_ operator *(string_ Imp, in string_ str)
    {
        string a = new string(new char[Imp.len]);
        int n = 0;
        for (int i = 0; i < Imp.len; i++)
        {
            for (int j = 0; j < str.len; j++)
            {
                if (Imp.S[i] == str.S[j])
                {
                    a = ChangeCharacter(a, n++, Imp.S[i]);
                    break;
                }
            }
        }
        a = a.Substring(0, n);
        string_ aere = new string_(a);
        a = null;
        return new string_(aere);
    }
}

public static class Globals
{
    internal static void Main()
    {
        string_ A = new string_("Иванов ");
        string_ B = new string_("Иван ");
        string_ C = new string_("Иванович");
        string_ D = new string_("sdqcg");
        string_ E = new string_("rgfas34");
        string_ RES = new string_();

        RES.CopyFrom(A + B + C);
        Console.Write(RES.GetStr());
        Console.Write("\n\n");
        RES.CopyFrom(D * E);
        Console.Write(RES.GetStr());
        Console.Write("\n\n");
        Console.ReadLine();
    }
}


