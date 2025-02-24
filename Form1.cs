using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphicsApp
{
    public partial class formMain : Form
    {
        Graphics gp;
        Pen myPen;

        Color selectedColor;
        int widthPen;
        private Dictionary<string, Color> colorMap;

        bool isPress = true; // a flag

        bool isSelectedLine = false;
        bool isSelectedRect = false;
        bool isSelectedEcllipse = false;
        bool isSelectedArc = false;
        bool isSelectedShape
        {
            get
            {
                return this.isSelectedLine
                    || this.isSelectedRect
                    || this.isSelectedEcllipse
                    || this.isSelectedArc;
            }
        }

        List<DrawShape> lstObject = new List<DrawShape>();

        DrawShape selectedShape = null;
        List<DrawShape> selectedShapesGroup = new List<DrawShape>();

        public formMain()
        {
            InitializeComponent();
            InitializeUI();
            gp = this.panelCanvas.CreateGraphics();
            selectedColor = Color.Blue;
            widthPen = 5;
            myPen = new Pen(selectedColor, widthPen);
        }

        private void InitializeUI()
        {
            dropdownColor.DropDownStyle = ComboBoxStyle.DropDownList;
            colorMap = new Dictionary<string, Color>
            {
                { "Xanh Dương", Color.Blue },
                { "Đỏ", Color.Red },
                { "Xanh Lá", Color.Green },
                { "Vàng", Color.Yellow },
                { "Đen", Color.Black },
                { "Trắng", Color.White },
                { "Xám", Color.Gray },
                { "Tím", Color.Purple },
                { "Hồng", Color.Pink },
                { "Cam", Color.Orange },
            };

            foreach (var color in colorMap.Keys)
            {
                dropdownColor.Items.Add(color);
            }
            dropdownColor.SelectedIndex = 0;
        }

        private void formMain_Load(object sender, EventArgs e) { }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.isSelectedLine = true;
            this.isSelectedRect = false;
            this.isSelectedEcllipse = false;
            this.isSelectedArc = false;
            labelSelection.Text = btnLine.Text;
        }

        private void btnEclipse_Click(object sender, EventArgs e)
        {
            this.isSelectedEcllipse = true;
            this.isSelectedLine = false;
            this.isSelectedRect = false;
            this.isSelectedArc = false;
            labelSelection.Text = btnEclipse.Text;
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            this.isSelectedRect = true;
            this.isSelectedLine = false;
            this.isSelectedEcllipse = false;
            this.isSelectedArc = false;
            labelSelection.Text = btnRect.Text;
        }

        private void btnArc_Click(object sender, EventArgs e)
        {
            this.isSelectedArc = true;
            this.isSelectedLine = false;
            this.isSelectedEcllipse = false;
            this.isSelectedRect = false;
            labelSelection.Text = btnArc.Text;
        }

        private void btnRemoveShapes_Click(object sender, EventArgs e)
        {
            this.lstObject.Clear();
            panelCanvas.Refresh();
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in lstObject)
            {
                using (Pen pen = new Pen(shape.color, shape.width))
                {
                    shape.Draw(e.Graphics, pen);
                }
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isPress == true && this.lstObject.Count > 0)
            {
                this.lstObject[this.lstObject.Count - 1].p2 = e.Location;
                this.panelCanvas.Refresh();
            }
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.isPress = true;
            if (!isSelectedShape)
            {
                MessageBox.Show(
                    "Vui lòng chọn hình vẽ để bắt đầu vẽ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (isSelectedShape)
            {
                DrawShape myObj = null;

                if (isSelectedLine)
                    myObj = new LineShape();
                if (isSelectedEcllipse)
                    myObj = new EllipseShape();
                if (isSelectedRect)
                    myObj = new RectShape();
                if (isSelectedArc)
                    myObj = new ArcShape();
                if (myObj != null)
                {
                    myObj.p1 = e.Location;
                    myObj.color = selectedColor;
                    myObj.width = widthPen;
                    lstObject.Add(myObj);
                }
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.isPress = false;
            this.lstObject[this.lstObject.Count - 1].p2 = e.Location;
            this.panelCanvas.Refresh();
            // this.isSelectedRect = false;
            // this.isSelectedEcllipse = false;
            // this.isSelectedLine = false;
        }

        private void btnRemoveSelection_Click(object sender, EventArgs e)
        {
            labelSelection.Text = "";
            isPress = false;
            isSelectedLine = false;
            isSelectedEcllipse = false;
            isSelectedRect = false;
        }

        public abstract class DrawShape
        {
            public Point p1;
            public Point p2;
            public int width;
            public Color color;

            public Rectangle boundingRect
            {
                get
                {
                    int x = Math.Min(p1.X, p2.X);
                    int y = Math.Min(p1.Y, p2.Y);
                    int width = Math.Abs(p2.X - p1.X);
                    int height = Math.Abs(p2.Y - p1.Y);
                    return new Rectangle(x, y, width, height);
                }
            }
            public abstract void Draw(Graphics myGp, Pen myPen);
        };

        public class LineShape : DrawShape
        {
            public override void Draw(Graphics myGp, Pen myPen)
            {
                myGp.DrawLine(myPen, this.p1, this.p2);
            }
        };

        public class EllipseShape : DrawShape
        {
            public override void Draw(Graphics myGp, Pen myPen)
            {
                myGp.DrawEllipse(
                    myPen,
                    this.p1.X,
                    this.p1.Y,
                    this.p2.X - this.p1.X,
                    this.p2.Y - this.p1.Y
                );
            }
        };

        public class RectShape : DrawShape
        {
            public override void Draw(Graphics myGp, Pen myPen)
            {
                myGp.DrawRectangle(myPen, this.p1.X, this.p1.Y, this.p2.X, this.p2.Y);
            }
        };

        public class ArcShape : DrawShape
        {
            public override void Draw(Graphics myGp, Pen myPen)
            {
                int x = Math.Min(this.p1.X, this.p2.X);
                int y = Math.Min(this.p1.Y, this.p2.Y);
                int width = Math.Abs(this.p2.X - this.p1.X);
                int height = Math.Abs(this.p2.Y - this.p1.Y);

                float startAngle = 0;
                float sweepAngle = 180;
                if (width == 0 || height == 0)
                {
                    Console.WriteLine("invalid width, height arc.");
                    return;
                }

                myGp.DrawArc(myPen, x, y, width, height, startAngle, sweepAngle);
            }
        };

        private void dropdownColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColor = dropdownColor.SelectedItem.ToString();
            this.selectedColor = colorMap[selectedColor];
        }

        private void inputWidthPen_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputWidthPen.Text))
            {
                return;
            }

            if (int.TryParse(inputWidthPen.Text, out int value) && value > 0)
            {
                this.widthPen = value;
            }
            else
            {
                MessageBox.Show(
                    "Giá trị nhập sai! Vui lòng nhập số nguyên dương.",
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void inputWidthPen_Leave(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(inputWidthPen.Text)
                || !int.TryParse(inputWidthPen.Text, out int value)
                || value <= 0
            )
            {
                inputWidthPen.Text = this.widthPen.ToString();
            }
        }
    }
}
