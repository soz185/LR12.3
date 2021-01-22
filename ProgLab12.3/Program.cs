using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLab6
{
    public class Radius
    {
        private double radius { get; set; }

        public Radius()
        {
            radius = 0;
        }
        public Radius(double rad)
        {
            radius = rad;
        }
        public void readRadius()
        {
            Console.Write("Радиус = ");
            this.radius = Convert.ToDouble(Console.ReadLine().ToString());
        }
        public void displayRadius()
        {
            Console.Write(radius);
        }
        public Object addRadius(Radius rad1, Radius rad2)
        {
            this.radius = rad1.radius + rad2.radius;
            return this;
        }
        public double returnRadius()
        {
            return radius;
        }
        public static Radius operator ++(Radius rad)
        {
            ++rad.radius;
            return rad;
        }

    }
    public class Vector: ICloneable
    {
        static Exception e;
        protected double X { get; set; }
        protected double Y { get; set; }
        protected double Z { get; set; }
        //private Radius cylinderRadius { get; set; }
        public static int countOfVector = 0;

        public Vector()
        {
            //Radius rad = new Radius(0);
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            //this.cylinderRadius = rad;
            countOfVector++;
        }

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            //this.cylinderRadius = rad;
            countOfVector++;
        }
        public Vector(int n)
        {
            //Radius rad = new Radius(n);
            this.X = n;
            this.Y = n;
            this.Z = n;
            //this.cylinderRadius = rad;
            countOfVector++;
        }
        ~Vector()
        {
            if (countOfVector > 0)
                countOfVector--;
        }
        public object Clone()
        {
            return new Vector(X, Y, Z);
        }
        public static int GetCountOfVector()
        {
            return countOfVector;
        }
        double getX() { return this.X; }
        double getY() { return this.Y; }
        double getZ() { return this.Z; }

        public void read()
        {
            Console.Write("x = ");
            this.X = Convert.ToDouble(Console.ReadLine().ToString());
            Console.Write("y = ");
            this.Y = Convert.ToDouble(Console.ReadLine().ToString());
            Console.Write("z = ");
            this.Z = Convert.ToDouble(Console.ReadLine().ToString());
            //this.cylinderRadius.readRadius();
            if (X < -100 || X > 100 || Y < -100 || Y > 100 || Z < -100 || Z > 100)
                throw e = new Exception();
        }
        //public void display()
        //{
        //    Console.Write(this.X + "; " + this.Y + "; " + this.Z);
        //    Console.Write(", радиус = ");
        //    //this.cylinderRadius.displayRadius();
        //}
        public override String ToString()
        {
            String str = X + " " + Y + " " + Z;
            return str;
        }

        public Vector add(Vector vector)
        {
            Radius rad = new Radius(0.0);
            Vector c = new Vector(0, 0, 0);
            c.X = this.X + vector.X;
            c.Y = this.Y + vector.Y;
            c.Z = this.Z + vector.Z;
            //c.cylinderRadius.addRadius(this.cylinderRadius, vector.cylinderRadius);
            return this;
        }
        public double length()
        {
            double length = Math.Pow(this.X * this.X + this.Y * this.Y + this.Z * this.Z, 0.5);
            return length;
        }
        public void scalar(Vector vector, out double scalar)
        {
            scalar = this.X * vector.X + this.Y * vector.Y + this.Z * vector.Z;
        }
        public void Volume(ref double volume)
        {
            volume = 0;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            Radius rad = new Radius(0.0);
            Vector c = new Vector(0, 0, 0);
            c.X = vector1.X + vector2.X;
            c.Y = vector1.Y + vector2.Y;
            c.Z = vector1.Z + vector2.Z;
            //c.cylinderRadius.addRadius(vector1.cylinderRadius, vector2.cylinderRadius);
            return c;
        }

        public static Vector operator ++(Vector vector)
        {
            ++vector.X;
            ++vector.Y;
            ++vector.Z;
            //++vector.cylinderRadius;
            return vector;
        }
    }
    class Cylinder : Vector
    {
    private double height;
    public static int countOfCylinder;
    public Cylinder() : base(0, 0, 0) { height = 0; countOfCylinder++; }
    public Cylinder(double X, double Y, double Z, double h) : base(X, Y, Z) { height = h; countOfCylinder++; }


    double Volume()
    {
        double volume = height * length() * length() * 3.14;
        return volume;
    }
    static int getCountOfSphere()
    {
        return countOfCylinder;
    }

        public override String ToString()
        {
            String str = X + " " + Y + " " + Z + " " + height;
            return str;
        }
    };

    interface IFigure
    {
        double Volume();
    }

    class Sphere : IFigure
    {
        double radius = 1;
        public double Volume()
        {
            double volume = (4.0 / 3.0) * 3.14 * radius * radius * radius;
            return volume;
        }
    }

    abstract class Figure
    {
        public abstract void ReturnName();
    };

    class Circle : Figure
    {
        public override void ReturnName() { Console.WriteLine("Круг"); }
    };

    class Square : Figure
    {
        public override void ReturnName() { Console.WriteLine("Квадрат"); }
    };


class Program
    {
        static void Main(string[] args)
        {
            String str = "Работа с векторами и радиусами цилиндров.";
            int length_str = str.Length;
            Console.WriteLine(str);
            Console.WriteLine("Длина строки " + length_str);

            Radius rad = new Radius(1.5);
            Vector a = new Vector();
            Vector c = new Vector();
            Vector b = new Vector(1, 0, -2);
            Console.WriteLine("Количество созданных векторов: " + Vector.GetCountOfVector());

            bool p = false;
            while (!p)
            {
                p = true;
                try
                {
                    Console.WriteLine("Введите координаты и радиус a [-100;100]:");
                    a.read();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Повторите ввод");
                    p = false;
                }
            }
            Console.WriteLine("Цилиндры:");
            Console.Write("a ");
            Console.WriteLine(a.ToString());
            Console.WriteLine();
            Console.Write("b ");
            Console.WriteLine(b.ToString());
            Console.WriteLine("");
            b = (Vector)a.Clone();
            a++;
            Console.Write("a ");
            Console.WriteLine(a.ToString());
            Console.WriteLine("");
            Console.Write("b ");
            Console.WriteLine(b.ToString());
            Console.WriteLine("");

            Console.WriteLine("Сложение цилиндров a и b: ");
            c = a + b;
            Console.Write("c ");
            c.ToString();
            Console.WriteLine("\nДлина вектора a равна " + a.length());
            double volume = 0;
            a.Volume(ref volume);
            Console.WriteLine("Объем цилиндра a равен " + volume);
            double scalar;
            a.scalar(b, out scalar);
            Console.WriteLine("Скалярное произведение векторов a и b равно " + scalar);

            Console.WriteLine("Работа с массивом объектов.");
            Vector[] arr = new Vector[3];
            for (int i = 0; i < 3; i++)
                arr[i] = new Vector(i);
            Console.WriteLine("Количество созданных векторов: " + Vector.GetCountOfVector());
            p = false;
            while (!p)
            {
                p = true;
                try
                {
                    Console.WriteLine("Введите координаты и радиус a [-100;100]:");
                    arr[0].read();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Повторите ввод");
                    p = false;
                }
            }

            Console.WriteLine("Цилиндры:");
            Console.Write("arr[0] ");
            Console.WriteLine(arr[0].ToString());
            Console.WriteLine();
            Console.Write("arr[1] ");
            Console.WriteLine(arr[1].ToString());
            Console.WriteLine("");

            Console.WriteLine("Сложение цилиндров arr[0] и arr[1]: ");
            arr[2] = arr[0] + arr[1];
            Console.Write("arr[2] ");
            Console.WriteLine(arr[2].ToString());
            Console.WriteLine("\nДлина вектора arr[0] равна " + arr[0].length());
            double volume_arr = 0;
            a.Volume(ref volume_arr);
            Console.WriteLine("Объем цилиндра arr[0] равен " + volume_arr);
            double scalar_arr;
            a.scalar(b, out scalar_arr);
            Console.WriteLine("Скалярное произведение векторов arr[0] и arr[1] равно " + scalar_arr);

            Vector[,] arrayVector = new Vector[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    arrayVector[i, j] = new Vector();
                    Console.WriteLine(arrayVector[i, j].ToString());
                    Console.WriteLine();
                }
            Console.WriteLine(arrayVector.Length);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    arrayVector[i, j]++;
                    Console.WriteLine(arrayVector[i, j].ToString());
                    Console.WriteLine();
                }
            Cylinder sp = new Cylinder(1, 3, 2, 2);

            Circle circle = new Circle();
            Square square = new Square();
            circle.ReturnName();
            square.ReturnName();

            Sphere sphere = new Sphere();
            Console.WriteLine(sphere.Volume());
        }
    }
}
