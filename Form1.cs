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
        int anchorSize = 10;
        private Dictionary<string, Color> colorMap;
        
        public enum ShapeType
        {
            Line,
            Ellipse,
            FilledEllipse,
            Rectangle,
            FilledRectangle,
            Circle,
            FilledCircle,
            Arc,
            Polygon
        }

        // events state management of canvas
        bool isFocusActionDrawing = true;
        private bool isDragging = false;
        private Point lastMousePosition;
        private bool isResizing = false;
        private string currentAnchor = null;

        ShapeType? selectedShapeType = null;

        DrawShape selectedShape;
        List<DrawShape> lstObject = new List<DrawShape>();
        List<DrawShape> selectedShapesGroup = new List<DrawShape>();

        public abstract class DrawShape
        {
            public Guid id = Guid.NewGuid();
            public Point p1;
            public Point p2;
            public int width;
            public Color color;
            public ShapeType type;

            public Rectangle NormalizeRect(Point a, Point b)
            {
                int x = Math.Min(a.X, b.X);
                int y = Math.Min(a.Y, b.Y);
                int width = Math.Abs(b.X - a.X);
                int height = Math.Abs(b.Y - a.Y);
                return new Rectangle(x, y, width, height);
            }

            public virtual Rectangle BoundingRect
            {
                get
                {
                    return NormalizeRect(p1, p2);
                }
            }

            public abstract void Draw(Graphics myGp, Pen myPen);
        }

        public class LineShape : DrawShape
        {
            public LineShape() { this.type = ShapeType.Line; }
            public override void Draw(Graphics myGp, Pen myPen)
            {
                myGp.DrawLine(myPen, this.p1, this.p2);
            }
        }

        public class EllipseShape : DrawShape
        {
            public EllipseShape() { this.type = ShapeType.Ellipse; }
            public override void Draw(Graphics myGp, Pen myPen)
            {
                Rectangle rect = NormalizeRect(this.p1, this.p2);
                myGp.DrawEllipse(myPen, rect);
            }
        }

        public class FilledEllipseShape : DrawShape
        {
            public FilledEllipseShape() { this.type = ShapeType.FilledEllipse; }
            public override void Draw(Graphics myGp, Pen myPen)
            {
                Rectangle rect = NormalizeRect(this.p1, this.p2);
                using (SolidBrush brush = new SolidBrush(this.color))
                {
                    myGp.FillEllipse(brush, rect);
                }
            }
        }

        public class RectShape : DrawShape
        {
            public RectShape() { this.type = ShapeType.Rectangle; }
            public override void Draw(Graphics myGp, Pen myPen)
            {
                Rectangle rect = NormalizeRect(this.p1, this.p2);
                myGp.DrawRectangle(myPen, rect);
            }
        }
        
        public class FilledRectShape : DrawShape
        {
            public FilledRectShape() { this.type = ShapeType.FilledRectangle; }
            public override void Draw(Graphics myGp, Pen myPen)
            {
                Rectangle rect = NormalizeRect(this.p1, this.p2);
                using (SolidBrush brush = new SolidBrush(this.color))
                {
                    myGp.FillRectangle(brush, rect);
                }
            }
        }

        public class ArcShape : DrawShape
        {
            public ArcShape() { this.type = ShapeType.Arc; }
            public override void Draw(Graphics myGp, Pen myPen)
            {
                Rectangle rect = NormalizeRect(this.p1, this.p2);
                float startAngle = 0;
                float sweepAngle = 180;

                if (rect.Width == 0 || rect.Height == 0)
                {
                    Console.WriteLine("Invalid arc size.");
                    return;
                }

                myGp.DrawArc(myPen, rect, startAngle, sweepAngle);
            }
        }

        public class CircleShape : DrawShape
        {
            public CircleShape() { this.type = ShapeType.Circle; }

            public override Rectangle BoundingRect
            {
                get
                {
                    int radius = Math.Min(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
                    return new Rectangle(p1.X, p1.Y, radius, radius);
                }
            }

            public override void Draw(Graphics myGp, Pen myPen)
            {
                int radius = Math.Min(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
                myGp.DrawEllipse(myPen, new Rectangle(p1.X, p1.Y, radius, radius));
            }
        }

        public class FilledCircleShape : DrawShape
        {
            public FilledCircleShape() { this.type = ShapeType.FilledCircle; }

            public override Rectangle BoundingRect
            {
                get
                {
                    int radius = Math.Min(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
                    return new Rectangle(p1.X, p1.Y, radius, radius);
                }
            }

            public override void Draw(Graphics myGp, Pen myPen)
            {
                int radius = Math.Min(Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));
                using (SolidBrush brush = new SolidBrush(this.color))
                {
                    myGp.FillEllipse(brush, new Rectangle(p1.X, p1.Y, radius, radius));
                }
            }
        }

        public class PolygonShape : DrawShape
        {
            public List<Point> Points = new List<Point>();

            public PolygonShape()
            {
                this.type = ShapeType.Polygon;
            }

            public override void Draw(Graphics myGp, Pen myPen)
            {
                int centerX = (p1.X + p2.X) / 2;
                int centerY = (p1.Y + p2.Y) / 2;
                Point center = new Point(centerX, centerY);

                int radiusX = Math.Abs(p2.X - p1.X) / 2;
                int radiusY = Math.Abs(p2.Y - p1.Y) / 2;
                int radius = Math.Min(radiusX, radiusY);

                List<Point> generatedPoints = GenerateRegularPolygon(center, radius, 5);
                if (generatedPoints.Count >= 3)
                {
                    myGp.DrawPolygon(myPen, generatedPoints.ToArray());
                }

                // Lưu lại để BoundingRect hoạt động
                this.Points = generatedPoints;
            }

            public override Rectangle BoundingRect
            {
                get
                {
                    if (Points.Count == 0) return Rectangle.Empty;
                    int minX = Points.Min(p => p.X);
                    int minY = Points.Min(p => p.Y);
                    int maxX = Points.Max(p => p.X);
                    int maxY = Points.Max(p => p.Y);
                    return new Rectangle(minX, minY, maxX - minX, maxY - minY);
                }
            }

            private List<Point> GenerateRegularPolygon(Point center, int radius, int sides)
            {
                List<Point> points = new List<Point>();
                for (int i = 0; i < sides; i++)
                {
                    double angleDeg = 360.0 / sides * i - 90; // đỉnh đầu hướng lên
                    double angleRad = angleDeg * Math.PI / 180.0;
                    int x = center.X + (int)(radius * Math.Cos(angleRad));
                    int y = center.Y + (int)(radius * Math.Sin(angleRad));
                    points.Add(new Point(x, y));
                }
                return points;
            }

        }

        public formMain()
        {
            InitializeComponent();
            InitializeUI();
            gp = this.panelCanvas.CreateGraphics();
            selectedColor = Color.Blue;
            widthPen = 5;
            myPen = new Pen(selectedColor, widthPen);

            this.KeyDown += formMain_KeyDown;
            this.KeyPreview = true;
        }
        private void formMain_KeyDown(object sender, KeyEventArgs e)
        {
            
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

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in lstObject)
            {
                using (Pen pen = new Pen(shape.color, shape.width))
                {
                    shape.Draw(e.Graphics, pen);
                }

                // Bounding box
                var rect = shape.BoundingRect;
                if (shape == selectedShape)
                {
                    using (Pen redPen = new Pen(Color.Red, 1))
                    {
                        redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawRectangle(redPen, rect);
                    }

                    // Draw 4 corner anchors
                    DrawAnchor(e.Graphics, rect.Left, rect.Top, anchorSize);
                    DrawAnchor(e.Graphics, rect.Right, rect.Top, anchorSize);
                    DrawAnchor(e.Graphics, rect.Left, rect.Bottom, anchorSize);
                    DrawAnchor(e.Graphics, rect.Right, rect.Bottom, anchorSize);
                }
                else
                {
                    // Optional: transparent border for unselected (no need to draw anything)
                }
            }
        }

        private void DrawAnchor(Graphics g, int x, int y, int size)
        {
            Rectangle anchor = new Rectangle(x - size / 2, y - size / 2, size, size);
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                g.FillRectangle(brush, anchor);
            }
        }

        private string HitTestAnchor(Point mouse, Rectangle rect)
        {
            Rectangle topLeft = new Rectangle(rect.Left - anchorSize / 2, rect.Top - anchorSize / 2, anchorSize, anchorSize);
            Rectangle topRight = new Rectangle(rect.Right - anchorSize / 2, rect.Top - anchorSize / 2, anchorSize, anchorSize);
            Rectangle bottomLeft = new Rectangle(rect.Left - anchorSize / 2, rect.Bottom - anchorSize / 2, anchorSize, anchorSize);
            Rectangle bottomRight = new Rectangle(rect.Right - anchorSize / 2, rect.Bottom - anchorSize / 2, anchorSize, anchorSize);

            if (topLeft.Contains(mouse)) return "TopLeft";
            if (topRight.Contains(mouse)) return "TopRight";
            if (bottomLeft.Contains(mouse)) return "BottomLeft";
            if (bottomRight.Contains(mouse)) return "BottomRight";
            return null;
        }
        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.isFocusActionDrawing = false;

            // 1. check if has selected shape check the hit position is anchor or not
            if (this.selectedShape != null)
            {
                string anchorHit = HitTestAnchor(e.Location, this.selectedShape.BoundingRect);
                if (anchorHit != null)
                {
                    this.isResizing = true;
                    this.currentAnchor = anchorHit;
                    this.lastMousePosition = e.Location;
                    return;
                }
            }

            // 2. check if the position clicked by cursor included of shape
            // -> active bounding box of selected shape
            for (int i = lstObject.Count - 1; i >= 0; i--)
            {
                var shape = lstObject[i];
                if (shape.BoundingRect.Contains(e.Location))
                {
                    this.isDragging = true;
                    this.lastMousePosition = e.Location;
                    this.selectedShape = shape;
                    panelCanvas.Refresh(); // refresh canvas with selected shape
                    return;
                }
            }

            // 2. check if click empty then implement draw function
            if (this.selectedShapeType == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn hình vẽ để bắt đầu vẽ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            else
            {
                this.isFocusActionDrawing = true;
                DrawShape myObj = null;
                if (this.selectedShapeType == ShapeType.Line)
                    myObj = new LineShape();
                else if (this.selectedShapeType == ShapeType.Ellipse)
                    myObj = new EllipseShape();
                else if (this.selectedShapeType == ShapeType.FilledEllipse)
                    myObj = new FilledEllipseShape();
                else if (this.selectedShapeType == ShapeType.Rectangle)
                    myObj = new RectShape();
                else if (this.selectedShapeType == ShapeType.FilledRectangle)
                    myObj = new FilledRectShape();
                else if (this.selectedShapeType == ShapeType.Circle)
                    myObj = new CircleShape();
                else if (this.selectedShapeType == ShapeType.FilledCircle)
                    myObj = new FilledCircleShape();
                else if (this.selectedShapeType == ShapeType.Arc)
                    myObj = new ArcShape();
                else if (this.selectedShapeType == ShapeType.Polygon)
                    myObj = new PolygonShape();

                if (myObj != null)
                {
                    myObj.p1 = e.Location;
                    myObj.p2 = e.Location;
                    myObj.color = selectedColor;
                    myObj.width = widthPen;
                    lstObject.Add(myObj);
                }
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // zoom in/zoom out shape by drag anchor
            if (!this.isFocusActionDrawing && this.isResizing && this.selectedShape != null && this.currentAnchor != null)
            {
                Point delta = new Point(e.X - lastMousePosition.X, e.Y - lastMousePosition.Y);
                lastMousePosition = e.Location;

                Point newP1 = selectedShape.p1;
                Point newP2 = selectedShape.p2;

                switch (currentAnchor)
                {
                    case "TopLeft":
                        newP1 = new Point(selectedShape.p1.X + delta.X, selectedShape.p1.Y + delta.Y);
                        break;
                    case "TopRight":
                        newP2 = new Point(selectedShape.p2.X + delta.X, selectedShape.p2.Y);
                        newP1 = new Point(selectedShape.p1.X, selectedShape.p1.Y + delta.Y);
                        break;
                    case "BottomLeft":
                        newP1 = new Point(selectedShape.p1.X + delta.X, selectedShape.p1.Y);
                        newP2 = new Point(selectedShape.p2.X, selectedShape.p2.Y + delta.Y);
                        break;
                    case "BottomRight":
                        newP2 = new Point(selectedShape.p2.X + delta.X, selectedShape.p2.Y + delta.Y);
                        break;
                }

                selectedShape.p1 = newP1;
                selectedShape.p2 = newP2;

                panelCanvas.Refresh();
                return;
            }

            // drag/drop selected shape
            if (!this.isFocusActionDrawing && this.isDragging && this.selectedShape != null)
            {
                int dx = e.X - lastMousePosition.X;
                int dy = e.Y - lastMousePosition.Y;

                selectedShape.p1 = new Point(selectedShape.p1.X + dx, selectedShape.p1.Y + dy);
                selectedShape.p2 = new Point(selectedShape.p2.X + dx, selectedShape.p2.Y + dy);

                lastMousePosition = e.Location;
                panelCanvas.Refresh();
            }
            
            // drawing shape to canvas
            if (this.isFocusActionDrawing && this.selectedShapeType != null && this.lstObject.Count > 0)
            {
                DrawShape currentShape = this.lstObject[lstObject.Count - 1];
                currentShape.p2 = e.Location;
                panelCanvas.Refresh();
            }
        }
        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isFocusActionDrawing == true)
            {
                this.isFocusActionDrawing = false;
                this.lstObject[this.lstObject.Count - 1].p2 = e.Location;
                this.panelCanvas.Refresh();
            }
            if (!this.isFocusActionDrawing && this.isResizing)
            {
                this.isResizing = false;
                this.currentAnchor = null;
            }
            if (!this.isFocusActionDrawing && this.isDragging)
            {
                this.isDragging = false;
            }
        }

        private void btnRemoveSelection_Click(object sender, EventArgs e)
        {
            labelSelection.Text = "";
            this.isFocusActionDrawing = false;
            this.selectedShapeType = null;
        }

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

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.Line;
            labelSelection.Text = btnLine.Text;
        }

        private void btnEclipse_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.Ellipse;
            labelSelection.Text = btnEclipse.Text;
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.Rectangle;
            labelSelection.Text = btnRect.Text;
        }

        private void btnArc_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.Arc;
            labelSelection.Text = btnArc.Text;
        }

        private void btnRemoveShapes_Click(object sender, EventArgs e)
        {
            this.lstObject.Clear();
            this.selectedShape = null;
            panelCanvas.Refresh();
        }
        
        private void btnFilledEclipse_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.FilledEllipse;
            labelSelection.Text = btnFilledEclipse.Text;
        }

        private void btnFilledRect_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.FilledRectangle;
            labelSelection.Text = btnFilledRect.Text;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.Circle;
            labelSelection.Text = btnCircle.Text;
        }

        private void btnFilledCircle_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.FilledCircle;
            labelSelection.Text = btnFilledCircle.Text;
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            this.selectedShapeType = ShapeType.Polygon;
            labelSelection.Text = btnPolygon.Text;
        }
    }
}
