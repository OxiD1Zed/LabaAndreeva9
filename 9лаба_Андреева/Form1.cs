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
    public partial class Form1 : Form
    {
        private int BackSelectedIndex;
        private int back;
        public Form1()
        {
            InitializeComponent();
            BackSelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)  // прогрузка формы
        {
            checkedListBox1.SetItemChecked(0, true);
            listBox1.Items.AddRange(new object[6] {"Треугольник2D", "Прямоугольник2D", "Окружность2D", "Треугольник3D", "Прямоугольник3D", "Окружность3D"});
            back = 0;
            LoadInfo();
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e) // изменение выбора
        {
            ControlOneSelected(new ListBox[2] { listBox1, listBox2 }, BackSelectedIndex);
        }
        private void button1_Click(object sender, EventArgs e) // добавление/вычисление фигуры
        {
            if (BackSelectedIndex == 0) // выбран элемент из listBox1, т.е создание фигуры
            {
                Form2 addForm;
                Figure2D figure2D = null;
                Figure3D figure3D = null;
                bool IsObject2D = true;
                switch (listBox1.SelectedIndex) // создание фигуры
                {
                    case 0:
                        addForm = new Form2(Figures.Triangle, true);
                        if (addForm.ShowDialog() == DialogResult.OK)
                            figure2D = addForm.GetFigure2D();
                        break;
                    case 1:
                        addForm = new Form2(Figures.Rectangle, true);
                        if (addForm.ShowDialog() == DialogResult.OK)
                            figure2D = addForm.GetFigure2D();
                        break;
                    case 2:
                        addForm = new Form2(Figures.Circumference, true);
                        if (addForm.ShowDialog() == DialogResult.OK)
                            figure2D = addForm.GetFigure2D();
                        break;
                    case 3:
                        addForm = new Form2(Figures.Triangle, false);
                        if (addForm.ShowDialog() == DialogResult.OK)
                            figure3D = addForm.GetFigure3D();
                        IsObject2D = false;
                        break;
                    case 4:
                        addForm = new Form2(Figures.Rectangle, false);
                        if (addForm.ShowDialog() == DialogResult.OK)
                            figure3D = addForm.GetFigure3D();
                        IsObject2D = false;
                        break;
                    case 5:
                        addForm = new Form2(Figures.Circumference, false);
                        if (addForm.ShowDialog() == DialogResult.OK)
                            figure3D = addForm.GetFigure3D();
                        IsObject2D = false;
                        break;
                }

                if (figure2D is null && !(figure3D is null))
                {
                    Program.figures.Add(figure3D);
                    Program.figuresIs2D.Add(false);
                    PrintResult(figure3D, IsObject2D);
                }
                else if (figure3D is null && !(figure2D is null))
                {
                    Program.figures.Add(figure2D);
                    Program.figuresIs2D.Add(true);
                    PrintResult(figure2D, IsObject2D);
                }
            }
            else if (BackSelectedIndex == 1 && listBox2.SelectedIndex != -1) // выбран элемент из listBox2, т.е нужно просто вывести требуемую информацию
            {
                var figure = Program.figures[listBox2.SelectedIndex];
                var isFigure2D = Program.figuresIs2D[listBox2.SelectedIndex];
                PrintResult(figure, isFigure2D);
            }
            LoadInfo();
        }
        private void PrintResult(object figure, bool isObject2D)  // вывод информации в textBox1 (результат)
        {
            try
            {
                switch (checkedListBox1.CheckedIndices.Count)
                {
                    case 1:
                        switch (isObject2D)
                        {
                            case true:
                                if (checkedListBox1.CheckedIndices[0] == 0)
                                {
                                    textBox1.Text = $"Площадь: {((Figure2D)figure).GetSquare()}";
                                }
                                else
                                {
                                    throw new Exception("Невозможно вычислить объем для плоской фигуры!");
                                }
                                break;
                            case false:
                                if (checkedListBox1.CheckedIndices[0] == 0)
                                {
                                    textBox1.Text = $"Площадь: {((Figure3D)figure).GetSquare()}";
                                }
                                else
                                {
                                    textBox1.Text = $"Площадь: {((Figure3D)figure).GetVolume()}";
                                }
                                break;
                        }
                        break;
                    case 2:
                        switch (isObject2D)
                        {
                            case true:
                                textBox1.Text = $"Площадь: {((Figure2D)figure).GetSquare()}";
                                throw new Exception("Невозможно вычислить объем для плоской фигуры!");
                            case false:
                                textBox1.Text = $"Площадь: {((Figure3D)figure).GetSquare()} Объем: {((Figure3D)figure).GetVolume()}";
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) // изменение выбора
        {
        }
        private void ControlOneSelected(ListBox[] listBoxes, int backSelectedIndex) // Контролирует за тем, чтобы из двух листов был выбран только один элемент
        {
            for(int i = 0; i < listBoxes.Length; i++)
            {
                if (i != backSelectedIndex && listBoxes[i].SelectedItems.Count != 0)
                {
                    var listBox = listBoxes[i];
                    listBox.SetSelected(listBox.SelectedIndex, false);
                }
            }
        }
        private void LoadInfo() // Прогружает информацию о созданных фигурах в listBox2
        {
            listBox2.Items.Clear();
            int countFigures = Program.figures.Count;
            string[] lines = new string[countFigures];
            for(int i = 0; i < countFigures; i++)
            {
                try
                {
                    var figure = (Figure3D)Program.figures[i];
                    int startIndexRemove = figure.ToString().IndexOf('\n');
                    int countCharRemove = figure.ToString().Length - startIndexRemove;
                    lines[i] = figure.ToString().Remove(startIndexRemove, countCharRemove);
                }
                catch
                {
                    var figure = (Figure2D)Program.figures[i];
                    int startIndexRemove = figure.ToString().IndexOf('\n');
                    int countCharRemove = figure.ToString().Length - startIndexRemove;
                    lines[i] = figure.ToString().Remove(startIndexRemove, countCharRemove);
                }
            }
            listBox2.Items.AddRange(lines);
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            BackSelectedIndex = 0;
        }
        private void listBox2_Click(object sender, EventArgs e)
        {
            BackSelectedIndex = 1;
        }
        private void textBox1_TextChanged(object sender, EventArgs e) // включение scrollbar
        {
            if (textBox1.Text.Length > 69)
                textBox1.ScrollBars = ScrollBars.Vertical;
        }
    }
}
