namespace ConsoleApp3
{
    internal class Coord
    {
        double x;
        double y;
        double z;

        public Coord(double X, double Y, double Z)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
        }

        public void show()
        {
            Console.WriteLine("{0},{1},{2}", this.x, this.y, this.z);
        }

        public static double Dist(Coord A, Coord B)
        {
            double rez;
            rez = Math.Sqrt(Math.Pow(A.x - B.x, 2) + Math.Pow(A.y - B.y, 2) + Math.Pow(A.z - B.z, 2));
            return rez;
        }

        public static void Equasion2D(Coord A, Coord B)
        {
            Console.WriteLine("(x-{0})/{1}=(y-{2})/{3}=(z-{4})/{5}", A.x, B.x - A.x, A.y, B.y - A.y, A.z, B.z - A.z);
        }
        public static void Equasion3D(Coord A, Coord B, Coord C)
        {
            Console.WriteLine("(x-{0})*{1}-(y-{2})*{3}+(z-{4})*{5} = 0", A.x, (B.y - A.y) * (C.z - A.z) - (C.y - A.y) * (B.z - A.z), A.y, (B.x - A.x) * (C.z - A.z) - (B.z - A.z) * (C.x - A.x), A.z, (B.x - A.x) * (C.y - A.y) - (B.y - A.y) * (C.x - A.x));
        }
        public static double DistBeg(Coord A)
        {
            double rez;
            rez = Math.Sqrt(Math.Pow(A.x, 2) + Math.Pow(A.y, 2) + Math.Pow(A.z, 2));
            return rez;
        }

        public static Coord operator +(Coord A, Coord B)
        {
            return new(A.x + B.x, A.y + B.y, A.z + B.z);
        }

        public static double operator *(Coord A, Coord B)
        {
            return A.x * B.x + A.y * B.y + A.z * B.z;
        }
        public static void VectMult(Coord A, Coord B)
        {
            Console.WriteLine("{0}*i - ({1})*j + ({2})*k", A.y * B.z - A.z * B.y, A.x * B.z - A.z * B.x, A.x * B.y - A.y * B.x);
        }
    }


}
