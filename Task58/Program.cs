// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


Console.WriteLine($"\nДанная программа задаст две матрицы, заполненной случайными целыми числами от 1 до N (меньшее 50),");
Console.WriteLine("и которая будет находить произведение двух матриц.");
Console.WriteLine($"\nРазмеры матриц и диапазон задаёт пользователь.\n");
int m = InputNumbers("Введите небольшое целое число строк 1-й матрицы: ");
int n = InputNumbers("Введите небольшое целое число столбцов 1-й матрицы (и строк 2-й): ");
int p = InputNumbers("Введите небольшое целое число столбцов 2-й матрицы: ");
int range = InputNumbers("Введите диапазон случайных чисел: от 1 до ");

int[,] firstMartrix = new int[m, n];
CreateArray(firstMartrix);
Console.WriteLine($"\nПервая матрица:\n");
WriteArray(firstMartrix);

int[,] secomdMartrix = new int[n, p];
CreateArray(secomdMartrix);
Console.WriteLine($"\nВторая матрица:\n");
WriteArray(secomdMartrix);

int[,] resultMatrix = new int[m,p];

MultiplyMatrix(firstMartrix, secomdMartrix, resultMatrix);
Console.WriteLine($"\nПроизведение первой и второй матриц:\n");
WriteArray(resultMatrix);

void MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix, int[,] resultMatrix)
{
  for (int i = 0; i < resultMatrix.GetLength(0); i++)
  {
    for (int j = 0; j < resultMatrix.GetLength(1); j++)
    {
      int sum = 0;
      for (int k = 0; k < firstMartrix.GetLength(1); k++)
      {
        sum += firstMartrix[i,k] * secomdMartrix[k,j];
      }
      resultMatrix[i,j] = sum;
    }
  }
}

int InputNumbers(string input)
{
  Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    for (; output <= 0 || output > 50;)
    {
        Console.Write($"\nУказанное число задано некорректно. Программа прервана. Введите целое положительное число от 1 до 50.\n");
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

void WriteArray (int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      Console.Write(j < array.GetLength(1) - 1 ? $"{array[i, j],6}" : $"{array[i, j],6} ");
    }
    Console.WriteLine();
  }
}
 Console.WriteLine();

