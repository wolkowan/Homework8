
using System;

namespace Homiwork8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            System.Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
            int[,] array1 = GetArray(5,5);
            PrintArray(RowsRange(array1));
            System.Console.WriteLine();

            System.Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
            int[,] array2 = GetArray(3,3);
            PrintArray(array2);
            int [] sum = SumInRange(array2);
            MininRange(sum);
            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
            int[,] array3 = GetArray(3,3);
            PrintArray(array3);
            System.Console.WriteLine();
            int[,] array4 = GetArray(3,3);
            PrintArray(array4);
            System.Console.WriteLine();
            PrintArray(MultiplyArreys(array3, array4));
            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.WriteLine("Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
            int[,,] array5=GetArray3D(3, 3, 3, 10);
            PrintArray3D(array5);
            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");
            int[,] array6 = GetSpiralArray (4);
            PrintArray(array6);
 

int[,,] GetArray3D(int x = 3, int y = 3, int z = 3, int numMin = 1) 
{ 
    int[,,] newArray3D = new int[x, y, z]; 
    int[] arrValues = new int[x * y * z]; 
    var rand = new Random(); 
 
    for (int i = 0; i < arrValues.Length; ++i) 
    { 
        bool isUnique; 
        do 
        { 
            arrValues[i] = rand.Next(numMin, numMin+ x*y*z); 
            isUnique = true; 
            for (int j = 0; j < i; ++j) 
                if (arrValues[i] == arrValues[j]) 
                { 
                    isUnique = false; 
                    break; 
                } 
        } while (!isUnique); 
    } 
 
 
    for (int i = 0; i < x; i++) 
    { 
        for (int j = 0; j < y; j++) 
        { 
            for (int k = 0; k < z; k++) 
            { 
                newArray3D[i, j, k] = arrValues[i * newArray3D.GetLength(0)*newArray3D.GetLength(0) + j *newArray3D.GetLength(1) + k]; 
            } 
        } 
    } 
 
    return newArray3D; 
}

void PrintArray3D(int[,,] array) 
{ 
    for (int i = 0; i < array.GetLength(0); i++) 
    { 
        for (int j = 0; j < array.GetLength(1); j++) 
        { 
            for (int k = 0; k < array.GetLength(2); k++) 
            { 
                Console.Write($"{array[i, j, k]}({i},{j},{k}) "); 
            } 
            Console.WriteLine(); 
        } 
        Console.WriteLine(); 
    } 
}
int[,] GetArray(int row, int columns){    
   int[,] array = new int[row, columns];
   
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i,j]= new Random().Next(1,10);
            //System.Console.Write($"{array[i,j]}   ");
        }
        //System.Console.WriteLine();
    }
    return array;
}

void PrintArray(int[,]array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i,j]}   ");
        }
       System.Console.WriteLine(); 
    }
}

int[]SumInRange(int[,]array)
{
    int[] result = new int [array.GetLength(0)];
    System.Console.WriteLine($"сумма элементов в строках: ");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int summ = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            summ+=array[i,j];
        }
        result[i]=summ;
        System.Console.Write($" {result[i]}   ");
    }
    
    return result;
}

void MininRange(int[]range)
{
    int min = range[0];
    int minIndex = 0;
    for (int i = 0; i < range.Length; i++)
    {
        if (range[i]<min) 
        {
        min= range[i];
        minIndex=i;
        }
    }
System.Console.WriteLine();
System.Console.WriteLine($"Первая строка с наименьшей суммой элементов {minIndex+1}");
}

int[,]MultiplyArreys(int[,]arr1, int[,]arr2)
{

    int[,]result = new int [arr1.GetLength(0),arr1.GetLength(1)];
    
    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr1.GetLength(1); j++)
        {
            for (int k = 0; k < arr1.GetLength(1); k++)
            {
                result[i,j]+=arr1[i,k]*arr2[k,j];
                
            }
            
        }
    }
    return result;
}

int[,]RowsRange(int [,]arr)
{
    

    for (int i = 0; i < arr.GetLength(1); i++)
    {
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            for (int k = j+1; k < arr.GetLength(0); k++)
            {
                if(arr[i,j]<arr[i,k])
                { 
                int temp =arr[i,j];
                arr[i,j]=arr[i,k];
                arr[i,k]=temp;
                }  
            }
                      
        }
    }
    return arr;
}

int[,] GetSpiralArray (int size) 
{
    int[,] result = new int[size, size];
    int i = 0;
    int j = 0;
    int rowE = size - 1;
    int columnE = size - 1;
    int rowS = 0;
    int columnS = 0;
    bool left = true;
    bool top = true;
    int count = 10;

    while (count - 10 < (size * size))
    {
        count++;
        result[i, j] = count;
        
        if (left && top)
        {
            if (j == columnE)
            {
                rowS++;
                top = true;
                left = false;
                i++;
                continue;
            }

            else
            {
                j++;
                continue;
            }
        }
       
        if (!left && top)
        {
            if (i == rowE)
            {
                columnE--;
                top = false;
                left = false;
                j--;
                continue;
            }

            else
            {
                i++;
                continue;
            }
        }
       
        if (!left && !top)
        {
            if (j == columnS)
            {
                rowE--;
                top = false;
                left = true;
                i--;
                continue;
            }

            else
            {
                j--;
                continue;
            }
        }
       
        if (left && !top)
        {
            if (i == rowS)
            {
                columnS++;
                top = true;
                left = true;
                j++;
                continue;
            }

            else
            {
                i--;
                continue;
            }
        }
    }
    return result;
}


}
}
}


