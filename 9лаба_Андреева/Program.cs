using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9лаба_Андреева
{
    internal static class Program
    {
        public static List<object> figures = new List<object>();
        public static List<bool> figuresIs2D = new List<bool>();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public enum Figures // тип фигур
    {
        Rectangle, // прямоугольник
        Triangle, // треугольник
        Circumference // окружность
    }
}
