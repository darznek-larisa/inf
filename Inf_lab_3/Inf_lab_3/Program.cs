using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество неизвестных " +
                "переменных (= количеству уравнений)");
            int n = int.Parse(Console.ReadLine());

            float[,] A = new float[n, n];
            float[] B = new float[n];
            float[] X = new float[n];

            float[] a = new float[n];
            float[] b = new float[n];
            float[] e = new float[n];

            ReadSLAU(ref A, ref B);
            GaussMethod(ref A, ref B, ref X);

            Console.WriteLine("Матрица А после приведеня к ступенчатому виду:");
            ShowMatrix(A);
            Console.WriteLine("Матрица В после прямого хода:");
            ShowMatrix(B);
            Console.WriteLine("Корни системы:");
            ShowMatrix(X);

            ReadSLAU(ref A, ref B);
            SweepMethod(A, B, ref X, a, b, e);

            Console.WriteLine("\nКорни системы:");
            ShowMatrix(X);

            Console.ReadLine();
        }

        public static void ReadSLAU(ref float[,] a, ref float[] b)
        {
            int n = b.Length;
            Console.WriteLine("Введите поочередно коэффициенты " +
                "перед Х (левая часть), начиная с первой строки");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = float.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введите поочередно коэффициенты " +
                "перед Y (правая часть), начиная с первой строки");
            for (int i = 0; i < n; i++)
            {
                b[i] = float.Parse(Console.ReadLine());
            }
        }

        public static void ShowMatrix(float[] b)
        {
            int n = b.Length;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{Math.Round(b[i], 3)}\t");
            }
        }

        public static void ShowMatrix(float[,] a)
        {
            int n = (int)Math.Sqrt(a.Length);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{Math.Round(a[i, j], 3)}\t");
                }
                Console.WriteLine();
            }
        }

        public static void GaussMethod(ref float[,] a, ref float[] b, ref float[] x)
        {
            Gauss(ref a, ref b, ref x);
            ReverseMove(ref a, ref b, ref x);
        }

        private static void Gauss(ref float[,] a, ref float[] b, ref float[] x)
        {
            float d;
            int n = b.Length;
            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    d = a[i, k] / a[k, k];
                    for (int j = k; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * d;
                    }
                    b[i] = b[i] - b[k] * d;
                }
            }
        }

        private static void ReverseMove(ref float[,] a, ref float[] b, ref float[] x)
        {
            float s;
            int n = b.Length;
            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int i = k; i <= n - 1; i++)
                {
                    s += a[k, i] * x[i];
                }
                if (a[k, k] == 0)
                {
                    Console.WriteLine("Элемент A", k, ',', k, "= 0");
                    Environment.Exit(0);
                }
                x[k] = (b[k] - s) / a[k, k];
            }
        }

        public static void SweepMethod(float[,] A, float[] B, ref float[] X, float[] a, float[] b, float[] e)
        {
            int n = B.Length;

            e[0] = A[0, 0];
            a[0] = -A[0, 1] / e[0];
            b[0] = B[0] / e[0];
            for (int i = 1; i < n - 1; i++)
            {
                if (A[i, i] == 0)
                {
                    Console.WriteLine("Элемент A", i, ',', i, "= 0");
                    Environment.Exit(0);
                }
                e[i] = A[i, i] + A[i, i - 1] * a[i - 1];
                a[i] = -A[i, i + 1] / e[i];
                b[i] = (B[i] - A[i, i - 1] * b[i - 1]) / e[i];
            }
            e[n - 1] = A[n - 1, n - 1] + A[n - 1, n - 2] * a[n - 2];
            b[n - 1] = (B[n - 1] - A[n - 1, n - 2] * b[n - 2]) / e[n - 1];

            X[n - 1] = b[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                X[i] = a[i] * X[i + 1] + b[i];
            }
        }
    }
}