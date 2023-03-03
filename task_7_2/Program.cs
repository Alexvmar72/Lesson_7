/*      Задача 50. Напишите программу, которая на вход принимает позиции 
элемента в двумерном массиве, и возвращает значение этого элемента 
или же указание, что такого элемента нет.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет     */

using System;
using static System.Console;

Clear();

int Prompt(string message)
{
    Console.Write(message);
    int result = int.Parse(Console.ReadLine()!);
    return result;
}

string SearchNumArray(int m, int n, int[,] Array)
{
    string result;
    if (m > Array.GetLength(0) || n > Array.GetLength(1))
    {
        result = "такого числа в массиве нет";
    }
    else
    {
        result = $"{Array[m, n]}";
    }
    return result;
}

int[,] Array = new int[,]
{
{1, 4, 7, 2},
{5, 9, 2, 3},
{8, 4, 2, 4},
{7, 5, 23, 53453},
};

int m = Prompt("Введите номер строки: ");
int n = Prompt("Введите номер столбца: ");
WriteLine($"{m}{n} -> {SearchNumArray(m, n, Array)}");