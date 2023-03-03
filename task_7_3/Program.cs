/* Задача 52. Задайте двумерный массив из целых чисел. 
Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.               */

using System;
using static System.Console;

Clear();

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
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

double[] AverageColumnArray(int[,] inArray)
{
    double sum = 0;
    double[] result = new double[inArray.GetLength(0)];
    for (int i = 0; i < inArray.GetLength(1); i++)
    {
        for (int j = 0; j < inArray.GetLength(0); j++)
        {
            sum += inArray[j, i];
        }
        result[i] = sum / inArray.GetLength(1);
        sum = 0;
    }
    return result;
}

int Prompt(string message)
{
    Console.Write(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

int m = Prompt("Введите размер массива по строкам: ");
int n = Prompt("Введите размер массива по столбцам: ");
int minValue = Prompt("Введите минимальное значение массива: ");
int maxValue = Prompt("Введите максимальное значение массива: ");


int[,] table = GetArray(m, n, minValue, maxValue);
PrintArray(table);

WriteLine($"Среднее арифметическое каждого столбца: {string.Join(", ", AverageColumnArray(table))}");