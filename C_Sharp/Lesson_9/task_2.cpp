#include <windows.h>
#include <stdio.h>
#include <string.h>
#include <conio.h>
#define MAXSURNAME 28 
#define MAXNAME 28 
#define MAXPAT 28 
#define MAXABOUT 24 
#define MAXHPHONE 10 
#define MAXWPHONE 10 
#define MAXMPHONE 10 
#define MAXPHONEBOOK 100 
#define STOP ""

using namespace std;
int count = 0;

#define FILE_NAME "zap_kniga.dat"

class Phone_book
{
public:
    char* surname;
    char* name;
    char* patronymic;
    char* homephone;
    char* workphone;
    char* mobilephone;
    char* about;
    Phone_book();
    ~Phone_book();
    void Initial(char* s, char* n, char* p, char* h, char* w, char* m, char* a);
    char* s_gets(char* st, int n);
    void print_razdel();
    void print_head();
    void print_end();
    void input();
    void out();
    void out_s(int i);
    void del();
    void search_surname();
    void search_name();
    void search_patronymic();
    void search_homephone();
    void search_workphone();
    void search_mobilephone();
    int Save(const char* fileName, Phone_book* P_ZAP_KNIGA_SAVE, int size_);
    Phone_book* Load(const char* fileName, int* size);

};
Phone_book::Phone_book() {

    surname = new char[28];
    name = new char[28];
    patronymic = new char[28];
    homephone = new char[28];
    workphone = new char[28];
    mobilephone = new char[28];
    about = new char[24];
}
Phone_book::~Phone_book() {

    delete[]surname;
    delete[]name;
    delete[]patronymic;
    delete[]homephone;
    delete[]workphone;
    delete[]mobilephone;
    delete[]about;

};
void Phone_book::Initial(char* s, char* n, char* p, char* h, char* w, char* m, char* a)
{
    strcpy(surname, s);
    strcpy(name, n);
    strcpy(patronymic, p);
    strcpy(homephone, h);
    strcpy(workphone, w);
    strcpy(mobilephone, m);
    strcpy(about, a);
}
Phone_book a, shop[MAXPHONEBOOK],tmp[MAXPHONEBOOK];
int main(void)
{
    Phone_book* p_phone_book_a;
    p_phone_book_a = new Phone_book[1];
    system("cls");
    int i1 = GetConsoleCP();
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    bool prodolgenie_int = true;
    int  menu_item_int;
    bool prodolgenie_int1 = true;
    int  menu_item_int1;
    bool prodolgenie_int2 = true;
    int  menu_item_int2;
    do
    {
        system("cls");
        printf("1) Добавление нового абонента.\n");
        printf("2) Удаление абонента.\n");
        printf("3) Поиск абонента.\n");
        printf("4) Показать всех абонентов.\n");
        printf("5) Сохрнаить в файл.\n");
        printf("6) Загрузить из файла.\n");
        printf("7) Выход.\n");
        scanf("%d", &menu_item_int);
        if (menu_item_int < 1 || menu_item_int>7)
        {
            printf("\nВыбран не верный путь меню, повторите ввод\n");
            system("pause");
        }
        else
            switch (menu_item_int)
            {
            case 1:
                a.input();
                system("pause");
                break;
            case 2:
                a.out();
                a.del();
                system("pause");
                break;
            case 3:
                do
                {
                    system("cls");
                    printf("1) Поиск по фамилии.\n");
                    printf("2) Поиск по имени.\n");
                    printf("3) Поиск по отчеству.\n");
                    printf("4) Поиск по телефону.\n");
                    printf("5) Выход.\n");
                    scanf("%d", &menu_item_int1);
                    if (menu_item_int1 < 1 || menu_item_int1>5)
                    {
                        printf("\nВыбран не верный путь меню, повторите ввод\n");
                        system("pause");
                    }
                    else
                        switch (menu_item_int1)
                        {
                        case 1:
                            a.search_surname();
                            system("pause");
                            break;
                        case 2:
                            a.search_name();
                            system("pause");
                            break;
                        case 3:
                            a.search_patronymic();
                            system("pause");
                            break;
                        case 4:
                            do
                            {
                                system("cls");
                                printf("1) Поиск по домашнему телефону.\n");
                                printf("2) Поиск по рабочему телефону.\n");
                                printf("3) Поиск по мобильному телефону.\n");
                                printf("4) Выход.\n");
                                scanf("%d", &menu_item_int2);
                                if (menu_item_int2 < 1 || menu_item_int2>4)
                                {
                                    printf("\nВыбран не верный путь меню, повторите ввод\n");
                                    system("pause");
                                }
                                else
                                    switch (menu_item_int2)
                                    {
                                    case 1:
                                        a.search_homephone();
                                        system("pause");
                                        break;
                                    case 2:
                                        a.search_workphone();
                                        system("pause");
                                        break;
                                    case 3:
                                        a.search_mobilephone();
                                        system("pause");
                                        break;
                                    case 4:
                                        prodolgenie_int2 = false;
                                        break;
                                    }
                            } while (prodolgenie_int2);
                            system("pause");
                            break;
                        case 5:
                            prodolgenie_int1 = false;
                            break;
                        }
                } while (prodolgenie_int1);

                system("pause");
                break;
            case 4:
                a.out();
                system("pause");
                break;
            case 5:
                p_phone_book_a = new Phone_book[count];
                a.Save(FILE_NAME, p_phone_book_a, count);
                system("pause");
                break;
            case 6:  
                a.Load(FILE_NAME, &count);
                system("pause");
                break;
            case 7:
                prodolgenie_int = false;
                break;
            }
    } while (prodolgenie_int);
    SetConsoleCP(i1);
    SetConsoleOutputCP(i1);
    return 0;
}


void Phone_book::input()
{

    printf("Введите фамилию абонента:\n");
    printf("Нажмите <Enter> в начале строки для останова.\n");
    s_gets(shop[count].surname, MAXSURNAME);
    while (strcmp(s_gets(shop[count].surname, MAXSURNAME), STOP) != 0 && count < MAXPHONEBOOK)
    {
        printf("Введите имя абонента:\n");
        s_gets(shop[count].name, MAXNAME);
        printf("Введите отчество абонента:\n");
        s_gets(shop[count].patronymic, MAXPAT);
        printf("Введите домашний телефон:\n");
        s_gets(shop[count].homephone, MAXHPHONE);
        printf("Введите рабочий телефон:\n");
        s_gets(shop[count].workphone, MAXWPHONE);
        printf("Введите мобильный телефон:\n");
        s_gets(shop[count].mobilephone, MAXMPHONE);
        printf("Введите дополнительную информацию о абоненте:\n");
        s_gets(shop[count++].about, MAXABOUT);
        if (count < MAXPHONEBOOK)
            printf("Фамилия следующего абонента:\n");
    }
    if (count == 0)
        printf("Вообще нет никаких абонентов?. Если так, то очень плохо!!!\n");
}

void Phone_book::out()
{
    if (count > 0)
    {
        printf("Каталог введённых абонентов:\n");
        print_head();
        print_razdel();
        for (int index = 0; index < count; index++)
        {
            SetConsoleOutputCP(866);
            printf("\xBA");
            printf("%3d", index);
            SetConsoleOutputCP(866);
            printf(" \xBA");
            SetConsoleOutputCP(1251);
            printf("%-19s", shop[index].surname);
            SetConsoleOutputCP(866);
            printf(" \xBA");
            SetConsoleOutputCP(1251);
            printf("%-15s", shop[index].name);
            SetConsoleOutputCP(866);
            printf(" \xBA");
            SetConsoleOutputCP(1251);
            printf("%-19s", shop[index].patronymic);
            SetConsoleOutputCP(866);
            printf("\xBA");
            SetConsoleOutputCP(1251);
            printf("%16s", shop[index].homephone);
            SetConsoleOutputCP(866);
            printf("\xBA");
            SetConsoleOutputCP(1251);
            printf("%16s", shop[index].workphone);
            SetConsoleOutputCP(866);
            printf("\xBA");
            SetConsoleOutputCP(1251);
            printf("%18s", shop[index].mobilephone);
            SetConsoleOutputCP(866);
            printf("\xBA");
            SetConsoleOutputCP(1251);
            printf("%-15s", shop[index].about);
            SetConsoleOutputCP(866);
            printf("\xBA");

            if (index != (count - 1))
                print_razdel();
        }
        print_end();
    }
}

void Phone_book::del()
{
    int num=0;
    printf("Введите номер записи для удаления: \n");
    scanf("%d", &num);
    if (num<0 || num > count - 1)
    {
        printf("Номер записи за границами.\n");
    }
    else printf("Запись номер %d удалена.\n",num);
    for (int i = 0;i < num;i++)
    {
        strcpy(tmp[i].surname, shop[i].surname);
        strcpy(tmp[i].name, shop[i].name);
        strcpy(tmp[i].patronymic, shop[i].patronymic);
        strcpy(tmp[i].homephone, shop[i].homephone);
        strcpy(tmp[i].workphone, shop[i].workphone);
        strcpy(tmp[i].mobilephone, shop[i].mobilephone);
        strcpy(tmp[i].about, shop[i].about);
    }
    for (int i = num+1;i <=count;i++)
    {
        strcpy(tmp[i-1].surname, shop[i].surname);
        strcpy(tmp[i-1].name, shop[i].name);
        strcpy(tmp[i-1].patronymic, shop[i].patronymic);
        strcpy(tmp[i-1].homephone, shop[i].homephone);
        strcpy(tmp[i-1].workphone, shop[i].workphone);
        strcpy(tmp[i-1].mobilephone, shop[i].mobilephone);
        strcpy(tmp[i-1].about, shop[i].about);
    }
    count--;
    for (int i =0;i < count;i++)
    {
        strcpy(shop[i].surname, tmp[i].surname);
        strcpy(shop[i].name, tmp[i].name);
        strcpy(shop[i].patronymic, tmp[i].patronymic);
        strcpy(shop[i].homephone, tmp[i].homephone);
        strcpy(shop[i].workphone, tmp[i].workphone);
        strcpy(shop[i].mobilephone, tmp[i].mobilephone);
        strcpy(shop[i].about, tmp[i].about);
    }
} 
char* Phone_book::s_gets(char* st, int n)
{
    char* ret_val;
    char* find;
    ret_val = fgets(st, n, stdin);
    fseek(stdin, 0, SEEK_END);// очищаем поток ввода
    if (ret_val)
    {
        find = strchr(st, '\n'); // поиск новой строки
        if (find)              // если адрес не равен NULL,
            *find = '\0';          // поместить туда нулевой символ
        else
            while (getchar() != '\n')
                continue;             // отбросить остаток строки
    }
    return ret_val;
}

void Phone_book::print_razdel()
{
    SetConsoleOutputCP(866);
    printf("\n\xCC\xCD\xCD\xCD\xCD\xCE\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCE"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xB9\n");
}

void Phone_book::print_head()
{
    SetConsoleOutputCP(866);
    printf("\xC9\xCD\xCD\xCD\xCD\xCB\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCB"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBB\n");
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("№   ");
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("Фамилия             ");
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("Имя             ");
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("Отчество           ");
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("Домашний телефон");
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("Рабочий телефон ");
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("Мобильный телефон ");
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("Доп.информация ");
    SetConsoleOutputCP(866);
    printf("\xBA");
}

void Phone_book::print_end()
{
    SetConsoleOutputCP(866);
    printf("\n\xC8\xCD\xCD\xCD\xCD\xCA\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
        "\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCA"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
        "\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCA"
        "\xCD\xCD\xCD\xCD\xCD\xCD"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCA"
        "\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xCD\xBC\n");
    SetConsoleOutputCP(1251);
}



void Phone_book::out_s(int i)
{
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("%4d", i);
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("%-19s", shop[i].surname);
    SetConsoleOutputCP(866);
    printf(" \xBA");
    SetConsoleOutputCP(1251);
    printf("%-15s", shop[i].name);
    SetConsoleOutputCP(866);
    printf(" \xBA");
    SetConsoleOutputCP(1251);
    printf("%-19s", shop[i].patronymic);
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("%16s", shop[i].homephone);
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("%16s", shop[i].workphone);
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("%18s", shop[i].mobilephone);
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
    printf("%-15s", shop[i].about);
    SetConsoleOutputCP(866);
    printf("\xBA");
    SetConsoleOutputCP(1251);
}




void Phone_book::search_surname()
{
    char surname[MAXNAME];
    int kol = 0, kol2 = 0;
    printf("Введите фамилию для поиска:\n");
    while (getchar() != '\n');
    gets_s(surname, MAXSURNAME);
    for (int i = 0;i < count; i++)
        if (strcmp(shop[i].surname, surname) == 0)
            kol++;
    if (kol == 0) printf("По данноой фамилии абонент не найден!\n");
    else
    {
        print_head();
        for (int i = 0;i < count; i++)
        {
            if (strcmp(shop[i].surname, surname) == 0)
            {
                kol2++;
                print_razdel();
                a.out_s(i);
                if (kol2 == kol)
                    print_end();
            }
        }
    }
}

void Phone_book::search_name()
{
    char name[MAXNAME];
    int kol = 0, kol2 = 0;
    printf("Введите имя для поиска:\n");
    while (getchar() != '\n');
    gets_s(name, MAXNAME);
    for (int i = 0;i < count; i++)
        if (strcmp(shop[i].name, name) == 0)
            kol++;
    if (kol == 0) printf("По данному имени абонент не найден!\n");
    else
    {
        print_head();
        for (int i = 0;i < count; i++)
        {
            if (strcmp(shop[i].name, name) == 0)
            {
                kol2++;
                print_razdel();
                a.out_s(i);
                if (kol2 == kol)
                    print_end();
            }
        }
    }
}

void Phone_book::search_patronymic()
{
    char patronymic[MAXPAT];
    int kol = 0, kol2 = 0;
    printf("Введите отчество для поиска:\n");
    while (getchar() != '\n');
    gets_s(patronymic, MAXPAT);
    for (int i = 0;i < count; i++)
        if (strcmp(shop[i].patronymic, patronymic) == 0)
            kol++;
    if (kol == 0) printf("По данному отчеству абонент не найден!\n");
    else
    {
        print_head();
        for (int i = 0;i < count; i++)
        {
            if (strcmp(shop[i].patronymic, patronymic) == 0)
            {
                kol2++;
                print_razdel();
                a.out_s(i);
                if (kol2 == kol)
                    print_end();
            }
        }
    }
}

void Phone_book::search_homephone()
{
    int kol = 0, kol2 = 0;
    printf("Введите домашний телефон для поиска:\n");
    while (getchar() != '\n');
    gets_s(homephone, MAXHPHONE);
    for (int i = 0;i < count; i++)
        if (strcmp(shop[i].homephone, homephone) == 0)
            kol++;
    if (kol == 0) printf("По данному домашнему телефону абонент не найден!\n");
    else
    {
        print_head();
        for (int i = 0;i < count; i++)
        {
            if (strcmp(shop[i].homephone, homephone) == 0)
            {
                kol2++;
                print_razdel();
                a.out_s(i);
                if (kol2 == kol)
                    print_end();
            }
        }
    }
}

void Phone_book::search_workphone()
{
    int kol = 0, kol2 = 0;
    printf("Введите домашний телефон для поиска:\n");
    while (getchar() != '\n');
    gets_s(workphone, MAXWPHONE);
    for (int i = 0;i < count; i++)
        if (strcmp(shop[i].workphone, workphone) == 0)
            kol++;
    if (kol == 0) printf("По данному рабочему телефону абонент не найден!\n");
    else
    {
        print_head();
        for (int i = 0;i < count; i++)
        {
            if (strcmp(shop[i].workphone, workphone) == 0)
            {
                kol2++;
                print_razdel();
                a.out_s(i);
                if (kol2 == kol)
                    print_end();
            }
        }
    }
}



void Phone_book::search_mobilephone()
{
    int kol = 0, kol2 = 0;
    printf("Введите домашний телефон для поиска:\n");
    while (getchar() != '\n');
    gets_s(mobilephone, MAXMPHONE);
    for (int i = 0;i < count; i++)
        if (strcmp(shop[i].mobilephone, mobilephone) == 0)
            kol++;
    if (kol == 0) printf("По данному мобильному телефону абонент не найден!\n");
    else
    {
        print_head();
        for (int i = 0;i < count; i++)
        {
            if (strcmp(shop[i].mobilephone, mobilephone) == 0)
            {
                kol2++;
                print_razdel();
                a.out_s(i);
                if (kol2 == kol)
                    print_end();
            }
        }
    }
}


int Phone_book::Save(const char* fileName, Phone_book* p_phone_book_save, int size_)
{
    size_t size_dannye;
    FILE* file = fopen(fileName, "w+b");
    fseek(file, 0, SEEK_SET);
    fwrite(&size_, sizeof(int), 1, file);
    for (int i = 0; i < size_; i++)
    {
        size_dannye = strlen((p_phone_book_save + i)->surname) + 1;
        fwrite(&size_dannye, sizeof(int), 1, file);
        fwrite((p_phone_book_save + i)->surname, sizeof(char), size_dannye, file);
        size_dannye = strlen((p_phone_book_save + i)->name) + 1;
        fwrite(&size_dannye, sizeof(int), 1, file);
        fwrite((p_phone_book_save + i)->name, sizeof(char), size_dannye, file);
        size_dannye = strlen((p_phone_book_save + i)->patronymic) + 1;
        fwrite(&size_dannye, sizeof(int), 1, file);
        fwrite((p_phone_book_save + i)->patronymic, sizeof(char), size_dannye, file);
        size_dannye = strlen((p_phone_book_save + i)->homephone) + 1;
        fwrite(&size_dannye, sizeof(int), 1, file);
        fwrite((p_phone_book_save + i)->homephone, sizeof(char), size_dannye, file);
        size_dannye = strlen((p_phone_book_save + i)->workphone) + 1;
        fwrite(&size_dannye, sizeof(int), 1, file);
        fwrite((p_phone_book_save + i)->workphone, sizeof(char), size_dannye, file);
        size_dannye = strlen((p_phone_book_save + i)->mobilephone) + 1;
        fwrite(&size_dannye, sizeof(int), 1, file);
        fwrite((p_phone_book_save + i)->mobilephone, sizeof(char), size_dannye, file);
        size_dannye = strlen((p_phone_book_save + i)->about) + 1;
        fwrite(&size_dannye, sizeof(int), 1, file);
        fwrite((p_phone_book_save + i)->about, sizeof(char), size_dannye, file);
    }
    fclose(file);
    printf("Файл сохранен.\n");
    return 1;
}

Phone_book* Phone_book:: Load(const char* fileName, int* size)
{
    Phone_book* p_phone_book_load;
    FILE* file = fopen(fileName, "r+b");
    if (!file)
    {
        printf("ОШИБКА! Файл не существует.\n");
        return NULL;
    }
    int size_load;
    size_t size_dannye;
    fseek(file, 0, SEEK_SET);
    fread(&size_load, sizeof(int), 1, file);
    p_phone_book_load = new Phone_book[size_load];
    for (int i = 0;i < size_load;i++)
    {
        fread(&size_dannye, sizeof(int), 1, file);
        fread((p_phone_book_load + i)->surname, sizeof(char), size_dannye, file);
        fread(&size_dannye, sizeof(int), 1, file);
        fread((p_phone_book_load + i)->name, sizeof(char), size_dannye, file);
        fread(&size_dannye, sizeof(int), 1, file);
        fread((p_phone_book_load + i)->patronymic, sizeof(char), size_dannye, file);
        fread(&size_dannye, sizeof(int), 1, file);
        fread((p_phone_book_load + i)->homephone, sizeof(char), size_dannye, file);
        fread(&size_dannye, sizeof(int), 1, file);
        fread((p_phone_book_load + i)->workphone, sizeof(char), size_dannye, file);
        fread(&size_dannye, sizeof(int), 1, file);
        fread((p_phone_book_load + i)->mobilephone, sizeof(char), size_dannye, file);
        fread(&size_dannye, sizeof(int), 1, file);
        fread((p_phone_book_load + i)->about, sizeof(char), size_dannye, file);
    }
    fclose(file);
    printf("Файл загружен.\n");
    *size = size_load;
    return p_phone_book_load;
}
