/*
    Дано целое число N большее 0. Это число программа должна получать у 
    пользователя. Найти число, полученное при прочтении числа N справа налево. 
    Например, если было введено число 345, то программа должна вывести число 
    543.

 */
using System;
class Task_4
{
    static void Main()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Дано целое число N большее 0. Это число программа должна получать у\nпользователя. Найти число, полученное при прочтении числа N справа налево.");
        Console.WriteLine("Введите N: ");
        uint a = Convert.ToUInt32(Console.ReadLine());
        uint b;
        while (a > 0)
        {
            b = a % 10;
            a /= 10;
            Console.Write(b);
        }
        Console.Write("\nДля продолжения - клавиша <Enter>");
        Console.ReadLine();
    }

}

