/*Написать программу, которая предлагает пользователю ввести массив и число. 
  Далее считает, сколько раз это число встречается в массиве. Массив одномерный 
  Целочисленный. Массив ввести с клавиатуры.
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
        Console.Write("Введите число для поиска в массиве: ");
        int value = int.Parse(Console.ReadLine());
        int counter = 0;
        Console.WriteLine();
        foreach (int elem in a)
        {
            if (elem == value)
                counter++;
            Console.Write(elem + " ");
        }
        Console.WriteLine(String.Format("\n\n Значение {0} встречается {1} раз(а) в массиве.", value, counter));
        Console.ReadKey();
    }
}
