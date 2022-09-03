// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


Console.WriteLine($"\nДанная программа выведет двумерный массив, заполненный случайными целыми числами от 1 до N (меньшее 100),");
Console.WriteLine("и которая будет находить строку с наименьшей суммой элементов.");
Console.WriteLine($"\nКоличество строк, столбцов и диапазон задаёт пользователь.");

Console.WriteLine($"\nВведите размер массива m x n и диапазон (N) случайных значений:");
int m = InputNumbers("Введите не очень большое целое число m (строки): ");
int n = InputNumbers("Введите не очень большое целое число n (столбцы): ");
int range = InputNumbers("Введите диапазон N: от 1 до ");

Console.WriteLine($"\nИсходный массив:\n");
int[,] array = new int[m, n];
CreateArray(array);
WriteArray(array);

int minSumLine = 0;
int sumLine = SumLineElements(array, 0);
for (int i = 1; i < array.GetLength(0); i++)
{
    int tempSumLine = SumLineElements(array, i);
    if (sumLine > tempSumLine)
    {
        sumLine = tempSumLine;
        minSumLine = i;
    }
}

Console.WriteLine($"\nСтрока {minSumLine + 1} - это строкa с наименьшей суммой ({sumLine}) элементов.");


int SumLineElements(int[,] array, int i)
{
    int sumLine = array[i, 0];
    for (int j = 1; j < array.GetLength(1); j++)
    {
        sumLine += array[i, j];
    }
    return sumLine;
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
