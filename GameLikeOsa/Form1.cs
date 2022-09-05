using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLikeOsa
{
    public partial class Form1 : Form
    {
        public Bitmap HandlerTexture = Resource1.basketball1,
                      TargetTexture = Resource1.tennis;

        private Point _targetPosition = new Point(300, 300);
        private Point _direction = Point.Empty;
        private int _score = 0;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            UpdateStyles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            timer2.Interval = random.Next(25, 1000);
            _direction.X = random.Next(-1, 2);
            _direction.Y = random.Next(-1, 2);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var localPosition = this.PointToClient(Cursor.Position);

            _targetPosition.X += _direction.X * 10;
            _targetPosition.Y += _direction.Y * 10;


            if (_targetPosition.X < 0 || _targetPosition.X > 500)
            {
                _direction.X *= -1;
            }

            if (_targetPosition.Y < 0 || _targetPosition.Y > 500)
            {
                _direction.Y *= -1;
            }


            Point between = new Point(localPosition.X - _targetPosition.X, localPosition.Y - _targetPosition.Y);
            double distance = Math.Sqrt(between.X * between.X + between.Y * between.Y);

            if (distance < 20)
            {
                AddScore();
            }

            var HandlerRectangle = new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100, 100);

            var TargetRetangle = new Rectangle(_targetPosition.X - 50, _targetPosition.Y - 50, 100, 100);

            g.DrawImage(TargetTexture, HandlerRectangle);
            g.DrawImage(HandlerTexture, TargetRetangle);
        }

     

        private void AddScore()
        {
            _score ++;
            scoreNum.Value = _score;
        }
    }
}
