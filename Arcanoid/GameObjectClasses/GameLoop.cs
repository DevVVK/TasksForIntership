using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Arcanoid.CollisionClasses;
using Arcanoid.ExceptionClasses;
using Arcanoid.Interfaces;

namespace Arcanoid.GameObjectClasses
{
    public class GameLoop
    {
        private readonly Platform _platform;

        private readonly Ball _ball;

        private readonly PictureBox _canvas;
        
        private List<GameObject> _blocks;

        private readonly ICollisionBall _hanlerCollisionBall;

        public int CountLivesBall
        {
            get => _ball.CountLives;
            set => _ball.CountLives = value;
        }

        public int CountBlocks { get; set; }

        public GameLoop(PictureBox canvas, int countBlocks, int countLivesBall)
        {
            _canvas = canvas;

            _platform = new Platform(new Size(150, 50), new Point(_canvas.Width - _canvas.Width / 2, _canvas.Bottom - 30), Color.AliceBlue);

            _ball = new Ball(new Size(20, 20), new Point(_platform.Position.X + _platform.Size.Width / 2, _platform.Position.Y - 20), Color.Coral, countLivesBall);

            SetGameObjectToCanvas(_platform);
            SetGameObjectToCanvas(_ball);

            CountBlocks = countBlocks;
            InitializeBlocks(CountBlocks, new Size(100, 40));

            _updateGame.Interval = 1000 / 60;
            _updateGame.Tick += UpdateGame_tick;

            _hanlerCollisionBall = new CollisionBallAndCanvas();
        }

        #region Инициализация поля блоками

        /// <summary>
        /// Расчитывает координаты точек сетки по размеру блоков и размеру игрового поля
        /// </summary>
        /// <param name="sizeBlock">размер блококов</param>
        /// <returns>координаты точек сетки </returns>
        private List<Point> SetGridForBlocks(Size sizeBlock)
        {
            var pointsGrid = new List<Point>();

            var width = sizeBlock.Width;
            var heigth = sizeBlock.Height;

            for (var i = heigth; i < _canvas.Height / 2 - heigth; i += heigth + 5)
            {
                for (var j = width; j < _canvas.Width - width; j += width + 5)
                {
                    pointsGrid.Add(new Point(j, i));
                }
            }

            return pointsGrid;
        }

        private static readonly Random RandGenerator = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Выбирает случайную точку сетки
        /// </summary>
        /// <param name="pointsGrid">список точек сетки</param>
        /// <returns>точка сетки</returns>
        private Point GetRandomPoint(List<Point> pointsGrid)
        {
            return pointsGrid[RandGenerator.Next(0, pointsGrid.Count)];
        }

        /// <summary>
        /// Инициализирует игровое поле блоками
        /// </summary>
        /// <param name="countBlocks">количество блоков</param>
        /// <param name="sizeBlocks">размер блоков</param>
        private void InitializeBlocks(int countBlocks, Size sizeBlocks)
        {
            var pointGrid = SetGridForBlocks(sizeBlocks);

            if (countBlocks * sizeBlocks.Width * sizeBlocks.Height > _canvas.Width * _canvas.Height / 2)
            {
                throw new InvalidSizeException();
            }

            _blocks = new List<GameObject>(countBlocks);

            for (var i = 0; i < countBlocks; i++)
            {
                var randomPoint = GetRandomPoint(pointGrid);
                _blocks.Add(new Block(sizeBlocks, randomPoint, Color.Gold));
                SetGameObjectToCanvas(_blocks[i]);
                pointGrid.Remove(randomPoint);
            }
        }

        /// <summary>
        /// Добавляет игровой обьект на полотно
        /// </summary>
        /// <param name="gameObject">игровой обьект</param>
        private void SetGameObjectToCanvas(GameObject gameObject)
        {
            _canvas.Controls.Add(gameObject.RenderGameObject());
        }

        /// <summary>
        /// Удаляет игровой обьект из полотна
        /// </summary>
        /// <param name="gameObject">игровой обьект</param>
        private void RemoveGameObject(GameObject gameObject)
        {
            _canvas.Controls.Remove(gameObject.RenderGameObject());
        }

        #endregion

        #region логика

        private Keys? _keyPressed;

        /// <summary>
        /// Свойство принимающая значение нажатой клавишы
        /// </summary>
        public Keys? KeyPressed
        {
            get => _keyPressed;
            set
            {
                _keyPressed = value;

                if (_keyPressed == Keys.Space)
                {
                    _updateGame.Start();
                }

                if (_keyPressed == Keys.Left)
                {
                    if (_platform.SpeedVector.X > 0)
                    {
                        _platform.SpeedVector = new Point(-1 * _platform.SpeedVector.X, 0);
                    }
                }

                if (_keyPressed != Keys.Right) return;

                if (_platform.SpeedVector.X < 0)
                {
                    _platform.SpeedVector = new Point(-1 * _platform.SpeedVector.X, 0);
                }
            }
        }

        private readonly Timer _updateGame = new Timer();

        /// <summary>
        /// Игровой цикл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateGame_tick(object sender, EventArgs e)
        {
            for (var i = 0; i < _blocks.Count; i++)
            {
                var block = _blocks[i];

                block.ReactionToCollisions(_ball);

                if (block.IsCollision)
                {
                    RemoveGameObject(block);
                }

                var countControls = _canvas.Controls.Count - 2;

                if (countControls < _blocks.Count)
                {
                    _blocks.Remove(block);
                }
            }

            _platform.ReactionToCollisions(_ball);

            _hanlerCollisionBall.DetectCollision(_canvas, _ball);

            _ball.MovementGameObject();

            if (_keyPressed != Keys.Left && _keyPressed != Keys.Right) return;

            if (_platform.Position.X > _canvas.Location.X && _platform.SpeedVector.X < 0 ||
                _platform.Position.X + _platform.Size.Width < _canvas.Width && _platform.SpeedVector.X > 0)
            {
                _platform.MovementGameObject();
            }
        }

        #endregion
    }
} 