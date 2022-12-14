Console.Clear();

int I = GetUserNumber("Введите число строк матрицы А: ");    
int m = GetUserNumber("Введите число столбцов матрицы А: ");

int mI = GetUserNumber("Введите число строк матрицы В: ");
int n = GetUserNumber("Введите число столбцов матрицы В: ");

string resultExist = string.Empty;
if (m != mI)
{                                                           
    resultExist = "Умножение невозможно, матрицы не согласованы: число столбцов матрицы А не равно числу строк матрицы В";  

}
else
{
    resultExist = "Конец";
    int[,] matrixA = GetMatrix(I, m, 0, 10);               
    int[,] matrixB = GetMatrix(mI, n, 0, 10);               
    int[,] matrixC = ABMultiplication(matrixA, matrixB);    
    PrintArray(matrixA);
    PrintArray(matrixB);
    PrintArray(matrixC);

}
Console.WriteLine(resultExist);

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

int[,] ABMultiplication(int[,] matrA, int[,] matrB)
{
    int[,] matrixC = new int[matrA.GetLength(0), matrB.GetLength(1)];

    for (int i = 0; i < matrixC.GetLength(0); i++)
    {
        for (int j = 0; j < matrixC.GetLength(1); j++)
        {
            for (int r = 0; r< matrA.GetLength(1); r++)
            {
                matrixC[i,j] += matrA[i,r]*matrB[r,j];
            }
        }
    }
    return matrixC;
}