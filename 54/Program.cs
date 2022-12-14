﻿int m = GetUserNumber("Введите число строк массива: ");         
int n = GetUserNumber("Введите число столбцов массива: ");

int[,] matrix = GetMatrix(m, n, 0, 100);           
PrintArray(matrix);
SelectionSort(matrix);

PrintArray(matrix);


int GetUserNumber(string messageToUser)
{
    while (true)
    {
        Console.Write(messageToUser);
        if (int.TryParse(Console.ReadLine(), out int userNumber) && userNumber > 0)
            return userNumber;
        Console.WriteLine("Ошибка! Введите целое число больше нуля");
    }
}


int[,] GetMatrix(int m, int n, int minValue, int maxValue)
{
    int[,] resultMatrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            resultMatrix[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return resultMatrix;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}  ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void SelectionSort(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {

            int maxCol = j;
            for (int r = j + 1; r < inArray.GetLength(1); r++)
            {
                if (inArray[i, r] > inArray[i, maxCol])
                    maxCol = r;
            }
            int temp = inArray[i, j];
            inArray[i, j] = inArray[i, maxCol];
            inArray[i, maxCol] = temp;
        }
    }
}