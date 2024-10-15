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
        private float[,] Figure;
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
        int[,] faces; // Стороны куба

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
            int[,] cubefaces = new int[,]
            {
                { 0, 1, 2, 3 }, // Передняя грань (A-B-C-D)
                { 4, 5, 6, 7 }, // Задняя грань (E-F-G-H)
                { 0, 1, 5, 4 }, // Левая грань (A-B-F-E)
                { 2, 3, 7, 6 }, // Правая грань (C-D-H-G)
                { 1, 2, 6, 5 }, // Верхняя грань (B-C-G-F)
                { 0, 3, 7, 4 }  // Нижняя грань (A-D-H-E)
            };

            faces = cubefaces;
            DrawCube();

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
         * из которых строится куб
         */
        private void SetDefaultPosition()
        {
            float[,] f =
            {
                { 0, 0, 100, 1 },      //A - 0
                { 0, 100, 100, 1 },    //B - 1
                { 100, 100, 100, 1 },  //C - 2
                { 100, 0, 100, 1 },    //D - 3
                { 0, 0, 0, 1 },        //E - 4
                { 0, 100, 0, 1 },      //F - 5
                { 100, 100, 0, 1 },    //G - 6
                { 100, 0, 0, 1 },      //H - 7
            };
            Figure = f;
        }

        /**
         * Метод для отрисовки проекции куба
         */
        private bool IsEdgeVisible(int start, int end, Vector observer, Vector[] vertices)
        {
            for (int i = 0; i < faces.GetLength(0); i++)
            {
                int[] face = { faces[i, 0], faces[i, 1], faces[i, 2], faces[i, 3] };

                if ((face[0] == start || face[0] == end) &&
                    (face[1] == start || face[1] == end) &&
                    IsVisible(face, observer))
                {
                    return true;
                }
                if ((face[2] == start || face[2] == end) &&
                    (face[1] == start || face[1] == end) &&
                    IsVisible(face, observer))
                {
                    return true;
                }
                if ((face[3] == start || face[3] == end) &&
                    (face[2] == start || face[2] == end) &&
                    IsVisible(face, observer))
                {
                    return true;
                }
                if ((face[3] == start || face[3] == end) &&
                    (face[0] == start || face[0] == end) &&
                    IsVisible(face, observer))
                {
                    return true;
                }
            }
            return false;
        }

        private void DrawCube()
        {
            graphics = CreateGraphics();
            DrawAxis();
            float[,] matrixDraw = MultiplyMatrices(Figure, proection);

            Vector[] vertices = new Vector[8];
            for (int i = 0; i < 8; i++)
            {
                vertices[i] = new Vector(matrixDraw[i, 0], matrixDraw[i, 1], Figure[i, 2]); // Использование оригинальной координаты Z
            }

            Vector observer = new Vector(150, 150, 500); // Наблюдатель на дистанции по оси Z

            // Определяем соединения между вершинами куба (каждая грань состоит из 4 точек)
            int[,] edges = new int[,]
            {
                { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 0 },
                { 4, 5 }, { 5, 6 }, { 6, 7 }, { 7, 4 },
                { 0, 4 }, { 1, 5 }, { 2, 6 }, { 3, 7 }
            };

            // Рисуем линии для соединений
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int start = edges[i, 0];
                int end = edges[i, 1];
                if (IsEdgeVisible(start, end, observer, vertices))
                {
                    graphics.DrawLine(Pens.Red, matrixDraw[start, 0], matrixDraw[start, 1], matrixDraw[end, 0], matrixDraw[end, 1]);
                }
            }
        }

        /**
         * Метод обрабатывает событие нажатия на кнопку buttonDeffaultPosition
         * В результате буква перерисовывается в изначальном положении и первоначальном виде
         */
        private void buttonDeffaultPosition_Click(object sender, EventArgs e)
        {
            SetDefaultPosition();
            DrawCube();
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
            Figure = MultiplyMatrices(Figure, Rotate);
            DrawCube();
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
            Figure = MultiplyMatrices(Figure, Rotate);
            DrawCube();
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
            Figure = MultiplyMatrices(Figure, Rotate);
            DrawCube();

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

        private Vector VectorSubtraction(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        private Vector VectorCrossProduct(Vector v1, Vector v2)
        {
            return new Vector(
                v1.y * v2.z - v1.z * v2.y,
                v1.z * v2.x - v1.x * v2.z,
                v1.x * v2.y - v1.y * v2.x
            );
        }

        private float VectorDotProduct(Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        private Vector Normalize(Vector v)
        {
            float magnitude = (float)Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            if (magnitude == 0) return new Vector(0, 0, 0);
            return new Vector(v.x / magnitude, v.y / magnitude, v.z / magnitude);
        }

        // Внутренний класс для представления вектора
        private class Vector
        {
            public float x;
            public float y;
            public float z;

            public Vector(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        private bool IsVisible(int[] face, Vector observer)
        {
            Vector AB = new Vector(Figure[face[1], 0], Figure[face[1], 1], Figure[face[1], 2]);
            Vector BC = new Vector(Figure[face[0], 0], Figure[face[0], 1], Figure[face[0], 2]);
            Vector CA = new Vector(Figure[face[2], 0], Figure[face[2], 1], Figure[face[2], 2]);
            Vector vec1 = VectorSubtraction(AB, BC);
            Vector vec2 = VectorSubtraction(CA, AB);
            Vector normal = Normalize(VectorCrossProduct(vec1, vec2));
            float D = -VectorDotProduct(normal, BC);
            int sign = -(int)Math.Sign(VectorDotProduct(normal, new Vector(0, 0, 0)) + D);
            normal.x *= sign;
            normal.y *= sign;
            normal.z *= sign;
            return VectorDotProduct(normal, observer) + D > 0;
        }
    }
}
