/*
Разработать абстрактный класс «Геометрическая Фигура» с методами «Площадь Фигуры» и «Периметр Фигуры». Разработать классы-наследники: Треугольник, Квадрат, Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг,
Эллипс. 
Реализовать конструкторы, которые однозначно определяют объекты данных классов. 
Реализовать класс «Составная Фигура», который может состоять из любого количества «Геометрических Фигур». Для данного класса определить метод нахождения площади фигуры. Результат проверить на реальной программе.
*/

using System;
namespace Figures
{
    public abstract class GeoFigure
    {
        public double _perimeter { get; set; }
        public double Square { get; set; }
        public string _figure { get; set; }
        public double _height { get; set; }
        public const double pi = 3.14;
        public GeoFigure(string figure)
        {
            _figure = figure;
        }
        public abstract double Perimeter();
        public abstract double Area();
        public void PrintFigure()
        {
            Console.WriteLine($" Площадь {_figure}а {Area()} см2 \n Периметр {_figure}а {Perimeter()} см \n");
        }
        public virtual void Print()
        {
            Console.WriteLine($" Площадь фигуры {Area()} см2 \n Периметр фигуры {Perimeter()} см ");
        }
    }

    class Triangle : GeoFigure
    {
        public double _sideA { get; set; }
        public double _sideB { get; set; }
        public double _sideC { get; set; }
        public Triangle(string figure, double sideA, double sideB, double sideC) : base(figure)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }
        public override double Perimeter()
        {
            _perimeter = _sideA + _sideB + _sideC;
            return _perimeter;
        }
        public override double Area()
        {
            double P = 0.5 * (_sideA + _sideB + _sideC);
            Square = Math.Sqrt(P * (P - _sideA) * (P - _sideB) * (P - _sideC));
            return Square;
        }
        public override void Print()
        {
            Console.WriteLine($"Площадь треугольника {Area()} \n периметр треугольника {Perimeter()} \n");
        }
    }
    class Square : GeoFigure
    {
        public Square(string figure, double height) : base(figure)
        {
            _height = height;
        }
        public override double Area()
        {
            return Square = _height * _height;
        }
        public override double Perimeter()
        {
            return _perimeter = 4 * _height;
        }
        public override void Print()
        {
            Console.WriteLine($"Площадь квадрата {Area()} \n периметр квадрата {Perimeter()}\n");
        }
    }
    class Romb : GeoFigure
    {
        public double _diagonal1 { get; set; }
        public double _diagonal2 { get; set; }
        public Romb(string figure, double height) : base(figure)
        {
            _height = height;
        }
        public Romb(string figure, double diagonal1, double diagonal2) : base(figure)
        {
            _diagonal1 = diagonal1;
            _diagonal2 = diagonal2;
        }
        public Romb(string figure, double diagonal1, double diagonal2, double height) : base(figure)
        {
            _diagonal1 = diagonal1;
            _diagonal2 = diagonal2;
            _height = height;
        }
        public override double Area()
        {
            return Square = 0.5 * (_diagonal1 * _diagonal2);
        }
        public override double Perimeter()
        {
            return _perimeter = 4 * _height;
        }
        public override void Print()
        {
            Console.WriteLine($"Площадь ромба {Area()} \n периметр ромба {Perimeter()} \n");
        }
    }
    class Rectangle : GeoFigure
    {
        public double _sideA { get; set; }
        public double _sideB { get; set; }
        public Rectangle(string figure, double sideA, double sideB) : base(figure)
        {
            _sideA = sideA;
            _sideB = sideB;
        }
        public override double Area()
        {
            return Square = _sideA * _sideB;
        }
        public override double Perimeter()
        {
            return _perimeter = 2 * (_sideA + _sideB);
        }
        public override void Print()
        {
            Console.WriteLine($"Площадь прямоугольника {Area()} \n периметр прямоугольника {Perimeter()}\n ");
        }
    }

    class Parallelogram : GeoFigure
    {
        public double _sideA { get; set; }
        public double _sideB { get; set; }
        public Parallelogram(string figure, double sideA, double height) : base(figure)
        {
            _sideA = sideA;
            _height = height;
        }
        public Parallelogram(string figure, double sideA, double height, double sideB) : base(figure)
        {
            _sideA = sideA;
            _sideB = sideB;
            _height = height;
        }
        public override double Area()
        {
            return Square = _sideA * _height;
        }
        public override double Perimeter()
        {
            return _perimeter = 2 * (_sideA + _sideB);
        }
        public override void Print()
        {
            Console.WriteLine($"Площадь параллелограмма {Area()} \n периметр параллелограмма {Perimeter()} \n");
        }
    }

    class Trapezoid : GeoFigure
    {
        public double _sideA { get; set; }
        public double _sideB { get; set; }
        public double _sideC { get; set; }
        public double _sideD { get; set; }

        public Trapezoid(string figure, double sideA, double sideB, double sideC, double sideD) : base(figure)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            _sideD = sideD;
        }
        public Trapezoid(string figure, double sideA, double sideB, double height) : base(figure)
        {
            _sideA = sideA;
            _sideB = sideB;
            _height = height;
        }
        public Trapezoid(string figure, double sideA, double sideB, double sideC, double sideD, double height) : base(figure)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            _sideD = sideD;
            _height = height;
        }
        public override double Area()
        {
            double v = (_sideA + _sideB);
            return Square = 0.5 * v * _height;
        }
        public override double Perimeter()
        {
            return _perimeter = _sideA + _sideB + _sideC + _sideD;
        }
        public override void Print()
        {
            Console.WriteLine($"Площадь трапеции {Area()} \n периметр трапеции {Perimeter()} \n");
        }
    }

    class Circle : GeoFigure
    {
        public double _radius { get; set; }
        public Circle(string figure, double radius) : base(figure)
        {
            _radius = radius;
        }
        public override double Area()
        {
            return Square = pi * _radius * _radius;
        }
        public override double Perimeter()
        {
            return _perimeter = 2 * pi * _radius;
        }
        public override void Print()
        {
            Console.WriteLine($" Площадь круга {Area()} \n периметр круга {Perimeter()} \n");
        }
    }
    class Ellipse : GeoFigure
    {
        public double _Radius { get; set; }
        public double _radius { get; set; }
        public Ellipse(string figure, double Radius, double radius) : base(figure)
        {
            _Radius = Radius;
            _radius = radius;
        }
        public override double Area()
        {
            return Square = pi * _Radius * _radius;
        }
        public override double Perimeter()
        {
            return _perimeter = 4 * ((Math.PI * _Radius * _radius) + (_Radius - _radius) / (_Radius + _radius));
        }
        public override void Print()
        {
            Console.WriteLine($"Площадь эллипса {Area()} \n периметр эллипса {Perimeter()} \n");
        }
    }

    class SosFigure
    {
        public double result = 0;
        public GeoFigure[] geoFigures { get; set; }
        public SosFigure(params GeoFigure[] geoFigures)
        {
            this.geoFigures = geoFigures;
            PrintShow();
        }
        public double Area()
        {
            for (int i = 0; i < geoFigures.Length; i++)
            {
                result += geoFigures[i].Area();
            }
            return result;
        }
        public void PrintShow()
        {
            Console.WriteLine($"Площадь составной фигуры {Area()} см2\n ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            GeoFigure[] figures =
            {
               new Triangle("треугольник", 4, 4, 5),
               new Square("квадрат", 5),
               new Rectangle("прямоугольник", 5, 7),
               new Romb("ромб", 3, 4, 5),
               new Parallelogram("параллелограмм", 5, 6, 7),
               new Trapezoid("трапеция", 5, 6, 4,7,6.5),
               new Circle("круг", 5),
               new Ellipse("эллипс", 5, 8)
            };
            foreach (GeoFigure item in figures)
            {
                item.PrintFigure();
                result += item.Area();
            }
            Console.WriteLine($" сумма площади фигур {result} см2\n");
            GeoFigure[] geos =
            {
                new Triangle("треугольник", 3, 4, 5),
               new Square("квадрат", 8),
               new Rectangle("прямоугольник", 3, 7)
            };
            SosFigure sos = new SosFigure(geos);
            Console.ReadKey();
        }
    }
}

