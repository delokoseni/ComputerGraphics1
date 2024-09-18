using System.Windows.Forms;

namespace ComputerGraphics1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDeffaultPosition = new System.Windows.Forms.Button();
            this.ButtonPrintLine = new System.Windows.Forms.Button();
            this.ButtonDeleteLine = new System.Windows.Forms.Button();
            this.ButtonRotateForward = new System.Windows.Forms.Button();
            this.ButtonRotateBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLineForRotation = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.CoordinateX = new System.Windows.Forms.TextBox();
            this.CoordinateY = new System.Windows.Forms.TextBox();
            this.CoordinateZ = new System.Windows.Forms.TextBox();
            this.labelX1 = new System.Windows.Forms.Label();
            this.labelY1 = new System.Windows.Forms.Label();
            this.labelZ1 = new System.Windows.Forms.Label();
            this.CoordinateX1 = new System.Windows.Forms.TextBox();
            this.CoordinateY1 = new System.Windows.Forms.TextBox();
            this.CoordinateZ1 = new System.Windows.Forms.TextBox();
            this.MoveTextBox = new System.Windows.Forms.TextBox();
            this.MovePlusX = new System.Windows.Forms.Button();
            this.MovePlusY = new System.Windows.Forms.Button();
            this.MovePlusZ = new System.Windows.Forms.Button();
            this.MoveMinusZ = new System.Windows.Forms.Button();
            this.MoveMinusY = new System.Windows.Forms.Button();
            this.MoveMinusX = new System.Windows.Forms.Button();
            this.RotateTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RotateLeftZ = new System.Windows.Forms.Button();
            this.RotateLeftY = new System.Windows.Forms.Button();
            this.RotateLeftX = new System.Windows.Forms.Button();
            this.RotateRightZ = new System.Windows.Forms.Button();
            this.RotateRightY = new System.Windows.Forms.Button();
            this.RotateRightX = new System.Windows.Forms.Button();
            this.MirrorXY = new System.Windows.Forms.Button();
            this.MirrorXZ = new System.Windows.Forms.Button();
            this.MirrorYZ = new System.Windows.Forms.Button();
            this.Stretch = new System.Windows.Forms.Button();
            this.Clench = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDeffaultPosition
            // 
            this.buttonDeffaultPosition.Location = new System.Drawing.Point(13, 12);
            this.buttonDeffaultPosition.Name = "buttonDeffaultPosition";
            this.buttonDeffaultPosition.Size = new System.Drawing.Size(183, 30);
            this.buttonDeffaultPosition.TabIndex = 0;
            this.buttonDeffaultPosition.Text = "Начальная позиция";
            this.buttonDeffaultPosition.UseVisualStyleBackColor = true;
            this.buttonDeffaultPosition.Click += new System.EventHandler(this.buttonDeffaultPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Перемещение";
            // 
            // MoveTextBox
            // 
            this.MoveTextBox.Location = new System.Drawing.Point(118, 45);
            this.MoveTextBox.Name = "MoveTextBox";
            this.MoveTextBox.Size = new System.Drawing.Size(78, 22);
            this.MoveTextBox.TabIndex = 2;
            this.MoveTextBox.Text = "10";
            // 
            // MovePlusX
            // 
            this.MovePlusX.Location = new System.Drawing.Point(16, 73);
            this.MovePlusX.Name = "MovePlusX";
            this.MovePlusX.Size = new System.Drawing.Size(50, 30);
            this.MovePlusX.TabIndex = 3;
            this.MovePlusX.Text = "X+";
            this.MovePlusX.UseVisualStyleBackColor = true;
            this.MovePlusX.Click += (sender, e) => MoveX_Click(sender, e, true);
            // 
            // MovePlusY
            // 
            this.MovePlusY.Location = new System.Drawing.Point(81, 73);
            this.MovePlusY.Name = "MovePlusY";
            this.MovePlusY.Size = new System.Drawing.Size(50, 30);
            this.MovePlusY.TabIndex = 4;
            this.MovePlusY.Text = "Y+";
            this.MovePlusY.UseVisualStyleBackColor = true;
            this.MovePlusY.Click += (sender, e) => MoveY_Click(sender, e, true);
            // 
            // MovePlusZ
            // 
            this.MovePlusZ.Location = new System.Drawing.Point(146, 73);
            this.MovePlusZ.Name = "MovePlusZ";
            this.MovePlusZ.Size = new System.Drawing.Size(50, 30);
            this.MovePlusZ.TabIndex = 5;
            this.MovePlusZ.Text = "Z+";
            this.MovePlusZ.UseVisualStyleBackColor = true;
            this.MovePlusZ.Click += (sender, e) => MoveZ_Click(sender, e, true);
            // 
            // MoveMinusZ
            // 
            this.MoveMinusZ.Location = new System.Drawing.Point(146, 109);
            this.MoveMinusZ.Name = "MoveMinusZ";
            this.MoveMinusZ.Size = new System.Drawing.Size(50, 30);
            this.MoveMinusZ.TabIndex = 8;
            this.MoveMinusZ.Text = "Z-";
            this.MoveMinusZ.UseVisualStyleBackColor = true;
            this.MoveMinusZ.Click += (sender, e) => MoveZ_Click(sender, e, false);
            // 
            // MoveMinusY
            // 
            this.MoveMinusY.Location = new System.Drawing.Point(81, 109);
            this.MoveMinusY.Name = "MoveMinusY";
            this.MoveMinusY.Size = new System.Drawing.Size(50, 30);
            this.MoveMinusY.TabIndex = 7;
            this.MoveMinusY.Text = "Y-";
            this.MoveMinusY.UseVisualStyleBackColor = true;
            this.MoveMinusY.Click += (sender, e) => MoveY_Click(sender, e, false);
            // 
            // MoveMinusX
            // 
            this.MoveMinusX.Location = new System.Drawing.Point(16, 109);
            this.MoveMinusX.Name = "MoveMinusX";
            this.MoveMinusX.Size = new System.Drawing.Size(50, 30);
            this.MoveMinusX.TabIndex = 6;
            this.MoveMinusX.Text = "X-";
            this.MoveMinusX.UseVisualStyleBackColor = true;
            this.MoveMinusX.Click += (sender, e) => MoveX_Click(sender, e, false);
            // 
            // RotateTextBox
            // 
            this.RotateTextBox.Location = new System.Drawing.Point(118, 145);
            this.RotateTextBox.Name = "RotateTextBox";
            this.RotateTextBox.Size = new System.Drawing.Size(78, 22);
            this.RotateTextBox.TabIndex = 10;
            this.RotateTextBox.Text = "45";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Вращение";
            // 
            // RotateLeftZ
            // 
            this.RotateLeftZ.Location = new System.Drawing.Point(146, 212);
            this.RotateLeftZ.Name = "RotateLeftZ";
            this.RotateLeftZ.Size = new System.Drawing.Size(50, 30);
            this.RotateLeftZ.TabIndex = 16;
            this.RotateLeftZ.Text = "Z-l";
            this.RotateLeftZ.UseVisualStyleBackColor = true;
            this.RotateLeftZ.Click += (sender, e) => RotateZ_Click(sender, e, "left");
            // 
            // RotateLeftY
            // 
            this.RotateLeftY.Location = new System.Drawing.Point(81, 212);
            this.RotateLeftY.Name = "RotateLeftY";
            this.RotateLeftY.Size = new System.Drawing.Size(50, 30);
            this.RotateLeftY.TabIndex = 15;
            this.RotateLeftY.Text = "Y-l";
            this.RotateLeftY.UseVisualStyleBackColor = true;
            this.RotateLeftY.Click += (sender, e) => RotateY_Click(sender, e, "left");
            // 
            // RotateLeftX
            // 
            this.RotateLeftX.Location = new System.Drawing.Point(16, 212);
            this.RotateLeftX.Name = "RotateLeftX";
            this.RotateLeftX.Size = new System.Drawing.Size(50, 30);
            this.RotateLeftX.TabIndex = 14;
            this.RotateLeftX.Text = "X-l";
            this.RotateLeftX.UseVisualStyleBackColor = true;
            this.RotateLeftX.Click += (sender, e) => RotateX_Click(sender, e, "left");
            // 
            // RotateRightZ
            // 
            this.RotateRightZ.Location = new System.Drawing.Point(146, 176);
            this.RotateRightZ.Name = "RotateRightZ";
            this.RotateRightZ.Size = new System.Drawing.Size(50, 30);
            this.RotateRightZ.TabIndex = 13;
            this.RotateRightZ.Text = "Z-r";
            this.RotateRightZ.UseVisualStyleBackColor = true;
            this.RotateRightZ.Click += (sender, e) => RotateZ_Click(sender, e, "right");
            // 
            // RotateRightY
            // 
            this.RotateRightY.Location = new System.Drawing.Point(81, 176);
            this.RotateRightY.Name = "RotateRightY";
            this.RotateRightY.Size = new System.Drawing.Size(50, 30);
            this.RotateRightY.TabIndex = 12;
            this.RotateRightY.Text = "Y-r";
            this.RotateRightY.UseVisualStyleBackColor = true;
            this.RotateRightY.Click += (sender, e) => RotateY_Click(sender, e, "right");
            // 
            // RotateRightX
            // 
            this.RotateRightX.Location = new System.Drawing.Point(16, 176);
            this.RotateRightX.Name = "RotateRightX";
            this.RotateRightX.Size = new System.Drawing.Size(50, 30);
            this.RotateRightX.TabIndex = 11;
            this.RotateRightX.Text = "X-r";
            this.RotateRightX.UseVisualStyleBackColor = true;
            this.RotateRightX.Click += (sender, e) => RotateX_Click(sender, e, "right");
            // 
            // MirrorXY
            // 
            this.MirrorXY.Location = new System.Drawing.Point(16, 248);
            this.MirrorXY.Name = "MirrorXY";
            this.MirrorXY.Size = new System.Drawing.Size(183, 30);
            this.MirrorXY.TabIndex = 17;
            this.MirrorXY.Text = "Отражение OXY";
            this.MirrorXY.UseVisualStyleBackColor = true;
            this.MirrorXY.Click += (sender, e) => Reflection(sender, e, "XY");
            // 
            // MirrorXZ
            // 
            this.MirrorXZ.Location = new System.Drawing.Point(16, 284);
            this.MirrorXZ.Name = "MirrorXZ";
            this.MirrorXZ.Size = new System.Drawing.Size(183, 30);
            this.MirrorXZ.TabIndex = 18;
            this.MirrorXZ.Text = "Отражение OXZ";
            this.MirrorXZ.UseVisualStyleBackColor = true;
            this.MirrorXZ.Click += (sender, e) => Reflection(sender, e, "XZ");
            // 
            // MirrorYZ
            // 
            this.MirrorYZ.Location = new System.Drawing.Point(16, 320);
            this.MirrorYZ.Name = "MirrorYZ";
            this.MirrorYZ.Size = new System.Drawing.Size(183, 30);
            this.MirrorYZ.TabIndex = 19;
            this.MirrorYZ.Text = "Отражение OYZ";
            this.MirrorYZ.UseVisualStyleBackColor = true;
            this.MirrorYZ.Click += (sender, e) => Reflection(sender, e, "YZ");
            // 
            // Stretch
            // 
            this.Stretch.Location = new System.Drawing.Point(16, 356);
            this.Stretch.Name = "Stretch";
            this.Stretch.Size = new System.Drawing.Size(183, 30);
            this.Stretch.TabIndex = 20;
            this.Stretch.Text = "Растяжение";
            this.Stretch.UseVisualStyleBackColor = true;
            this.Stretch.Click += (sender, e) => Scaling_Click(sender, e, true);
            // 
            // Clench
            // 
            this.Clench.Location = new System.Drawing.Point(16, 392);
            this.Clench.Name = "Clench";
            this.Clench.Size = new System.Drawing.Size(183, 30);
            this.Clench.TabIndex = 21;
            this.Clench.Text = "Сжатие";
            this.Clench.UseVisualStyleBackColor = true;
            this.Clench.Click += (sender, e) => Scaling_Click(sender, e, false);
            // 
            // labelLineForRotation
            // 
            this.labelLineForRotation.AutoSize = true;
            this.labelLineForRotation.Location = new System.Drawing.Point(13, 432);
            this.labelLineForRotation.Name = "labelLineForRotation";
            this.labelLineForRotation.Size = new System.Drawing.Size(99, 16);
            this.labelLineForRotation.TabIndex = 1;
            this.labelLineForRotation.Text = "Прямая для вращения";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(13, 452);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(99, 16);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X = ";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(113, 452);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(99, 16);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Y = ";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(213, 452);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(99, 16);
            this.labelZ.TabIndex = 1;
            this.labelZ.Text = "Z = ";
            // 
            // CoordinateX
            // 
            this.CoordinateX.Location = new System.Drawing.Point(50, 448);
            this.CoordinateX.Name = "CoordinateX";
            this.CoordinateX.Size = new System.Drawing.Size(50, 22);
            this.CoordinateX.TabIndex = 2;
            this.CoordinateX.Text = "";
            // 
            // CoordinateY
            // 
            this.CoordinateY.Location = new System.Drawing.Point(150, 448);
            this.CoordinateY.Name = "CoordinateY";
            this.CoordinateY.Size = new System.Drawing.Size(50, 22);
            this.CoordinateY.TabIndex = 2;
            this.CoordinateY.Text = "";
            // 
            // CoordinateZ
            // 
            this.CoordinateZ.Location = new System.Drawing.Point(250, 448);
            this.CoordinateZ.Name = "CoordinateZ";
            this.CoordinateZ.Size = new System.Drawing.Size(50, 22);
            this.CoordinateZ.TabIndex = 2;
            this.CoordinateZ.Text = "";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(13, 482);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 16);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "X1 = ";
            // 
            // labelY1
            // 
            this.labelY1.AutoSize = true;
            this.labelY1.Location = new System.Drawing.Point(113, 482);
            this.labelY1.Name = "labelY1";
            this.labelY1.Size = new System.Drawing.Size(99, 16);
            this.labelY1.TabIndex = 1;
            this.labelY1.Text = "Y1 = ";
            // 
            // labelZ1
            // 
            this.labelZ1.AutoSize = true;
            this.labelZ1.Location = new System.Drawing.Point(213, 482);
            this.labelZ1.Name = "labelZ1";
            this.labelZ1.Size = new System.Drawing.Size(99, 16);
            this.labelZ1.TabIndex = 1;
            this.labelZ1.Text = "Z1 = ";
            // 
            // CoordinateX1
            // 
            this.CoordinateX1.Location = new System.Drawing.Point(50, 478);
            this.CoordinateX1.Name = "CoordinateX1";
            this.CoordinateX1.Size = new System.Drawing.Size(50, 22);
            this.CoordinateX1.TabIndex = 2;
            this.CoordinateX1.Text = "";
            // 
            // CoordinateY1
            // 
            this.CoordinateY1.Location = new System.Drawing.Point(150, 478);
            this.CoordinateY1.Name = "CoordinateY1";
            this.CoordinateY1.Size = new System.Drawing.Size(50, 22);
            this.CoordinateY1.TabIndex = 2;
            this.CoordinateY1.Text = "";
            // 
            // CoordinateZ1
            // 
            this.CoordinateZ1.Location = new System.Drawing.Point(250, 478);
            this.CoordinateZ1.Name = "CoordinateZ1";
            this.CoordinateZ1.Size = new System.Drawing.Size(50, 22);
            this.CoordinateZ1.TabIndex = 2;
            this.CoordinateZ1.Text = "";
            // 
            // ButtonPrintLine
            // 
            this.ButtonPrintLine.Location = new System.Drawing.Point(13, 508);
            this.ButtonPrintLine.Name = "ButtonPrintLine";
            this.ButtonPrintLine.Size = new System.Drawing.Size(183, 30);
            this.ButtonPrintLine.TabIndex = 0;
            this.ButtonPrintLine.Text = "Отобразить линию";
            this.ButtonPrintLine.UseVisualStyleBackColor = true;
            this.ButtonPrintLine.Click += new System.EventHandler(this.ButtonPrintLine_Click);
            // 
            // ButtonDeleteLine
            // 
            this.ButtonDeleteLine.Location = new System.Drawing.Point(13, 543);
            this.ButtonDeleteLine.Name = "ButtonDeleteLine";
            this.ButtonDeleteLine.Size = new System.Drawing.Size(183, 30);
            this.ButtonDeleteLine.TabIndex = 0;
            this.ButtonDeleteLine.Text = "Удалить линию";
            this.ButtonDeleteLine.UseVisualStyleBackColor = true;
            this.ButtonDeleteLine.Click += new System.EventHandler(this.ButtonDeleteLine_Click);
            // 
            // ButtonRotateForward
            // 
            this.ButtonRotateForward.Location = new System.Drawing.Point(13, 578);
            this.ButtonRotateForward.Name = "ButtonRotateForward";
            this.ButtonRotateForward.Size = new System.Drawing.Size(183, 30);
            this.ButtonRotateForward.TabIndex = 0;
            this.ButtonRotateForward.Text = "Вращать вперед";
            this.ButtonRotateForward.UseVisualStyleBackColor = true;
            this.ButtonRotateForward.Click += (sender, e) => Rotate_Click(sender, e, "forward");
            // 
            // ButtonRotateBack
            // 
            this.ButtonRotateBack.Location = new System.Drawing.Point(13, 613);
            this.ButtonRotateBack.Name = "ButtonRotateBack";
            this.ButtonRotateBack.Size = new System.Drawing.Size(183, 30);
            this.ButtonRotateBack.TabIndex = 0;
            this.ButtonRotateBack.Text = "Вращать назад";
            this.ButtonRotateBack.UseVisualStyleBackColor = true;
            this.ButtonRotateBack.Click += (sender, e) => Rotate_Click(sender, e, "back");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 572);
            this.Controls.Add(this.Clench);
            this.Controls.Add(this.Stretch);
            this.Controls.Add(this.MirrorYZ);
            this.Controls.Add(this.MirrorXZ);
            this.Controls.Add(this.MirrorXY);
            this.Controls.Add(this.RotateLeftZ);
            this.Controls.Add(this.RotateLeftY);
            this.Controls.Add(this.RotateLeftX);
            this.Controls.Add(this.RotateRightZ);
            this.Controls.Add(this.RotateRightY);
            this.Controls.Add(this.RotateRightX);
            this.Controls.Add(this.RotateTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MoveMinusZ);
            this.Controls.Add(this.MoveMinusY);
            this.Controls.Add(this.MoveMinusX);
            this.Controls.Add(this.MovePlusZ);
            this.Controls.Add(this.MovePlusY);
            this.Controls.Add(this.MovePlusX);
            this.Controls.Add(this.MoveTextBox);
            this.Controls.Add(this.CoordinateX);
            this.Controls.Add(this.CoordinateY);
            this.Controls.Add(this.CoordinateZ);
            this.Controls.Add(this.CoordinateX1);
            this.Controls.Add(this.CoordinateY1);
            this.Controls.Add(this.CoordinateZ1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLineForRotation);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelY1);
            this.Controls.Add(this.labelZ1);
            this.Controls.Add(this.buttonDeffaultPosition);
            this.Controls.Add(this.ButtonPrintLine);
            this.Controls.Add(this.ButtonDeleteLine);
            this.Controls.Add(this.ButtonRotateForward);
            this.Controls.Add(this.ButtonRotateBack);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Афинные преобразования";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeffaultPosition;
        private System.Windows.Forms.Button ButtonPrintLine;
        private System.Windows.Forms.Button ButtonDeleteLine;
        private System.Windows.Forms.Button ButtonRotateForward;
        private System.Windows.Forms.Button ButtonRotateBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLineForRotation;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TextBox CoordinateX;
        private System.Windows.Forms.TextBox CoordinateZ;
        private System.Windows.Forms.TextBox CoordinateY;
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Label labelY1;
        private System.Windows.Forms.Label labelZ1;
        private System.Windows.Forms.TextBox CoordinateX1;
        private System.Windows.Forms.TextBox CoordinateZ1;
        private System.Windows.Forms.TextBox CoordinateY1;
        private System.Windows.Forms.TextBox MoveTextBox;
        private System.Windows.Forms.Button MovePlusX;
        private System.Windows.Forms.Button MovePlusY;
        private System.Windows.Forms.Button MovePlusZ;
        private System.Windows.Forms.Button MoveMinusZ;
        private System.Windows.Forms.Button MoveMinusY;
        private System.Windows.Forms.Button MoveMinusX;
        private System.Windows.Forms.TextBox RotateTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RotateLeftZ;
        private System.Windows.Forms.Button RotateLeftY;
        private System.Windows.Forms.Button RotateLeftX;
        private System.Windows.Forms.Button RotateRightZ;
        private System.Windows.Forms.Button RotateRightY;
        private System.Windows.Forms.Button RotateRightX;
        private System.Windows.Forms.Button MirrorXY;
        private System.Windows.Forms.Button MirrorXZ;
        private System.Windows.Forms.Button MirrorYZ;
        private System.Windows.Forms.Button Stretch;
        private System.Windows.Forms.Button Clench;
    }

}