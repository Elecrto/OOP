using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matr
    {
        private int m;
        private int n;
        private double[,] matr;
        public int N { get { return n; } set { N = value; } }
        public int M { get { return m; } set { M = value; } }
        public double[,] Matrix { get { return matr; } set { matr = value; } }
        public bool IsSquare { get => this.M == this.N; }
        public Matr(int n = 0, int m = 0, bool Zero = false)
        {
            this.m = m;
            this.n = n;
            Random r = new Random();
            Random d = new Random();
            double[,] matr = new double[n, m];
            if (Zero)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matr[i, j] = 0;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matr[i, j] = r.Next(10);
                    }
                }
            }
            this.matr = matr;
        }
        public Matr(Matr m)
        {
            this.n = m.n;
            this.m = m.m;
            this.matr = m.matr;
        }
        public Matr()
        {
            Console.WriteLine("Введите размерность матрицы (Все значения вводить с новой строки): ");
            
            n = Convert.ToInt32(Console.ReadLine());
            
            m = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите матрицу: ");
            double[,] matr = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            this.Matrix = matr;
        }
        public void Show()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write("{0} ", this.matr[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static Matr Transponation(Matr A)
        {
            int n = A.n;
            int m = A.m;

            Matr C = new Matr(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    C.matr[i, j] = A.matr[j, i];
                }
            }
            return C;
        }
        public static double TakeElem(Matr A, int n, int m)
        {
            return A.matr[n, m];
        }

        public static Matr operator +(Matr A, Matr B)
        {
            int n = A.n;
            int m = A.m;
            Matr C = new Matr(n, m);
            if (n == B.n && m == B.m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        C.matr[i, j] = A.matr[i, j] + B.matr[i, j];
                    }
                }
                return C;
            }
            else
            {
                Matr Z = new Matr(n, m, true);
                return null;
            }
        }
        public static Matr operator -(Matr A, Matr B)
        {
            int n = A.n;
            int m = A.m;
            Matr C = new Matr(n, m);
            if (n == B.n && m == B.m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        C.matr[i, j] = A.matr[i, j] - B.matr[i, j];
                    }
                }
                return C;
            }
            else
            {
                Matr Z = new Matr(n, m, true);
                return Z;
            }
        }
        public static Matr operator *(Matr A, Matr B)
        {
            int n = A.n;
            int m = A.m;
            Matr C = new Matr(n, m, true);
            if (n == B.m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            C.matr[i, j] += A.matr[i, k] * B.matr[k, j];
                        }
                    }
                }
                return C;
            }
            else
            {
                Matr Z = new Matr(n, m, true);
                return Z;
            }
        }
        public static Matr operator *(Matr A, double B)
        {
            int n = A.n;
            int m = A.m;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    A.matr[i, j] = A.matr[i, j] * B;
                }
            }
            return A;
        }
        public static Matr operator /(Matr A, double B)
        {
            int n = A.n;
            int m = A.m;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    A.matr[i, j] = A.matr[i, j] / B;
                }
            }
            return A;
        }
    }
}
