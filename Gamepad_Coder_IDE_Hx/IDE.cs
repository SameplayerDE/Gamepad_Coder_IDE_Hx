﻿using System;
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

            _codelines[_currentLine] = "";
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
                    _currentLine += 1;
                    _codelines[_currentLine] = "";

                }
                
            }

            Window.Title = code;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            base.Draw(gameTime);
        }
    }
}
