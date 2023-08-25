/* 
 Написать класс Money, предназначенный для хранения денежной суммы (в рублях и копейках). Для класса реализовать перегрузку операторов:
+ (сложение денежных сумм);
– (вычитание сумм);
/ (деление суммы на целое число);
* (умножение суммы на целое число);
++ (сумма увеличивается на 1 копейку);
-- (сумма уменьшается на 1 копейку);
<;
>;
==;
!=.
Класс не может содержать отрицательную сумму. В случае если при исполнении какой-либо операции получается отрицательная сумма денег, то класс генерирует исключительную ситуацию «Банкрот».
Программа должна с помощью меню продемонстрировать все возможности класса Money. Обработка исключительных ситуаций производится в программе.
 */
using System;
using static System.Console;

namespace money1
{
    class Money
    {
        public long Rub { get; private set; }
        public byte Kop { get; private set; }
        static Money Account = new Money(0, 0);
        public Money()
        {
            WriteLine("Введите количество рублей!");
            Rub = long.Parse(ReadLine());
            if (Kop >= 100 || Kop < 0)
                throw new ArgumentException("Количество копеек должно быть от 0 до 99.");
            WriteLine("Введите количество копеек!");
            Kop = byte.Parse(ReadLine());
            if (Rub < 0)
                throw new ArgumentException("Количество рублей должно быть положительным.");
            this.Rub = Rub;
            this.Kop = Kop;

        }
        public Money(long rub, byte kop)
        {
            if (kop >= 100 || kop < 0)
                throw new ArgumentException("Количество копеек должно быть от 0 до 99.");
            if (rub < 0)
                throw new ArgumentException("Количество рублей должно быть положительным.");
            this.Rub = rub;
            this.Kop = kop;

        }

        public static void ShowAccount()
        {
            WriteLine($"Текущая сумма на счете равна {Account} рублей!");
            Console.ReadKey();
        }
        public override string ToString()
        {
            return string.Format("{0},{1:00}", Rub, Kop);
        }

        public static Money operator +(Money a, Money b)
        {
            int kopSum = a.Kop + b.Kop;
            long rub = a.Rub + b.Rub + kopSum / 100;
            byte kop = (byte)(kopSum % 100);
            return new Money(rub, kop);

        }
        public static Money operator -(Money a, Money b)
        {
            int kopDiff = a.Kop - b.Kop;
            long rub = a.Rub - b.Rub;
            if (kopDiff < 0)
            {
                rub--;
                kopDiff += 100;
            }
            byte kop = (byte)(kopDiff % 100);
            return new Money(rub, kop);
        }
        public static Money operator /(Money a, int b)
        {
            int kopDiv = a.Kop / b;
            long rub = a.Rub / b;
            byte kop = (byte)(kopDiv % 100);
            return new Money(rub, kop);
        }
        public static Money operator *(Money a, int b)
        {
            int kopMul = a.Kop * b;
            long rub = a.Rub * b + kopMul / 100;
            byte kop = (byte)(kopMul % 100);
            return new Money(rub, kop);
        }
        public static Money operator ++(Money a)
        {
            int kopMul = a.Kop + 1;
            long rub = a.Rub + kopMul / 100;
            byte kop = (byte)(kopMul % 100);
            return new Money(rub, kop);
        }
        public static Money operator --(Money a)
        {
            int kopMul = a.Kop - 1;
            long rub = a.Rub + kopMul / 100;
            byte kop = (byte)(kopMul % 100);
            return new Money(rub, kop);
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Money a, Money b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }
        public static bool operator >(Money a, Money b)
        {
            return ((a.Rub * 100 + a.Kop) > (b.Rub * 100 + b.Kop));
        }
        public static bool operator <(Money a, Money b)
        {
            return ((a.Rub * 100 + a.Kop) < (b.Rub * 100 + b.Kop));
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                bool prodolgenie_int = true;
                int menu_item_int;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1) Открытие счета.");
                    Console.WriteLine("2) Пополнение счета.");
                    Console.WriteLine("3) Снять сумму со счета.");
                    Console.WriteLine("4) Увеличить счет в определенное количество раз.");
                    Console.WriteLine("5) Уменьшить счет в определенное количество раз.");
                    Console.WriteLine("6) Увеличить счет на 1 копейку.");
                    Console.WriteLine("7) Уменьшить счет на 1 копейку.");
                    Console.WriteLine("8) Посмотреть остаток на счете.");
                    Console.WriteLine("9) Сравнить суммы.");
                    Console.WriteLine("10) Выход.");
                    menu_item_int = Convert.ToInt32(Console.ReadLine());
                    if (menu_item_int < 1 || menu_item_int > 10)
                    {
                        Console.WriteLine("\nВыбран не верный путь меню, повторите ввод\n");

                    }
                    else
                        switch (menu_item_int)
                        {
                            case 1:
                                WriteLine("Введите первоначальную сумму счета :\n ");
                                Account = new Money();
                                ShowAccount();
                                break;
                            case 2:
                                WriteLine("Введите сумму для пополнения счета :\n ");
                                var num1 = new Money();
                                Account += num1;
                                ShowAccount();
                                break;
                            case 3:
                                try
                                {
                                    WriteLine("Введите сумму для снятия co счета :\n ");
                                    var num2 = new Money();
                                    Account -= num2;
                                    ShowAccount();
                                }
                                catch
                                {
                                    WriteLine("Банкрот!");
                                }
                                break;
                            case 4:
                                WriteLine("Введите во сколько раз хотите увеличить сумму на счете:\n ");
                                int n = int.Parse(ReadLine());
                                Account = Account * n;
                                ShowAccount();
                                break;
                            case 5:
                                WriteLine("Введите во сколько раз хотите уменьшить сумму на счете:\n ");
                                int m = int.Parse(ReadLine());
                                Account = Account / m;
                                ShowAccount();
                                break;
                            case 6:
                                WriteLine("Увеличиваем счет на 1 копейку!");
                                ++Account;
                                ShowAccount();
                                break;
                            case 7:
                                try
                                {
                                    WriteLine("Уменьшаем счет на 1 копейку!");
                                    --Account;
                                    ShowAccount();
                                }
                                catch
                                {
                                    WriteLine("Банкрот!");
                                }
                                break;
                            case 8:
                                ShowAccount();
                                break;
                            case 9:
                                WriteLine("Введите первую сумму для сравнения:\n ");
                                var num3 = new Money();
                                WriteLine("Введите вторую сумму для сравнения:\n ");
                                var num4 = new Money();
                                WriteLine($"Первая сумма {num3:0.00} == вторая сумма {num4:0.00}: {num3 == num4}");
                                WriteLine($"Первая сумма {num3:0.00} != вторая сумма {num4:0.00}: {num3 != num4}\n");
                                WriteLine($"Первая сумма {num3:0.00} > вторая сумма {num4:0.00}: {num3 > num4}");
                                WriteLine($"Первая сумма {num3:0.00} < вторая сумма {num4:0.00}: {num3 < num4}");
                                Console.ReadKey();
                                break;
                            case 10:
                                prodolgenie_int = false;
                                break;
                        }
                } while (prodolgenie_int);
            }
        }
    }
}

