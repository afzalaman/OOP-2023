using LowerTriangle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace LowerTriangle
{
    public class LTMatrix
    {
        public class InvalidIndexException : Exception { };
        public class OutOfTriangleException : Exception { };
        public class DimensionMismatchException : Exception { };
        public class InvalidVectorException : Exception { };

        public List<int> _vec;
        private int _size;


        public int ind(int i, int j)
        {
            //indexing from zero 
            return j + i * (i - 1) / 2 - 1;
        }
        private double calcSizeFromLength(int length)
        {
            return (-1 + Math.Sqrt(1 + 8 * length)) / 2; /// root of (x^2+x-2*length=0) as x*(x-1)/2=length
        }
        private bool inLowerTrng(int i, int j)
        {
            return (1 <= j && j <= i && i <= _size);
        }

        //constructors
        public LTMatrix() /// basic 3x3 matrix
        {
            _size = 3;
            _vec = new List<int>(){1,2,3,4,5,6};
        }
        public LTMatrix(in List<int> vec) /// matrix with given vector
        {
            SetVec(vec);
        }
        public LTMatrix(int size) /// zero matrix with given size
        {
            _size = size;
            _vec = new List<int>();
            int length = (size * (size + 1)) / 2; 
            for (int i=0;i<length;i++)
            {
                _vec.Add(0);
            }
        }
        public LTMatrix(in String fileName) /// matrix read from a file
        {
            try
            {
                _vec = new List<int>();
                TextFileReader f = new TextFileReader(fileName);
                while (f.ReadInt(out int e))
                {
                    _vec.Add(e);
                }
                double n = calcSizeFromLength(_vec.Count);
                if (n == Math.Floor(n))
                {
                    _size = Convert.ToInt32(n);
                }
                else
                {
                    _size = 0;
                    _vec.Clear();
                    throw new InvalidVectorException();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Something wrong with the file : "+fileName);
                _size = 0;
                _vec.Clear();
            }
        }


        public LTMatrix(in LTMatrix m) /// copying  matrix
        {
            _size = m._size;
            _vec = m._vec;
        }

        public int GetSize()
        {
            return _size;
        }

        public int GetElement(int i, int j)  /// Get matrix element by indices
        {
            if (inLowerTrng(i, j)) /// indices pointing to the lower triangle
            {
                return _vec[ind(i, j)];
            }
            else if (1 <= j && j <= _size && 1 <= i && i <= _size) /// other valid indices
            {
                return 0;
            }
            else /// invalid indices
            {
                throw new InvalidIndexException();
            }
        }

        /// Setter

        public void SetVec(in List<int> vec) /// Modifying the whole matrix
        {
            double n = calcSizeFromLength(vec.Count); /// calculate the matrix size based on the vector length
            if (n == Math.Floor(n)) ///if the supposed matrix size is integer
            {
                _size = Convert.ToInt32(n);
                _vec = vec;
            }
            else /// invalid vector length
            {
                throw new InvalidVectorException();
            }
        }

        void SetElement(int i, int j, int e)
        {
            if (1 <= j && j <= i && i <=_size) /// indices of the lower part
            {
                _vec[ind(i, j)] = e; /// vector indexing starts at 0
            }
            else
            {
                throw new OutOfTriangleException();
            }
        }

        /// Static methods

        public static LTMatrix Add(in LTMatrix a, in LTMatrix b)
        {
            if (a.GetSize() == b.GetSize())
            {
                LTMatrix sum = new LTMatrix(a);
                for (int i = 0; i < a._vec.Count; i++)
                {
                    sum._vec[i] += b._vec[i];
                }
                return sum;
            }
            else
            {
                throw new DimensionMismatchException();
            }
        }

        public static LTMatrix Multiply(in LTMatrix a, in LTMatrix b)
        {
            if (a.GetSize() == b.GetSize())
            {
                LTMatrix mul = new LTMatrix(a.GetSize());
                for (int i = 1; i <= a._size; i++)
                {
                    for (int j = 1; j < a._size; j++)
                    {
                        if (a.inLowerTrng(i, j)) /// only the lower triangular part need calculation
                        {
                            for (int k = j; k <= i; k++)
                            {
                                mul.SetElement(i, j, mul.GetElement(i, j) + a.GetElement(i, k) * b.GetElement(k, j));
                            }
                        }
                    }
                }
                return mul;
            }
            else
            {
                throw new DimensionMismatchException();
            }
        }

        public override String ToString()
        {
            String str = "";
            str += _size.ToString() + "x" + _size.ToString()+"\n";
            for (int i = 1; i <= _size; i++)
            {
                for (int j = 1; j <= _size; j++)
                {
                    str += GetElement(i, j).ToString() + " ";
                }
                str += "\n";
            }
            return str;
        }
    }
}