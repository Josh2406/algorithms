using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementations
{
    public class JBigInteger
    {
        public List<int> Data { get; set; }
        public int NumberBase { get; set; } = 10;
        public bool IsNegative { get; internal set; } = false;

        public JBigInteger(): this(string.Empty)
        {
        }

        public JBigInteger(string stringValue, int numberBase = 10)
        {
            Data = new List<int>();
            NumberBase = numberBase;



            if(stringValue.All(c => IsCharANum(c)))
            {
                int n = stringValue.Length;

                for (int i = n - 1; i >= 0; --i)
                {
                    char c = stringValue[i];
                    Data.Add(int.Parse(c.ToString()));
                }
            }
            else
            {
                throw new Exception($"Constructor param \"stringValue\" cannot contain non-numeric character!");
            }
        }

        public static JBigInteger operator +(JBigInteger A, JBigInteger B)
        {
            var result = new JBigInteger(string.Empty, A.NumberBase);

            if (A.NumberBase != B.NumberBase)
            {
                throw new ArgumentException("A and B must have same number base");
            }

            int numberBase = A.NumberBase;
            if (A.Data.Any(a=>a >= numberBase) || B.Data.Any(b=>b >= numberBase))
            {
                throw new ArgumentException("Neither A nor B can have a number greater than or equals to the number base");
            }

            int n = A.Data.Count > B.Data.Count ? A.Data.Count : B.Data.Count;
            int carry = 0;

            for(int i = 0; i < n; i++)
            {
                int aa = i > (A.Data.Count - 1) ? 0 : A.Data[i];
                int bb = i > (B.Data.Count - 1) ? 0 : B.Data[i];

                int c = aa + bb + carry;

                if(c >= numberBase)
                {
                    result.Data.Add(c - numberBase);
                    carry = 1;
                }
                else
                {
                    result.Data.Add(c);
                    carry = 0;
                }
            }

            if(carry == 1)
            {
                result.Data.Add(1);
            }

            return result;
        }

        public static JBigInteger operator -(JBigInteger A, JBigInteger B)
        {
            var result = new JBigInteger(string.Empty, A.NumberBase);

            if (A.NumberBase != B.NumberBase)
            {
                throw new ArgumentException("A and B must have same number base");
            }

            int numberBase = A.NumberBase;
            if (A.Data.Any(a => a >= numberBase) || B.Data.Any(b => b >= numberBase))
            {
                throw new ArgumentException("Neither A nor B can have a number greater than or equals to the number base");
            }
            
            int n = A.Data.Count > B.Data.Count ? A.Data.Count : B.Data.Count;

            if(A == B)
            {
                result.Data.Add(0);
            }
            else if(A < B)
            {
                result.Data = (B - A).Data;
                result.IsNegative = true;
            }
            else
            {
                int borrow = 0;
                for (int i = 0; i < n; i++)
                {
                    int aa = i > (A.Data.Count - 1) ? 0 : A.Data[i];
                    int bb = i > (B.Data.Count - 1) ? 0 : B.Data[i];

                    int c = (aa - borrow) - bb;
                    if (c < 0)
                    {
                        borrow = 1;
                        result.Data.Add(c + A.NumberBase);
                    }
                    else
                    {
                        borrow = 0;
                        result.Data.Add(c);
                    }
                }
            }

            return result;
        }

        public static bool operator >(JBigInteger A, JBigInteger B)
        {
           return !(A <= B);
        }

        public static bool operator <(JBigInteger A, JBigInteger B)
        {
            return !(A >= B);
        }

        public static bool operator ==(JBigInteger A, JBigInteger B)
        {
            return Equals(A, B);
        }

        public static bool operator !=(JBigInteger A, JBigInteger B)
        {
            return !(A == B);
        }

        public static bool operator >=(JBigInteger A, JBigInteger B)
        {
            return GreaterThan(A, B) || Equals(A, B);
        }

        public static bool operator <=(JBigInteger A, JBigInteger B)
        {
            return !GreaterThan(A, B) || Equals(A, B);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private static bool Equals(JBigInteger Left, JBigInteger Right)
        {
            bool result = true;
            if (Left.NumberBase != Right.NumberBase)
            {
                throw new ArgumentException("A and B must have same number base");
            }

            int numberBase = Left.NumberBase;
            if (Left.Data.Any(a => a >= numberBase) || Right.Data.Any(b => b >= numberBase))
            {
                throw new ArgumentException("Neither A nor B can have a number greater than or equals to the number base");
            }

            int n = Left.Data.Count > Right.Data.Count ? Left.Data.Count : Right.Data.Count;

            int borrow = 0;
            for (int i = 0; i < n; i++)
            {
                int aa = i > (Left.Data.Count - 1) ? 0 : Left.Data[i];
                int bb = i > (Right.Data.Count - 1) ? 0 : Right.Data[i];

                int c = (aa - borrow) - bb;
                if(c == 0)
                {
                    borrow = 0;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return borrow == 0 && result;
        }

        private static bool IsCharANum(char c)
        {
            bool result = int.TryParse(c.ToString(), out int _);
            return result;
        }

        private static bool GreaterThan(JBigInteger Left, JBigInteger Right)
        {
            if (Left.NumberBase != Right.NumberBase)
            {
                throw new ArgumentException("A and B must have same number base");
            }

            int numberBase = Left.NumberBase;
            if (Left.Data.Any(a => a >= numberBase) || Right.Data.Any(b => b >= numberBase))
            {
                throw new ArgumentException("Neither A nor B can have a number greater than or equals to the number base");
            }

            int n = Left.Data.Count > Right.Data.Count ? Left.Data.Count : Right.Data.Count;

            int borrow = 0;
            for (int i = 0; i < n; i++)
            {
                int aa = i > (Left.Data.Count - 1) ? 0 : Left.Data[i];
                int bb = i > (Right.Data.Count - 1) ? 0 : Right.Data[i];

                int c = (aa - borrow) - bb;
                if (c < 0)
                {
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
            }
            
            return borrow == 0;
        }

        public override string ToString()
        {
            int n = Data.Count;
            StringBuilder sb = new StringBuilder();
            for(int i = n - 1; i >= 0; --i)
            {
                sb.Append(Data[i]);
            }
            string result = sb.ToString().TrimStart('0');
            return string.IsNullOrEmpty(result) ? "0" : result;
        }
    }
}
