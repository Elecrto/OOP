using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class RevMatr : SquareMatr
    {
        public bool IsInv{ 
            get 
            {
                if(this.M == this.N && CalculateDeterminant() != 0)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public RevMatr(SquareMatr m) : base(m)
        {

        }

        
        public Matr Inv()
        {
            var determinant = CalculateDeterminant();
            
            Matr result = new Matr(M,M,true);
            if (!this.IsInv)
            {
                throw new InvalidOperationException("Matrix not inversible!");
            }
            for (int i = 0; i < M; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    result.Matrix[i, j] = ((i + j) % 2 == 1 ? -1 : 1) * CalculateMinor(i, j) / determinant;
                }
            }
            result = Transponation(result);
            
            return result;
        }
        private double CalculateMinor(int i, int j)
        {
            return this.DeleteColumnRow(i, j).CalculateDeterminant();
        }

    }
}
