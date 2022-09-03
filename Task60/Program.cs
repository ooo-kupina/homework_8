// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


Console.WriteLine($"\nДанная программа создаёт трёхмерный массив из неповторяющихся двузначных чисел от 10 до 100,");
Console.WriteLine("и которая будет построчно выводить массив, добавляя индексы каждого элемента.");
Console.WriteLine($"\nРазмеры массива задаёт пользователь.");
Console.WriteLine($"\nВведите размер массива X x Y x Z:\n");
int x = InputNumbers("Введите число X меньшее или равное 4: ");
int y = InputNumbers("Введите число Y меньшее или равное 4: ");
int z = InputNumbers("Введите число Z меньшее или равное 4: ");
Console.WriteLine($"");

int[,,] array3D = new int[x, y, z];
CreateArray(array3D);
WriteArray(array3D);

int InputNumbers(string input)
{
    Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    for (; output < 1 || output > 4;)
    {
        Console.Write($"\nУказанное число задано некорректно. Программа прервана. Введите целое положительное число от 1 до 4.\n");
        Console.WriteLine();
        Environment.Exit(0);
    }
    return output;
}

void WriteArray(int[,,] array3D)
{
    Console.WriteLine($"Массив размером {x} x {y} x {z} с индексами:");
    Console.WriteLine();
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"{array3D[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

void CreateArray(int[,,] array3D)
{
    int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10, 100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                    temp[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temp[i];
                }
                number = temp[i];
            }
        }
    }
    int count = 0;
    for (int x = 0; x < array3D.GetLength(0); x++)
    {
        for (int y = 0; y < array3D.GetLength(1); y++)
        {
            for (int z = 0; z < array3D.GetLength(2); z++)
            {
                array3D[x, y, z] = temp[count];
                count++;
            }
        }
    }
}


