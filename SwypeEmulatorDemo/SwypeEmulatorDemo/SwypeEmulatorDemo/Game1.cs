// ***
// *
// * Aurality Studios
// *
// * Swype Algorithm Demo
// *
// * Zackary Misso & Tyler Young
// *
// ***
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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            keyboard = new Keyboard();
            keyController = new KeyController();
            lineController = new LineController();
            algorithmer = new SwypeAlgorithm();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D line = Content.Load<Texture2D>("singlePix");
            Texture2D keyImg = Content.Load<Texture2D>("key");
            SpriteFont font = Content.Load<SpriteFont>("KeyFont");
            keyboard.setFont(font);
            keyboard.setTexture(keyImg);
            lineController.setTexture(line);
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
                if (lineController.addPoint(new Vector2(mouseState.X, mouseState.Y)))
                    keyController.addKey(keyboard.onClick(new Vector2(mouseState.X, mouseState.Y)));
            if (mouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
            {
                algorithmer.algorithm(keyController.getCurrent(),lineController.getPoints());
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
