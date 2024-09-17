using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private int cenX;
        private int cenY;
        private Graphics _graphics;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cenX = Size.Width / 2;
            cenY = Size.Height / 2;
            SetDefaultPosition();
            //кабинетное проецирование относительно центра правосторонней системы координат
            float[,] p =
            {
                { 1, 0, 0, 0},
                { 0, -1, 0, 0},
                { -(float)(Math.Cos(Math.PI/4))/2, (float)(Math.Cos(Math.PI/4))/2, 0, 0},
                { cenX, cenY, 0, 1}
            };
            proection = p;
            DrawLetterB();
        }

        //умножение матриц
        private float[,] Mult(float[,] X, float[,] Y)
        {
            float[,] result = new float[X.GetLength(0), Y.GetLength(1)];
            for (int i = 0; i < X.GetLength(0); i++)
                for (int j = 0; j < Y.GetLength(1); j++)
                    for (int k = 0; k < Y.GetLength(0); k++)
                        result[i, j] += X[i, k] * Y[k, j];
            return result;
        }

        //отрисовка осей
        private void DrawAxis()
        {
            _graphics = CreateGraphics();
            _graphics.Clear(Color.White);
            float[,] Axis =
            {
                { 0, 0, 0, 1},
                { 500, 0, 0, 1},
                { 0, 400, 0, 1},
                { 0, 0, 500, 1},
                { 490, 5, 0, 1},
                { 490, -5, 0, 1},
                { 5, 390, 0, 1},
                { -5, 390, 0, 1},
                { 12, 0, 495, 1},
                { -10, 0, 480, 1}
            };
            Axis = Mult(Axis, proection);
            #region X
            _graphics.DrawLine(Pens.Gray, Axis[0, 0], Axis[0, 1], Axis[1, 0], Axis[1, 1]);
            _graphics.DrawLine(Pens.Gray, Axis[1, 0], Axis[1, 1], Axis[4, 0], Axis[4, 1]);
            _graphics.DrawLine(Pens.Gray, Axis[1, 0], Axis[1, 1], Axis[5, 0], Axis[5, 1]);
            #endregion
            #region Y
            _graphics.DrawLine(Pens.Gray, Axis[0, 0], Axis[0, 1], Axis[2, 0], Axis[2, 1]);
            _graphics.DrawLine(Pens.Gray, Axis[2, 0], Axis[2, 1], Axis[6, 0], Axis[6, 1]);
            _graphics.DrawLine(Pens.Gray, Axis[2, 0], Axis[2, 1], Axis[7, 0], Axis[7, 1]);
            #endregion
            #region Z
            _graphics.DrawLine(Pens.Gray, Axis[0, 0], Axis[0, 1], Axis[3, 0], Axis[3, 1]);
            _graphics.DrawLine(Pens.Gray, Axis[3, 0], Axis[3, 1], Axis[8, 0], Axis[8, 1]);
            _graphics.DrawLine(Pens.Gray, Axis[3, 0], Axis[3, 1], Axis[9, 0], Axis[9, 1]);
            #endregion
        }

        //начальные значения Z
        private void SetDefaultPosition()
        {
            float[,] DefB =
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
                { 0, 0, 10, 1 },     //A` - 12
                { 0, 100, 10, 1 },   //B` - 13
                { 60, 100, 10, 1 },  //C` - 14
                { 60, 80, 10, 1 },   //D` - 15
                { 20, 80, 10, 1 },   //E` - 16
                { 20, 50, 10, 1 },   //F` - 17
                { 60, 50, 10, 1 },   //G` - 18
                { 60, 0, 10, 1 },    //H` - 19
                { 20, 10, 10, 1 },   //I` - 20
                { 20, 40, 10, 1 },   //J` - 21 
                { 50, 40, 10, 1 },   //K` - 22
                { 50, 10, 10, 1 },   //L` - 23
            };
            LetterB = DefB;
        }

        //отрисовка проекции буквы
        private void DrawLetterB()
        {
            _graphics = CreateGraphics();
            DrawAxis();
            float[,] matrixDraw = Mult(LetterB, proection);

            // Рисуем линии для нижней части буквы
            for (int i = 0; i < 7; i++)
            {
                _graphics.DrawLine(Pens.Red, matrixDraw[i, 0], matrixDraw[i, 1], matrixDraw[i + 1, 0], matrixDraw[i + 1, 1]);
            }

            // Рисуем линии для верхней части буквы
            for (int i = 12; i < 19; i++)
            {
                _graphics.DrawLine(Pens.Red, matrixDraw[i, 0], matrixDraw[i, 1], matrixDraw[i + 1, 0], matrixDraw[i + 1, 1]);
            }

            // Соединяем нижнюю и верхнюю части
            for (int i = 0; i < 8; i++) // Соединяем точки между нижней и верхней частями
            {
                _graphics.DrawLine(Pens.Red, matrixDraw[i, 0], matrixDraw[i, 1], matrixDraw[i + 12, 0], matrixDraw[i + 12, 1]);
            }

            // Дополнительные соединения для завершения буквы
            _graphics.DrawLine(Pens.Red, matrixDraw[0, 0], matrixDraw[0, 1], matrixDraw[7, 0], matrixDraw[7, 1]); // A - H
            _graphics.DrawLine(Pens.Red, matrixDraw[12, 0], matrixDraw[12, 1], matrixDraw[19, 0], matrixDraw[19, 1]); // A' - H'

            
            _graphics.DrawLine(Pens.Red, matrixDraw[8, 0], matrixDraw[8, 1], matrixDraw[9, 0], matrixDraw[9, 1]);   // I - J
            _graphics.DrawLine(Pens.Red, matrixDraw[9, 0], matrixDraw[9, 1], matrixDraw[10, 0], matrixDraw[10, 1]); // J - K
            _graphics.DrawLine(Pens.Red, matrixDraw[10, 0], matrixDraw[10, 1], matrixDraw[11, 0], matrixDraw[11, 1]); // K - L
            _graphics.DrawLine(Pens.Red, matrixDraw[11, 0], matrixDraw[11, 1], matrixDraw[8, 0], matrixDraw[8, 1]);   // L - I
             // Соединяем точки I и J с их верхними версиями I' и J'
            _graphics.DrawLine(Pens.Red, matrixDraw[8, 0], matrixDraw[8, 1], matrixDraw[20, 0], matrixDraw[20, 1]); // I - I'
            _graphics.DrawLine(Pens.Red, matrixDraw[9, 0], matrixDraw[9, 1], matrixDraw[21, 0], matrixDraw[21, 1]); // J - J'
            _graphics.DrawLine(Pens.Red, matrixDraw[10, 0], matrixDraw[10, 1], matrixDraw[22, 0], matrixDraw[22, 1]); // K - K'
            _graphics.DrawLine(Pens.Red, matrixDraw[11, 0], matrixDraw[11, 1], matrixDraw[23, 0], matrixDraw[23, 1]); // L - L'


            _graphics.DrawLine(Pens.Red, matrixDraw[20, 0], matrixDraw[20, 1], matrixDraw[21, 0], matrixDraw[21, 1]); // I' - J'
            _graphics.DrawLine(Pens.Red, matrixDraw[21, 0], matrixDraw[21, 1], matrixDraw[22, 0], matrixDraw[22, 1]); // J' - K'
            _graphics.DrawLine(Pens.Red, matrixDraw[22, 0], matrixDraw[22, 1], matrixDraw[23, 0], matrixDraw[23, 1]); // K' - L'
            _graphics.DrawLine(Pens.Red, matrixDraw[23, 0], matrixDraw[23, 1], matrixDraw[20, 0], matrixDraw[20, 1]); // L' - I'
        }

        //поместить буквы начального размера в центр системы координат
        private void buttonDeffaultPosition_Click(object sender, EventArgs e)
        {
            SetDefaultPosition();
            DrawLetterB();
        }

        //движение вдоль OX в положительном направлении
        private void MovePlusX_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { toMove, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Move);
            DrawLetterB();
        }

        //движение вдоль OX в отрицательном направлении
        private void MoveMinusX_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { -toMove, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Move);
            DrawLetterB();
        }

        //движение вдоль OY в положительном направлении
        private void MovePlusY_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, toMove, 0, 1}
            };
            LetterB = Mult(LetterB, Move);
            DrawLetterB();
        }

        //движение вдоль OY в отрицательном направлении
        private void MoveMinusY_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, -toMove, 0, 1}
            };
            LetterB = Mult(LetterB, Move);
            DrawLetterB();
        }

        //движение вдоль OZ в положительном направлении
        private void MovePlusZ_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, toMove, 1}
            };
            LetterB = Mult(LetterB, Move);
            DrawLetterB();
        }

        //движение вдоль OZ в отрицательном направлении
        private void MoveMinusZ_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, -toMove, 1}
            };
            LetterB = Mult(LetterB, Move);
            DrawLetterB();
        }

        //вращение вокруг OX вправо
        private void RotateRightX_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            //перевод в радианы
            float angle = (float)(toRotate * Math.PI / 180);
            float[,] Rotate =
            {
                { 1, 0, 0, 0},
                { 0, (float)(Math.Cos(angle)), (float)(Math.Sin(angle)), 0},
                { 0, -(float)(Math.Sin(angle)), (float)(Math.Cos(angle)), 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Rotate);
            DrawLetterB();
        }

        //вращение вокруг OX влево
        private void RotateLeftX_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            //перевод в радианы
            float angle = (float)(toRotate * Math.PI / 180);
            float[,] Rotate =
            {
                { 1, 0, 0, 0},
                { 0, (float)Math.Cos(angle), -((float)(Math.Sin(angle))), 0},
                { 0, ((float)(Math.Sin(angle))), ((float)(Math.Cos(angle))), 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Rotate);
            DrawLetterB();
        }

        //вращение вокруг OY вправо
        private void RotateRightY_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            //перевод в радианы
            float angle = (float)(toRotate * Math.PI / 180);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(angle))), 0, ((float)(Math.Sin(angle))), 0},
                { 0, 1, 0, 0},
                { -((float)(Math.Sin(angle))), 0, ((float)(Math.Cos(angle))), 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Rotate);
            DrawLetterB();
        }

        //вращение вокруг OY влево
        private void RotateLeftY_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            //перевод в радианы
            float angle = (float)(toRotate * Math.PI / 180);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(angle))), 0, -((float)(Math.Sin(angle))), 0},
                { 0, 1, 0, 0},
                { ((float)(Math.Sin(angle))), 0, ((float)(Math.Cos(angle))), 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Rotate);
            DrawLetterB();
        }

        //вращение вокруг OZ вправо
        private void RotateRightZ_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            //перевод в радианы
            float angle = (float)(toRotate * Math.PI / 180);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(angle))), -((float)(Math.Sin(angle))), 0, 0},
                { ((float)(Math.Sin(angle))), ((float)(Math.Cos(angle))), 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Rotate);
            DrawLetterB();
        }

        //вращение вокруг OZ влево
        private void RotateLeftZ_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            //перевод в радианы
            float angle = (float)(toRotate * Math.PI / 180);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(angle))), ((float)(Math.Sin(angle))), 0, 0},
                { -((float)(Math.Sin(angle))), ((float)(Math.Cos(angle))), 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Rotate);
            DrawLetterB();
        }

        //отражение относительно плоскости XY
        private void MirrorXY_Click(object sender, EventArgs e)
        {
            float[,] Mirror =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, -1, 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Mirror);
            DrawLetterB();
        }

        //отражение относительно плоскости XZ
        private void MirrorXZ_Click(object sender, EventArgs e)
        {
            float[,] Mirror =
            {
                { 1, 0, 0, 0},
                { 0, -1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Mirror);
            DrawLetterB();
        }

        //отражение относительно плоскости YZ
        private void MirrorYZ_Click(object sender, EventArgs e)
        {
            float[,] Mirror =
            {
                { -1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Mirror);
            DrawLetterB();
        }

        //растяжение
        private void Stretch_Click(object sender, EventArgs e)
        {
            float[,] Stretch =
            {
                { 2, 0, 0, 0},
                { 0, 2, 0, 0},
                { 0, 0, 2, 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Stretch);
            DrawLetterB();
        }

        //сжатие
        private void Clench_Click(object sender, EventArgs e)
        {
            float[,] Clench =
            {
                { (float)(0.5), 0, 0, 0},
                { 0, (float)(0.5), 0, 0},
                { 0, 0, (float)(0.5), 0},
                { 0, 0, 0, 1}
            };
            LetterB = Mult(LetterB, Clench);
            DrawLetterB();
        }
    }
}
