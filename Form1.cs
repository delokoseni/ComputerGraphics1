using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ComputerGraphics1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private float[,] LetterB;
        private float[,] proection;
        private int centerX;
        private int centerY;
        private Graphics graphics;
        private bool RotatingX, RotatingY, RotatingZ;
        private Timer rotateXTimer = new Timer();
        private Timer rotateYTimer = new Timer();
        private Timer rotateZTimer = new Timer();
        private bool isRotatingX = false;
        private bool isRotatingY = false;
        private bool isRotatingZ = false;
        private string rotateXDirection;
        private string rotateYDirection;
        private string rotateZDirection;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            centerX = Size.Width / 2;
            centerY = Size.Height / 2;
            RotatingX = false;
            RotatingY = false;
            RotatingZ = false;
            SetDefaultPosition();
            /** 
             * Кабинетное проецирование относительно центра прямоугольной системы координат
             * Вместо -Sin45 используется Cos45 так как в противном случае ось Z будет уходить в плоскость
             * внутрь экрана
            */
            float[,] p =
            {
                { 1, 0, 0, 0},
                { 0, -1, 0, 0},
                { -(float)(Math.Cos(Math.PI/4))/2, (float)(Math.Cos(Math.PI/4))/2, 0, 0},  
                { centerX, centerY, 0, 1}
            };
            proection = p;
            DrawLetterB();

            rotateXTimer.Interval = 100; // Интервал в миллисекундах, можно настроить по своему усмотрению

            rotateYTimer.Interval = 100;

            rotateZTimer.Interval = 100;

            rotateXTimer.Tick += RotateXTimer_Tick;
            rotateYTimer.Tick += RotateYTimer_Tick;
            rotateZTimer.Tick += RotateZTimer_Tick;

        }

        private void RotateXTimer_Tick(object sender, EventArgs e)
        {
            if (isRotatingX)
            {
                RotateX_Click(rotateXDirection);
            }
        }

        private void RotateYTimer_Tick(object sender, EventArgs e)
        {
            if (isRotatingY)
            {
                RotateY_Click(rotateYDirection);
            }
        }

        private void RotateZTimer_Tick(object sender, EventArgs e)
        {
            if (isRotatingZ)
            {
                RotateZ_Click(rotateZDirection);
            }
        }


        /**
         * Метод для умножения матриц 
         */
        private float[,] MultiplyMatrices(float[,] X, float[,] Y)
        {
            float[,] result = new float[X.GetLength(0), Y.GetLength(1)];
            for (int i = 0; i < X.GetLength(0); i++)
                for (int j = 0; j < Y.GetLength(1); j++)
                    for (int k = 0; k < Y.GetLength(0); k++)
                        result[i, j] += X[i, k] * Y[k, j];
            return result;
        }

        /**
         * Метод для отрисовки координатных осей
         */
        private void DrawAxis()
        {
            graphics = CreateGraphics();
            graphics.Clear(Color.White);
            float[,] Axis =
            {
                { 0, 0, 0, 1},      // Начало оси (0, 0, 0) - точка
                { 500, 0, 0, 1},    // Конец оси X (500, 0, 0)
                { 0, 400, 0, 1},    // Конец оси Y (0, 400, 0)
                { 0, 0, 500, 1},    // Конец оси Z (0, 0, 500)
                { 490, 5, 0, 1},
                { 490, -5, 0, 1},
                { 5, 390, 0, 1},
                { -5, 390, 0, 1},
                { 12, 0, 495, 1},
                { -10, 0, 480, 1}
            };
            Axis = MultiplyMatrices(Axis, proection);
            // Ось X
            graphics.DrawLine(Pens.Gray, Axis[0, 0], Axis[0, 1], Axis[1, 0], Axis[1, 1]); // Сама прямая линия
            graphics.DrawLine(Pens.Gray, Axis[1, 0], Axis[1, 1], Axis[4, 0], Axis[4, 1]);
            graphics.DrawLine(Pens.Gray, Axis[1, 0], Axis[1, 1], Axis[5, 0], Axis[5, 1]);
            
            // Ось Y
            graphics.DrawLine(Pens.Gray, Axis[0, 0], Axis[0, 1], Axis[2, 0], Axis[2, 1]); // Сама прямая линия
            graphics.DrawLine(Pens.Gray, Axis[2, 0], Axis[2, 1], Axis[6, 0], Axis[6, 1]);
            graphics.DrawLine(Pens.Gray, Axis[2, 0], Axis[2, 1], Axis[7, 0], Axis[7, 1]);
           
            // Ось Z
            graphics.DrawLine(Pens.Gray, Axis[0, 0], Axis[0, 1], Axis[3, 0], Axis[3, 1]); // Сама прямая линия
            graphics.DrawLine(Pens.Gray, Axis[3, 0], Axis[3, 1], Axis[8, 0], Axis[8, 1]);
            graphics.DrawLine(Pens.Gray, Axis[3, 0], Axis[3, 1], Axis[9, 0], Axis[9, 1]);
            
        }

        /**
         * Метод устанавливающий начальные значения для точек 
         * из которых строится буква Б
         */
        private void SetDefaultPosition()
        {
            float[,] B =
            {
                { 0, 0, 0, 1 },      //A - 0
                { 0, 100, 0, 1 },    //B - 1
                { 60, 100, 0, 1 },   //C - 2
                { 60, 80, 0, 1 },    //D - 3
                { 20, 80, 0, 1 },    //E - 4
                { 20, 50, 0, 1 },    //F - 5
                { 60, 50, 0, 1 },    //G - 6
                { 60, 0, 0, 1 },     //H - 7
                { 20, 10, 0, 1 },    //I - 8
                { 20, 40, 0, 1 },    //J - 9
                { 50, 40, 0, 1 },    //K - 10
                { 50, 10, 0, 1 },    //L - 11
                { 0, 0, 10, 1 },     //A' - 12
                { 0, 100, 10, 1 },   //B' - 13
                { 60, 100, 10, 1 },  //C' - 14
                { 60, 80, 10, 1 },   //D' - 15
                { 20, 80, 10, 1 },   //E' - 16
                { 20, 50, 10, 1 },   //F' - 17
                { 60, 50, 10, 1 },   //G' - 18
                { 60, 0, 10, 1 },    //H' - 19
                { 20, 10, 10, 1 },   //I' - 20
                { 20, 40, 10, 1 },   //J' - 21 
                { 50, 40, 10, 1 },   //K' - 22
                { 50, 10, 10, 1 },   //L' - 23
            };
            LetterB = B;
        }

        /**
         * Метод для отрисовки проекции буквы
         */
        private void DrawLetterB()
        {
            graphics = CreateGraphics();
            DrawAxis();
            float[,] matrixDraw = MultiplyMatrices(LetterB, proection);

            // Рисуем линии для нижней части буквы
            for (int i = 0; i < 11; i++)
            {
                if(i != 7)
                    graphics.DrawLine(Pens.Red, matrixDraw[i, 0], matrixDraw[i, 1], matrixDraw[i + 1, 0], matrixDraw[i + 1, 1]);
            }

            // Рисуем линии для верхней части буквы
            for (int i = 12; i < 23; i++)
            {
                if(i != 19)
                    graphics.DrawLine(Pens.Red, matrixDraw[i, 0], matrixDraw[i, 1], matrixDraw[i + 1, 0], matrixDraw[i + 1, 1]);
            }

            // Соединяем нижнюю и верхнюю части
            for (int i = 0; i < 12; i++) 
            {
                graphics.DrawLine(Pens.Red, matrixDraw[i, 0], matrixDraw[i, 1], matrixDraw[i + 12, 0], matrixDraw[i + 12, 1]);
            }

            // Дополнительные соединения для завершения буквы
            graphics.DrawLine(Pens.Red, matrixDraw[0, 0], matrixDraw[0, 1], matrixDraw[7, 0], matrixDraw[7, 1]); // A - H
            graphics.DrawLine(Pens.Red, matrixDraw[12, 0], matrixDraw[12, 1], matrixDraw[19, 0], matrixDraw[19, 1]); // A' - H'
            graphics.DrawLine(Pens.Red, matrixDraw[11, 0], matrixDraw[11, 1], matrixDraw[8, 0], matrixDraw[8, 1]);   // I - L
            graphics.DrawLine(Pens.Red, matrixDraw[23, 0], matrixDraw[23, 1], matrixDraw[20, 0], matrixDraw[20, 1]); // I' - L'
        }

        /**
         * Метод обрабатывает событие нажатия на кнопку buttonDeffaultPosition
         * В результате буква перерисовывается в изначальном положении и первоначальном виде
         */
        private void buttonDeffaultPosition_Click(object sender, EventArgs e)
        {
            SetDefaultPosition();
            DrawLetterB();
        }

        /**
         * Метод вращает букву вдоль оси X в обе стороны
         */
        private void RotateX_Click(string way)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float angle = (float)(toRotate * Math.PI / 180); // Перевод в радианы

            int sign;
            if (way == "right")
                sign = 1;
            else
                sign = -1;

            float[,] Rotate =
            {
                { 1, 0, 0, 0},
                { 0, (float)(Math.Cos(angle)), sign * (float)(Math.Sin(angle)), 0},
                { 0, -sign * (float)(Math.Sin(angle)), (float)(Math.Cos(angle)), 0},
                { 0, 0, 0, 1}
            };
            LetterB = MultiplyMatrices(LetterB, Rotate);
            DrawLetterB();
        }

        /**
         * Метод вращает букву вдоль оси Y в обе стороны
         */
        private void RotateY_Click(string way)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float angle = (float)(toRotate * Math.PI / 180); // Перевод в радианы

            int sign;
            if (way == "right")
                sign = 1;
            else
                sign = -1;

            float[,] Rotate =
            {
                { ((float)(Math.Cos(angle))), 0, sign * ((float)(Math.Sin(angle))), 0},
                { 0, 1, 0, 0},
                { -sign * ((float)(Math.Sin(angle))), 0, ((float)(Math.Cos(angle))), 0},
                { 0, 0, 0, 1}
            };
            LetterB = MultiplyMatrices(LetterB, Rotate);
            DrawLetterB();
        }

        /**
         * Метод вращает букву вдоль оси Z в обе стороны
         */
        private void RotateZ_Click(string way)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float angle = (float)(toRotate * Math.PI / 180); // Перевод в радианы

            int sign;
            if (way == "right")
                sign = 1;
            else
                sign = -1;

            float[,] Rotate =
            {
                { ((float)(Math.Cos(angle))), -sign * ((float)(Math.Sin(angle))), 0, 0},
                { sign * ((float)(Math.Sin(angle))), ((float)(Math.Cos(angle))), 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            LetterB = MultiplyMatrices(LetterB, Rotate);
            DrawLetterB();

        }

        private void RotateRightX_MouseDown(object sender, MouseEventArgs e)
        {
            isRotatingX = true;
            rotateXDirection = "right";
            rotateXTimer.Start();
        }

        private void RotateRightX_MouseUp(object sender, MouseEventArgs e)
        {
            isRotatingX = false;
            rotateXTimer.Stop();
        }

        private void RotateLeftX_MouseDown(object sender, MouseEventArgs e)
        {
            isRotatingX = true;
            rotateXDirection = "left";
            rotateXTimer.Start();
        }

        private void RotateLeftX_MouseUp(object sender, MouseEventArgs e)
        {
            isRotatingX = false;
            rotateXTimer.Stop();
        }

        private void RotateRightY_MouseDown(object sender, MouseEventArgs e)
        {
            isRotatingY = true;
            rotateYDirection = "right";
            rotateYTimer.Start();
        }

        private void RotateRightY_MouseUp(object sender, MouseEventArgs e)
        {
            isRotatingY = false;
            rotateYTimer.Stop();
        }

        private void RotateLeftY_MouseDown(object sender, MouseEventArgs e)
        {
            isRotatingY = true;
            rotateYDirection = "left";
            rotateYTimer.Start();
        }

        private void RotateLeftY_MouseUp(object sender, MouseEventArgs e)
        {
            isRotatingY = false;
            rotateYTimer.Stop();
        }

        private void RotateRightZ_MouseDown(object sender, MouseEventArgs e)
        {
            isRotatingZ = true;
            rotateZDirection = "right";
            rotateZTimer.Start();
        }

        private void RotateRightZ_MouseUp(object sender, MouseEventArgs e)
        {
            isRotatingZ = false;
            rotateZTimer.Stop();
        }

        private void RotateLeftZ_MouseDown(object sender, MouseEventArgs e)
        {
            isRotatingZ = true;
            rotateZDirection = "left";
            rotateZTimer.Start();
        }

        private void RotateLeftZ_MouseUp(object sender, MouseEventArgs e)
        {
            isRotatingZ = false;
            rotateZTimer.Stop();
        }

    }
}
