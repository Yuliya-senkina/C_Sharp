/*
 Преобразовать массив так, чтобы сначала шли все отрицательные элементы, а 
 потом положительные, 0 считать положительным. Массив одномерный 
 целочисленный. Массив ввести с клавиатуры.
*/

using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов массива: \n");
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите {0}-й элемент", i + 1);
            a[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Исходный массив: \n");
        foreach (int element in a)
            Console.Write(element + "\t");
        int tmp;
        bool flag = false;
        do
        {
            flag = false;
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] >= 0 && a[i + 1] < 0)
                {
                    tmp = a[i];
                    a[i] = a[i + 1];
                    a[i + 1] = tmp;
                    flag = true;
                }
            }
        } while (flag);
        Console.WriteLine("\n");
        Console.Write("Преобразованный массив: \n");
        foreach (int ielement in a)
            Console.Write(ielement + "\t");
        Console.ReadKey();
    }
}
