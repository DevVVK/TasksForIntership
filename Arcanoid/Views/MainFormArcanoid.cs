using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Arcanoid.ClassesArcanoid;

namespace Arcanoid.Views
{
    public partial class MainFormArcanoid : Form
    {
        private GameObject _platform;

        private GameObject _ball;

        private GameObject[] _blocks;

        public MainFormArcanoid()
        {
            InitializeComponent();
            InitializeCanvas();
        }
        
        private void InitializeCanvas()
        {
            _platform = new Platform(new Size(140, 50), 
                                     new Point(pbxCanvasArcanoid.Width - pbxCanvasArcanoid.Width / 2, pbxCanvasArcanoid.Bottom - 30), 
                                     Color.AliceBlue, 10);

            _ball = new Ball(new Size(20,20), 
                             new Point(pbxCanvasArcanoid.Width - pbxCanvasArcanoid.Width / 2 + 55, pbxCanvasArcanoid.Bottom - 60),  
                             Color.Red, 5);

            _platform.SetGameObjectToCanvas(pbxCanvasArcanoid);

            _ball.SetGameObjectToCanvas(pbxCanvasArcanoid);

            InitializeBlocks(10, new Size(100, 50));
        }

        private static readonly Random RandGenerator = new Random(Guid.NewGuid().GetHashCode());

        private List<Point> SetGridForBlocks(Size sizeBlock)
        {
            var pointsGrid = new List<Point>();

            var width = sizeBlock.Width;
            var heigth = sizeBlock.Height;

            for (var i = heigth; i < pbxCanvasArcanoid.Height / 2 - heigth; i += (heigth + 30))
            {
                for (var j = width; j < pbxCanvasArcanoid.Width - width; j += (width + 30))
                {
                    pointsGrid.Add(new Point(j, i));
                }
            }
           
            return pointsGrid;
        }

        private Point GetRandomPoint(List<Point> pointsGrid)
        {
            return pointsGrid[RandGenerator.Next(0, pointsGrid.Count)];
        }

        private void InitializeBlocks(int countBlocks, Size sizeBlocks)
        {
            var pointGrid = SetGridForBlocks(sizeBlocks);

            if (countBlocks * sizeBlocks.Width * sizeBlocks.Height > pbxCanvasArcanoid.Width * pbxCanvasArcanoid.Height / 2)
            {
                throw new InvalidSizeException();
            }

            _blocks = new GameObject[countBlocks];

            for (var i = 0; i < countBlocks; i++)
            {
                var randomPoint = GetRandomPoint(pointGrid);
                _blocks[i] = new Block(sizeBlocks, randomPoint, Color.Gold);
                _blocks[i].SetGameObjectToCanvas(pbxCanvasArcanoid);
                pointGrid.Remove(randomPoint);
            }
        }

        private void MainFormArcanoid_Load(object sender, EventArgs e)
        {

        }

        private void MainFormArcanoid_KeyDown(object sender, KeyEventArgs e)
        {
            KeyCommand = e.KeyCode;

            if (KeyCommand == Keys.Space)
            {
                tmrForMoveBall.Start();
            }

            if (KeyCommand == Keys.Left)
            {
                 _platform.VectorMove = new Point(-1, 0);
            }

            if (KeyCommand == Keys.Right)
            {
                 _platform.VectorMove = new Point(1, 0);
            }

            tmrForMoveWithoutDelay.Start();
        }

        private void MainFormArcanoid_KeyUp(object sender, KeyEventArgs e)
        {
            tmrForMoveWithoutDelay.Stop();
        }

        private Keys KeyCommand { get; set; }

        private void timerForMoveWithoutDelay_Tick(object sender, EventArgs e)
        {
            if (KeyCommand == Keys.Left && _platform.PointObject.X > 0 || 
                KeyCommand == Keys.Right && _platform.PointObject.X + 
                _platform.SizeObject.Width < pbxCanvasArcanoid.Width)
            {
                _platform.MovementGameObject();
            }
        }

        private void tmrForMoveBall_Tick(object sender, EventArgs e)
        {
            foreach (var block in _blocks)
            {
                block.DetectCollisions(_ball);
            }

            _platform.DetectCollisions(_ball);

            _ball.MovementGameObject();
        }
    }
}
