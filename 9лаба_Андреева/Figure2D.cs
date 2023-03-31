using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9лаба_Андреева
{
    public class Figure2D
    {
        public int ID { get; private set; }
        private static int count = 1;
        public double Width
        {
            get { return _width; }
            private set
            {
                if (value < 0)
                    throw new Exception("Ширина отрицательная");
                else
                    _width = value;
            }
        }
        private double _width;
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                    throw new Exception("Высота отрицательная");
                else
                    _height = value;
            }
        }
        private double _height;
        public Figures Figure
        {
            get { return _figure; }
            private set
            {
                if (Figures.Circumference == value && Width != Height)
                    throw new Exception("У окружности ширина и высота равны");
                else
                {
                    _figure = value;
                }
            }
        }
        private Figures _figure;

        public Figure2D()
        {
            ID = count;
            Width = 10;
            Height = 10;
            Figure = Figures.Rectangle;
            count++;
        }
        public Figure2D(double width, double height)
        {
            ID = count;
            Width = width;
            Height = height;
            Figure = Figures.Rectangle;
            count++;
        }
        public Figure2D(double width, double height, Figures figure)
        {
            ID = count;
            Width = width;
            Height = height;
            Figure = figure;
            count++;
        }

        public double GetSquare()
        {
            switch (Figure)
            {
                case Figures.Triangle:
                    return Width * Height / 2;
                case Figures.Rectangle:
                    return Width * Height;
                default:
                    return Math.PI * Math.Pow(Width / 2, 2);
            }
        }

        public override string ToString()
        {
            return $"2D: Номер: {ID}\nШирина: {Width}\nВысота: {Height}";
        }
    }
}
