/*
Задание 1. 
Разработать абстрактный класс Геометрическая Фигура с полями 
 ПлощадьФигуры и ПериметрФигуры.
Разработать классы-наследники: Треугольник, Квадрат, Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг, Эллипс. Реализовать свойства, которые однозначно определяют объекты данных классов.
Реализовать интерфейс ПростойНУгольник, который имеет свойства: Высота, Основание, УголМеждуОснованиемИСмежнойСтороной, КоличествоСторон, ДлиныСторон, Площадь, Периметр.
Реализовать класс СоставнаяФигура который может состоять из любого количества ПростыхНУгольников. Для данного класса определить метод нахождения площади фигуры.
Предусмотреть варианты невозможности задания фигуры (введены отрицательные длины сторон или при создании объекта треугольника существует пара сторон, сумма длин которых меньше длины третьей стороны и т.п.)
Реализовать пример программы.

Задание 2.
Написать приложение, которое будет отображать в консоли простейшие геометрические фигуры, заданные пользователем. Пользователь выбирает фигуру и задаёт её расположение на экране, а также размер и цвет с помощью меню. Все заданные пользователем фигуры отображаются одновременно на экране. Фигуры (прямоугольник, ромб, треугольник, трапеция, многоугольник) рисуются
звёздочками или другими символами. Для реализации программы необходимо разработать иерархию классов (продумать возможность абстрагирования).
Для хранения всех заданных пользователем фигур создать класс Коллекция геометрических фигур с методом Отобразить все фигуры. Чтобы отобразить все фигуры указанным методом требуется использовать оператор foreach, для чего в классе Коллекция геометрических фигур необходимо реализовать соответствующие интерфейсы.

 */
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    interface InAngle
    {
        double Heigth { get; set; }
        double Base { get; set; }
        double Side { get; set; }
        double Alfa { get; set; }
        double Area();
        double Perimetr();
        int CountSide { get; set; }
        double[] SezeSide(int CountSide);
    }
    internal class Triangle_I : InAngle
    {
        public double C { get; set; }
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }
        public Triangle_I()
        {
            Console.WriteLine("Введите основание треугольника!\n");
            Base = double.Parse(Console.ReadLine());
            while (Base <= 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны основание > 0");
                Base = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите сторону треугольника сторона<=основания!\n");
            Side = double.Parse(Console.ReadLine());
            while (Base < Side)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны cторона<=база]!\n");
                Side = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите высоту треугольника Высота < Стороны!\n");
            Heigth = double.Parse(Console.ReadLine());
            while (Heigth >= Side)
            {
                Console.WriteLine("Неверный ввод данных, будьте внимательны  Высота < Стороны !\n");
                Heigth = double.Parse(Console.ReadLine());
            }
            double B1 = Math.Sqrt(Math.Pow(Side, 2) - Math.Pow(Heigth, 2));
            double B2 = Base - B1;
            C = Math.Round((Math.Sqrt(Math.Pow(Heigth, 2) + Math.Pow(B2, 2))), 2);
            Alfa = Math.Round(((Math.Acos(B1 / Side)) * (180 / Math.PI)), 0);
            CountSide = 3;
        }
        public Triangle_I(double B, double S, double H)
        {
            Base = B; Side = S;
            if (B > H) Heigth = H;
            else Console.WriteLine("Ошибка, сторона > высоты!");
            double B1 = Math.Sqrt(Math.Pow(S, 2) - Math.Pow(H, 2));
            double B2 = B - B1;
            C = Math.Round((Math.Sqrt(Math.Pow(Heigth, 2) + Math.Pow(B2, 2))), 2);
            Alfa = Math.Round(((Math.Acos(B1 / Side)) * (180 / Math.PI)), 0);
            CountSide = 3;
        }
        public double Area()
        {
            return Math.Round((0.5 * Base * Heigth), 2);
        }
        public double Perimetr()
        {
            return (Base + Side + C);
        }
        public double[] SezeSide(int CountSide)
        {
            double[] res = new double[CountSide];
            res[0] = Base;
            res[1] = Side;
            res[2] = C;
            return res;
        }
        public override string ToString()
        {
            return $"Фигура - Треугольник: количество сторон - {CountSide}: - {Base} см, {Side} см, {C} см;\n" +
                $"угол между основанием и стороной - {Alfa} градусов;\n" +
                $"Площадь - {Area()} см2, Периметр - {Perimetr()} см;";
        }
    }
    internal class Squere_I : InAngle
    {
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }
        public Squere_I()
        {
            Console.WriteLine("Введите сторону квадрата!\n");
            Side = double.Parse(Console.ReadLine());
            while (Side <= 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны сторона > 0");
                Side = double.Parse(Console.ReadLine());
            }
            CountSide = 4;
        }
        public Squere_I(double Side)
        {
            this.Side = Side;
            CountSide = 4;
        }
        public double Area()
        {
            return Math.Round((Side), 2);
        }
        public double Perimetr()
        {
            return Math.Round((4 * Side), 2);
        }
        public double[] SezeSide(int CountSide)
        {
            double[] res = new double[CountSide];
            for (int i = 0; i < res.Length; i++) res[i] = Side;
            return res;
        }
        public override string ToString()
        {
            return $"Фигура - Квадрат: Сторона - {Side} cм, Площадь - {Area()} cм2, Периметр - {Perimetr()} cм.";
        }
    }
    internal class Rectangle_I : InAngle
    {
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }
        public Rectangle_I()
        {
            Console.WriteLine("Введите первую сторону прямоугольника!\n");
            Base = double.Parse(Console.ReadLine());
            while (Base <= 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны сторона > 0\n");
                Base = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите вторую сторону прямоугольника!\n");
            Side = double.Parse(Console.ReadLine());
            while (Side <= 0 || Side == Base)
            {
                Console.WriteLine("Неверный ввод данных, будьте внимательны сторона 1 должна быть не равна стороне 2");
                Side = double.Parse(Console.ReadLine());
            }
            this.CountSide = 4;
            this.Alfa = 90;
        }
        public Rectangle_I(double Base, double Side)
        {
            this.Base = Base;
            if (Base != Side) this.Side = Side;
            this.CountSide = 4;
            this.Alfa = 90;
        }
        public double Area()
        {
            return Math.Round((Base * Side), 2);
        }
        public double Perimetr()
        {
            return Math.Round((2 * (Base + Side)), 2);
        }
        public double[] SezeSide(int CountSide)
        {
            double[] res = new double[CountSide];
            res[0] = res[2] = Base;
            res[1] = res[3] = Side;
            return res;
        }
        public override string ToString()
        {
            return $"Фигура - Прямоугольник: количество сторон - {CountSide}: - {Base} cм, {Side} cм;\n" +
                $"угол между основанием и стороной - {Alfa} градусов;\n" +
                $"Площадь - {Area()} cм2, Периметр - {Perimetr()} cм;";
        }
    }
    internal class Rhombus_I : InAngle
    {
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }
        public Rhombus_I()
        {
            Console.WriteLine("Введите сторону ромба!\n");
            Side = double.Parse(Console.ReadLine());
            while (Side <= 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны [сторона > 0]!");
                Side = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите угол между сторонами [0 < угол < 90]!\n");
            Alfa = double.Parse(Console.ReadLine());
            while (Alfa <= 0 || Alfa >= 90)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны [0 < угол < 90]!");
                Alfa = double.Parse(Console.ReadLine());
            }
            Heigth = Math.Round((Side * (Math.Sin(Alfa * Math.PI / 180))), 2);
            CountSide = 4;
        }
        public Rhombus_I(double Side, double Alfa)
        {
            this.Side = Side;
            if (Alfa > 0 && Alfa < 90) this.Alfa = Alfa;
            else Console.WriteLine("Ошибка, [0 < угол < 90 градусов]!");
            Heigth = Math.Round((Side * (Math.Sin(Alfa * Math.PI / 180))), 2);
            CountSide = 4;
        }
        public double Area()
        {
            return Math.Round((Side * Heigth), 2);
        }

        public double Perimetr()
        {
            return Math.Round((4 * Side), 2);
        }

        public double[] SezeSide(int CountSide)
        {
            double[] sides = new double[CountSide];
            for (int i = 0; i < sides.Length; i++) sides[i] = Side;
            return sides;
        }

        public override string ToString()
        {
            return $"Рисунок – Ромб: количество сторон - {CountSide}: сторона - {Side} cм; стороны равны;\n" +
               $"угол между основанием и стороной - {Alfa} градусов;\n" +
               $"Площадь - {Area()} cм2, Периметр - {Perimetr()} cм;";
        }
    }
    internal class Parallelogram_I : InAngle
    {
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }

        public Parallelogram_I()
        {
            Console.WriteLine("Введите основание параллелограмма [0 < основание]!\n");
            Base = double.Parse(Console.ReadLine());
            while (Base <= 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны [0 < основание]!");
                Base = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите сторону параллелограмма [ 0 < сторона и сторона < основание]!\n");
            Side = double.Parse(Console.ReadLine());
            while (Side <= 0 || Side > Base)
            {
                Console.WriteLine("Неправильный ввод данных, будьте осторожны [ 0 < сторона и сторона < основание]!");
                Side = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите высоту параллелограмма [высота > 0 и высота < сторона]!\n");
            Heigth = double.Parse(Console.ReadLine());
            while (Heigth <= 0 || Heigth >= Side)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны [Высота > 0 и Высота < Сторона]!");
                Heigth = double.Parse(Console.ReadLine());
            }
            CountSide = 4;
            Alfa = Math.Round(((Math.Sin(Heigth / Side)) * (180 / Math.PI)), 0);
        }

        public Parallelogram_I(double Base, double Side, double Heigth)
        {
            if (Base > 0) this.Base = Base;
            if (Side > 0 && Side < Base) this.Side = Side;
            if (Heigth > 0 && Heigth < Side) this.Heigth = Heigth;
            CountSide = 4;
            Alfa = Math.Round(((Math.Sin(Heigth / Side)) * (180 / Math.PI)), 0);
        }

        public double Area()
        {
            return Math.Round((Base * Heigth), 2);
        }

        public double Perimetr()
        {
            double rez = 0;
            foreach (var el in this.SezeSide(CountSide)) rez += el;
            return rez;
        }

        public double[] SezeSide(int CountSide)
        {
            double[] rez = new double[CountSide];
            rez[0] = rez[2] = Base;
            rez[1] = rez[3] = Side;
            return rez;
        }

        public override string ToString()
        {
            return $"Рисунок – Параллелограмм: количество сторон - {CountSide}: - {Base} cм, {Side} cм;\n" +
                $"угол между основанием и стороной - {Alfa} градусов;\n" +
                $"Площадь - {Area()} cм2, Периметр - {Perimetr()} cм;";
        }
    }
    internal class Trapezoid_I : InAngle
    {
        public double UpBase { get; set; }
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double SideSec { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }
        public Trapezoid_I()
        {
            Console.WriteLine("Введите верхнее основание трапеции!\n");
            UpBase = double.Parse(Console.ReadLine());
            while (UpBase <= 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны [0 < основание]!");
                UpBase = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите нижнее основание трапеции [ Нижнее основание > Верхнее основание]!\n");
            Base = double.Parse(Console.ReadLine());
            while (Base <= UpBase)
            {
                Console.WriteLine("Неправильный ввод данных, будьте осторожны [ Нижняя сторона > Верхней стороны]!");
                Base = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите сторону трапеции!\n");
            Side = double.Parse(Console.ReadLine());
            while (Side <= 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте осторожны [ Сторона > 0 ]!");
                Side = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите высоту трапеции!\n");
            Heigth = double.Parse(Console.ReadLine());
            while (Heigth >= Side)
            {
                Console.WriteLine("Неверный ввод данных, будьте внимательны [ Сторона > Высоты]!");
                Heigth = double.Parse(Console.ReadLine());
            }
            double B1 = Math.Round((Math.Sqrt((Math.Pow(Side, 2) - Math.Pow(Heigth, 2)))), 2);
            double B2 = Base - UpBase - B1;
            SideSec = Math.Round(Math.Sqrt(Math.Pow(Heigth, 2) + Math.Pow(B2, 2)), 2);
            CountSide = 4;
            Alfa = Math.Round(((Math.Sin(Heigth / Side)) * (180 / Math.PI)), 0);
        }
        public Trapezoid_I(double UpB, double B, double S, double H)
        {
            if (UpB > 0) UpBase = UpB;
            if (B > 0 && B > UpB) Base = B;
            if (S > 0) Side = S;
            if (H > 0 && H < S) Heigth = H;
            double B1 = Math.Round((Math.Sqrt((Math.Pow(Side, 2) - Math.Pow(Heigth, 2)))), 2);
            double B2 = Base - UpBase - B1;
            SideSec = Math.Round(Math.Sqrt(Math.Pow(Heigth, 2) + Math.Pow(B2, 2)), 2);
            CountSide = 4;
            Alfa = Math.Round(((Math.Sin(Heigth / Side)) * (180 / Math.PI)), 0);
        }

        public double Area()
        {
            return Math.Round((0.5 * Heigth * (UpBase + Base)), 2);
        }

        public double Perimetr()
        {
            double rez = 0;
            foreach (var el in SezeSide(CountSide)) rez += el;
            return rez;
        }

        public double[] SezeSide(int CountSide)
        {
            double[] rex = new double[CountSide];
            rex[0] = Base;
            rex[1] = Side;
            rex[2] = UpBase;
            rex[3] = SideSec;
            return rex;
        }

        public override string ToString()
        {
            return $"Рисунок - Трапеция: количество сторон - {CountSide}:\n" +
               $"Верхняя сторона - {UpBase} cм, нижняя сторона - {Base} cм, первая сторона - {Side} cм, вторая сторона {SideSec} cм" +
               $"угол между основанием и стороной - {Alfa} градуов;\n" +
               $"Площадь - {Area()} cм2, Периметр - {Perimetr()} cм;";
        }

    }
    internal class RegularHexagon : InAngle
    {
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }

        public RegularHexagon()
        {
            Console.WriteLine("Введите сторону правильного шестиугольника [сторона > 0]!");
            Side = double.Parse(Console.ReadLine());
            while (Side <= 0)
            {
                Console.WriteLine("Неправильный ввод данных, будьте осторожны [сторона > 0]!");
                Side = double.Parse(Console.ReadLine());
            }
            Alfa = 120;
            CountSide = 6;
        }
        public RegularHexagon(double Side)
        {
            if (Side > 0) this.Side = Side;
            Alfa = 120;
            CountSide = 6;
        }

        public double Area()
        {
            return Math.Round(((3 * Math.Sqrt(3) * Math.Pow(Side, 2)) * 0.5), 2);
        }

        public double Perimetr()
        {
            return Math.Round(6 * Side);
        }

        public double[] SezeSide(int CountSide)
        {
            double[] rex = new double[CountSide];
            for (int i = 0; i < rex.Length; i++) rex[i] = Side;
            return rex;
        }

        public override string ToString()
        {
            return $"Фигура – правильный шестиугольник: количество сторон - {CountSide}, сторона - {Side} cм:\n" +
              $"угол между основанием и стороной - {Alfa} градусов;\n" +
              $"Площадь - {Area()} cм2, Периметр - {Perimetr()} cм;";
        }

    }
    internal class RegularPentagon : InAngle
    {
        public double Heigth { get; set; }
        public double Base { get; set; }
        public double Side { get; set; }
        public double Alfa { get; set; }
        public int CountSide { get; set; }

        public RegularPentagon()
        {
            Console.WriteLine("Введите сторону правильного пятиугольника [сторона > 0]!");
            Side = double.Parse(Console.ReadLine());
            while (Side <= 0)
            {
                Console.WriteLine("Неправильный ввод данных, будьте осторожны [сторона > 0]!");
                Side = double.Parse(Console.ReadLine());
            }
            Alfa = 108;
            CountSide = 5;
        }

        public RegularPentagon(double Side)
        {
            if (Side > 0) this.Side = Side;
            Alfa = 108;
            CountSide = 5;
        }

        public double Area()
        {
            return Math.Round(((Math.Pow(Side, 2)) * Math.Sqrt(25 + 10 * Math.Sqrt(5)) / 4), 2);
        }

        public double Perimetr()
        {
            return Math.Round((5 * Side), 2);
        }

        public double[] SezeSide(int CountSide)
        {
            double[] rex = new double[CountSide];
            for (int i = 0; i < rex.Length; i++) rex[i] = Side;
            return rex;
        }

        public override string ToString()
        {
            return $"Рисунок - правильный пятиугольник: количество сторон - {CountSide}, сторона - {Side} cм:\n" +
               $"угол между основанием и стороной - {Alfa} градусов;\n" +
               $"Площадь - {Area()} cм2, Периметр - {Perimetr()} cм;";
        }
    }
    internal class AssembledFigure_I
    {
        InAngle[] arr;
        public AssembledFigure_I(InAngle[] obj)
        {
            arr = new InAngle[obj.Length];
            for (int i = 0; i < obj.Length; i++) arr[i] = obj[i];
        }

        public AssembledFigure_I()
        {
            Console.WriteLine("Ввдите размер массива!\n");
            int s = int.Parse(Console.ReadLine());
            arr = new InAngle[s];
            int i = 0;
            String f;
            do
            {
                Console.WriteLine("Выберите геометрическую фигуру для создания:\n" +
                    "1. Треугольник\n" +
                    "2. Квадрат\n" +
                    "3. Прямоугольник\n" +
                    "4. Ромб\n" +
                    "5. Параллелограмм\n" +
                    "6. Трапеция\n" +
                    "7. Правильный шестиугольник\n" +
                    "8. Правильный пятиугольник\n"
                    );
                f = Console.ReadLine();
                if (f == "1") arr[i] = new Triangle_I();
                else if (f == "2") arr[i] = new Squere_I();
                else if (f == "3") arr[i] = new Rectangle_I();
                else if (f == "4") arr[i] = new Rhombus_I();
                else if (f == "5") arr[i] = new Parallelogram_I();
                else if (f == "6") arr[i] = new Trapezoid_I();
                else if (f == "7") arr[i] = new RegularPentagon();
                else if (f == "8") { arr[i] = new RegularHexagon(); }
                if (f == "1" || f == "2" || f == "3" || f == "4" || f == "5" || f == "6" || f == "7" || f == "8") i++;
            } while (i < s);
        }

        public void Show_I()
        {
            int i = 1;
            Console.WriteLine("Собранная фигура состоит из:\n");
            foreach (var el in arr)
            {
                Console.WriteLine($"{i++}." + el);
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            Console.WriteLine($"Общая площадь собранной фигуры = {this.SummAreaFigure_I()} cм2.");
            Console.WriteLine($"Общий периметр собранной фигуры = {this.SummPerimetrFifure_I()} cм.");
        }

        public double SummAreaFigure_I()
        {
            double rezult = 0;
            foreach (var el in arr) rezult += el.Area();
            return rezult;
        }

        public double SummPerimetrFifure_I()
        {
            double rezult = 0;
            foreach (var el in arr) rezult += el.Perimetr();
            return rezult;
        }
    }


    interface IShowFigure
    {
        int Side { get; set; }
        int PosY { get; set; }
        int PosX { get; set; }
        string Color { get; set; }
        void print();
    }
    internal class ShowSquere : IShowFigure
    {
        public int Side { get; set; }
        public int PosY { get; set; }
        public int PosX { get; set; }
        public string Color { get; set; }
        public ShowSquere()
        {
            Console.WriteLine("Введите размер фигуры [размер > 5]!\n");
            Side = int.Parse(Console.ReadLine());
            while (Side <= 5)
            {
                Console.WriteLine("Неправильный ввод данных, будьте осторожны [сторона > 5]!");
                Side = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Укажите расположение фигуры на экране [X, Y]!");
            Console.Write("X = "); PosX = int.Parse(Console.ReadLine());
            Console.Write("Y = "); PosY = int.Parse(Console.ReadLine());
            Console.WriteLine("Укажите цвет фигуры [red, green, blue, yellow, gray]!");
            Color = Console.ReadLine();
            while (Color != "red" && Color != "green" && Color != "blue" && Color != "yellow" && Color != "gray")
            {
                Console.WriteLine("Неверный ввод данных, будьте внимательны, указанного цвета нет в списке!");
                Color = Console.ReadLine();
            }
        }
        public ShowSquere(int S, int X, int Y, string C)
        {
            if (S > 0) Side = S;
            PosX = X;
            PosY = Y;
            if (C == "red" || C == "green" || C == "blue" || C == "yellow" || C == "gray") Color = C;
        }

        public virtual void print()
        {
            if (Color == "red") Console.ForegroundColor = ConsoleColor.Red;
            else if (Color == "green") Console.ForegroundColor = ConsoleColor.Green;
            else if (Color == "blue") Console.ForegroundColor = ConsoleColor.Blue;
            else if (Color == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (Color == "gray") Console.ForegroundColor = ConsoleColor.Gray;
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Указанного цвета нет в списке!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            for (int i = 0; i < (Side * 2); i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    Console.SetCursorPosition(PosX + i, PosY + j);
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    internal class ShowTriangle : ShowSquere
    {
        public ShowTriangle() : base() { }
        public ShowTriangle(int S, int X, int Y, string C) : base(S, X, Y, C) { }
        public override void print()
        {
            if (Color == "red") Console.ForegroundColor = ConsoleColor.Red;
            else if (Color == "green") Console.ForegroundColor = ConsoleColor.Green;
            else if (Color == "blue") Console.ForegroundColor = ConsoleColor.Blue;
            else if (Color == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (Color == "gray") Console.ForegroundColor = ConsoleColor.Gray;
            else
            {
                Console.SetCursorPosition(0, 0); Console.WriteLine("Указанного цвета нет в списке!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            for (int i = 0; i < Side; i++)
            {
                Console.SetCursorPosition(PosX + (Side - i), PosY + (i + 1));
                for (int j = 0; j <= i * 2; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    internal class ShowRectangle : IShowFigure
    {
        public int Base { get; set; }
        public int Side { get; set; }
        public int PosY { get; set; }
        public int PosX { get; set; }
        public string Color { get; set; }
        public ShowRectangle()
        {
            Console.WriteLine("Введите первую сторону треугольника!\n");
            Base = int.Parse(Console.ReadLine());
            while (Base < 0)
            {
                Console.WriteLine("Неверный ввод данных, будьте внимательны [ Первая сторона > 0]!");
                Base = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите вторую сторону треугольника!\n");
            Side = int.Parse(Console.ReadLine());
            while (Side < 0)
            {
                Console.WriteLine("Неправильный ввод данных, будьте осторожны [ Вторая сторона > 0 ]!");
                Side = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Укажите расположение фигуры на экране [X, Y]!");
            Console.Write("X = "); PosX = int.Parse(Console.ReadLine());
            Console.Write("Y = "); PosY = int.Parse(Console.ReadLine());
            Console.WriteLine("Укажите цвет фигуры [red, green, blue, yellow, gray]!");
            Color = Console.ReadLine();
            while (Color != "red" && Color != "green" && Color != "blue" && Color != "yellow" && Color != "gray")
            {
                Console.WriteLine("Неверный ввод данных, будьте внимательны, указанного цвета нет в списке!");
                Color = Console.ReadLine();
            }
        }
        public ShowRectangle(int B, int S, int X, int Y, string C)
        {
            if (B > 0) Base = B;
            if (S > 0) Side = S;
            PosX = X;
            PosY = Y;
            if (C == "red" || C == "green" || C == "blue" || C == "yellow" || C == "gray") Color = C;
        }

        public void print()
        {
            if (Color == "red") Console.ForegroundColor = ConsoleColor.Red;
            else if (Color == "green") Console.ForegroundColor = ConsoleColor.Green;
            else if (Color == "blue") Console.ForegroundColor = ConsoleColor.Blue;
            else if (Color == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (Color == "gray") Console.ForegroundColor = ConsoleColor.Gray;
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Указанного цвета нет в списке!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            for (int i = 0; i < (Base * 2); i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    Console.SetCursorPosition(PosX + i, PosY + j);
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    internal class ShowRhombus : ShowSquere
    {
        public ShowRhombus() : base() { }
        public ShowRhombus(int B, int X, int Y, string C) : base(B, X, Y, C) { }
        public override void print()
        {
            if (Color == "red") Console.ForegroundColor = ConsoleColor.Red;
            else if (Color == "green") Console.ForegroundColor = ConsoleColor.Green;
            else if (Color == "blue") Console.ForegroundColor = ConsoleColor.Blue;
            else if (Color == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (Color == "gray") Console.ForegroundColor = ConsoleColor.Gray;
            else
            {
                Console.SetCursorPosition(0, 0); Console.WriteLine("Указанного цвета нет в списке!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Side = Side % 2 == 0 ? Side + 1 : Side;
            for (var i = 0; i < Side; i++)
            {
                Console.SetCursorPosition(PosX, PosY + i);
                var spacesBefore = Math.Abs(Side / 2 - i);
                var starsCount = (Side - 2 * spacesBefore);
                Console.WriteLine("{0}{1}", new string(' ', spacesBefore), new string('*', starsCount));
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    internal class ShowTrapezoid : ShowSquere
    {
        public int Base { get; set; }
        public ShowTrapezoid() : base()
        {
            Console.WriteLine("Введите верхнюю базовую фигуру [Верхнее основание <Размер]!\n");
            Base = int.Parse(Console.ReadLine());
            while (Base >= Side)
            {
                Console.WriteLine("Неправильный ввод данных, будьте осторожны [верхнее основание < Размер]!\n");
                Base = int.Parse(Console.ReadLine());
            }
        }
        public ShowTrapezoid(int S, int X, int Y, string C, int B) : base(S, X, Y, C)
        {
            if (B < S) Base = B;
        }
        public override void print()
        {
            if (Color == "red") Console.ForegroundColor = ConsoleColor.Red;
            else if (Color == "green") Console.ForegroundColor = ConsoleColor.Green;
            else if (Color == "blue") Console.ForegroundColor = ConsoleColor.Blue;
            else if (Color == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (Color == "gray") Console.ForegroundColor = ConsoleColor.Gray;
            else
            {
                Console.SetCursorPosition(0, 0); Console.WriteLine("Указанного цвета нет в списке!\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            for (int i = Base; i < Side; i++)
            {
                Console.SetCursorPosition(PosX + (Side - i), PosY + (i + 1));
                for (int j = 0; j <= i * 2; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    internal class ShowRegularHexagon : ShowSquere
    {
        public ShowRegularHexagon()
        {
            while (Side < 18)
            {
                Console.WriteLine("Извиняюсь! [сторона >= 18] Введите новый размер фигуры!");
                Side = int.Parse(Console.ReadLine());
            }
        }
        public ShowRegularHexagon(int B, int X, int Y, string C) : base(B, X, Y, C) { }
        public override void print()
        {
            if (Color == "red") Console.ForegroundColor = ConsoleColor.Red;
            else if (Color == "green") Console.ForegroundColor = ConsoleColor.Green;
            else if (Color == "blue") Console.ForegroundColor = ConsoleColor.Blue;
            else if (Color == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (Color == "gray") Console.ForegroundColor = ConsoleColor.Gray;
            else
            {
                Console.SetCursorPosition(0, 0); Console.WriteLine("Указанного цвета нет в списке!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            int S = Side / 3;
            for (int i = (S / 2); i < S; i++)
            {
                Console.SetCursorPosition(PosX + (S - i), PosY + (i + 1));
                for (int j = 0; j < i * 2; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < S * 2; i++)
            {
                for (int j = 0; j < S / 2; j++)
                {
                    Console.SetCursorPosition((PosX) + i, (PosY + S + 1) + j);
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = S; i > (S / 2); i--)
            {
                Console.SetCursorPosition(PosX + (S - i), (PosY + S + S + (S / 2) + 1) - (i + 1));
                for (int j = 0; j < i * 2; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    internal class ShowAssembledFigure
    {
        IShowFigure[] arr;
        public ShowAssembledFigure()
        {
            Console.WriteLine("Введите количество фигур!\n");
            int num = int.Parse(Console.ReadLine());
            arr = new IShowFigure[num];
            int i = 0;
            string M;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Выберите геометрическую фигуру для вывода:\n" +
                    "1. Квадрат\n" +
                    "2. Треугльник\n" +
                    "3. Прямоугольник\n" +
                    "4. Ромб\n" +
                    "5. Трапеция\n" +
                    "6. Правильный шестиугольник\n");
                M = Console.ReadLine();
                if (M == "1") arr[i] = new ShowSquere();
                else if (M == "2") arr[i] = new ShowTriangle();
                else if (M == "3") arr[i] = new ShowRectangle();
                else if (M == "4") arr[i] = new ShowRhombus();
                else if (M == "5") arr[i] = new ShowTrapezoid();
                else if (M == "6") arr[i] = new ShowRegularHexagon();
                if (M == "1" || M == "2" || M == "3" || M == "4" || M == "5" || M == "6" || M == "7" || M == "8") i++;
            } while (i < num);
        }

        public ShowAssembledFigure(IShowFigure[] obj)
        {
            arr = new IShowFigure[obj.Length];
            for (int i = 0; i < obj.Length; i++) arr[i] = obj[i];
        }

        public void ShowPrint()
        {
            Console.Clear();
            foreach (var el in arr)
                el.print();
        }
    }

    internal class ClassMenu
    {
        public InAngle[] listIntf = {
             new Triangle_I(15.56, 8.79, 5.17),
                     new Rectangle_I(15.71, 10.64),
                     new Squere_I(12.01),
                    new Rhombus_I(12.45, 45),
                    new Parallelogram_I(18.15, 10.15, 7.8 ),
                    new Trapezoid_I(7, 21, 15, 12),
                    new RegularPentagon(8.79),
                    new RegularHexagon(5.12)
        };

        public Figure[] listabst = {
                     new Triangle(5.56, 3.89, 2.51),
                     new Rectangle(5.61, 4.56),
                     new Squere(4.23),
                    new Rhombus(2.45, 3.12),
                    new Parallelogram(28.15, 12.5, 7.45),
                    new Circle(5.89),
                   new Ellipse(4.32, 8.98),
                   new Trapezoid(7, 21, 15, 12)
                };

        public IShowFigure[] listShow =
            {
                new ShowSquere(15, 5, 5, "yellow"),
                new ShowTriangle(15, 40, 5, "red"),
                new ShowRectangle(20, 10, 70, 5, "blue"),
                new ShowRhombus(20, 110, 5, "green"),
                new ShowTrapezoid(15, 5, 20, "green", 5),
                new ShowRegularHexagon(30, 40, 20, "blue")
            };

        public void Menu()
        {
            string mn;
            do
            {
                Clear();
                WriteLine(
                    "1. Первое задание\n" +
                    "2. Второе задание\n" +
                    "0. Выход\n");
                mn = Console.ReadLine();
                if (mn == "1")
                {
                    string mnu;
                    do
                    {
                        Clear();
                        WriteLine("1. Абстрактный класс Геометрическая фигура\n" +
                            "2. Реализация интерфейса Геометрическая фигура\n" +
                            "0. Выход в главное меню\n");
                        mnu = ReadLine();
                        if (mnu == "1")
                        {
                            Clear();
                            string m;
                            do
                            {
                                Clear();
                                WriteLine(
                                    "1. Треугольник\n" +
                                    "2. Прямоугольник\n" +
                                    "3. Квадрат\n" +
                                    "4. Ромб\n" +
                                    "5. Параллелограмм\n" +
                                    "6. Круг\n" +
                                    "7. Эллипс\n" +
                                    "8. Трапеция\n" +
                                    "9. Составная фигура\n" +
                                    "0. Выход\n");
                                m = Console.ReadLine();
                                switch (m)
                                {
                                    case "1": Clear(); Figure a = new Triangle(); WriteLine(a); ReadKey(); break;
                                    case "2": Clear(); Figure b = new Rectangle(); WriteLine(b); ReadKey(); break;
                                    case "3": Clear(); Figure c = new Squere(); WriteLine(c); ReadKey(); break;
                                    case "4": Clear(); Figure d = new Rhombus(); WriteLine(d); ReadKey(); break;
                                    case "5": Clear(); Figure e = new Parallelogram(); WriteLine(e); ReadKey(); break;
                                    case "6": Clear(); Figure g = new Circle(); WriteLine(g); ReadKey(); break;
                                    case "7": Clear(); Figure f = new Ellipse(); WriteLine(f); ReadKey(); break;
                                    case "8": Clear(); Figure t = new Trapezoid(); WriteLine(t); ReadKey(); break;
                                    case "9":
                                        Clear();
                                        string men;
                                        do
                                        {
                                            WriteLine(
                                                "1. Создать собственную составную фигуру\n" +
                                                "2. Отображение существующей составной фигуры\n" +
                                                "0. Выход в главное меню\n");
                                            men = ReadLine();
                                            if (men == "1")
                                            {
                                                Clear();
                                                AssembledFigure q = new AssembledFigure();
                                                q.Show();
                                                ReadKey();
                                            }
                                            else if (men == "2")
                                            {
                                                Clear();
                                                AssembledFigure q1 = new AssembledFigure(listabst);
                                                q1.Show();
                                                ReadKey();
                                            }
                                            Clear();
                                        } while (men != "0");
                                        ReadKey(); break;
                                    case "0": break;
                                }
                                Clear();
                            } while (m != "0");
                        }
                        else if (mnu == "2")
                        {
                            Clear();
                            string m;
                            do
                            {
                                Clear();
                                WriteLine(
                                    "1. Треугольник\n" +
                                    "2. Прямоугольник\n" +
                                    "3. Квадрат\n" +
                                    "4. Ромб\n" +
                                    "5. Параллелограмм\n" +
                                    "6. Трапеция\n" +
                                    "7. Правильный пятиугольнк\n" +
                                    "8. Правильный шестиугольник;\n" +
                                    "9. Составная фигура;\n" +
                                    "0. Выход\n");
                                m = Console.ReadLine();
                                switch (m)
                                {
                                    case "1": Clear(); InAngle a = new Triangle_I(); WriteLine(a); ReadKey(); break;
                                    case "2": Clear(); InAngle b = new Rectangle_I(); WriteLine(b); ReadKey(); break;
                                    case "3": Clear(); InAngle c = new Squere_I(); WriteLine(c); ReadKey(); break;
                                    case "4": Clear(); InAngle d = new Rhombus_I(); WriteLine(d); ReadKey(); break;
                                    case "5": Clear(); InAngle e = new Parallelogram_I(); WriteLine(e); ReadKey(); break;
                                    case "6": Clear(); InAngle g = new Trapezoid_I(); WriteLine(g); ReadKey(); break;
                                    case "7": Clear(); InAngle f = new RegularPentagon(); WriteLine(f); ReadKey(); break;
                                    case "8": Clear(); InAngle t = new RegularHexagon(); WriteLine(t); ReadKey(); break;
                                    case "9":
                                        Clear();
                                        string men;
                                        do
                                        {
                                            WriteLine("1. Создать собственную составную фигуру\n" +
                                                "2. Отображение существующей составной фигуры\n" +
                                                "0. Выход в главное меню\n");
                                            men = ReadLine();
                                            if (men == "1")
                                            {
                                                Clear();
                                                AssembledFigure_I q = new AssembledFigure_I();
                                                q.Show_I();
                                                ReadKey();
                                            }
                                            else if (men == "2")
                                            {
                                                Clear();
                                                AssembledFigure_I q1 = new AssembledFigure_I(listIntf);
                                                q1.Show_I();
                                                ReadKey();
                                            }
                                            Clear();
                                        } while (men != "0");
                                        break;
                                    case "0": break;
                                }
                                Clear();
                            } while (m != "0");


                        }
                        Clear();
                    } while (mnu != "0");
                }
                else if (mn == "2")
                {
                    string mnw;
                    do
                    {
                        Clear();
                        WriteLine(
                            "1. Отобразить набор геометрических фигур\n" +
                            "2. Создать коллекцию геометрических фигур\n" +
                            "0. Выйти в главное меню!"
                            );
                        mnw = ReadLine();
                        if (mnw == "1")
                        {
                            ShowAssembledFigure showAssembledFigure = new ShowAssembledFigure(listShow);
                            showAssembledFigure.ShowPrint();
                            ReadKey();
                        }
                        else if (mnw == "2")
                        {
                            Clear();
                            ShowAssembledFigure showAssembledFigure = new ShowAssembledFigure();
                            showAssembledFigure.ShowPrint();
                            ReadKey();
                        }
                    } while (mnw != "0");
                }
                Clear();
            } while (mn != "0");
        }
    }
    internal abstract class Figure
    {
        public abstract double Area();
        public abstract double Perimeter();
    }
    internal class Triangle : Figure
    {
        public double A { get; set; }
        public double H { get; set; }
        public double B { get; set; }
        public double C;
        public Triangle()
        {
            WriteLine("Введите основание треугольника!\n");
            A = double.Parse(ReadLine());
            WriteLine("Введите первую сторону треугольника!\n");
            B = double.Parse(ReadLine());
            WriteLine("Введите высоту треугольника [ высота < стороны ]!\n");
            H = double.Parse(ReadLine());
            while (B <= H)
            {
                WriteLine("Неверный ввод даты, будьте осторожны [ высота < стороны ]!\n");
                H = double.Parse(ReadLine());
            }
            double A1 = Math.Sqrt(Math.Pow(B, 2) - Math.Pow(H, 2));
            double A2 = A - A1;
            C = Math.Round((Math.Sqrt(Math.Pow(H, 2) + Math.Pow(A2, 2))), 2);
        }
        public Triangle(double A, double B, double H)
        {
            this.A = A;
            this.B = B;
            if (B > H) this.H = H;
            double A1 = Math.Sqrt(Math.Pow(B, 2) - Math.Pow(H, 2));
            double A2 = A - A1;
            C = Math.Round((Math.Sqrt(Math.Pow(H, 2) + Math.Pow(A2, 2))), 2);
        }
        public override double Area()
        {
            return Math.Round((0.5 * A * H), 2);
        }
        public override double Perimeter()
        {
            return A + B + C;
        }
        public override string ToString()
        {
            return $"Треугольник: основание - {A} cм, первая сторона - {B} cм, вторая сторона - {C} cм, высота - {H} cм;  Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм.";
        }
    }
    internal class Squere : Figure
    {
        public double A { get; set; }
        public Squere()
        {
            WriteLine("Войдите в сторону квадрата!\n");
            A = double.Parse(ReadLine());
        }
        public Squere(double A)
        {
            this.A = A;
        }
        public override double Area()
        {
            return Math.Round((Math.Pow(A, 2)), 2);
        }
        public override double Perimeter()
        {
            return Math.Round((4 * A), 2);
        }
        public override string ToString()
        {
            return $"Квадрат: сторона - {A} cм; Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм.";
        }
    }
    internal class Rectangle : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public Rectangle()
        {
            WriteLine("Введите первую сторону прямоугольника!\n");
            A = double.Parse(ReadLine());
            WriteLine("Введите вторую сторону прямоугольника!\n");
            B = double.Parse(ReadLine());
        }
        public Rectangle(double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public override double Area()
        {
            return Math.Round((A * B), 2);
        }
        public override double Perimeter()
        {
            return Math.Round((2 * (A + B)), 2);
        }
        public override string ToString()
        {
            return $"Прямоугольник: сторона - {A} cм, {B} cm; Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм.";
        }

    }
    internal class Rhombus : Figure
    {

        public double A { get; set; }
        public double B { get; set; }
        public Rhombus()
        {
            WriteLine("Введите первую диагональ ромба!\n");
            A = double.Parse(ReadLine());
            WriteLine("Введите вторую диагональ ромба!\n");
            B = double.Parse(ReadLine());
        }
        public Rhombus(double A, double B)
        {
            this.A = A;
            this.B = B;
        }
        public override double Area()
        {
            return Math.Round((0.5 * A * B), 2);
        }
        public override double Perimeter()
        {
            return Math.Round((2 * Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2))), 2);
        }
        public override string ToString()
        {
            return $"Ромб: диагонали - {A} cс, {B} cm; Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм.";
        }
    }
    internal class Parallelogram : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }
        public Parallelogram()
        {
            WriteLine("Введите основание параллелограмма!\n");
            A = double.Parse(ReadLine());
            WriteLine("Введите сторону параллелограмма!\n");
            B = double.Parse(ReadLine());
            WriteLine("Введите высоту параллелограмма [высота < стороны]!\n");
            H = double.Parse(ReadLine());
            while (H >= B)
            {
                WriteLine("Неверный ввод данных, будьте внимательны [высота < стороны]!");
                H = double.Parse(ReadLine());
            }
        }
        public Parallelogram(double A, double B, double H)
        {
            this.A = A;
            this.B = B;
            this.H = H;
        }
        public override double Area()
        {
            return Math.Round((A * H), 2);
        }
        public override double Perimeter()
        {
            return Math.Round((2 * (A + B)), 2);
        }
        public override string ToString()
        {
            return $"Параллелограмм: основание - {A} cс, сторона {B} cм, высота - {H}; Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм.";
        }
    }
    internal class Circle : Figure
    {
        public double R { get; set; }
        public Circle()
        {
            WriteLine("Введите радиус окружности!\n");
            R = double.Parse(ReadLine());
        }
        public Circle(double R)
        {
            this.R = R;
        }
        public override double Area()
        {
            return Math.Round(Math.PI * (Math.Pow(R, 2)), 2);
        }

        public override double Perimeter()
        {
            return Math.Round((2 * Math.PI * R), 2);
        }

        public override string ToString()
        {
            return $"Круг: Радиус - {R} cм; Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм.";
        }
    }
    internal class Ellipse : Figure
    {
        public double R { get; set; }
        public double r { get; set; }
        public Ellipse()
        {
            WriteLine("Введите большой радиус эллипса!\n");
            R = double.Parse(ReadLine());
            WriteLine("Введите малый радиус эллипса [большой радиус > малого радиуса]!\n");
            r = double.Parse(ReadLine());
            while (r >= R)
            {
                WriteLine("Неверный ввод даты, будьте осторожны [большой радиус > малого радиуса]!");
                r = double.Parse(ReadLine());
            }
        }
        public Ellipse(double r, double R)
        {
            if (R > r) { this.R = R; this.r = r; }
        }
        public override double Area()
        {
            return Math.Round((Math.PI * R * r), 2);
        }
        public override double Perimeter()
        {
            return Math.Round((2 * Math.PI * Math.Sqrt((Math.Pow(R, 2) + Math.Pow(r, 2)) / 2)), 2);
        }
        public override string ToString()
        {
            return $"Эллипс: малый радиус- {r} cм, большой радиус - {R} cм; Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм."; ;
        }
    }
    internal class Trapezoid : Figure
    {
        public double C2;
        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }
        public double C { get; set; }
        public Trapezoid()
        {
            WriteLine("Введите верхнее основание трапеции!\n");
            A = double.Parse(ReadLine());
            WriteLine("Введите нижнее основание трапеции!\n");
            B = double.Parse(ReadLine());
            while (B <= A)
            {
                WriteLine("Неправильный ввод данных, будьте осторожны [нижнее основание > верхнего основания]!");
                B = double.Parse(ReadLine());
            }
            WriteLine("Введите сторону трапеции!\n");
            C = double.Parse(ReadLine());
            WriteLine("Введите высоту трапеции!\n");
            H = double.Parse(ReadLine());
            while (C <= H)
            {
                WriteLine("Неверный ввод данных, будьте внимательны [сторона трапеции > высота трапеции]!");
                H = double.Parse(ReadLine());
            }
            double B1 = Math.Round((Math.Sqrt((Math.Pow(C, 2) - Math.Pow(H, 2)))), 2);
            double B2 = B - A - B1;
            while (B2 <= 0)
            {
                WriteLine("Введите верхнее основание трапеции!\n");
                A = double.Parse(ReadLine());
                WriteLine("Введите нижнее основание трапеции!\n");
                B = double.Parse(ReadLine());
                while (B <= A)
                {
                    WriteLine("Неправильный ввод данных, будьте осторожны [нижнее основание > верхнего основания]!");
                    B = double.Parse(ReadLine());
                }
                WriteLine("Введите сторону трапеции!\n");
                C = double.Parse(ReadLine());
                WriteLine("Введите высоту трапеции\n");
                H = double.Parse(ReadLine());
                while (C <= H)
                {
                    WriteLine("Неверный ввод данных, будьте внимательны [сторона > высоты]!");
                    H = double.Parse(ReadLine());
                }
                B1 = Math.Round((Math.Sqrt((Math.Pow(C, 2) - Math.Pow(H, 2)))), 2);
                B2 = B - A - B1;
            }
            this.C2 = Math.Round(Math.Sqrt(Math.Pow(H, 2) + Math.Pow(B2, 2)), 2);
            WriteLine(C2);
        }
        public Trapezoid(double A, double B, double C, double H)
        {
            this.A = A;
            if (A < B) this.B = B;
            this.C = C;
            if (H < C) this.H = H;
            double B1 = Math.Round((Math.Sqrt((Math.Pow(C, 2) - Math.Pow(H, 2)))), 2);
            double B2 = B - A - B1;
            C2 = Math.Round(Math.Sqrt(Math.Pow(H, 2) + Math.Pow(B2, 2)), 2);
        }

        public override double Area()
        {
            return Math.Round((0.5 * H * (A + B)), 2);
        }

        public override double Perimeter()
        {
            return A + B + C + C2;
        }

        public override string ToString()
        {
            return $"Трапеция: нижнее основание - {B} cм, верхняя база - {A} cм, первая сторона - {C} cм, вторая сторона - {C2} cм, высота - {H} cм; Площадь - {this.Area()} cм2, Периметр - {this.Perimeter()} cм."; ;
        }
    }
    internal class AssembledFigure
    {
        Figure[] arr;

        public AssembledFigure(Figure[] obj)
        {
            arr = new Figure[obj.Length];
            for (int i = 0; i < obj.Length; i++) arr[i] = obj[i];
        }

        public AssembledFigure()
        {
            WriteLine("Введите массив размеров!\n");
            int s = int.Parse(ReadLine());
            arr = new Figure[s];
            int i = 0;
            String f;
            do
            {
                WriteLine("Выберите геометрическую фигуру для создания:\n" +
                    "1. Треугольник\n" +
                    "2. Квадрат\n" +
                    "3. Прямоугольник\n" +
                    "4. Ромб\n" +
                    "5. Параллелограмм\n" +
                    "6. Трапеция\n" +
                    "7. Круг\n" +
                    "8. Эллипс\n");
                f = ReadLine();
                if (f == "1") arr[i] = new Triangle();
                else if (f == "2") arr[i] = new Squere();
                else if (f == "3") arr[i] = new Rectangle();
                else if (f == "4") arr[i] = new Rhombus();
                else if (f == "5") arr[i] = new Parallelogram();
                else if (f == "6") arr[i] = new Trapezoid();
                else if (f == "7") arr[i] = new Circle();
                else if (f == "8") arr[i] = new Ellipse();
                if (f == "1" || f == "2" || f == "3" || f == "4" || f == "5" || f == "6" || f == "7" || f == "8") i++;
            } while (i < s);
        }

        public void Show()
        {
            int i = 1;
            WriteLine("Собранная фигура состоит из:\n");
            foreach (var el in arr)
                WriteLine($"{i++}." + el);
            WriteLine($"Общая площадь собранной фигуры = {this.SummAreaFigure()} cм2.");
            WriteLine($"Общий периметр собранной фигуры = {this.SummPerimetrFifure()} cм.");
        }

        public double SummAreaFigure()
        {
            double rezult = 0;
            foreach (var el in arr) rezult += el.Area();
            return rezult;
        }

        public double SummPerimetrFifure()
        {
            double rezult = 0;
            foreach (var el in arr) rezult += el.Perimeter();
            return rezult;
        }
    }
}



