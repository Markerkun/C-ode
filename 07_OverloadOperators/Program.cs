using System.Drawing;

namespace _07_OverloadOperators
{
    public class Rectangle
    {
        private int a;
        public int A
        {
            get { return a; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Value cannot be negative.");
                else a = value;
            }
        }
        private int b;
        public int B
        {
            get { return b; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Value cannot be negative.");
                else b = value;
            }
        }
        public Rectangle(int a, int b)
        {
            A = a;
            B = b;
        }
        public Rectangle(int a) : this(a, a) { }
        public Rectangle() : this(0, 0) { }

        override public string ToString()
        {
            return $"Rectangle: A = {A}, B = {B}";
        }
        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(r1.A + r2.A, r1.B + r2.B);
        }
        public static Rectangle operator -(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(r1.A - r2.A, r1.B - r2.B);
        }
        public static Rectangle operator *(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(r1.A * r2.A, r1.B * r2.B);
        }
        public static Rectangle operator /(Rectangle r1, Rectangle r2)
        {
            if (r2.A == 0 || r2.B == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return new Rectangle(r1.A / r2.A, r1.B / r2.B);
        }
        public static Rectangle operator ++(Rectangle r)
        {
            return new Rectangle(r.A++, r.B++);
        }
        public static Rectangle operator --(Rectangle r)
        {
            return new Rectangle(r.A--, r.B--);
        }
        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            return r1.A == r2.A && r1.B == r2.B;
        }
        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return !(r1 == r2);
        }
        public static bool operator >(Rectangle r1, Rectangle r2)
        {
            return (r1.A > r2.A && r2.B < r1.B);
        }
        public static bool operator <(Rectangle r1, Rectangle r2)
        {
            return (r1.A < r2.A && r2.B > r1.B);
        }
        public static bool operator >=(Rectangle r1, Rectangle r2)
        {
            return (r1.A >= r2.A && r2.B <= r1.B);
        }
        public static bool operator <=(Rectangle r1, Rectangle r2)
        {
            return (r1.A <= r2.A && r2.B >= r1.B);
        }
        public override bool Equals(object obj)
        {
            if (obj is Rectangle r)
            {
                return this == r;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }
        public static bool operator true(Rectangle r)
        {
            return (r.A > 0 && r.B > 0);
        }
        public static bool operator false(Rectangle r)
        {
            return (r.A <= 0 || r.B <= 0);
        }
        public static explicit operator Square(Rectangle r)
        {
            return new Square((r.A + r.B) / 2);
        }
        public static explicit operator int(Rectangle r)
        {
            return (r.A + r.B) / 2;
        }
    }

    public class Square
    {
        private int side;
        public int Side
        {
            get { return side; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Value cannot be negative.");
                else side = value;
            }
        }
        public Square(int side)
        {
            Side = side;
        }
        public Square() : this(0) { }
        override public string ToString()
        {
            return $"Square: Side = {Side}";
        }
        public static Square operator +(Square s1, Square s2)
        {
            return new Square(s1.Side + s2.Side);
        }
        public static Square operator -(Square s1, Square s2)
        {
            return new Square(s1.Side - s2.Side);
        }
        public static Square operator *(Square s1, Square s2)
        {
            return new Square(s1.Side * s2.Side);
        }
        public static Square operator /(Square s1, Square s2)
        {
            if (s2.Side == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return new Square(s1.Side / s2.Side);
        }
        public static Square operator ++(Square s)
        {
            return new Square(s.Side++);
        }
        public static Square operator --(Square s)
        {
            return new Square(s.Side--);
        }
        public static bool operator ==(Square s1, Square s2)
        {
            return s1.Side == s2.Side;
        }
        public static bool operator !=(Square s1, Square s2)
        {
            return !(s1 == s2);
        }
        public static bool operator >(Square s1, Square s2)
        {
            return s1.Side > s2.Side;
        }
        public static bool operator <(Square s1, Square s2)
        {
            return s1.Side < s2.Side;
        }
        public static bool operator >=(Square s1, Square s2)
        {
            return s1.Side >= s2.Side;
        }
        public static bool operator <=(Square s1, Square s2)
        {
            return s1.Side <= s2.Side;
        }
        public override bool Equals(object obj)
        {
            if (obj is Square s)
            {
                return this == s;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Side);
        }
        public static bool operator true(Square s)
        {
            return s.Side > 0;
        }
        public static bool operator false(Square s)
        {
            return s.Side <= 0;
        }
        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle(s.Side);
        }
        public static implicit operator int(Square s)
        {
            return s.Side;
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(5, 10);
            Rectangle r2 = new Rectangle(3, 4);
            Console.WriteLine("Rectangle Operations:");
            Console.WriteLine($"R1: {r1}");
            Console.WriteLine($"R2: {r2}");
            Console.WriteLine($"R1 + R2: {r1 + r2}");
            Console.WriteLine($"R1 - R2: {r1 - r2}");
            Console.WriteLine($"R1 * R2: {r1 * r2}");
            Console.WriteLine($"R1 / R2: {r1 / r2}");
            Console.WriteLine($"R1++: {++r1}");
            Console.WriteLine($"R1--: {--r1}");
            Console.WriteLine($"R1 == R2: {r1 == r2}");
            Console.WriteLine($"R1 > R2: {r1 > r2}");
            Console.WriteLine($"R1 >= R2: {r1 >= r2}");
            Console.WriteLine($"R1 is true: {r1}");
            Console.WriteLine($"R1 is false: {r2}");
            Console.WriteLine($"R1 is equal to R2: {r1.Equals(r2)}");
            Console.WriteLine($"R1 hash code: {r1.GetHashCode}");

            Console.WriteLine();

            Square s1 = new Square(5);
            Square s2 = new Square(3);
            Console.WriteLine("\nSquare Operations:");
            Console.WriteLine($"S1: {s1}");
            Console.WriteLine($"S2: {s2}");
            Console.WriteLine($"S1 + S2: {s1 + s2}");
            Console.WriteLine($"S1 - S2: {s1 - s2}");
            Console.WriteLine($"S1 * S2: {s1 * s2}");
            Console.WriteLine($"S1 / S2: {s1 / s2}");
            Console.WriteLine($"S1++: {++s1}");
            Console.WriteLine($"S1--: {--s1}");
            Console.WriteLine($"S1 == S2: {s1 == s2}");
            Console.WriteLine($"S1 > S2: {s1 > s2}");
            Console.WriteLine($"S1 >= S2: {s1 >= s2}");
            Console.WriteLine($"S1 is true: {s1}");
            Console.WriteLine($"S1 is false: {s2}");
            Console.WriteLine($"S1 is equal to S2: {s1.Equals(s2)}");
            Console.WriteLine($"S1 hash code: {s1.GetHashCode}");

            Console.WriteLine();

            Console.WriteLine("\nImplicit Conversion from Square to Rectangle:");
            Rectangle rFromS = s1;
            Console.WriteLine($"Converted Rectangle from Square: {rFromS}");
            int rectangleValue = (int)rFromS;
            Console.WriteLine("\nExplicit Conversion from Rectangle to Square:");
            Square sFromR = (Square)r1;
            Console.WriteLine($"Converted Square from Rectangle: {sFromR}");
            Console.WriteLine("\nImplicit Conversion from Square to int:");
            int sideValue = s1;

            

        }
    }
}