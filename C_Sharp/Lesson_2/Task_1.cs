/*
 Сжать массив, удалив из него все 0 и, заполнить освободившиеся справа
 элементы значениями (–1). Массив одномерный целочисленный. Массив ввести с 
 клавиатуры.
*/

using System;
class Task_2_1
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
        for (int i = a.Length - 1; i >= 0; --i)
        {
            if (a[i] == 0)
            {
                for (int j = i; j < a.Length - 1; ++j)
                {
                    a[j] = a[j + 1];
                }
                a[a.Length - 1] = -1;
            }
        }
        Console.WriteLine("\n");
        Console.Write("Преобразованный массив: \n");
        foreach (int ielement in a)
            Console.Write(ielement + "\t");
        Console.ReadKey();
    }
}

