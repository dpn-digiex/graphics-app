namespace GraphicsApp
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnFilledCircle = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnFilledRect = new System.Windows.Forms.Button();
            this.btnFilledEclipse = new System.Windows.Forms.Button();
            this.btnArc = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnEclipse = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSelection = new System.Windows.Forms.Label();
            this.btnRemoveSelection = new System.Windows.Forms.Button();
            this.btnRemoveShapes = new System.Windows.Forms.Button();
            this.dropdownColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputWidthPen = new System.Windows.Forms.TextBox();
            this.panelSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSideBar.Controls.Add(this.btnPolygon);
            this.panelSideBar.Controls.Add(this.btnFilledCircle);
            this.panelSideBar.Controls.Add(this.btnCircle);
            this.panelSideBar.Controls.Add(this.btnFilledRect);
            this.panelSideBar.Controls.Add(this.btnFilledEclipse);
            this.panelSideBar.Controls.Add(this.btnArc);
            this.panelSideBar.Controls.Add(this.btnRect);
            this.panelSideBar.Controls.Add(this.btnEclipse);
            this.panelSideBar.Controls.Add(this.btnLine);
            this.panelSideBar.Location = new System.Drawing.Point(1, 0);
            this.panelSideBar.Margin = new System.Windows.Forms.Padding(2);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(150, 413);
            this.panelSideBar.TabIndex = 0;
            // 
            // btnPolygon
            // 
            this.btnPolygon.Location = new System.Drawing.Point(8, 251);
            this.btnPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(124, 26);
            this.btnPolygon.TabIndex = 10;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnFilledCircle
            // 
            this.btnFilledCircle.Location = new System.Drawing.Point(8, 191);
            this.btnFilledCircle.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilledCircle.Name = "btnFilledCircle";
            this.btnFilledCircle.Size = new System.Drawing.Size(124, 26);
            this.btnFilledCircle.TabIndex = 9;
            this.btnFilledCircle.Text = "Filled Circle";
            this.btnFilledCircle.UseVisualStyleBackColor = true;
            this.btnFilledCircle.Click += new System.EventHandler(this.btnFilledCircle_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(8, 161);
            this.btnCircle.Margin = new System.Windows.Forms.Padding(2);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(124, 26);
            this.btnCircle.TabIndex = 8;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnFilledRect
            // 
            this.btnFilledRect.Location = new System.Drawing.Point(8, 131);
            this.btnFilledRect.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilledRect.Name = "btnFilledRect";
            this.btnFilledRect.Size = new System.Drawing.Size(124, 26);
            this.btnFilledRect.TabIndex = 7;
            this.btnFilledRect.Text = "Filled Rectangle";
            this.btnFilledRect.UseVisualStyleBackColor = true;
            this.btnFilledRect.Click += new System.EventHandler(this.btnFilledRect_Click);
            // 
            // btnFilledEclipse
            // 
            this.btnFilledEclipse.Location = new System.Drawing.Point(8, 71);
            this.btnFilledEclipse.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilledEclipse.Name = "btnFilledEclipse";
            this.btnFilledEclipse.Size = new System.Drawing.Size(124, 26);
            this.btnFilledEclipse.TabIndex = 6;
            this.btnFilledEclipse.Text = "Filled Ellipse";
            this.btnFilledEclipse.UseVisualStyleBackColor = true;
            this.btnFilledEclipse.Click += new System.EventHandler(this.btnFilledEclipse_Click);
            // 
            // btnArc
            // 
            this.btnArc.Location = new System.Drawing.Point(8, 221);
            this.btnArc.Margin = new System.Windows.Forms.Padding(2);
            this.btnArc.Name = "btnArc";
            this.btnArc.Size = new System.Drawing.Size(124, 26);
            this.btnArc.TabIndex = 5;
            this.btnArc.Text = "Arc";
            this.btnArc.UseVisualStyleBackColor = true;
            this.btnArc.Click += new System.EventHandler(this.btnArc_Click);
            // 
            // btnRect
            // 
            this.btnRect.Location = new System.Drawing.Point(8, 101);
            this.btnRect.Margin = new System.Windows.Forms.Padding(2);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(124, 26);
            this.btnRect.TabIndex = 4;
            this.btnRect.Text = "Rectangle";
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnEclipse
            // 
            this.btnEclipse.Location = new System.Drawing.Point(8, 41);
            this.btnEclipse.Margin = new System.Windows.Forms.Padding(2);
            this.btnEclipse.Name = "btnEclipse";
            this.btnEclipse.Size = new System.Drawing.Size(124, 26);
            this.btnEclipse.TabIndex = 3;
            this.btnEclipse.Text = "Ellipse";
            this.btnEclipse.UseVisualStyleBackColor = true;
            this.btnEclipse.Click += new System.EventHandler(this.btnEclipse_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(8, 10);
            this.btnLine.Margin = new System.Windows.Forms.Padding(2);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(124, 26);
            this.btnLine.TabIndex = 2;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.SystemColors.Info;
            this.panelCanvas.Location = new System.Drawing.Point(155, 28);
            this.panelCanvas.Margin = new System.Windows.Forms.Padding(2);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(600, 385);
            this.panelCanvas.TabIndex = 1;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseDown);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bạn đang chọn vẽ:";
            this.label1.Click += new System.EventHandler(this.formMain_Load);
            // 
            // labelSelection
            // 
            this.labelSelection.AutoSize = true;
            this.labelSelection.Location = new System.Drawing.Point(255, 7);
            this.labelSelection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelection.Name = "labelSelection";
            this.labelSelection.Size = new System.Drawing.Size(0, 13);
            this.labelSelection.TabIndex = 2;
            // 
            // btnRemoveSelection
            // 
            this.btnRemoveSelection.Location = new System.Drawing.Point(336, 4);
            this.btnRemoveSelection.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveSelection.Name = "btnRemoveSelection";
            this.btnRemoveSelection.Size = new System.Drawing.Size(56, 20);
            this.btnRemoveSelection.TabIndex = 3;
            this.btnRemoveSelection.Text = "Xóa";
            this.btnRemoveSelection.UseVisualStyleBackColor = true;
            this.btnRemoveSelection.Click += new System.EventHandler(this.btnRemoveSelection_Click);
            // 
            // btnRemoveShapes
            // 
            this.btnRemoveShapes.Location = new System.Drawing.Point(397, 4);
            this.btnRemoveShapes.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveShapes.Name = "btnRemoveShapes";
            this.btnRemoveShapes.Size = new System.Drawing.Size(110, 20);
            this.btnRemoveShapes.TabIndex = 4;
            this.btnRemoveShapes.Text = "Xóa tất cả hình vẽ";
            this.btnRemoveShapes.UseVisualStyleBackColor = true;
            this.btnRemoveShapes.Click += new System.EventHandler(this.btnRemoveShapes_Click);
            // 
            // dropdownColor
            // 
            this.dropdownColor.FormattingEnabled = true;
            this.dropdownColor.Location = new System.Drawing.Point(509, 4);
            this.dropdownColor.Margin = new System.Windows.Forms.Padding(2);
            this.dropdownColor.Name = "dropdownColor";
            this.dropdownColor.Size = new System.Drawing.Size(92, 21);
            this.dropdownColor.TabIndex = 5;
            this.dropdownColor.Text = "Chọn màu sắc";
            this.dropdownColor.SelectedIndexChanged += new System.EventHandler(this.dropdownColor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(604, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kích thước bút vẽ:";
            // 
            // inputWidthPen
            // 
            this.inputWidthPen.Location = new System.Drawing.Point(700, 4);
            this.inputWidthPen.Margin = new System.Windows.Forms.Padding(2);
            this.inputWidthPen.Name = "inputWidthPen";
            this.inputWidthPen.Size = new System.Drawing.Size(37, 20);
            this.inputWidthPen.TabIndex = 7;
            this.inputWidthPen.Text = "5";
            this.inputWidthPen.TextChanged += new System.EventHandler(this.inputWidthPen_TextChanged);
            this.inputWidthPen.Leave += new System.EventHandler(this.inputWidthPen_Leave);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 414);
            this.Controls.Add(this.inputWidthPen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dropdownColor);
            this.Controls.Add(this.btnRemoveShapes);
            this.Controls.Add(this.btnRemoveSelection);
            this.Controls.Add(this.labelSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelSideBar);
            this.Controls.Add(this.panelCanvas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formMain";
            this.Text = "Graphics Application";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.panelSideBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSelection;
        private System.Windows.Forms.Button btnRemoveSelection;
        private System.Windows.Forms.Button btnEclipse;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnRemoveShapes;
        private System.Windows.Forms.Button btnArc;
        private System.Windows.Forms.ComboBox dropdownColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputWidthPen;
        private System.Windows.Forms.Button btnFilledEclipse;
        private System.Windows.Forms.Button btnFilledRect;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnFilledCircle;
        private System.Windows.Forms.Button btnPolygon;
    }
}

