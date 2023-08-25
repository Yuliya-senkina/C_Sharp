/* Создайте пользовательский класс Date, который будет содержать информацию о 
    дате: день, месяц, год. С помощью механизма перегрузки операций определите 
    операцию разности двух дат, результатом которой будет количество дней между 
    датами, а также операцию увеличения даты на определённое количество дней. 
*/

using System;
public class Date
{
    public uint _d;
    public uint _m;
    public uint _y;

    public Date(uint d, uint m, uint y)
    {
        this._d = d;
        this._m = m;
        this._y = y;
    }

    public Date CopyFrom(Date d)
    {
        _d = d._d;
        _m = d._m;
        _y = d._y;
        return this;
    }

    public static Date operator +(Date result, uint days)
    {
        int _days = result.daysInDate();
        _days += (int)(days);
        result.daysToDate(_days);
        return result;
    }

    public static int operator -(Date result, Date r)
    {
        if (result.daysInDate() < r.daysInDate())
        {
            return r.daysInDate() - result.daysInDate();
        }
        else
        {
            return result.daysInDate() - r.daysInDate();
        }
    }

    public int yearDay()
    {
        int[] array = { 0, 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        int leap = (_y % 4 == 0 && _y % 100 != 0 || _y % 400 == 0) && (_m > 2) ? 1 : 0;
        return (int)(array[_m] + leap + _d);
    }

    public int daysInDate()
    {
        return (int)(_y * 365 + (_y - 1) / 4 - (_y - 1) / 100 + (_y - 1) / 400 + yearDay());
    }

    public void printDate()
    {
        Console.WriteLine("{0}.{1}.{2}", _d, _m, _y);
    }

    private void daysToDate(int days)
    {
        const double daysInYear = 365.2425;
        _y = (uint)(days / daysInYear);
        _m = _d = 1;
        int nDays_1_1_year = daysInDate();
        int d = (int)(days - nDays_1_1_year + 1);
        if (d <= 0)
        {
            setDate(this.daysInYear(_y - 1) - d, (uint)(_y - 1));
        }
        else
        {
            if (d > this.daysInYear(_y))
            {
                setDate(d - this.daysInYear(_y), (uint)(_y + 1));
            }
        }
        setDate(d, _y);
    }


    private int daysInYear(uint y)
    {
        if (y % 4 == 0 && y % 100 != 0 || y % 400 == 0)
        {
            return 366;
        }
        return 365;
    }

    private void setDate(int dayNum, uint year)
    {
        int[][] array =
        {
            new int[] {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365},
            new int[] {0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366}
        };
        int[] arrayPtr;
        if (daysInYear(year) == 365)
        {
            arrayPtr = array[0];
        }
        else
        {
            arrayPtr = array[1];
        }
        int i;
        for (i = 1; i <= 12; i++)
        {
            if (dayNum <= arrayPtr[i])
            {
                break;
            }
        }
        _d = (uint)(dayNum - arrayPtr[i - 1]);
        _m = (uint)i;
        _y = year;
    }
}

public static class Globals
{
    internal static void Main()
    {
        uint d1 = 0;
        uint d2 = 0;
        uint m1 = 0;
        uint m2 = 0;
        uint y1 = 0;
        uint y2 = 0;
        uint d3 = 0;
        uint d4 = 0;
        uint @var = 0;
        uint difference = 0;
        Date day1 = new Date(d1, m1, y1);
        Date day2 = new Date(d1, m1, y1);
        bool prodolgenie_int = true;
        int menu_item_int;
        do
        {
            Console.Clear();
            Console.WriteLine("1) Ввод дат.");
            Console.WriteLine("2) Посчитать разницу дат.");
            Console.WriteLine("3) Увеличить дату на количество дней.");
            Console.WriteLine("4) Выход.");
            menu_item_int = Convert.ToInt32(Console.ReadLine());
            if (menu_item_int < 1 || menu_item_int > 4)
            {
                Console.WriteLine("\nВыбран не верный путь меню, повторите ввод\n");

            }
            else
                switch (menu_item_int)
                {
                    case 1:
                        Console.WriteLine("1-ая дата - ");
                        Console.WriteLine("Введите число : ");
                        d1 = Convert.ToUInt32(Console.ReadLine());
                        Console.WriteLine("Введите месяц в формате mm : ");
                        m1 = Convert.ToUInt32(Console.ReadLine());
                        Console.WriteLine("Введите год в формате yyyy : ");
                        y1 = Convert.ToUInt32(Console.ReadLine());


                        Console.WriteLine("2-ая дата - ");
                        Console.WriteLine("Введите число : ");
                        d2 = Convert.ToUInt32(Console.ReadLine());
                        Console.WriteLine("Введите месяц в формате mm : ");
                        m2 = Convert.ToUInt32(Console.ReadLine());
                        Console.WriteLine("Введите год в формате yyyy : ");
                        y2 = Convert.ToUInt32(Console.ReadLine());
                        day1._d = d1;
                        day1._m = m1;
                        day1._y = y1;
                        day2._d = d2;
                        day2._m = m2;
                        day2._y = y2;
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("\n1-ая дата: ");
                        day1.printDate();
                        Console.WriteLine("\n2-ая дата: ");
                        day2.printDate();

                        difference = (uint)(day2 - day1);
                        Console.WriteLine("Разница  дат: {0}", difference - 1);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("\nКакую дату будем менять, 1-ую или 2-ую?\n");
                        var = Convert.ToUInt32(Console.ReadLine());
                        if (var == 1 || var == 2)
                        {
                            if (var == 1)
                            {
                                Console.WriteLine("\nКакое количество дней прибавляем?\n");
                                d3 = Convert.ToUInt32(Console.ReadLine());
                                day1 = day1 + d3;
                                Console.WriteLine("\nДень изменён на: \n");
                                day1.printDate();
                            }
                            else
                            {
                                Console.WriteLine("\nКакое количество дней прибавляем?\n");
                                d4 = Convert.ToUInt32(Console.ReadLine());
                                day2 = day2 + d4;
                                Console.WriteLine("\nДень изменён на: \n");
                                day2.printDate();
                            }
                        }
                        else Console.WriteLine("\nНужно ввести 1 или 2\n");
                        Console.ReadKey();
                        break;
                    case 4:
                        prodolgenie_int = false;
                        break;
                }
        } while (prodolgenie_int);

    }
}

