/* 
Игра «Жизнь» была придумана английским математиком Джоном Конвейем в 1970 году.
Впервые описание этой игры опубликовано в октябрьском выпуске (1970) журнала Scientic American,
в рубрике «Математические игры» Мартина Гарднера.

Место действия этой игры – «вселенная» – это размеченная на клетки поверхность.
Каждая клетка на этой поверхности может находиться в двух состояниях: быть живой или быть мертвой.
Клетка имеет восемь соседей. Распределение живых клеток в начале игры называется первым поколением.
Каждое следующее поколение рассчитывается на основе предыдущего по таким правилам:

1)пустая(мертвая) клетка с ровно тремя живыми клетками-соседями оживает;
2)если у живой клетки есть две или три живые соседки, то эта клетка продолжает жить;
в противном случае (если соседок меньше двух или больше трех)
клетка умирает(от «одиночества» или от «перенаселенности»).
В этой задаче рассматривается игра «Жизнь» на торе.
Представим себе прямоугольник размером n строк на m столбцов.
Для того, чтобы превратить его в тор мысленно «склеим» его верхнюю сторону с нижней, а левую с правой.

Таким образом, у каждой клетки, даже если она раньше находилась на границе прямоугольника,
теперь есть ровно восемь соседей.

Ваша задача состоит в том, чтобы найти конфигурацию клеток, которая будет через k поколений от заданного.
n m k(4 ≤ n, m ≤ 100; 0 ≤ k ≤ 100).                       */

using System;
using static System.Console;

Clear();

int[,] GetArray(int m, int n)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(2);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j]} ");
        }
        WriteLine();
    }
}

int[,] NextArray(int[,] Array, int countArray)
{
    int sum = 0;
    int in_count = 0;
    int m = Array.GetLength(0);
    int n = Array.GetLength(1);
    int[,] ArrayNext = new int[m, n];
    while (in_count < countArray)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //Сначала реализуем проверку окружения не крайних клеток
                if (i > 0 && i < m - 1 && j > 0 && j < n - 1)
                {
                    if (Array[i + 1, j] == 1) sum += 1;
                    if (Array[i + 1, j + 1] == 1) sum += 1;
                    if (Array[i + 1, j - 1] == 1) sum += 1;
                    if (Array[i - 1, j - 1] == 1) sum += 1;
                    if (Array[i - 1, j + 1] == 1) sum += 1;
                    if (Array[i - 1, j] == 1) sum += 1;
                    if (Array[i, j + 1] == 1) sum += 1;
                    if (Array[i, j - 1] == 1) sum += 1;
                }

                // Теперь проверяем крайний левый столбец j = 0

                else if (j == 0 && i > 0 && i < m - 1)
                {
                    if (Array[i + 1, j] == 1) sum += 1;
                    if (Array[i + 1, j + 1] == 1) sum += 1;
                    if (Array[i + 1, n - 1] == 1) sum += 1;
                    if (Array[i - 1, n - 1] == 1) sum += 1;
                    if (Array[i - 1, j + 1] == 1) sum += 1;
                    if (Array[i - 1, j] == 1) sum += 1;
                    if (Array[i, j + 1] == 1) sum += 1;
                    if (Array[i, n - 1] == 1) sum += 1;
                }

                // Теперь проверяем крайний правый столбец j = n - 1

                else if (j == n - 1 && i > 0 && i < m - 1)
                {
                    if (Array[i + 1, 0] == 1) sum += 1;
                    if (Array[i + 1, j] == 1) sum += 1;
                    if (Array[i + 1, j - 1] == 1) sum += 1;
                    if (Array[i - 1, j - 1] == 1) sum += 1;
                    if (Array[i - 1, j] == 1) sum += 1;
                    if (Array[i - 1, 0] == 1) sum += 1;
                    if (Array[i, 0] == 1) sum += 1;
                    if (Array[i, j - 1] == 1) sum += 1;
                }


                //Здесь проверяем верхнюю строку i = 0
                else if (i == 0 && j > 0 && j < n - 1)
                {
                    if (Array[i + 1, j] == 1) sum += 1;
                    if (Array[i + 1, j + 1] == 1) sum += 1;
                    if (Array[i + 1, j - 1] == 1) sum += 1;
                    if (Array[m - 1, j - 1] == 1) sum += 1;
                    if (Array[m - 1, j + 1] == 1) sum += 1;
                    if (Array[m - 1, j] == 1) sum += 1;
                    if (Array[i, j + 1] == 1) sum += 1;
                    if (Array[i, j - 1] == 1) sum += 1;
                }

                // Здесь проверяем нижнюю строку i = m-1
                else if (i == m - 1 && j > 0 && j < n - 1)
                {
                    if (Array[i - 1, j + 1] == 1) sum += 1;
                    if (Array[i - 1, j - 1] == 1) sum += 1;
                    if (Array[i - 1, j] == 1) sum += 1;
                    if (Array[i, j + 1] == 1) sum += 1;
                    if (Array[i, j - 1] == 1) sum += 1;
                    if (Array[0, j - 1] == 1) sum += 1;
                    if (Array[0, j + 1] == 1) sum += 1;
                    if (Array[0, j] == 1) sum += 1;
                }


                // Здесь проверяем верхний левый угол i = 0, j = 0
                else if (i == 0 && j == 0)
                {
                    if (Array[i + 1, j] == 1) sum += 1;
                    if (Array[i + 1, j + 1] == 1) sum += 1;
                    if (Array[i + 1, n - 1] == 1) sum += 1;
                    if (Array[m - 1, j + 1] == 1) sum += 1;
                    if (Array[m - 1, n - 1] == 1) sum += 1;
                    if (Array[m - 1, j] == 1) sum += 1;
                    if (Array[i, j + 1] == 1) sum += 1;
                    if (Array[i, n - 1] == 1) sum += 1;
                }

                // Здесь проверяем верхний правый угол i = 0, j = n - 1
                else if (i == 0 && j == n - 1)
                {
                    if (Array[i + 1, 0] == 1) sum += 1;
                    if (Array[i + 1, n - 1] == 1) sum += 1;
                    if (Array[i + 1, n - 2] == 1) sum += 1;
                    if (Array[m - 1, n - 2] == 1) sum += 1;
                    if (Array[m - 1, n - 1] == 1) sum += 1;
                    if (Array[m - 1, 0] == 1) sum += 1;
                    if (Array[i, n - 2] == 1) sum += 1;
                    if (Array[i, 0] == 1) sum += 1;
                }

                //Здесь проверяем нижний правый угол i = m - 1, j = n-1
                else if (i == m - 1 && j == n - 1)
                {
                    if (Array[m - 2, 0] == 1) sum += 1;
                    if (Array[m - 2, n - 2] == 1) sum += 1;
                    if (Array[m - 2, n - 1] == 1) sum += 1;
                    if (Array[m - 1, n - 2] == 1) sum += 1;
                    if (Array[m - 1, 0] == 1) sum += 1;
                    if (Array[0, n - 1] == 1) sum += 1;
                    if (Array[0, n - 2] == 1) sum += 1;
                    if (Array[0, 0] == 1) sum += 1;
                }

                //Здесь проверяем нижний левый угол i = m - 1, j = 0
                else if (i == m - 1 && j == 0)
                {
                    if (Array[m - 2, j] == 1) sum += 1;
                    if (Array[m - 2, j + 1] == 1) sum += 1;
                    if (Array[m - 2, n - 1] == 1) sum += 1;
                    if (Array[m - 1, j + 1] == 1) sum += 1;
                    if (Array[m - 1, n - 1] == 1) sum += 1;
                    if (Array[0, j + 1] == 1) sum += 1;
                    if (Array[0, n - 1] == 1) sum += 1;
                    if (Array[0, j] == 1) sum += 1;
                }

                if (Array[i, j] == 0) if (sum == 3) ArrayNext[i, j] = 1;
                    else if (sum < 2 || sum > 3) ArrayNext[i, j] = 0;
                sum = 0;
            }
        }
        in_count++;
        Array = ArrayNext;
    }

    return ArrayNext;
}

int Prompt(string message)
{
    Console.Write(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}


int row = Prompt("Введите размер массива по строкам: ");
int column = Prompt("Введите размер массива по столбцам: ");
int count = Prompt("Введите количество реинкарнаций: ");

int[,] Array = GetArray(row, column);

PrintArray(Array);
int[,] Array_n = NextArray(Array, count);

WriteLine();
PrintArray(Array_n);