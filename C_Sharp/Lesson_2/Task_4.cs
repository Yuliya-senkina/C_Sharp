/*В двумерном массиве M-строк на N-столбцов поменяйте местами заданные 
  столбцы. Значения M и N, а также номера столбцов ввести с клавиатуры. Массив 
  целочисленный. Массив ввести с клавиатуры.
*/

using System;
class Task2_4
{
    static void Main()
    {
        Console.Write("Введите количество строк массива: \n");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Введите количество cтолбцов массива: \n");
        int y = int.Parse(Console.ReadLine());
        int[,] a = new int[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Console.WriteLine("Введите a[{0}][{1}]=", i + 1, j + 1);
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.Write("Введите 1-ый столбец для замены: \n");
        int x1 = int.Parse(Console.ReadLine());
        Console.Write("Введите 2-ой столбец для замены: \n");
        int y1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Исходный массив: \n");
        for (int i = 0; i < a.GetLength(0); ++i)
        {
            for (int j = 0; j < a.GetLength(1); ++j)
            {
                Console.Write(a[i, j] + "   ");
            }
            Console.WriteLine();
        }
        int limit = a.GetLength(1);
        if (x1 > limit || y1 > limit)
        {
            Console.WriteLine("Вне диапазона!\n");
            return;
        }
        else
        {
            int temp;
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                temp = a[i, x1 - 1];
                a[i, x1 - 1] = a[i, y1 - 1];
                a[i, y1 - 1] = temp;
            }
        }
        Console.WriteLine("Массив поле замены столбцов: \n");
        for (int i = 0; i < a.GetLength(0); ++i)
        {
            for (int j = 0; j < a.GetLength(1); ++j)
            {
                Console.Write(a[i, j] + "   ");
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}
