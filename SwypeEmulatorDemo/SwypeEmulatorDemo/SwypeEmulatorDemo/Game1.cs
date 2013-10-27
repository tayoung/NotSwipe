using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SwypeEmulatorDemo
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Keyboard keyboard;
        private KeyController keyController;
        private LineController lineController;
        private SwypeAlgorithm algorithmer;
        private MouseState mouseState;
        private MouseState previousMouseState;
        private bool isClicking;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            keyboard = new Keyboard();
            keyController = new KeyController();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D tex;
            // TODO: use this.Content to load your game content here
            lineController = new LineController(tex);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (lineController.addPoint(new Vector2(mouseState.X, mouseState.Y)))
                    keyController.addKey(keyboard.onClick(new Vector2(mouseState.X, mouseState.Y)));
            }
            if (mouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
            {
                algorithmer.algorithm(keyController.getCurrent());
                lineController.clear();
                keyController.clear();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            keyboard.draw(spriteBatch);
            lineController.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
