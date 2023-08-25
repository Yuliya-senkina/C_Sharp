/*
 Разработать в двух вариантах: СИ++, СИ#.

Создайте приложение "Телефонная книга". 
1. Необходимо хранить данные об абоненте: 
     - Фамилия;
     - Имя;
     - Отчество;
     - домашний телефон;
     - рабочий телефон;
     - мобильный телефон;
     - дополнительная информация о контакте.
    внутри соответствующего класса.
2. Предоставьте пользователю следующие возможности:
    - добавлять новых абонентов;
    - удалять абонентов;
    - искать абонентов по фамилии, имени, отчеству;
    - искать абонентов по телефонам;
    - показывать всех абонентов;
- сохранять информацию в файл и загружать из файла.
*/

using System;
using static System.Console;
#nullable disable
public class Phone_book
{
    public string surname;
    public string name;
    public string patronymic;
    public string homephone;
    public string workphone;
    public string mobilephone;
    public string about;
    public const int MAXSURNAME = 28;
    public const int MAXNAME = 28;
    public const int MAXPAT = 28;
    public const int MAXABOUT = 24;
    public const int MAXHPHONE = 10;
    public const int MAXWPHONE = 10;
    public const int MAXMPHONE = 10;
    public const int MAXPHONEBOOK = 100;
    public const string STOP = "";
    public const string FILE_NAME = "zap_kniga.dat";
    public static int count = 0;
    public static Phone_book a = new Phone_book();
    public static Phone_book[] shop = new Phone_book[MAXPHONEBOOK];
    public static Phone_book[] tmp = new Phone_book[MAXPHONEBOOK];
    public Phone_book()
    {

        surname = new string(new char[27]);
        name = new string(new char[27]);
        patronymic = new string(new char[27]);
        homephone = new string(new char[27]);
        workphone = new string(new char[27]);
        mobilephone = new string(new char[27]);
        about = new string(new char[23]);
    }



    public void Initial(string s, string n, string p, string h, string w, string m, string a)
    {
        surname = s;
        name = n;
        patronymic = p;
        homephone = h;
        workphone = w;
        mobilephone = m;
        about = a;
    }

    public void print_razdel()
    {

        Console.Write("\n\xCC\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xB9\n");
    }
    public void print_head()
    {

        Console.Write("\xC9\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBB\n");
        Console.Write("\xBA");
        Console.Write("№   ");
        Console.Write("\xBA");
        Console.Write("Фамилия             ");
        Console.Write("\xBA");
        Console.Write("Имя             ");
        Console.Write("\xBA");
        Console.Write("Отчество           ");
        Console.Write("\xBA");
        Console.Write("Домашний телефон");
        Console.Write("\xBA");
        Console.Write("Рабочий телефон ");
        Console.Write("\xBA");
        Console.Write("Мобильный телефон ");
        Console.Write("\xBA");
        Console.Write("Доп.информация ");
        Console.Write("\xBA");
    }
    public void print_end()
    {
        Console.Write("\n\xC8\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA" + "\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCA" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA" + "\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCA" + "\xCD\xCD\xCD\xCD\xCD\xCD" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA" + "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBC\n");
    }
    public void input()
    {

        Console.Write("Введите фамилию абонента:\n");
        shop[count].surname = Console.ReadLine();
        while (Console.Read() != '\n') ;
        {
            Console.Write("Введите имя абонента:\n");
            shop[count].name = Console.ReadLine();
            Console.Write("Введите отчество абонента:\n");
            shop[count].patronymic = Console.ReadLine();
            Console.Write("Введите домашний телефон:\n");
            shop[count].homephone = Console.ReadLine();
            Console.Write("Введите рабочий телефон:\n");
            Console.Write("Введите мобильный телефон:\n");
            shop[count].mobilephone = Console.ReadLine();
            Console.Write("Введите дополнительную информацию о абоненте:\n");
            shop[count].about = Console.ReadLine();
            if (count < MAXPHONEBOOK)
            {
                Console.Write("Фамилия следующего абонента:\n");
            }
        }
        if (count == 0)
        {
            Console.Write("Вообще нет никаких абонентов?. Если так, то очень плохо!!!\n");
        }
    }
    public void _out()
    {
        if (count > 0)
        {
            Console.Write("Каталог введённых абонентов:\n");
            print_head();
            print_razdel();
            for (int index = 0; index < count; index++)
            {
                Console.Write("\xBA");
                Console.Write("{0,3:D}", index);
                Console.Write(" \xBA");
                Console.Write("{0,-19}", shop[index].surname);
                Console.Write(" \xBA");
                Console.Write("{0,-15}", shop[index].name);
                Console.Write(" \xBA");
                Console.Write("{0,-19}", shop[index].patronymic);
                Console.Write("\xBA");
                Console.Write("{0,16}", shop[index].homephone);
                Console.Write("\xBA");
                Console.Write("{0,16}", shop[index].workphone);
                Console.Write("\xBA");
                Console.Write("{0,18}", shop[index].mobilephone);
                Console.Write("\xBA");
                Console.Write("{0,-15}", shop[index].about);
                Console.Write("\xBA");
                if (index != (count - 1))
                {
                    print_razdel();
                }
            }
            print_end();
        }
    }
    public void out_s(int i)
    {
        Console.Write("\xBA");
        Console.Write("{0,4:D}", i);
        Console.Write("\xBA");
        Console.Write("{0,-19}", shop[i].surname);
        Console.Write(" \xBA");
        Console.Write("{0,-15}", shop[i].name);
        Console.Write(" \xBA");
        Console.Write("{0,-19}", shop[i].patronymic);
        Console.Write("\xBA");
        Console.Write("{0,16}", shop[i].homephone);
        Console.Write("\xBA");
        Console.Write("{0,16}", shop[i].workphone);
        Console.Write("\xBA");
        Console.Write("{0,18}", shop[i].mobilephone);
        Console.Write("\xBA");
        Console.Write("{0,-15}", shop[i].about);
        Console.Write("\xBA");
    }
    public void del()
    {
        int num = 0;
        Console.Write("Введите номер записи для удаления: \n");
        string tempVar = Console.ReadLine();
        if (tempVar != null)
        {
            num = int.Parse(tempVar);
        }
        if (num < 0 || num > count - 1)
        {
            Console.Write("Номер записи за границами.\n");
        }
        else
        {
            Console.Write("Запись номер {0:D} удалена.\n", num);
        }
        for (int i = 0; i < num; i++)
        {
            tmp[i].surname = shop[i].surname;
            tmp[i].name = shop[i].name;
            tmp[i].patronymic = shop[i].patronymic;
            tmp[i].homephone = shop[i].homephone;
            tmp[i].workphone = shop[i].workphone;
            tmp[i].mobilephone = shop[i].mobilephone;
            tmp[i].about = shop[i].about;
        }
        for (int i = num + 1; i <= count; i++)
        {
            tmp[i - 1].surname = shop[i].surname;
            tmp[i - 1].name = shop[i].name;
            tmp[i - 1].patronymic = shop[i].patronymic;
            tmp[i - 1].homephone = shop[i].homephone;
            tmp[i - 1].workphone = shop[i].workphone;
            tmp[i - 1].mobilephone = shop[i].mobilephone;
            tmp[i - 1].about = shop[i].about;
        }
        count--;
        for (int i = 0; i < count; i++)
        {
            shop[i].surname = tmp[i].surname;
            shop[i].name = tmp[i].name;
            shop[i].patronymic = tmp[i].patronymic;
            shop[i].homephone = tmp[i].homephone;
            shop[i].workphone = tmp[i].workphone;
            shop[i].mobilephone = tmp[i].mobilephone;
            shop[i].about = tmp[i].about;
        }
    }
    public void search_surname()
    {
        string surname = new string(new char[MAXNAME]);
        int kol = 0;
        int kol2 = 0;
        Console.Write("Введите фамилию для поиска:\n");
        while (Console.Read() != '\n') ;
        shop[count].surname = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (string.Compare(shop[i].surname, surname) == 0)
            {
                kol++;
            }
        }
        if (kol == 0)
        {
            Console.Write("По данноой фамилии абонент не найден!\n");
        }
        else
        {
            print_head();
            for (int i = 0; i < count; i++)
            {
                if (string.Compare(shop[i].surname, surname) == 0)
                {
                    kol2++;
                    print_razdel();
                    a.out_s(i);
                    if (kol2 == kol)
                    {
                        print_end();
                    }
                }
            }
        }
    }
    public void search_name()
    {
        string name = new string(new char[MAXNAME]);
        int kol = 0;
        int kol2 = 0;
        Console.Write("Введите имя для поиска:\n");
        while (Console.Read() != '\n') ;
        shop[count].name = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (string.Compare(shop[i].name, name) == 0)
            {
                kol++;
            }
        }
        if (kol == 0)
        {
            Console.Write("По данному имени абонент не найден!\n");
        }
        else
        {
            print_head();
            for (int i = 0; i < count; i++)
            {
                if (string.Compare(shop[i].name, name) == 0)
                {
                    kol2++;
                    print_razdel();
                    a.out_s(i);
                    if (kol2 == kol)
                    {
                        print_end();
                    }
                }
            }
        }
    }
    public void search_patronymic()
    {
        string patronymic = new string(new char[MAXPAT]);
        int kol = 0;
        int kol2 = 0;
        Console.Write("Введите отчество для поиска:\n");
        while (Console.Read() != '\n') ;
        shop[count].patronymic = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (string.Compare(shop[i].patronymic, patronymic) == 0)
            {
                kol++;
            }
        }
        if (kol == 0)
        {
            Console.Write("По данному отчеству абонент не найден!\n");
        }
        else
        {
            print_head();
            for (int i = 0; i < count; i++)
            {
                if (string.Compare(shop[i].patronymic, patronymic) == 0)
                {
                    kol2++;
                    print_razdel();
                    a.out_s(i);
                    if (kol2 == kol)
                    {
                        print_end();
                    }
                }
            }
        }
    }
    public void search_homephone()
    {
        int kol = 0;
        int kol2 = 0;
        Console.Write("Введите домашний телефон для поиска:\n");
        while (Console.Read() != '\n') ;
        shop[count].homephone = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (string.Compare(shop[i].homephone, homephone) == 0)
            {
                kol++;
            }
        }
        if (kol == 0)
        {
            Console.Write("По данному домашнему телефону абонент не найден!\n");
        }
        else
        {
            print_head();
            for (int i = 0; i < count; i++)
            {
                if (string.Compare(shop[i].homephone, homephone) == 0)
                {
                    kol2++;
                    print_razdel();
                    a.out_s(i);
                    if (kol2 == kol)
                    {
                        print_end();
                    }
                }
            }
        }
    }
    public void search_workphone()
    {
        int kol = 0;
        int kol2 = 0;
        Console.Write("Введите домашний телефон для поиска:\n");
        while (Console.Read() != '\n') ;
        shop[count].workphone = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (string.Compare(shop[i].workphone, workphone) == 0)
            {
                kol++;
            }
        }
        if (kol == 0)
        {
            Console.Write("По данному рабочему телефону абонент не найден!\n");
        }
        else
        {
            print_head();
            for (int i = 0; i < count; i++)
            {
                if (string.Compare(shop[i].workphone, workphone) == 0)
                {
                    kol2++;
                    print_razdel();
                    a.out_s(i);
                    if (kol2 == kol)
                    {
                        print_end();
                    }
                }
            }
        }
    }
    public void search_mobilephone()
    {
        int kol = 0;
        int kol2 = 0;
        Console.Write("Введите домашний телефон для поиска:\n");
        while (Console.Read() != '\n') ;
        shop[count].mobilephone = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (string.Compare(shop[i].mobilephone, mobilephone) == 0)
            {
                kol++;
            }
        }
        if (kol == 0)
        {
            Console.Write("По данному мобильному телефону абонент не найден!\n");
        }
        else
        {
            print_head();
            for (int i = 0; i < count; i++)
            {
                if (string.Compare(shop[i].mobilephone, mobilephone) == 0)
                {
                    kol2++;
                    print_razdel();
                    a.out_s(i);
                    if (kol2 == kol)
                    {
                        print_end();
                    }
                }
            }
        }
    }
    /* public int Save(string fileName, Phone_book p_phone_book_save, int size_)
     {
         uint size_dannye;
         FILE file = fopen(fileName, "w+b");
         fseek(file, 0, SEEK_SET);
         fwrite(size_, sizeof(int), 1, file);
         for (int i = 0; i < size_; i++)
         {
             size_dannye = Convert.ToString((p_phone_book_save + i).surname).Length + 1;
             fwrite(size_dannye, sizeof(int), 1, file);
             fwrite((p_phone_book_save + i).surname, sizeof(sbyte), size_dannye, file);
             size_dannye = Convert.ToString((p_phone_book_save + i).name).Length + 1;
             fwrite(size_dannye, sizeof(int), 1, file);
             fwrite((p_phone_book_save + i).name, sizeof(sbyte), size_dannye, file);
             size_dannye = Convert.ToString((p_phone_book_save + i).patronymic).Length + 1;
             fwrite(size_dannye, sizeof(int), 1, file);
             fwrite((p_phone_book_save + i).patronymic, sizeof(sbyte), size_dannye, file);
             size_dannye = Convert.ToString((p_phone_book_save + i).homephone).Length + 1;
             fwrite(size_dannye, sizeof(int), 1, file);
             fwrite((p_phone_book_save + i).homephone, sizeof(sbyte), size_dannye, file);
             size_dannye = Convert.ToString((p_phone_book_save + i).workphone).Length + 1;
             fwrite(size_dannye, sizeof(int), 1, file);
             fwrite((p_phone_book_save + i).workphone, sizeof(sbyte), size_dannye, file);
             size_dannye = Convert.ToString((p_phone_book_save + i).mobilephone).Length + 1;
             fwrite(size_dannye, sizeof(int), 1, file);
             fwrite((p_phone_book_save + i).mobilephone, sizeof(sbyte), size_dannye, file);
             size_dannye = Convert.ToString((p_phone_book_save + i).about).Length + 1;
             fwrite(size_dannye, sizeof(int), 1, file);
             fwrite((p_phone_book_save + i).about, sizeof(sbyte), size_dannye, file);
         }
         fclose(file);
         Console.Write("Файл сохранен.\n");
         return 1;
     }
     public Phone_book Load(string fileName, int size)
     {
         Phone_book p_phone_book_load;
         FILE file = fopen(fileName, "r+b");
         if (file == null)
         {
             Console.Write("ОШИБКА! Файл не существует.\n");
             return null;
         }
         int size_load;
         uint size_dannye;
         fseek(file, 0, SEEK_SET);
         fread(size_load, sizeof(int), 1, file);
         p_phone_book_load = Arrays.InitializeWithDefaultInstances<Phone_book>(size_load);
         for (int i = 0; i < size_load; i++)
         {
             fread(size_dannye, sizeof(int), 1, file);
             fread((p_phone_book_load + i).surname, sizeof(sbyte), size_dannye, file);
             fread(size_dannye, sizeof(int), 1, file);
             fread((p_phone_book_load + i).name, sizeof(sbyte), size_dannye, file);
             fread(size_dannye, sizeof(int), 1, file);
             fread((p_phone_book_load + i).patronymic, sizeof(sbyte), size_dannye, file);
             fread(size_dannye, sizeof(int), 1, file);
             fread((p_phone_book_load + i).homephone, sizeof(sbyte), size_dannye, file);
             fread(size_dannye, sizeof(int), 1, file);
             fread((p_phone_book_load + i).workphone, sizeof(sbyte), size_dannye, file);
             fread(size_dannye, sizeof(int), 1, file);
             fread((p_phone_book_load + i).mobilephone, sizeof(sbyte), size_dannye, file);
             fread(size_dannye, sizeof(int), 1, file);
             fread((p_phone_book_load + i).about, sizeof(sbyte), size_dannye, file);
         }
         fclose(file);
         Console.Write("Файл загружен.\n");
         size = size_load;
         return p_phone_book_load;
     }*/


    static int Main()
    {
        Phone_book[] p_phone_book_a;
        p_phone_book_a = new Phone_book[1];
        Console.Clear();
        int k = 0;
        int i1;

        bool prodolgenie_int = true;
        int menu_item_int = 0;
        bool prodolgenie_int1 = true;
        int menu_item_int1 = 0;
        bool prodolgenie_int2 = true;
        int menu_item_int2 = 0;
        do
        {
            Console.Clear();
            Console.Write("1) Добавление нового абонента.\n");
            Console.Write("2) Удаление абонента.\n");
            Console.Write("3) Поиск абонента.\n");
            Console.Write("4) Показать всех абонентов.\n");
            Console.Write("5) Сохранить в файл.\n");
            Console.Write("6) Загрузить из файла.\n");
            Console.Write("7) Выход.\n");
            string tempVar = Console.ReadLine();
            if (tempVar != null)
            {
                menu_item_int = int.Parse(tempVar);
            }
            if (menu_item_int < 1 || menu_item_int > 7)
            {
                Console.Write("\nВыбран не верный путь меню, повторите ввод\n");
                Console.ReadKey();
            }
            else
            {
                switch (menu_item_int)
                {
                    case 1:
                        a.input();
                        Console.ReadKey();
                        break;
                    case 2:
                        a._out();
                        a.del();
                        Console.ReadKey();
                        break;
                    case 3:
                        do
                        {
                            Console.Clear();
                            Console.Write("1) Поиск по фамилии.\n");
                            Console.Write("2) Поиск по имени.\n");
                            Console.Write("3) Поиск по отчеству.\n");
                            Console.Write("4) Поиск по телефону.\n");
                            Console.Write("5) Выход.\n");
                            string tempVar2 = Console.ReadLine();
                            if (tempVar2 != null)
                            {
                                menu_item_int1 = int.Parse(tempVar2);
                            }
                            if (menu_item_int1 < 1 || menu_item_int1 > 5)
                            {
                                Console.Write("\nВыбран не верный путь меню, повторите ввод\n");
                                Console.ReadKey();
                            }
                            else
                            {
                                switch (menu_item_int1)
                                {
                                    case 1:
                                        a.search_surname();
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        a.search_name();
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        a.search_patronymic();
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        do
                                        {
                                            Console.Clear();
                                            Console.Write("1) Поиск по домашнему телефону.\n");
                                            Console.Write("2) Поиск по рабочему телефону.\n");
                                            Console.Write("3) Поиск по мобильному телефону.\n");
                                            Console.Write("4) Выход.\n");
                                            string tempVar3 = Console.ReadLine();
                                            if (tempVar3 != null)
                                            {
                                                menu_item_int2 = int.Parse(tempVar3);
                                            }
                                            if (menu_item_int2 < 1 || menu_item_int2 > 4)
                                            {
                                                Console.Write("\nВыбран не верный путь меню, повторите ввод\n");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                switch (menu_item_int2)
                                                {
                                                    case 1:
                                                        a.search_homephone();
                                                        Console.ReadKey();
                                                        break;
                                                    case 2:
                                                        a.search_workphone();
                                                        Console.ReadKey();
                                                        break;
                                                    case 3:
                                                        a.search_mobilephone();
                                                        Console.ReadKey();
                                                        break;
                                                    case 4:
                                                        prodolgenie_int2 = false;
                                                        break;
                                                }
                                            }
                                        } while (prodolgenie_int2);
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        prodolgenie_int1 = false;
                                        break;
                                }
                            }
                        } while (prodolgenie_int1);

                        Console.ReadKey();
                        break;
                    case 4:
                        a._out();
                        Console.ReadKey();
                        break;
                    case 5:
                        p_phone_book_a = new Phone_book[count];

                        //a.Save(FILE_NAME, new Phone_book(p_phone_book_a), count);
                        Console.ReadKey();
                        break;
                    case 6:
                        // a.Load(FILE_NAME, count);
                        Console.ReadKey();
                        break;
                    case 7:
                        prodolgenie_int = false;
                        break;
                }
            }
        } while (prodolgenie_int);
        return 0;
    }
}

