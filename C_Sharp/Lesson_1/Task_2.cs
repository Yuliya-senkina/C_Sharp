/*
    Начальный вклад в банке равен 10000 бел.руб. Через каждый месяц размер 
    вклада увеличивается на P процентов от имеющейся суммы. P есть вещественное  
    число, 0 < P < 25. Значение P программа должна получать у пользователя. По 
    данному P определить через сколько месяцев размер вклада превысит 11000 
    бел.руб., и вывести найденное количество месяцев K (целое число) и итоговый  
    размер вклада S (вещественное число).

 */
using System;
class Task_2
{
    static void Main()
    {
        float p = 0;
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("    Начальный  вклад  в  банке  равен  1000  руб.  Через  каждый  месяц  размер  вклада \n    увеличивается на P процентов от имеющейся суммы (P — вещественное число, 0 < P < \n    25).  Значение  Р  программа  должна  получать  у  пользователя.  По  данному  P \n    определить,  через  сколько  месяцев  размер  вклада  превысит  1100  руб.,  и  вывести \n    найденное  количество  месяцев  K  (целое  число)  и  итоговый  размер  вклада  S \n    (вещественное число).");
        do
        {
            Console.WriteLine("Введите P (вещественное число, 0 < P < 25): ");
            p = Convert.ToSingle(Console.ReadLine());
        }
        while (p <= 0 || p >= 25);
        decimal cap = 1000.0000m;
        decimal capLim = 1100.00m;
        int k = 0;
        Console.WriteLine("\n Процентная ставка " + p.ToString() + "%.\n");
        cap = decimal.Round(cap, 2);
        Console.WriteLine(string.Format(" Ваш капитал {0} руб сейчас.\n", cap.ToString()));
        do
        {
            cap += cap * (decimal)p / 100;
            cap = decimal.Round(cap, 2);
            k++;
            Console.WriteLine(string.Format("{0}\t{1}", k, cap));
        }
        while (cap < capLim);
        {
            if (k == 0 || k > 4)
                Console.WriteLine(string.Format("\n\n Ваш капитал достигнет {1} руб через {0} месяцев.", k, cap));
            else
            if (k > 1 && k < 5)
                Console.WriteLine(string.Format("\n\n Ваш капитал достигнет {1} руб через {0} месяца.", k, cap));
            else
            if (k == 1)
                Console.WriteLine(string.Format("\n\n Ваш капитал достигнет {1} руб через {0} месяц.", k, cap));
        }
        Console.Write("Для продолжения - клавиша <Enter>");
        Console.ReadLine();
    }
}
