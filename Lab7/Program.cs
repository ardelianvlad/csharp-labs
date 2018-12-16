using System;
using System.Threading;

namespace Lab7
{
    public class Program
    {
        public static int FindElement(int[] line1, int[] line2)
        {
            int sum = 0;
            for (int i = 0; i < line1.Length; i++)
            {
                sum += line1[i] * line2[i];
            }
            return sum;
        }

        public static int[] GetLine(int[,] arr, int line, int length)
        {
            int[] a = new int[length];
            for (int i = 0; i < length; i++)
            {
                a[i] = arr[line, i];
            }
            return a;
        }

        public static int[] GetColl(int[,] arr, int line, int length)
        {
            int[] a = new int[length];
            for (int i = 0; i < length; i++)
            {
                a[i] = arr[i, line];
            }
            return a;
        }

        public static int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2, int n, int m)
        {
            int[,] newMatrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newMatrix[i, j] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newMatrix[i, j] = 0;

                    int[] line = GetLine(matrix1, i, m);
                    int[] col = GetColl(matrix2, j, m);

                    Thread methodThread = new Thread(() =>
                    {
                        newMatrix[i, j] = FindElement(line, col);
                    });

                    methodThread.Start();
                    methodThread.Join();
                }
            }

            return newMatrix;
        }


        public static int[,] RandomMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                }
            }
            return matrix;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter n and m: ");
            string line = Console.ReadLine();
            string[] splitLine = line.Split(' ');
            int n = int.Parse(splitLine[0]);
            int m = int.Parse(splitLine[1]);

            int[,] matrix1 = new int[n, m];
            matrix1 = RandomMatrix(n, m);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix1[i, j] + " ");
                }
            }

            Console.WriteLine();

            int[,] matrix2 = new int[m, n];
            matrix2 = RandomMatrix(m, n);
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix2[i, j] + " ");
                }
            }

            Console.WriteLine();
            int[,] matrix3 = new int[n, m];

            matrix3 = MultiplyMatrix(matrix1, matrix2, n, m);
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix3[i, j] + " ");
                }
            }

            Console.ReadKey();
        }
    }
}
