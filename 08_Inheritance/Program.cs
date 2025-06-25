namespace _08_Inheritance
{

    abstract class Figure
    {
        public abstract void GetArea();
        public abstract void GetPerimeter();
    }
    class Square : Figure
    {
        public int Side { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Square: {Side * Side}");
        }
        public override void GetPerimeter()
        {
            Console.WriteLine($"Perimeter of Square: {4 * Side}");
        }
    }
    class Triengle : Figure
    {
        public int Base { get; set; }
        public int Height { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Triangle: {0.5 * Base * Height}");
        }
        public override void GetPerimeter()
        {
            // Assuming an equilateral triangle for simplicity
            Console.WriteLine($"Perimeter of Triangle: {3 * Base}");
        }
    }
    class Romb : Figure
    {
        public int Diagonal1 { get; set; }
        public int Diagonal2 { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Romb: {0.5 * Diagonal1 * Diagonal2}");
        }
        public override void GetPerimeter()
        {
            Console.WriteLine($"Perimeter of Romb: {2 * (Diagonal1 + Diagonal2)}");
        }
    }
    class Rectangle : Figure
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Rectangle: {Length * Width}");
        }
        public override void GetPerimeter()
        {
            Console.WriteLine($"Perimeter of Rectangle: {2 * (Length + Width)}");
        }
    }
    class Parallelogram : Figure
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Parallelogram: {Length * Height}");
        }
        public override void GetPerimeter()
        {
            Console.WriteLine($"Perimeter of Parallelogram: {2 * (Length + Height)}");
        }
    }
    class Trapeze : Figure
    {
        public int Base1 { get; set; }
        public int Base2 { get; set; }
        public int Height { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Trapeze: {0.5 * (Base1 + Base2) * Height}");
        }
        public override void GetPerimeter()
        {
            Console.WriteLine($"Perimeter of Trapeze: {Base1 + Base2 + 2 * Height}");
        }
    }
    class Circle : Figure
    {
        public int Radius { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Circle: {Math.PI * Radius * Radius}");
        }
        public override void GetPerimeter()
        {
            Console.WriteLine($"Perimeter of Circle: {2 * Math.PI * Radius}");
        }
    }
    class Ellipse : Figure
    {
        public int SemiMajorAxis { get; set; }
        public int SemiMinorAxis { get; set; }
        public override void GetArea()
        {
            Console.WriteLine($"Area of Ellipse: {Math.PI * SemiMajorAxis * SemiMinorAxis}");
        }
        public override void GetPerimeter()
        {
            double h = Math.Pow((SemiMajorAxis - SemiMinorAxis), 2) / Math.Pow((SemiMajorAxis + SemiMinorAxis), 2);
            double perimeter = Math.PI * (SemiMajorAxis + SemiMinorAxis) * (1 + (3 * h) / (10 + Math.Sqrt(4 - 3 * h)));
            Console.WriteLine($"Perimeter of Ellipse: {perimeter}");
        }
    }
    class MultyFigure
    {
        Figure[] Figures;
        public MultyFigure(params Figure[] figures)
        {
            Figures = figures;
        }
        public void ShowFigures()
        {
            foreach (var figure in Figures)
            {
                figure.GetArea();
                figure.GetPerimeter();
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            Square square = new Square { Side = 5 };
            square.GetArea();
            square.GetPerimeter();
            Console.WriteLine("===================================");
            Triengle triangle = new Triengle { Base = 4, Height = 3 };
            triangle.GetArea();
            triangle.GetPerimeter();
            Console.WriteLine("===================================");
            Romb romb = new Romb { Diagonal1 = 6, Diagonal2 = 8 };
            romb.GetArea();
            romb.GetPerimeter();
            Console.WriteLine("===================================");
            Rectangle rectangle = new Rectangle { Length = 10, Width = 5 };
            rectangle.GetArea();
            rectangle.GetPerimeter();
            Console.WriteLine("===================================");
            Parallelogram parallelogram = new Parallelogram { Length = 7, Height = 4 };
            parallelogram.GetArea();
            parallelogram.GetPerimeter();
            Console.WriteLine("===================================");
            Trapeze trapeze = new Trapeze { Base1 = 5, Base2 = 3, Height = 4 };
            trapeze.GetArea();
            trapeze.GetPerimeter();
            Console.WriteLine("===================================");
            Circle circle = new Circle { Radius = 3 };
            circle.GetArea();
            circle.GetPerimeter();
            Console.WriteLine("===================================");
            Ellipse ellipse = new Ellipse { SemiMajorAxis = 5, SemiMinorAxis = 3 };
            ellipse.GetArea();
            ellipse.GetPerimeter();
            Console.WriteLine("===================================");
            MultyFigure multyFigure = new MultyFigure(square, triangle, romb, rectangle, parallelogram, trapeze, circle, ellipse);
            multyFigure.ShowFigures();


        }
    }
}
