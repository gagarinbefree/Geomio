namespace Geomio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = Container.Calculator;
        }
    }

    public interface IShape
    {
        abstract double CalcArea();
        abstract double CalcPerimeter();
    }

    public abstract class Shape: IShape
    {
        public abstract double CalcArea();
        public abstract double CalcPerimeter();
    }


    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalcArea() => Math.PI * Radius * Radius;

        public override double CalcPerimeter() => 2 * Math.PI * Radius;
    }

    // Класс для квадрата
    public class Square : Shape
    {
        public double Side1 { get; }
        public double Side2 { get; }

        public Square(double side1, double side2)
        {
            Side1 = side1;
            Side2 = side2;
        }

        public override double CalcArea() => Side1 * Side2;

        public override double CalcPerimeter() => 2 * (Side1 + Side2);
    }

    // Класс для треугольника
    public class Triangle : Shape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        public override double CalcArea()
        {
            // Формула Герона
            double p = CalcPerimeter() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public override double CalcPerimeter() => SideA + SideB + SideC;
    }

    // Класс для многоугольника
    public class Polygon : Shape
    {
        public List<(double X, double Y)> Vertices { get; }

        public Polygon(List<(double X, double Y)> vertices)
        {
            Vertices = vertices ?? throw new ArgumentNullException(nameof(vertices));
            if (vertices.Count < 3)
                throw new ArgumentException("Polygon must have at least 3 vertices");
        }

        public override double CalcArea()
        {
            // Формула площади Гаусса
            double area = 0;
            int n = Vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var current = Vertices[i];
                var next = Vertices[(i + 1) % n];
                area += current.X * next.Y - next.X * current.Y;
            }

            return Math.Abs(area / 2);
        }

        public override double CalcPerimeter()
        {
            double perimeter = 0;
            int n = Vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var current = Vertices[i];
                var next = Vertices[(i + 1) % n];
                perimeter += Math.Sqrt(Math.Pow(next.X - current.X, 2) + Math.Pow(next.Y - current.Y, 2));
            }

            return perimeter;
        }
    }

    public class Calc
    {
        private readonly IReadOnlyList<IShape> _shapes;
        public Calc(IEnumerable<IShape> shapes)
        {
            _shapes = shapes.ToList();
        }
    }
}