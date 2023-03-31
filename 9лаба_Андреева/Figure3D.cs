using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9лаба_Андреева
{
    public class Figure3D: Figure2D
    {
        public new int ID { get; private set; }
        private static int count = 1;
        public double Fatness
        {
            get { return _fatness; }
            private set
            {
                if (value < 0)
                    throw new Exception("Толщина отрицательная");
                else
                    _fatness = value;
            }
        }
        private double _fatness;
        public new Figures Figure 
        {
            get 
            {
                return _figure;
            } 
            set
            {
                if (Figures.Circumference == value && (Width != Height || Height != Fatness || Width != Fatness))
                    throw new FormatException("У шара ширина, толщина и высота равны");
                else
                    _figure = value;
            }
        }
        private Figures _figure;

        public Figure3D() : base()
        {
            ID = count;
            Fatness = 10;
            count++;
        }
        public Figure3D(double width, double height, double fatness) : base(width, height)
        {
            ID = count;
            Fatness = fatness;
            count++;
        }
        public Figure3D(double width, double height, double fatness, Figures figure) : base(width, height)
        {
            ID = count;
            Fatness = fatness;
            Figure = figure;
            count++;
        }

        public double GetVolume()
        {
            return GetSquare() * Fatness;
        }
        public override string ToString()
        {
            return $"3D: Номер: {ID}" + base.ToString().Remove(0, base.ToString().IndexOf('\n')) + $"\nТолщина: {Fatness}";
        }
    }
}
