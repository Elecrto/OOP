using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class SquareMatr : Matr
    {


        public SquareMatr(Matr m) : base(m)
        {


        }

        public SquareMatr DeleteColumnRow(int k, int d)
        {
            Matr l = new Matr(this.N - 1, this.N - 1, true);
            SquareMatr res = new SquareMatr(l);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i < k && j < d)
                    {
                        res.Matrix[i, j] = Matrix[i, j];
                    }
                    else if (i < k && j > d)
                    {
                        res.Matrix[i, j - 1] = Matrix[i, j];
                    }
                    else if (i > k && j < d)
                    {
                        res.Matrix[i - 1, j] = Matrix[i, j];
                    }
                    else if (i > k && j > d)
                    {
                        res.Matrix[i - 1, j - 1] = Matrix[i, j];
                    }
                }
            }
            return res;
        }
        public double CalculateDeterminant()
        {
            double result = 0;
            if (!this.IsSquare)
            {
                throw new InvalidOperationException("determinant can be calculated only for square matrix");
            }
            if (this.N == 1)
            {
                return Matrix[0, 0];
            }
            if (this.M == 2)
            {
                return this.Matrix[0, 0] * this.Matrix[1, 1] - this.Matrix[1, 0] * this.Matrix[0, 1];
            }
            for (int j = 0; j < N; j++)
            {
                result += Math.Pow((-1), j) * Matrix[0, j] * DeleteColumnRow(0, j).CalculateDeterminant();
            }

            return result;
        }
    }
}