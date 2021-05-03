using System;
using System.Collections.Generic;
using Hx002;
using Hx002.Framework;
using Hx002.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_VS2019_Hx002_Physicstest
{
    public class IDE : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private string code = "Test";
        private List<string> _codelines = new List<string>();
        private int _currentLine = 0;

        private Vector3 _cameraPosition = new Vector3(0, 0, 0);
        private float _scale = 0.25f;

        private SpriteFont _defaultFont;
        private Texture2D _sheet;

        private Dictionary<string, Texture2D> _textureAtlas = new Dictionary<string, Texture2D>();

        public IDE()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 16);
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += OnResize;
        }

        public void OnResize(Object sender, EventArgs e)
        {

        }

        protected override void Initialize()
        {
            Hx.Initialize(this);

            if (HxInput.IsGamePadConnected(PlayerIndex.One))
            {
                Console.WriteLine("GamePad connected...");
            }

            _codelines.Add("");
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _defaultFont = Content.Load<SpriteFont>("DefaultFont");
            _sheet = Content.Load<Texture2D>("sheet");
            
            _textureAtlas.Add("A", Hx.CutTexture(_sheet, 128 * 0, 128 * 0, 128, 128));
            _textureAtlas.Add("B", Hx.CutTexture(_sheet, 128 * 1, 128 * 0, 128, 128));
            _textureAtlas.Add("X", Hx.CutTexture(_sheet, 128 * 2, 128 * 0, 128, 128));
            _textureAtlas.Add("Y", Hx.CutTexture(_sheet, 128 * 3, 128 * 0, 128, 128));
            
            _textureAtlas.Add("U", Hx.CutTexture(_sheet, 128 * 1, 128 * 2, 128, 128));
            _textureAtlas.Add("D", Hx.CutTexture(_sheet, 128 * 2, 128 * 2, 128, 128));
            _textureAtlas.Add("L", Hx.CutTexture(_sheet, 128 * 3, 128 * 2, 128, 128));
            _textureAtlas.Add("R", Hx.CutTexture(_sheet, 128 * 4, 128 * 2, 128, 128));
            
            _textureAtlas.Add("LB", Hx.CutTexture(_sheet, 128 * 4, 128 * 0, 128, 128));
            _textureAtlas.Add("RB", Hx.CutTexture(_sheet, 128 * 5, 128 * 0, 128, 128));
            
        }

        protected override void Update(GameTime gameTime)
        {
            Hx.Update(gameTime);

            if (!IsActive)
            {
                return;
            }
            
            if (HxInput.IsGamePadConnected(PlayerIndex.One))
            {

                if (HxInput.CurrentGamepadStates[0].ThumbSticks.Right.Y >= 0.3f)
                {
                    _scale += 0.01f * _scale;
                }
                if (HxInput.CurrentGamepadStates[0].ThumbSticks.Right.Y <= -0.3f)
                {
                    _scale -= 0.01f * _scale;
                    if (_scale < 0.25f)
                    {
                        _scale = 0.25f;
                    }
                }
                
                if (HxInput.CurrentGamepadStates[0].ThumbSticks.Right.X >= 0.3f)
                {
                    _cameraPosition.X += HxInput.CurrentGamepadStates[0].ThumbSticks.Right.X;
                }
                
                if (HxInput.CurrentGamepadStates[0].ThumbSticks.Right.X <= -0.3f)
                {
                    _cameraPosition.X += HxInput.CurrentGamepadStates[0].ThumbSticks.Right.X;
                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.A))
                {
                    
                    //A pressed
                    _codelines[_currentLine] += ".A";
                    
                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.B))
                {
                    
                    //B pressed
                    _codelines[_currentLine] += ".B";
                    
                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.X))
                {
                    
                    //X pressed
                    _codelines[_currentLine] += ".X";
                    
                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.Y))
                {
                    
                    //Y pressed
                    _codelines[_currentLine] += ".Y";
                    
                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.DPadUp))
                {
                    
                    //Dup pressed
                    _codelines[_currentLine] += ".U";

                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.DPadDown))
                {
                    
                    //Ddown pressed
                    _codelines[_currentLine] += ".D";

                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.DPadLeft))
                {
                    
                    //Dleft pressed
                    _codelines[_currentLine] += ".L";

                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.DPadRight))
                {
                    
                    //Dright pressed
                    _codelines[_currentLine] += ".R";

                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.RightShoulder)) // New Line
                {
                    
                    //RShoulder pressed
                    //_codelines[_currentLine] += ".RB";
                    if (_codelines.Count - 1 <= _currentLine)
                    {
                        _currentLine += 1;
                        _codelines.Add("");
                    }
                    else
                    {
                        _currentLine += 1;
                    }
                    

                }
                
                if (HxInput.IsButtonPressed(PlayerIndex.One, Buttons.LeftShoulder)) // New Line
                {
                    
                    //RShoulder pressed
                    //_codelines[_currentLine] += ".RB";
                    if (_currentLine > 0)
                    {
                        _currentLine -= 1;
                    }

                }
                
            }

            if (_cameraPosition.X > 0)
            {
                _cameraPosition.X = 0;
            }
            
            string[] code = _codelines[_currentLine].Split(".");
            if ((code.Length * 128) * _scale > (GraphicsDevice.Viewport.Width / 2) - _cameraPosition.X)
            {
                _cameraPosition.X -= 128 * _scale;
            }
            else if ((code.Length * 128) * _scale <= (GraphicsDevice.Viewport.Width / 2))
            {
                Console.WriteLine((code.Length * 128) * _scale);
                Console.WriteLine((GraphicsDevice.Viewport.Width / 2) - _cameraPosition.X);
                Console.WriteLine();
                _cameraPosition.X = 0;
            }
            
            if ((_currentLine * 128) * _scale > (GraphicsDevice.Viewport.Height / 2) - _cameraPosition.Y)
            {
                _cameraPosition.Y -= 128 * _scale;
            }
            if ((_currentLine * 128) * _scale < 0 - _cameraPosition.Y)
            {
                _cameraPosition.Y += 128 * _scale;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin(transformMatrix: Matrix.CreateScale(_scale) * Matrix.CreateTranslation(_cameraPosition));

            for (int i = 0; i < _codelines.Count; i++)
            {

                Color color = Color.White * 0.5f;

                if (i == _currentLine)
                {
                    color = Color.White * 1f;
                }

                string[] code = _codelines[i].Split(".");
                int count = 0;
                foreach (string opp in code)
                {
                    if (_textureAtlas.ContainsKey(opp))
                    {
                        _spriteBatch.Draw(_textureAtlas[opp], new Vector2(count * 128, i * 128), color);
                    }
                    count++;
                }
                //_spriteBatch.DrawString(_defaultFont, (i + 1) + "  " + _codelines[i], Vector2.Zero + new Vector2(0, i * _defaultFont.LineSpacing), color);
            }
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
