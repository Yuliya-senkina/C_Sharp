/*
Разработать класс, описывающий студента. Предусмотреть в нём следующие
моменты:
- фамилия;
- имя;
- отчество;
- группа;
- возраст;
- массив (зубчатый) оценок по:
   - программированию;
   - администрированию;
   - дизайну. 
Предусмотреть массив данных о студентах.
Добавить методы по работе с перечисленными данными:
- ввод данных;
- корректировка данных;
- добавление/удаление данных;
- возможность установки оценки; 
- возможность получения оценки;
- получение среднего балла по заданному предмету;
- распечатка данных о студенте.
- получение данных о студентах требуемой группы.
*/

using System;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
class Student
{
    public string lastName = "";
    public string firstName = "";
    public string middleName = "";
    public int age = 0;
    public string group = "";


    public Student(string lastName, string firstName, string middleName, string group, int age)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.middleName = middleName;
        this.age = age;
        this.group = group;
    }
    public static void setMarks(ref int[][] mas)
    {
        Console.WriteLine("Введите № студента :");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите оценку по программированию: ");
        mas[num - 1][0] = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите оценку по администрированию: ");
        mas[num - 1][1] = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите оценку по дизайну: ");
        mas[num - 1][2] = Convert.ToInt32(Console.ReadLine());
    }
    public String getlastName()
    {
        return lastName;
    }
    public String getfirstName()
    {
        return firstName;
    }
    public String getmiddleName()
    {
        return middleName;
    }
    public int getage()
    {
        return age;
    }
    public String getgroup()
    {
        return group;
    }
    public void setlastName(String lastName)
    {
        this.lastName = lastName;
    }
    public void setfirstName(String firstName)
    {
        this.firstName = firstName;
    }
    public void setmiddleName(String middleName)
    {
        this.middleName = middleName;
    }
    public void setage(int age)
    {
        this.age = age;
    }
    public void setgroup(String group)
    {
        this.group = group;
    }

    public static Student[] addStudent(ref Student[] st, ref int n)
    {
        Console.WriteLine("Введите количество студентов:");
        n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int age; string lastName, firstName, middleName, group;
            Console.WriteLine("Введите фамилию студента: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Введите имя студента: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите отчество студента: ");
            middleName = Console.ReadLine();
            Console.WriteLine("Введите группу студента: ");
            group = Console.ReadLine();
            Console.WriteLine("Введите возраст студента: ");
            age = Convert.ToInt32(Console.ReadLine());
            st[i] = new Student(lastName, firstName, middleName, group, age);
        }

        return st;
    }



    public static Student[] addStudent_plus(ref Student[] st, ref int n)
    {
        Console.WriteLine("Введите количество студентов:");
        int n1 = Convert.ToInt32(Console.ReadLine());
        for (int i = n; i < n + n1; i++)
        {
            int age; string lastName, firstName, middleName, group;
            Console.WriteLine("Введите фамилию студента: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Введите имя студента: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите отчество студента: ");
            middleName = Console.ReadLine();
            Console.WriteLine("Введите группу студента: ");
            group = Console.ReadLine();
            Console.WriteLine("Введите возраст студента: ");
            age = Convert.ToInt32(Console.ReadLine());
            st[i] = new Student(lastName, firstName, middleName, group, age);
        }
        n = n + n1;
        return st;
    }



    public static void edit_Student(ref Student[] st, ref int n)
    {
        Console.WriteLine("Введите № студента данные которого хотите изменить: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num < 0 || num > n)
            Console.Write("Ученика с таким № нет! \n");
        else
        {
            int age; string lastName, firstName, middleName, group;
            Console.WriteLine("Введите фамилию студента: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Введите имя студента: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите отчество студента: ");
            middleName = Console.ReadLine();
            Console.WriteLine("Введите группу студента: ");
            group = Console.ReadLine();
            Console.WriteLine("Введите возраст студента: ");
            age = Convert.ToInt32(Console.ReadLine());
            st[num - 1] = new Student(lastName, firstName, middleName, group, age);
        }
    }



    public static void delete_Student(ref Student[] st, ref int n)
    {
        Console.WriteLine("Введите № студента данные которого хотите изменить: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num < 0 || num > n)
            Console.Write("Ученика с таким № нет! \n");
        else
        {
            Student[] st2 = new Student[100];

            for (int i = 0; i < num - 1; i++)
                st2[i] = st[i];
            for (int i = num - 1; i < n - 1; i++)
                st2[i] = st[i + 1];
            for (int i = 0; i < n - 1; i++)
                st[i] = st2[i];
            n--;
        }
    }



    public static void print_head()
    {
        Console.Write("╔════╦══════════════════════╦════════════════════════╦═══════════════════╦════════════════════╦═══════════╗\n");
        Console.Write("║");
        Console.Write("№   ");
        Console.Write("║");
        Console.Write("Фамилия               ");
        Console.Write("║");
        Console.Write("Имя                     ");
        Console.Write("║");
        Console.Write("Отчество           ");
        Console.Write("║");
        Console.Write("Группа              ");
        Console.Write("║");
        Console.Write("Возраст    ");
        Console.Write("║");
    }

    public static void print_head2()
    {
        Console.Write("╔════╦═════════════════╦═══════════════════════╦═══════════════════╦════════════════╦═════════════════╦══════╗\n");
        Console.Write("║");
        Console.Write("№   ");
        Console.Write("║");
        Console.Write("Фамилия          ");
        Console.Write("║");
        Console.Write("Имя                    ");
        Console.Write("║");
        Console.Write("Отчество           ");
        Console.Write("║");
        Console.Write("Программирование");
        Console.Write("║");
        Console.Write("Администрирование");
        Console.Write("║");
        Console.Write("Дизайн");
        Console.Write("║");
    }
    public static void print_razdel()
    {
        Console.Write("\n╠════╬══════════════════════╬════════════════════════╬═══════════════════╬════════════════════╬═══════════╣");
    }
    public static void print_razdel2()
    {
        Console.Write("\n╠════╬═════════════════╬═══════════════════════╬═══════════════════╬════════════════╬═════════════════╬══════╣");
    }
    public static void print_end()
    {
        Console.Write("\n╚════╩══════════════════════╩════════════════════════╩═══════════════════╩════════════════════╩═══════════╝\n");
    }
    public static void print_end2()
    {
        Console.Write("\n╚════╩═════════════════╩═══════════════════════╩═══════════════════╩════════════════╩═════════════════╩══════╝\n");
    }

    public static void printStudent_byGroup(ref Student[] st, ref int n)
    {
        Console.WriteLine("Введите название группы: ");
        string name_group = Console.ReadLine();
        int kol = 0;
        for (int i = 0; i < n; i++)
        {
            if (String.Compare(name_group, st[i].getgroup()) == 0)
                kol++;
        }
        if (kol == 0) Console.Write("Данной группы нет! \n");
        else
        {

            print_head();
            for (int i = 0; i < n; i++)
            {
                if (String.Compare(name_group, st[i].getgroup()) == 0)
                {
                    print_razdel();
                    Console.Write("\n");
                    Console.Write("║");
                    Console.Write("{0,-4}", i + 1);
                    Console.Write("║");
                    Console.Write("{0,-22}", st[i].getlastName());
                    Console.Write("║");
                    Console.Write("{0,-24}", st[i].getfirstName());
                    Console.Write("║");
                    Console.Write("{0,-19}", st[i].getmiddleName());
                    Console.Write("║");
                    Console.Write("{0,-20}", st[i].getgroup());
                    Console.Write("║");
                    Console.Write("{0,-11}", st[i].getage());
                    Console.Write("║");
                }
            }
            Student.print_end();
        }
    }

    public static void printStudent(ref Student[] st, ref int n)
    {
        print_head();
        for (int i = 0; i < n; i++)
        {
            print_razdel();
            Console.Write("\n");
            Console.Write("║");
            Console.Write("{0,-4}", i + 1);
            Console.Write("║");
            Console.Write("{0,-22}", st[i].getlastName());
            Console.Write("║");
            Console.Write("{0,-24}", st[i].getfirstName());
            Console.Write("║");
            Console.Write("{0,-19}", st[i].getmiddleName());
            Console.Write("║");
            Console.Write("{0,-20}", st[i].getgroup());
            Console.Write("║");
            Console.Write("{0,-11}", st[i].getage());
            Console.Write("║");
        }
        Student.print_end();
    }

    public static void printStudent_grade(ref Student[] st, ref int[][] mas, ref int n)
    {
        print_head2();
        for (int i = 0; i < n; i++)
        {
            print_razdel2();
            Console.Write("\n");
            Console.Write("║");
            Console.Write("{0,-4}", i + 1);
            Console.Write("║");
            Console.Write("{0,-17}", st[i].getlastName());
            Console.Write("║");
            Console.Write("{0,-23}", st[i].getfirstName());
            Console.Write("║");
            Console.Write("{0,-19}", st[i].getmiddleName());
            Console.Write("║");
            Console.Write("{0,-16}", mas[i][0]);
            Console.Write("║");
            Console.Write("{0,-17}", mas[i][1]);
            Console.Write("║");
            Console.Write("{0,-6}", mas[i][2]);
            Console.Write("║");
        }
        Student.print_end2();
    }

    public static void print_avg_grade(ref int[][] mas, ref int n)
    {
        double sum = 0;
        Console.WriteLine("Введите предмет для вывода среднего балла(Программирование, Администрирование, Дизайн): ");
        string name_sub = Console.ReadLine();
        if (String.Compare(name_sub, "Программирование") == 0)
        {
            for (int i = 0; i < n; i++)
                sum += mas[i][0];
            Console.Write("Средний балл по Программированию: {0}", sum / n);
        }
        else
              if (String.Compare(name_sub, "Администрирование") == 0)
        {
            for (int i = 0; i < n; i++)
                sum += mas[i][1];
            Console.Write("Средний балл по Администрированию: {0}", sum / n);
        }
        else
              if (String.Compare(name_sub, "Дизайн") == 0)
        {
            for (int i = 0; i < n; i++)
                sum += mas[i][2];
            Console.Write("Средний балл по Дизайну: {0}", sum / n);
        }
        else Console.Write("Предмет ввден не верно! \n");
    }

    static void Main(string[] args)
    {
        int n = 0;
        Student[] st = new Student[10];
        int[][] mas = new int[10][];
        mas[0] = new int[3];
        mas[1] = new int[3];
        mas[2] = new int[3];
        mas[3] = new int[3];
        mas[4] = new int[3];
        mas[5] = new int[3];
        mas[6] = new int[3];
        mas[7] = new int[3];
        mas[8] = new int[3];
        mas[9] = new int[3];
        bool prodolgenie_int = true;
        int menu_item_int;
        do
        {
            Console.Clear();
            Console.WriteLine("1) Ввод данных.");
            Console.WriteLine("2) Изменение данных студента.");
            Console.WriteLine("3) Добавление cтудента.");
            Console.WriteLine("4) Удаление cтудента.");
            Console.WriteLine("5) Выставить оценки.");
            Console.WriteLine("6) Вывести оценки.");
            Console.WriteLine("7) Получить средний балла по заданному предмету.");
            Console.WriteLine("8) Распечатать данные о студенте.");
            Console.WriteLine("9) Получить данные о студентах требуемой группы.");
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
                        st = addStudent(ref st, ref n);
                        Console.ReadKey();
                        break;
                    case 2:
                        printStudent(ref st, ref n);
                        edit_Student(ref st, ref n);
                        Console.WriteLine("\nДанные студента изменены!\n");
                        printStudent(ref st, ref n);
                        Console.ReadKey();
                        break;
                    case 3:
                        printStudent(ref st, ref n);
                        st = addStudent_plus(ref st, ref n);
                        Console.WriteLine("\nСтудент добавлен!\n");
                        printStudent(ref st, ref n);
                        Console.ReadKey();
                        break;
                    case 4:
                        printStudent(ref st, ref n);
                        delete_Student(ref st, ref n);
                        Console.WriteLine("\nСтудент удален!\n");
                        printStudent(ref st, ref n);
                        Console.ReadKey();
                        break;
                    case 5:
                        printStudent_grade(ref st, ref mas, ref n);
                        setMarks(ref mas);
                        Console.WriteLine("\nОценки выставлены!\n");
                        printStudent_grade(ref st, ref mas, ref n);
                        Console.ReadKey();
                        break;
                    case 6:
                        printStudent_grade(ref st, ref mas, ref n);
                        Console.ReadKey();
                        break;
                    case 7:
                        printStudent_grade(ref st, ref mas, ref n);
                        print_avg_grade(ref mas, ref n);
                        Console.ReadKey();
                        break;
                    case 8:
                        printStudent(ref st, ref n);
                        Console.ReadKey();
                        break;
                    case 9:
                        printStudent(ref st, ref n);
                        printStudent_byGroup(ref st, ref n);
                        Console.ReadKey();
                        break;
                    case 10:
                        prodolgenie_int = false;
                        break;
                }
        } while (prodolgenie_int);

    }
}



