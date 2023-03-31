using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9лаба_Андреева
{
    public partial class Form2 : Form
    {
        private int[] Labels;
        private Figures Figure;
        private Figure2D figure2D;
        private Figure3D figure3D;
        private bool IsObject2D;

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Figures figure, bool IsObject2D)
        {
            InitializeComponent();
            Figure = figure;
            Labels = new int[3] { 0, 1, 2 };
            this.IsObject2D = IsObject2D;
            if(IsObject2D)
            {
                label3.Visible = false;
                textBox3.Visible = false;
                Labels = new int[2] { 0, 1 };
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private void Control_StringOnlyNumber(TextBox textBox) // Контролирует за тем, чтобы в textBox не было лишних символов
        {
            const string nums = "1234567890";
            for(int i = 0; i < textBox.Text.Length; i++)
            {
                try
                {
                    if (!nums.Contains(textBox.Text[i]))
                    {
                        textBox.Text = textBox.Text.Remove(i, 1);
                        i--;
                    }
                }
                catch(IndexOutOfRangeException ex)
                {
                    break;
                }
            }
        } 
        private void Control_NullTextBox(int countLabel) // Контролирует за тем, чтобы все textBox были заполнены
        {
            Label[] labels = new Label[3] { label4, label5, label6 };
            TextBox[] textBoxes = new TextBox[3] { textBox1, textBox2, textBox3 };
            bool flag = false;
            for(int i =0; i < countLabel; i++)
            {
                if (textBoxes[i].Text == "")
                {
                    labels[i].Visible = true;
                    flag = true;
                }
            }
            if(flag)
                throw new FormatException("Данные не введены!");
        }
        private void textBox1_TextChanged(object sender, EventArgs e) // измнение textBox1
        {
            Control_StringOnlyNumber(textBox1);
            label4.Visible = false;
        }
        private void textBox2_TextChanged(object sender, EventArgs e) // изменение textBox2
        {
            Control_StringOnlyNumber(textBox2);
            label5.Visible = false;
        }
        private void textBox3_TextChanged(object sender, EventArgs e) // изменение textBox3
        {
            Control_StringOnlyNumber(textBox3);
            label6.Visible = false;
        }
        public Figure2D GetFigure2D() // возвращает 2Д фигуру
        {
            return figure2D;
        }
        public Figure3D GetFigure3D() // возвращает 3Д фигуру
        {
            return figure3D;
        }
        private void button1_Click(object sender, EventArgs e) // создание фигур
        {
            try
            {
                Control_NullTextBox(Labels.Length);
                if (IsObject2D)
                    figure2D = new Figure2D(double.Parse(textBox1.Text), double.Parse(textBox2.Text), Figure);
                else
                    figure3D = new Figure3D(double.Parse(textBox1.Text), double.Parse(textBox2.Text), double.Parse(textBox3.Text), Figure);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
