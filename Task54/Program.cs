// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.WriteLine($"\nДанная программа выведет двумерный массив, заполненный случайными целыми числами от 1 до N (меньшее 100),");
Console.WriteLine("и которая упорядочит по убыванию элементы каждой строки этого двумерного массива.");
Console.WriteLine($"\nКоличество строк, столбцов и диапазон задаёт пользователь.");

Console.WriteLine($"\nВведите размер массива m x n и диапазон (N) случайных значений:");
int m = InputNumbers("Введите не очень большое целое число m (строки): ");
int n = InputNumbers("Введите не очень большое целое число n (столбцы): ");
int range = InputNumbers("Введите диапазон N: от 1 до ");

Console.WriteLine($"\nИсходный массив:\n");
int[,] array = new int[m, n];
CreateArray(array);
WriteArray(array);

Console.WriteLine($"\nОтсортированный массив:\n");
OrderArrayLines(array);
WriteArray(array);

void OrderArrayLines(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int temp = array[i, k + 1];
                    array[i, k + 1] = array[i, k];
                    array[i, k] = temp;
                }
            }
        }
    }
}

int InputNumbers(string input)
{
    Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    for (; output <= 0 || output >= 101;)
    {
        Console.Write($"\nУказанное число задано некорректно. Программа прервана. Введите целое положительное число от 1 до 100.\n");
        Console.WriteLine();
        Environment.Exit(0);
    }
    return output;
}

void CreateArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(range);
        }
    }
}

void WriteArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(j < array.GetLength(1) - 1 ? $"{array[i, j],4}," : $"{array[i, j],4} ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
}

Console.WriteLine();
