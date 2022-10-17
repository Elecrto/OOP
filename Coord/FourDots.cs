using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class FourDots : Coord
    {
        private Coord A;
        private Coord B;
        private Coord C;
        private Coord D;

        public FourDots(Coord a, Coord b, Coord c, Coord d)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.D = d;
        }
        
        //1)Площадь фигуры
        public static double S(FourDots F)
        {
            if (IsInOnePlane(F))
            {
                double p = (Coord.Dist(F.A, F.B) + Coord.Dist(F.B, F.C) + Coord.Dist(F.C, F.D) + Coord.Dist(F.D, F.A)) / 2;
                return Math.Sqrt((p - Coord.Dist(F.A, F.B)) * (p - Coord.Dist(F.B, F.C)) * (p - Coord.Dist(F.C, F.D)) * (p - Coord.Dist(F.D, F.A)));
            }
            else
            {
                return -1;
            }
        }
        //2)Периметр фигуры
        public static double P(FourDots F)
        {
            if (IsInOnePlane(F))
            {
                return Coord.Dist(F.A, F.B) + Coord.Dist(F.B, F.C) + Coord.Dist(F.C, F.D) + Coord.Dist(F.D, F.A);
            }
            else
            {
                return -1;
            }
        }
        //3)Найти длины диагоналей
        public static void LenDeg(FourDots F)
        {
            Console.WriteLine("AC = {0}, BD = {1}", Coord.Dist(F.A, F.C), Coord.Dist(F.B, F.D));
        }
        //4)Проверить является выпуклым
        public static void IsConv(FourDots F)
        {
            Coord ab = new Coord(F.A.X - F.B.X, F.A.Y - F.B.Y);
            Coord bc = new Coord(F.B.X - F.C.X, F.B.Y - F.C.Y);
            Coord cd = new Coord(F.C.X - F.D.X, F.C.Y - F.D.Y);
            Coord da = new Coord(F.D.X - F.A.X, F.D.Y - F.A.Y);
            double productab = ab.X * bc.Y - ab.Y * bc.X;
            double productbc = bc.X * cd.Y - bc.Y * cd.X;
            double productcd = cd.X * da.Y - cd.Y * da.X;
            if (IsInOnePlane(F))
            {
                if (Math.Sign(productab) == Math.Sign(productcd) && Math.Sign(productcd) == Math.Sign(productbc))
                {
                    Console.WriteLine("Выпуклый");
                }
                else
                {
                    Console.WriteLine("Вогнутый");
                }
            }
            else
            {
                Console.WriteLine("Точки лежат в разных плоскостях");
            }
        }
        //7)Является ли фигура квадратом/ромбом/прямоуг/параллелограмм/трапеция
        public static void WichFig(FourDots F)
        {
            Coord ab = new Coord(F.A.X - F.B.X, F.A.Y - F.B.Y);
            Coord bc = new Coord(F.B.X - F.C.X, F.B.Y - F.C.Y);
            Coord cd = new Coord(F.C.X - F.D.X, F.C.Y - F.D.Y);
            Coord da = new Coord(F.D.X - F.A.X, F.D.Y - F.A.Y);
            double AB = Coord.Dist(F.A, F.B);
            double BC = Coord.Dist(F.B, F.C);
            double CD = Coord.Dist(F.C, F.D);
            double DA = Coord.Dist(F.D, F.A);
            double nglabbc = Math.Acos((ab.X * bc.X + ab.Y * bc.Y) / Math.Sqrt(ab.X * ab.X + ab.Y * ab.Y) / Math.Sqrt(bc.X * bc.X + bc.Y * bc.Y));
            double nglabcd = Math.Acos((ab.X * cd.X + ab.Y * cd.Y) / Math.Sqrt(ab.X * ab.X + ab.Y * ab.Y) / Math.Sqrt(cd.X * cd.X + cd.Y * cd.Y));
            double nglbcda = Math.Acos((bc.X * da.X + bc.Y * da.Y) / Math.Sqrt(bc.X * bc.X + bc.Y * bc.Y) / Math.Sqrt(da.X * da.X + da.Y * da.Y));
            if (AB == BC && BC == CD && CD == DA)
            {
                if(nglabbc == Math.PI / 2)
                {
                    Console.WriteLine("Квадрат");
                }
                else
                {
                    Console.WriteLine("Ромб");
                }
            }
            else if (AB == CD && BC == DA)
            {
                if (nglabbc == Math.PI / 2)
                {
                    Console.WriteLine("Прямоугольник");
                }
                else
                {
                    Console.WriteLine("Параллелограмм");
                }
            }
            else if (nglabcd == Math.PI || nglbcda == Math.PI)
            {
                Console.WriteLine("Трапеция");
            }
            else
            {
                IsConv(F);
            }
        }
        //8)Лежат 4 точки на одной плоскости
        public static bool IsInOnePlane(FourDots F)
        {
            double s = (F.D.X - F.A.X) * ((F.B.Y - F.A.Y) * (F.C.Z - F.A.Z) - (F.C.Y - F.A.Y) * (F.B.Z - F.A.Z)) - (F.D.Y - F.A.Y) * ((F.B.X - F.A.X) * (F.C.Z - F.A.Z) - (F.B.Z - F.A.Z) * (F.C.X - F.A.X)) + (F.D.Z - F.A.Z) * ((F.B.X - F.A.X) * (F.C.Y - F.A.Y) - (F.B.Y - F.A.Y) * (F.C.X - F.A.X));
            if (s == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}