using System.Text;

namespace Geomio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = Container.Calculator;
            calc.Print();
            calc.Print<Circle>();
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
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double CalcArea() => Math.PI * _radius * _radius;

        public override double CalcPerimeter() => 2 * Math.PI * _radius;
    }

    // Класс для квадрата
    public class Square : Shape
    {
        private readonly double _side1;
        private readonly double _side2;

        public Square(double side1, double side2)
        {
            _side1 = side1;
            _side2 = side2;
        }

        public override double CalcArea() => _side1 * _side2;

        public override double CalcPerimeter() => 2 * (_side1 + _side2);
    }

    // Класс для треугольника
    public class Triangle : Shape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        public Triangle(double a, double b, double c)
        {
            _sideA = a;
            _sideB = b;
            _sideC = c;
        }

        public override double CalcArea()
        {
            // Формула Герона
            double p = CalcPerimeter() / 2;
            return Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
        }

        public override double CalcPerimeter() => _sideA + _sideB + _sideC;
    }

    // Класс для многоугольника
    public class Polygon : Shape
    {
        private readonly List<(double X, double Y)> _vertices;

        public Polygon(List<(double X, double Y)> vertices)
        {
            _vertices = vertices;
            
            if (vertices.Count < 3)
                throw new ArgumentException("Polygon must have at least 3 vertices");
        }

        public override double CalcArea()
        {
            // Формула площади Гаусса
            double area = 0;
            int n = _vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var current = _vertices[i];
                var next = _vertices[(i + 1) % n];
                area += current.X * next.Y - next.X * current.Y;
            }

            return Math.Abs(area / 2);
        }

        public override double CalcPerimeter()
        {
            double perimeter = 0;
            int n = _vertices.Count;

            for (int i = 0; i < n; i++)
            {
                var current = _vertices[i];
                var next = _vertices[(i + 1) % n];
                perimeter += Math.Sqrt(Math.Pow(next.X - current.X, 2) + Math.Pow(next.Y - current.Y, 2));
            }

            return perimeter;
        }
    }

    public class Calc
    {
        private readonly List<IShape> _shapes;
        public Calc(IEnumerable<IShape> shapes)
        {
            _shapes = shapes.ToList();
        }

        public void Print() => _shapes.ForEach((s) => Console.WriteLine($"Shape:{s.GetType().Name} Area:{s.CalcArea()} Perimeter:{s.CalcPerimeter()}"));
        public void Print<T>() where T : IShape => _shapes.OfType<T>().ToList().ForEach((s) => Console.WriteLine($"Shape:{s.GetType().Name} Area:{s.CalcArea()} Perimeter:{s.CalcPerimeter()}"));
    }
}