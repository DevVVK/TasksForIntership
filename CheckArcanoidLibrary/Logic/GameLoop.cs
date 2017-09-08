using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Arcanoid.GameObjects;
using CheckArcanoidLibrary.ExceptionClasses;
using CheckArcanoidLibrary.Models;
using CheckArcanoidLibrary.Properties;
using CheckArcanoidLibrary.Serialization;
using Microsoft.Xna.Framework;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;

namespace CheckArcanoidLibrary.Logic
{
    public class GameLoop
    {
        #region Инициализация

        private readonly Canvas _canvas;
        private readonly Platform _platform;
        private readonly Ball _ball;

        private readonly PictureBox _pbxCanvas;
        private readonly PictureBox _pbxPlatform;
        private readonly PictureBox _pbxBall;

        private int CountLivesBall
        {
            set => _lblCountLivesBall.Text = $@"Количество жизней - {Convert.ToString(value)}";
        }

        private int Time
        {
            set => _lblTime.Text = $@"Время - {Convert.ToString(value)} / c";
        }

        private readonly Label _lblCountLivesBall;

        private readonly Label _lblTime;

        private readonly KeyListener _keyListener;

        public int CountBlocks { get; set; }

        public GameLoop(Control canvas, int countBlocks, int countLivesBall, KeyListener keyListener)
        {
            _keyListener = keyListener;

            _canvas = new Canvas(new Point(0,0), new Size(canvas.Size.Width, canvas.Size.Height));

            _platform = new Platform(new Point(_canvas.Size.Width - _canvas.Size.Width / 2, _canvas.Size.Height - 15), new Size(150, 10), new Vector2(10, 0));

            _ball = new Ball(new Point(_platform.Position.X + _platform.Size.Width / 2, _platform.Position.Y - 15), new Size(15, 15), new Vector2(5, 5), countLivesBall);

            _lblCountLivesBall = new Label
            {
                Location = new Point(_canvas.Position.X + 10, _canvas.Size.Height - 100),
                AutoSize = true,
                ForeColor = Color.White
            };

            _lblTime = new Label
            {
                Location = new Point(_lblCountLivesBall.Location.X, _lblCountLivesBall.Location.Y - 20),
                AutoSize = true,
                ForeColor = Color.White
            };

            _pbxCanvas = new PictureBox
            {
                Location = _canvas.Position,
                Size = _canvas.Size,
                BackColor = Color.DimGray
            };

            _pbxPlatform = new PictureBox
            {
                Location = _platform.Position,
                Size = _platform.Size,
                BackColor = Color.Azure
            };

            _pbxBall = new PictureBox
            {
                Location = _ball.Position,
                Size = _ball.Size,
                Image = DrawCircle()
            };

            SetGameObjectToCanvas(_pbxPlatform);
            SetGameObjectToCanvas(_pbxBall);
            SetGameObjectToCanvas(_lblCountLivesBall);
            SetGameObjectToCanvas(_lblTime);
            CountLivesBall = 5;
            Time = 0;

            CountBlocks = countBlocks;
            InitializeBlocks(CountBlocks, new Size(100, 30));

            _updateGame.Interval = 1000 / 60;
            _updateGame.Tick += UpdateGame_tick;

            _renderGame.Interval = 1000 / 60;
            _renderGame.Tick += RenderGame_tick;

            canvas.Controls.Add(_pbxCanvas);
        }

        private Image DrawCircle()
        {
            var ballBitmap = new Bitmap(_ball.Size.Width, _ball.Size.Height);
            var ballGraphics = Graphics.FromImage(ballBitmap);
            var ballRectangle = new Rectangle(0, 0, _ball.Size.Width, _ball.Size.Height);
            var ballBrush = new SolidBrush(Color.Red);

            ballGraphics.FillEllipse(ballBrush, ballRectangle);

            return ballBitmap;
        }
        
        #endregion

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

            for (var i = heigth; i < _canvas.Size.Height / 2 - heigth; i += heigth + 5)
            {
                for (var j = width; j < _canvas.Size.Width - width; j += width + 5)
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

        private Block _block;

        private List<PictureBox> _pbxBlocks;

        private List<Block> _blocks;
        /// <summary>
        /// Инициализирует игровое поле блоками
        /// </summary>
        /// <param name="countBlocks">количество блоков</param>
        /// <param name="sizeBlocks">размер блоков</param>
        private void InitializeBlocks(int countBlocks, Size sizeBlocks)
        {
            var pointGrid = SetGridForBlocks(sizeBlocks);

            if (countBlocks * sizeBlocks.Width * sizeBlocks.Height > _canvas.Size.Width * _canvas.Size.Height / 2)
            {
                throw new InvalidSizeException();
            }

            _pbxBlocks = new List<PictureBox>(countBlocks);
            _blocks = new List<Block>(countBlocks);

            for (var i = 0; i < countBlocks; i++)
            {
                var randomPoint = GetRandomPoint(pointGrid);

                _block = new Block(randomPoint, sizeBlocks);

                _blocks.Add(_block);

                var blockPictureBox = new PictureBox
                {
                    Location = _block.Position,
                    Size = _block.Size,
                    BackColor = Color.Chartreuse
                };

                _pbxBlocks.Add(blockPictureBox);

                SetGameObjectToCanvas(_pbxBlocks[i]);

                pointGrid.Remove(randomPoint);
            }
        }

        /// <summary>
        /// Добавляет игровой обьект на полотно
        /// </summary>
        /// <param name="gameObject">игровой обьект</param>
        private void SetGameObjectToCanvas(Control gameObject)
        {
            _pbxCanvas.Controls.Add(gameObject);
        }

        /// <summary>
        /// Удаляет игровой обьект из полотна
        /// </summary>
        /// <param name="gameObject">игровой обьект</param>
        private void RemoveGameObject(Control gameObject)
        {
            _pbxCanvas.Controls.Remove(gameObject);
        }

        #endregion

        #region логика

        public void StartGame()
        {
            _updateGame.Start();
            _renderGame.Start();
        }

        public void Pause()
        {
            _updateGame.Stop();
            _renderGame.Stop();
        }

        /// <summary>
        /// Свойство принимающая значение нажатой клавишы
        /// </summary>

        private readonly JsonSerializer<UserListModel> _serializer = new JsonSerializer<UserListModel>(Resources.FilePathUsers);

        /// <summary>
        /// Добавляет данные в статистику
        /// </summary>
        private void AddPlayesStatistic()
        {
            var user = new UserModel
            {
                Name = Properties.Settings.Default.User,
                Time = _time
            };

            var userList = new UserListModel();

            if (!_serializer.ExistsFile())
            {
                userList.Users.Add(user);
                _serializer.Serialize(userList);
            }
            else
            {
                userList = _serializer.Deserialize();

                if (CheckUser(user))
                {
                    var index = userList.Users.FindIndex(el => el.Name == user.Name);
                    userList.Users[index] = user;

                    _serializer.Serialize(userList);
                }
                else
                {
                    userList.Users.Add(user);
                    _serializer.Serialize(userList);    
                }
            }
        }

        /// <summary>
        /// Проверяет имеется ли пользователь с данным именем в файле
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <returns>если имеется пользователь то true, иначе false</returns>
        private bool CheckUser(UserModel user)
        {
            return _serializer.Deserialize().Users.Any(element => element.Name == user.Name);
        }

        private int _time;

        private double _tempTime;

        private readonly Timer _renderGame = new Timer();

        private readonly Timer _updateGame = new Timer();

        /// <summary>
        /// Перерисовывает обьект на игровом поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenderGame_tick(object sender, EventArgs e)
        {
            _pbxBall.Location = _ball.Position;

            _pbxPlatform.Location = _platform.Position;
        }

        /// <summary>
        /// Двигает обьект на игровом поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateGame_tick(object sender, EventArgs e)
        {
            for (var i = 0; i < _pbxBlocks.Count; i++)
            {
                var block = _blocks[i];
                var pbxBlock = _pbxBlocks[i];

                block.ReactionCollisionBall(_ball);

                if (!block.IsCollision) continue;

                _blocks.Remove(block);
                _pbxBlocks.Remove(pbxBlock);
                RemoveGameObject(pbxBlock);
            }

            _tempTime += 25;

            if (_tempTime >= 1000)
            {
                Time = _time += 1;
                _tempTime = 0;
            }

            if (_ball.CountLives > 0 && _blocks.Count == 0)
            {
                AddPlayesStatistic();
                _renderGame.Stop();
                _updateGame.Stop();
            }

            _platform.ReactionCollisionBall(_ball);
            _canvas.ReactionCollisionBall(_ball);

            CountLivesBall = _ball.CountLives;

            if (_ball.CountLives == 0)
            {
                _renderGame.Stop();
                _updateGame.Stop();
            }

            _ball.Move();

            if (_keyListener.ListKeys.Contains(Keys.Left))
            {
                if (_platform.SpeedVector.X > 0)
                {
                    _platform.SpeedVector = new Vector2(-_platform.SpeedVector.X, _platform.SpeedVector.Y);
                }
            }

            if (_keyListener.ListKeys.Contains(Keys.Right))
            {
                if (_platform.SpeedVector.X < 0)
                {
                    _platform.SpeedVector = new Vector2(-_platform.SpeedVector.X, _platform.SpeedVector.Y);
                }
            }

            if (_keyListener.ListKeys.Contains(Keys.Right) || _keyListener.ListKeys.Contains(Keys.Left))
            {
                if (_platform.Position.X > _canvas.Position.X && _platform.SpeedVector.X < 0 ||
                _platform.Position.X + _platform.Size.Width < _canvas.Size.Width && _platform.SpeedVector.X > 0)
                {
                    _platform.Move();
                }
            }
        }

        #endregion
    }
}