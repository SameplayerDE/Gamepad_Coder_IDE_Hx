using System;
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            base.Draw(gameTime);
        }
    }
}
