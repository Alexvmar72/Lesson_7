/* Задача 47. Задайте двумерный массив размером m×n, 
заполненный случайными вещественными числами.

m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9        */

using System;
using static System.Console;

Clear();

double[,] GetArray(int m, int n, double minValue, double maxValue)
{
    double[,] result = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().NextDouble() * (maxValue - minValue) + minValue;
        }
    }
    return result;
}

void PrintArray(double[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{Math.Round(inArray[i, j], 1)} ");
        }
        WriteLine();
    }
}

int Prompt(string message)
{
    Console.Write(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

double PromptDouble(string message)
{
    Console.Write(message);
    double result = double.Parse(Console.ReadLine()!);
    return result;
}

int m = Prompt("Введите размер массива по строкам: ");
int n = Prompt("Введите размер массива по столбцам: ");
double minValue = PromptDouble("Введите минимальное значение массива: ");
double maxValue = PromptDouble("Введите максимальное значение массива: ");

PrintArray(GetArray(m, n, minValue, maxValue));