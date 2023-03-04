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

int[,] NextArray(int[,] Array, int m, int n, int countArray)
{
    int sum = 0;
    int in_count = 0;
    int[,] ArrayNext = new int[m, n];
    while (in_count < countArray)
    {
        for (m = 0; m < Array.GetLength(0); m++)
        {
            for (n = 0; n < Array.GetLength(1); n++)
            {
                //Сначала реализуем проверку окружения не крайних клеток
                if (m > 0 && m < Array.GetLength(0) - 1 && n > 0 && n < Array.GetLength(1) - 1)
                {
                    if (Array[m - 1, n + 1] == 1) sum += 1;
                    if (Array[m, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n] == 1) sum += 1;
                    if (Array[m + 1, n - 1] == 1) sum += 1;
                    if (Array[m, n - 1] == 1) sum += 1;
                    if (Array[m - 1, n - 1] == 1) sum += 1;
                    if (Array[m - 1, n] == 1) sum += 1;
                }

                // Теперь проверяем крайний левый столбец n=0

                else if (n == 0 && m > 0 && m < Array.GetLength(0) - 1)
                {
                    if (Array[m - 1, n + 1] == 1) sum += 1;
                    if (Array[m, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n] == 1) sum += 1;
                    if (Array[m + 1, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[m, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[m - 1, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[m - 1, n] == 1) sum += 1;
                }

                // Теперь проверяем крайний правый столбец n=Array.GetLength(1)-1

                else if (n == Array.GetLength(1) - 1 && m > 0 && m < Array.GetLength(0) - 1)
                {
                    if (Array[m - 1, 0] == 1) sum += 1;
                    if (Array[m, 0] == 1) sum += 1;
                    if (Array[m + 1, 0] == 1) sum += 1;
                    if (Array[m + 1, n] == 1) sum += 1;
                    if (Array[m + 1, n - 1] == 1) sum += 1;
                    if (Array[m, n - 1] == 1) sum += 1;
                    if (Array[m - 1, n - 1] == 1) sum += 1;
                    if (Array[m - 1, n] == 1) sum += 1;
                }


                //Здесь проверяем верхнюю строку m=0
                else if (m == 0 && n > 0 && n < Array.GetLength(1) - 1)
                {
                    if (Array[Array.GetLength(1) - 1, n + 1] == 1) sum += 1;
                    if (Array[m, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n] == 1) sum += 1;
                    if (Array[m + 1, n - 1] == 1) sum += 1;
                    if (Array[m, n - 1] == 1) sum += 1;
                    if (Array[Array.GetLength(1) - 1, n - 1] == 1) sum += 1;
                    if (Array[Array.GetLength(1) - 1, n] == 1) sum += 1;
                }

                // Здесь проверяем нижнюю строку m=Array.GetLength(0)-1
                else if (m == Array.GetLength(0) - 1 && n > 0 && n < Array.GetLength(1) - 1)
                {
                    if (Array[m - 1, n + 1] == 1) sum += 1;
                    if (Array[m, n + 1] == 1) sum += 1;
                    if (Array[0, n + 1] == 1) sum += 1;
                    if (Array[0, n] == 1) sum += 1;
                    if (Array[0, n - 1] == 1) sum += 1;
                    if (Array[m, n - 1] == 1) sum += 1;
                    if (Array[m - 1, n - 1] == 1) sum += 1;
                    if (Array[m - 1, n] == 1) sum += 1;
                }


                // Здесь проверяем верхний левый угол m=0,n=0
                else if (m == 0 && n == 0)
                {
                    if (Array[Array.GetLength(0) - 1, n + 1] == 1) sum += 1;
                    if (Array[m, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n + 1] == 1) sum += 1;
                    if (Array[m + 1, n] == 1) sum += 1;
                    if (Array[m + 1, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[m, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, n] == 1) sum += 1;
                }

                // Здесь проверяем верхний правый угол m = 0, n = Array.GetLength(1)-1
                else if (m == 0 && n == Array.GetLength(1) - 1)
                {
                    if (Array[Array.GetLength(0) - 1, 0] == 1) sum += 1;
                    if (Array[m, 0] == 1) sum += 1;
                    if (Array[m + 1, 0] == 1) sum += 1;
                    if (Array[m + 1, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[m + 1, Array.GetLength(1) - 2] == 1) sum += 1;
                    if (Array[m, Array.GetLength(1) - 2] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, Array.GetLength(1) - 2] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, Array.GetLength(1) - 1] == 1) sum += 1;
                }

                //Здесь проверяем нижний правый угол m=Array.GetLength(0) - 1, n = Array.GetLength(1)-1
                else if (m == Array.GetLength(0) - 1 && n == Array.GetLength(1) - 1)
                {
                    if (Array[Array.GetLength(0) - 2, 0] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, 0] == 1) sum += 1;
                    if (Array[0, 0] == 1) sum += 1;
                    if (Array[0, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[0, Array.GetLength(1) - 2] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, Array.GetLength(1) - 2] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 2, Array.GetLength(1) - 2] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 2, Array.GetLength(1) - 1] == 1) sum += 1;
                }

                //Здесь проверяем нижний левый угол m = Array.GetLength(0) - 1, n = 0
                else if (m == Array.GetLength(0) - 1 && n == 0)
                {
                    if (Array[Array.GetLength(0) - 2, n + 1] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, n + 1] == 1) sum += 1;
                    if (Array[0, n + 1] == 1) sum += 1;
                    if (Array[0, n] == 1) sum += 1;
                    if (Array[0, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 1, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 2, Array.GetLength(1) - 1] == 1) sum += 1;
                    if (Array[Array.GetLength(0) - 2, n] == 1) sum += 1;
                }
                Write($"sum = {sum}");

                if (Array[m, n] == 0) if (sum == 3) ArrayNext[m, n] = 1;
                    else if (sum < 2 || sum > 3) ArrayNext[m, n] = 0;
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
int[,] Array_n = NextArray(Array, row, column, count);

PrintArray(Array_n);