using System;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Metadata;

internal class ex1
{
    class MyMatrix
    {
        public int m;
        public int n;
        public Random random;
        public int[,] matrix;
        MyMatrix(int m, int n, int minValue, int maxValue)
        {
            this.m = m;
            this.n = n;
            matrix = new int[m, n];
            random = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; i < n; i++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }
        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.m != b.m || a.n != b.n)
            {
                throw new ArgumentException("Ошибка");
            }
            MyMatrix c = new MyMatrix(a.m, a.n, 0, 0);
            for (int i = 0; i < a.m; i++)
            {
                for (int j = 0; i < a.n; i++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }
        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            if (a.m != b.m || a.n != b.n)
            {
                throw new ArgumentException("Ошибка");
            }
            MyMatrix c = new MyMatrix(a.m, a.n, 0, 0);
            for (int i = 0; i < a.m; i++)
            {
                for (int j = 0; i < a.n; i++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }
            return c;
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.m != b.n)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы для умножения.");
            }

            MyMatrix result = new MyMatrix(a.m, b.n, 0, 0);
            for (int i = 0; i < a.m; i++)
            {
                for (int j = 0; j < b.n; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.n; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        public static MyMatrix operator *(MyMatrix a, int scalar)
        {
            MyMatrix result = new MyMatrix(a.m, a.n, 0, 0);
            for (int i = 0; i < a.m; i++)
            {
                for (int j = 0; j < a.n; j++)
                {
                    result[i, j] = a[i, j] * scalar;
                }
            }
            return result;
        }
        public static MyMatrix operator /(MyMatrix a, int scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException("Деление на ноль недопустимо.");
            }

            MyMatrix result = new MyMatrix(a.m, a.n, 0, 0);
            for (int i = 0; i < a.m; i++)
            {
                for (int j = 0; j < a.n; j++)
                {
                    result[i, j] = a[i, j] / scalar;
                }
            }
            return result;
        }
        public void PrintMatrix(MyMatrix a)
        {
            for (int i = 0; i < a.m; i++)
            {
                for (int j = 0; i < a.n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

